using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Template;
using Moway.Controller;

namespace Moway.Server.Processes
{
    public partial class ProgramProcessForm : MowayForm
    {
        #region Attributes

        private string hexFile;
        private ProcessOp operation = ProcessOp.None;

        #endregion

        public ProgramProcessForm(string hexFile)
        {
            InitializeComponent();
            this.hexFile = hexFile;
        }

        #region Setup to disable the Close button of the form

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

        public new DialogResult ShowDialog()
        {
            this.opTimer.Enabled = true;
            this.operation = ProcessOp.Program;
            this.pbProgramMoway.Image = this.icons.Images[(int)ProcessState.Running];
            return base.ShowDialog();
        }

        private void OpTimer_Tick(object sender, EventArgs e)
        {
            switch (operation)
            {
                case ProcessOp.Program:
                    this.opTimer.Enabled = false;
                    Controller.Controller mController = Controller.Controller.GetController();
                    mController.ProgrammingProgress += new ProgressEventHandler(MController_ProgrammingProgress);
                    mController.ProgrammingCompleted += new EventHandler(MController_ProgrammingCompleted);
                    mController.ProgrammingCanceled += new EventHandler(MController_ProgrammingCanceled);
                   
                    try
                    {
                        if (mController.Firmware == "2.0.1")
                        {
                            this.bClose.Enabled = true;
                            this.pbProgramMoway.Image = this.icons.Images[(int)ProcessState.Error];
                            this.lProgramMoway.ForeColor = Color.FromArgb(208, 0, 0);
                            this.lProgramMoway.Text = Moway.Server.Processes.ProcessMessages.VERSION_ERROR;
                            return;
                        }
                        this.tProgramLimited.Enabled = true;
                        mController.ProgramMoway(this.hexFile);
                    }
                    catch (ControllerException ex)
                    {
                        this.bClose.Enabled = true;
                        this.pbProgramMoway.Image = this.icons.Images[(int)ProcessState.Error];
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
                case ProcessOp.Close:
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
            }
        }

       

        void MController_ProgrammingCanceled(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new EventHandler(this.MController_ProgrammingCanceled), new object[] { sender, e });
            else
            {
                this.bClose.Enabled = true;
                this.pbProgramMoway.Image = this.icons.Images[(int)ProcessState.Error];
                this.lProgramMoway.ForeColor = Color.FromArgb(208, 0, 0);
                this.lProgramMoway.Text = ProcessMessages.PROGRAMMOWAY_ERROR;
            }
        }

        void MController_ProgrammingCompleted(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new EventHandler(this.MController_ProgrammingCompleted), new object[] { sender, e });
            else
            {
                try
                {
                    this.pbProgramMoway.Image = this.icons.Images[(int)ProcessState.Finish];
                    this.lProgramMoway.Text = ProcessMessages.PROGRAMMOWAY_OK;
                    this.operation = ProcessOp.Close;
                    this.opTimer.Interval = 1000;
                    this.opTimer.Enabled = true;
                }
                catch { }
            }
        }

        void MController_ProgrammingProgress(object sender, ProgressEventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new ProgressEventHandler(this.MController_ProgrammingProgress), new object[] { sender, e });
            else
                this.lProgramMoway.Text = ProcessMessages.PROGRAMMING_MOWAY + ": " + e.Progress + "%";
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void TProgramLimited_Tick(object sender, EventArgs e)
        {
            this.tProgramLimited.Enabled = false;
            this.bClose.Enabled = true;
            this.pbProgramMoway.Image = this.icons.Images[(int)ProcessState.Error];
            this.lProgramMoway.ForeColor = Color.FromArgb(208, 0, 0);
            this.lProgramMoway.Text = ProcessMessages.PROGRAMMOWAY_ERROR;
        }
        
    }
}
