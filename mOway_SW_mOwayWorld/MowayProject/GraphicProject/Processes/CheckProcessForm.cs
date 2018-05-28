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
    /// Window to the verification process of the diagrams of a project
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    internal partial class CheckProcessForm : MowayForm
    {
        #region Attributes

        /// <summary>
        /// Project to generate and program in the MOway
        /// </summary>
        private GraphProject project;
        /// <summary>
        /// Current operation of the process/// </summary>
        private ProcessOperation operation = ProcessOperation.None;

        #endregion

        #region Events

        /// <summary>
        /// Occurs when errors are detected in the Diagrams
        /// </summary>
        public event ProcessEventHandler DiagramErrors;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="project">Project to generate and program in the MOway</param>
        public CheckProcessForm(GraphProject project)
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
            //Timer of launching operations
            switch (operation)
            {
                case ProcessOperation.Check:
                    //Checked the errors for all the Diagrams
                    List<DiagramError> errors = new List<DiagramError>();
                    foreach (Diagram diagram in this.project.Functions)
                        Generator.CheckDiagram(diagram, errors);
                    //If there are errors or warnings, it is reported
                    if (errors.Count != 0)
                    {
                        bool onlyWarnings = false;
                        //The errors are checked
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
                            this.opTimer.Interval = 1000;
                            //it passes to the following operation
                            this.operation = ProcessOperation.Close;
                        }
                        //The error event is launched
                        if (this.DiagramErrors != null)
                            this.DiagramErrors(this, new ProcessEventArgs(errors));
                    }
                    else
                    {
                        this.pbCheckDiagram.Image = this.icons.Images[(int)OperationState.Finish];
                        this.lCheckDiagram.Text = ProcessMessages.CHECKDIAGRAM_OK;
                        this.opTimer.Interval = 1000;
                        //it passes to the following operation
                        this.operation = ProcessOperation.Close;
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

        #endregion
    }
}
