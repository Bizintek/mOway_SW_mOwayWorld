using System;
using System.Drawing;
using System.Windows.Forms;

using Moway.Template;
using Moway.Controller;
using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.CodeGenerator;

namespace Moway.Processes
{
    /// <summary>
    /// Recording window of a .hex file 
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class ProgramProcessForm : MowayForm
    {
        #region Attributes

        /// <summary>
        /// Path of the file to be programmedr
        /// </summary>
        private string hexFile;
        /// <summary>
        /// Current operation of the process
        /// </summary>
        private ProcessOperation operation = ProcessOperation.None;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="hexFile"></param>
        public ProgramProcessForm(string hexFile)
        {
            InitializeComponent();
            this.hexFile = hexFile;
        }

        #region Definition to disable the close form button

        private const int CP_NOCLOSE_BUTTON = 0x200;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ClassStyle = createParams.ClassStyle | CP_NOCLOSE_BUTTON;
                return createParams;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Displays the form, releasing the recording process
        /// </summary>
        /// <returns></returns>
        public new DialogResult ShowDialog()
        {
            this.opTimer.Enabled = true;
            this.operation = ProcessOperation.Program;
            this.pbProgramMoway.Image = this.icons.Images[(int)OperationState.Running];
            return base.ShowDialog();
        }

        #endregion

        #region Form Events

        /// <summary>
        /// Timer of launching operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpTimer_Tick(object sender, EventArgs e)
        {
            //According to the operation to run
            switch (operation)
            {
                case ProcessOperation.Program:
                    //launches the process of recording
                    this.opTimer.Enabled = false;
                    //the driver of the mOway events are logged
                    Controller.Controller mController = Controller.Controller.GetController();
                    mController.ProgrammingProgress += new ProgressEventHandler(MController_ProgrammingProgress);
                    mController.ProgrammingCompleted += new EventHandler(MController_ProgrammingCompleted);
                    mController.ProgrammingCanceled += new EventHandler(MController_ProgrammingCanceled);
                    try
                    {
                        //checks the memory of the micro...
                        int response = mController.CheckPicMemory(this.hexFile);
                        if (response == 1)
                        {
                            //A confirmation is requested
                            if (DialogResult.No == MowayMessageBox.Show(ProcessMessages.HEX_TOO_LARGE_201 + "\r\n" + ProcessMessages.CONTINUE, ProcessMessages.PROGRAM, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                            {
                                //The Close button is enabled
                                this.bClose.Enabled = true;
                                //The error is displayed
                                this.pbProgramMoway.Image = this.icons.Images[(int)OperationState.Error];
                                this.lProgramMoway.ForeColor = Color.FromArgb(208, 0, 0);
                                this.lProgramMoway.Text = ProcessMessages.MEMORY_ERROR;
                                return;
                            }
                        }
                        else if (response == 2)
                        {
                            //A confirmation is requested
                            if (DialogResult.No == MowayMessageBox.Show(ProcessMessages.HEX_TOO_LARGE_202 + "\r\n" + ProcessMessages.CONTINUE, ProcessMessages.PROGRAM, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                            {
                                //The Close button is enabled
                                this.bClose.Enabled = true;
                                //The error is displayed
                                this.pbProgramMoway.Image = this.icons.Images[(int)OperationState.Error];
                                this.lProgramMoway.ForeColor = Color.FromArgb(208, 0, 0);
                                this.lProgramMoway.Text = ProcessMessages.MEMORY_ERROR;
                                return;
                            }
                        }
                        //It enables the timer which is limited to 15 seconds the recording process
                        this.tProgramLimited.Enabled = true;
                        //the mOway recording is released
                        mController.ProgramMoway(this.hexFile);
                    }
                    //error in the launch of the recording process
                    catch (ControllerException ex)
                    {
                        //The Close button is enabled
                        this.bClose.Enabled = true;
                        //The error is displayed
                        this.bClose.Enabled = true;
                        this.pbProgramMoway.Image = this.icons.Images[(int)OperationState.Error];
                        this.lProgramMoway.ForeColor = Color.FromArgb(208, 0, 0);
                        switch (ex.Message)
                        {
                            case "File not found":
                                this.lProgramMoway.Text = ProcessMessages.FILE_NOT_FOUND;
                                break;
                            case "Moway disconnected":
                                this.lProgramMoway.Text = ProcessMessages.MOWAY_DISCONNECTED;
                                break;
                            case "Moway busy":
                                this.lProgramMoway.Text = ProcessMessages.MOWAY_BUSY;
                                break;
                            default:
                                this.lProgramMoway.Text = ProcessMessages.PROGRAMMOWAY_ERROR;
                                break;
                        }
                    }
                    break;
                case ProcessOperation.Close:
                    //close the form
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// Pressing the button close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        /// <summary>
        /// Limitation of recording timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TProgramLimited_Tick(object sender, EventArgs e)
        {
            this.tProgramLimited.Enabled = false;
            //The Close button is enabled
            this.bClose.Enabled = true;
            //The error is displayed
            this.pbProgramMoway.Image = this.icons.Images[(int)OperationState.Error];
            this.lProgramMoway.ForeColor = Color.FromArgb(208, 0, 0);
            this.lProgramMoway.Text = ProcessMessages.PROGRAMMOWAY_ERROR;
        }

        #endregion

        #region The driver of the mOway events

        /// <summary>
        /// Cancellation of programming
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MController_ProgrammingCanceled(object sender, EventArgs e)
        {
            //an invocation is done to prevent problems between threads
            if (this.InvokeRequired)
                this.Invoke(new EventHandler(this.MController_ProgrammingCanceled), new object[] { sender, e });
            else
            {
                //The Close button is enabled
                this.bClose.Enabled = true;
                //The error is displayed
                this.pbProgramMoway.Image = this.icons.Images[(int)OperationState.Error];
                this.lProgramMoway.ForeColor = Color.FromArgb(208, 0, 0);
                this.lProgramMoway.Text = ProcessMessages.PROGRAMMOWAY_ERROR;
            }
        }

        /// <summary>
        /// Completion of recording
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MController_ProgrammingCompleted(object sender, EventArgs e)
        {
            //an invocation is done to prevent problems between threads
            if (this.InvokeRequired)
                this.Invoke(new EventHandler(this.MController_ProgrammingCompleted), new object[] { sender, e });
            else
            {
                try
                {
                    //the message is displayed
                    this.pbProgramMoway.Image = this.icons.Images[(int)OperationState.Finish];
                    this.lProgramMoway.Text = ProcessMessages.PROGRAMMOWAY_OK;
                    this.operation = ProcessOperation.Close;
                    //the timer is enabled so that the window closes automatically
                    this.opTimer.Interval = 1000;
                    this.opTimer.Enabled = true;
                }
                catch { }
            }
        }

        /// <summary>
        /// Progress of the recording process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MController_ProgrammingProgress(object sender, ProgressEventArgs e)
        {
            //an invocation is done to prevent problems between threads
            if (this.InvokeRequired)
                this.Invoke(new ProgressEventHandler(this.MController_ProgrammingProgress), new object[] { sender, e });
            else
                //updated the percentage of recording
                this.lProgramMoway.Text = ProcessMessages.PROGRAMMING_MOWAY + ": " + e.Progress + "%";
        }

        #endregion
    }
}
