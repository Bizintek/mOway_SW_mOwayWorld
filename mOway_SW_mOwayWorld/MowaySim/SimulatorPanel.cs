using System;
using System.Drawing;
using System.Windows.Forms;

using Moway.Simulator.Outputs;
using Moway.Simulator.Sensors;
using Moway.Simulator.Registers;
using Moway.Simulator.Communications;
using Moway.Simulator.Expansion;

namespace Moway.Simulator
{
    /// <summary>
    /// Simulator Panel
    /// </summary>
    /// <LastRevision>10.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class SimulatorPanel : Moway.Template.Controls.SharePanel
    {
        #region Attributes

        /// <summary>
        /// Simulator
        /// </summary>
        private ISimulator simulator;
        /// <summary>
        /// Outputs Panel
        /// </summary>
        private OutputsPanel outputPanel;
        /// <summary>
        /// Line Sensor and obstacle Panel
        /// </summary>
        private SensorsPanel sensorsPanel;
        /// <summary>
        /// Environment Sensor Panel
        /// </summary>
        private EnviromentPanel enviromentPanel;
        /// <summary>
        /// Accelerometer Panel
        /// </summary>
        private AccelerometerPanel accelerometerPanel;
        /// <summary>
        /// Communication Panel
        /// </summary>
        private CommunicationPanel communicationPanel;
        /// <summary>
        /// Resgisters Panel
        /// </summary>
        private RegistersPanel registersPanel;

        #endregion

        #region Properties

        /// <summary>
        /// Title of the panel
        /// </summary>
        public override string Tittle { get { return SimulatorMessages.SIMULATION; } }
        /// <summary>
        /// Short title of the panel
        /// </summary>
        public override string ShortTittle { get { return SimulatorMessages.SIMULATION; } }

        #endregion

        #region Events

        /// <summary>
        /// Activation of the option to start simulation
        /// </summary>
        public event EventHandler Run_Click;
        /// <summary>
        /// Activation of the option to start animation
        /// </summary>
        public event EventHandler Animate_Click;
        /// <summary>
        /// Activation of the option of pause
        /// </summary>
        public event EventHandler Pause_Click;
        /// <summary>
        /// Activation of the option of reset
        /// </summary>
        public event EventHandler Reset_Click;
        /// <summary>
        /// Activation of the option of step by step with entry into subroutines
        /// </summary>
        public event EventHandler StepIn_Click;
        /// <summary>
        /// Activation of the option of step by step without entry into subroutines
        /// </summary>
        public event EventHandler StepOver_Click;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="simulator"></param>
        public SimulatorPanel(ISimulator simulator)
        {
            InitializeComponent();
            //The simulator is saved
            this.simulator = simulator;
            //A Simulator status Change event is logged
            this.simulator.StateChanged += new EventHandler(Simulator_StateChanged);
            //MOway module panels are added
            this.outputPanel = new OutputsPanel(this.simulator.MowayModel);
            this.LoadSubPanel(this.outputPanel);
            this.sensorsPanel = new SensorsPanel(this.simulator.MowayModel);
            this.LoadSubPanel(this.sensorsPanel);
            this.enviromentPanel = new EnviromentPanel(this.simulator.MowayModel);
            this.LoadSubPanel(this.enviromentPanel);
            this.accelerometerPanel = new AccelerometerPanel(this.simulator.MowayModel);
            this.LoadSubPanel(this.accelerometerPanel);
            this.communicationPanel = new CommunicationPanel(this.simulator.MowayModel);
            this.LoadSubPanel(this.communicationPanel);
            this.registersPanel = new RegistersPanel(this.simulator.MowayModel);
            this.LoadSubPanel(this.registersPanel);
            this.cbMowayModule.SelectedIndex = 0;
        }

        #region Form Events

        /// <summary>
        /// Selection Change the module of the mOway
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbMowayModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((ModulePanel)this.cbMowayModule.SelectedItem).BringToFront();
        }

        #endregion

        #region Events of the panel buttons

        /// <summary>
        /// Click on the Start button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BRun_Click(object sender, EventArgs e)
        {
            if (this.Run_Click != null)
                this.Run_Click(this, new EventArgs());
        }

        /// <summary>
        /// Click on the animation button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BAnimate_Click(object sender, EventArgs e)
        {
            if (this.Animate_Click != null)
                this.Animate_Click(this, new EventArgs());
        }

        /// <summary>
        /// Click on the pause button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPause_Click(object sender, EventArgs e)
        {
            if (this.Pause_Click != null)
                this.Pause_Click(this, new EventArgs());
        }

        /// <summary>
        /// Click on the reset button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BReset_Click(object sender, EventArgs e)
        {
            if (this.Reset_Click != null)
                this.Reset_Click(this, new EventArgs());
        }

        /// <summary>
        /// Click on the step-by-step button with entry in subroutines
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BStepIn_Click(object sender, EventArgs e)
        {
            if (this.StepIn_Click != null)
                this.StepIn_Click(this, new EventArgs());
        }

        /// <summary>
        /// Click on the step-by-step button without entry in subroutines
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BStepOver_Click(object sender, EventArgs e)
        {
            if (this.StepOver_Click != null)
                this.StepOver_Click(this, new EventArgs());
        }

        #endregion

        #region Simulator events

        void Simulator_StateChanged(object sender, EventArgs e)
        {
            if (this.bRun.InvokeRequired)
                this.Invoke(new EventHandler(this.Simulator_StateChanged), new object[] { sender, e });
            else
                switch (this.simulator.State)
                {
                    case SimState.Running:
                        this.bRun.Enabled = false;
                        this.bAnimate.Enabled = false;
                        this.bPause.Enabled = true;
                        this.bReset.Enabled = false;
                        this.bStepIn.Enabled = false;
                        this.bStepOver.Enabled = false;
                        break;
                    case SimState.Pause:
                        this.bRun.Enabled = true;
                        this.bAnimate.Enabled = true;
                        this.bPause.Enabled = false;
                        this.bReset.Enabled = true;
                        this.bStepIn.Enabled = true;
                        this.bStepOver.Enabled = true;
                        break;
                    case SimState.Stop:
                        this.bRun.Enabled = false;
                        this.bAnimate.Enabled = false;
                        this.bPause.Enabled = false;
                        this.bReset.Enabled = true;
                        this.bStepIn.Enabled = false;
                        this.bStepOver.Enabled = false;
                        break;
                }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Loading a MOway module panel
        /// </summary>
        /// <param name="subpanel"></param>
        private void LoadSubPanel(ModulePanel subpanel)
        {
            subpanel.Location = new Point(4, 75);
            this.cbMowayModule.Items.Add(subpanel);
            this.Controls.Add(subpanel);
        }

        #endregion
    }
}
