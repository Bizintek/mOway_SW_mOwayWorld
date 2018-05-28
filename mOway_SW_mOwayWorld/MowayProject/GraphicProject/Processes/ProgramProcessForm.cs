using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Template;
using Moway.Controller;
using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.CodeGenerator;
using Moway.Compiler;

namespace Moway.Project.GraphicProject.Processes
{
    /// <summary>
    /// Window to the process of recording a project
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    internal partial class ProgramProcessForm : MowayForm
    {
        #region Attributes

        /// <summary>
        /// Project to generate and program in the MOway
        /// </summary>
        private GraphProject project;
        /// <summary>
        /// Current operation of the process
        /// </summary>
        private ProcessOperation operation = ProcessOperation.None;

        #endregion

        #region Events

        /// <summary>
        /// Occurs when errors are detected in the diagrams
        /// </summary>
        public event ProcessEventHandler DiagramErrors;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="project">Project to generate and program in the MOway</param>
        public ProgramProcessForm(GraphProject project)
        {
            InitializeComponent();
            this.project = project;
        }

        #region Redefinition to disable the Close button of the form

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
        /// Displays the form, launching the recording process
        /// </summary>
        /// <returns></returns>
        public new DialogResult ShowDialog()
        {
            this.opTimer.Enabled = true;
            this.operation = ProcessOperation.Check;
            this.pbCheckDiagram.Image = this.icons.Images[(int)OperationState.Running];
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
            //according to the operation to be executed
            switch (operation)
            {
                case ProcessOperation.Check:
                    //The errors of all the diagrams are checked
                    List<DiagramError> errors = new List<DiagramError>();
                    foreach (Diagram diagram in this.project.Functions)
                        Generator.CheckDiagram(diagram, errors);
                    //If there are errors, it is reported
                    if (errors.Count != 0)
                    {
                        bool onlyWarnings = false;
                        //the errors are checked
                        foreach (DiagramError error in errors)
                            //If any of the errors is not a warning
                            if (error.Type == ErrorType.Error)
                            {
                                onlyWarnings = true;
                                this.opTimer.Enabled = false;
                                //The Close button is enabled
                                this.bClose.Enabled = true;
                                //The error is displayed
                                this.pbCheckDiagram.Image = this.icons.Images[(int)OperationState.Error];
                                this.lCheckDiagram.Text = ProcessMessages.CHECKDIAGRAM_ERROR;
                                this.lCheckDiagram.ForeColor = Color.FromArgb(208, 0, 0);
                                break;
                            }
                        //If they are only warnings
                        if (!onlyWarnings)
                        {
                            //The warning message is displayed
                            this.pbCheckDiagram.Image = this.icons.Images[(int)OperationState.Warning];
                            this.lCheckDiagram.Text = ProcessMessages.CHECKDIAGRAM_WARNING;
                            this.lCheckDiagram.ForeColor = Color.FromArgb(200, 140, 0);
                            //it passes to the following operation
                            this.operation = ProcessOperation.Generate;
                            this.pbGenerateCode.Image = this.icons.Images[(int)OperationState.Running];
                        }
                        //The error event is launched
                        if (this.DiagramErrors != null)
                            this.DiagramErrors(this, new ProcessEventArgs(errors));
                    }
                    else
                    {
                        this.pbCheckDiagram.Image = this.icons.Images[(int)OperationState.Finish];
                        this.lCheckDiagram.Text = ProcessMessages.CHECKDIAGRAM_OK;
                        //it passes to the following operation
                        this.operation = ProcessOperation.Generate;
                        this.pbGenerateCode.Image = this.icons.Images[(int)OperationState.Running];
                    }
                    break;
                case ProcessOperation.Generate:
                    //Generates the source code for the diagrams
                    try
                    {
                        // The code is generated
                        AsmGenerator.GenerateCode(this.project.MainFunction, this.project.Subfunctions, this.project.Variables, this.project.AsmFile);
                        this.lGenerateCode.Text = ProcessMessages.GENERATECODE_OK;
                        this.pbGenerateCode.Image = this.icons.Images[(int)OperationState.Finish];
                        //it passes to the following operation
                        this.operation = ProcessOperation.Compile;
                        this.pbCompileCode.Image = this.icons.Images[(int)OperationState.Running];
                    }
                    catch { }
                    break;
                case ProcessOperation.Compile:
                    //The generated source code is compiled
                    try
                    {
                        //The project is compiled
                        if (AsmCompiler.Compile(this.project.AsmFile))
                        {
                            this.lCompileCode.Text = ProcessMessages.COMPILECODE_OK;
                            this.pbCompileCode.Image = this.icons.Images[(int)OperationState.Finish];
                            //it passes to the following operation
                            this.operation = ProcessOperation.Program;
                            this.opTimer.Interval = 50;
                            this.pbProgramMoway.Image = this.icons.Images[(int)OperationState.Running];
                        }
                        else
                        {
                            this.opTimer.Enabled = false;
                            //The Close button is enabled
                            this.bClose.Enabled = true;
                            //The error is displayed
                            this.pbCompileCode.Image = this.icons.Images[(int)OperationState.Error];
                            this.lCompileCode.ForeColor = Color.FromArgb(208, 0, 0);
                            this.lCompileCode.Text = ProcessMessages.COMPILECODE_ERROR;
                        }
                    }
                    //Code compilation failed
                    catch (CompilerException ex)
                    {
                        this.opTimer.Enabled = false;
                        //The Close button is enabled
                        this.bClose.Enabled = true;
                        //The error is displayed
                        this.pbCompileCode.Image = this.icons.Images[(int)OperationState.Error];
                        this.lCompileCode.ForeColor = Color.FromArgb(208, 0, 0);
                        switch (ex.Message)
                        {
                            case "File not found":
                                this.lCompileCode.Text = ProcessMessages.FILE_NOT_FOUND;
                                break;
                            case "Access denied":
                                this.lCompileCode.Text = ProcessMessages.ACCES_DENIED;
                                break;
                            default:
                                this.lCompileCode.Text = ProcessMessages.COMPILECODE_ERROR;
                                break;
                        }
                    }
                    break;
                case ProcessOperation.Program:
                    //Launches the recording process
                    this.opTimer.Enabled = false;
                    //MOway Driver events are logged
                    Controller.Controller mController = Controller.Controller.GetController();
                    mController.ProgrammingProgress += new ProgressEventHandler(MController_ProgrammingProgress);
                    mController.ProgrammingCompleted += new EventHandler(MController_ProgrammingCompleted);
                    mController.ProgrammingCanceled += new EventHandler(MController_ProgrammingCanceled);
                    try
                    {
                        //It checks the memory of the micro...
                        int response = mController.CheckPicMemory(this.project.HexFile);
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
                        //Timer is enabled to limit the recording process to 15 seconds
                        this.tProgramLimited.Enabled = true;
                        //It launches the recording of the mOway
                        mController.ProgramMoway(this.project.HexFile);
                    }
                    //Timer is enabled to limit the recording process to 15 seconds
                    catch (ControllerException ex)
                    {
                        //The Close button is enabled
                        this.bClose.Enabled = true;
                        //The error is displayed
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
                    //Close the form
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// Press Close button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        /// <summary>
        /// Recording limiting timer
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

        #region Events del controlador de mOway

        /// <summary>
        /// Cancellation of the programming
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MController_ProgrammingCanceled(object sender, EventArgs e)
        {
            //An invocation is made to avoid problems between threads
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
        /// End of recording
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MController_ProgrammingCompleted(object sender, EventArgs e)
        {
            //An invocation is made to avoid problems between threads
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(this.MController_ProgrammingCompleted), new object[] { sender, e });          
            }
            else
            {
                try
                {
                    //The message is displayed
                    this.pbProgramMoway.Image = this.icons.Images[(int)OperationState.Finish];
                    this.lProgramMoway.Text = ProcessMessages.PROGRAMMOWAY_OK;
                    this.operation = ProcessOperation.Close;
                    //Timer is enabled to automatically close the window
                    this.opTimer.Interval = 1000;
                    this.opTimer.Enabled = true;
                }
                catch { }
            }
        }

        /// <summary>
        /// Progress in the process of recording
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MController_ProgrammingProgress(object sender, ProgressEventArgs e)
        {
            //An invocation is made to avoid problems between threads
            if (this.InvokeRequired)
                this.Invoke(new ProgressEventHandler(this.MController_ProgrammingProgress), new object[] { sender, e });
            else
                //Updates the percentage of recording
                this.lProgramMoway.Text = ProcessMessages.PROGRAMMING_MOWAY + ": " + e.Progress + "%";
        }

        #endregion
    }
}
