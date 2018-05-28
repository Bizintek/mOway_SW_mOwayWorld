using System;
using System.IO;
using System.Xml;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Windows.Forms;

using Moway.Template;
using Moway.Template.Controls;
using Moway.Compiler;
using Moway.Project.GraphicProject.Processes;
using Moway.Project.GraphicProject.Controls;
using Moway.Project.GraphicProject.Boxes;
using Moway.Project.GraphicProject.Forms;
using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Operations;
using Moway.Project.GraphicProject.CodeGenerator;
using Moway.Project.GraphicProject.Simulator;
using Moway.Controller;
using Moway.Simulator;

using Moway.Project.GraphicProject.GraphLayout.Elements;
using Moway.Project.GraphicProject.Actions;
using Moway.Project.GraphicProject.Actions.Call;

namespace Moway.Project.GraphicProject
{
    internal class GraphManager : ProjectManager
    {
        #region Constants

        private const int TOOLBOX_WIDTH = 205;

        #endregion

        #region Attributes

        /// <summary>
        /// Logical Level Project
        /// </summary>
        private GraphProject project;
        private GraphDiagram mainFunction;
        /// <summary>
        /// Graphic functions of the project
        /// </summary>
        private SortedList<string, GraphDiagram> graphFunctions = new SortedList<string, GraphDiagram>();
        /// <summary>
        /// Selected function
        /// </summary>
        private GraphDiagram graphFunctionSelected = null;
        //Boxes for this type of project
        private ToolBox toolBox = new ToolBox();
        private WorkBox workBox = new WorkBox();
        private ResultsBox resultsBox = new ResultsBox();
        //Vertical panels for this type of project
        private PropertiesPanel propertiesPanel = new PropertiesPanel();
        private SimulatorPanel simulationPanel = null;
        //MenuItems for the MOwayWorld menu
        private ToolStripMenuItem miExport = new ToolStripMenuItem(GraphMessages.EXPORT);
        private ToolStripMenuItem miExportPng = new ToolStripMenuItem(GraphMessages.EXPORT_PNG);
        private ToolStripMenuItem miExportJpg = new ToolStripMenuItem(GraphMessages.EXPORT_JPG);
        private ToolStripMenuItem miExportPdf = new ToolStripMenuItem(GraphMessages.EXPORT_PDF);
        //MenuItems from the View menu
        private ToolStripMenuItem miViewProperties = new ToolStripMenuItem(GraphMessages.VIEW_PROPERTIES);
        private ToolStripMenuItem miViewResults = new ToolStripMenuItem(GraphMessages.VIEW_RESULTS);
        //MenuItems The Project menu
        private ToolStripMenuItem miProject = new ToolStripMenuItem(GraphMessages.PROJECT);
        private ToolStripMenuItem miCheckDiagram = new ToolStripMenuItem(GraphMessages.CHECK_DIAGRAMS);
        private ToolStripMenuItem miCompile = new ToolStripMenuItem(GraphMessages.COMPILE_MOWAY);
        private ToolStripMenuItem miProgram = new ToolStripMenuItem(GraphMessages.PROGRAM_MOWAY);
        private ToolStripMenuItem miViewCode = new ToolStripMenuItem(GraphMessages.VIEW_CODE);
        private ToolStripMenuItem miProperties = new ToolStripMenuItem(GraphMessages.PROPERTIES);
        //MenúItems of the Functions menu
        private ToolStripMenuItem miFunctions = new ToolStripMenuItem(GraphMessages.FUNCTIONS);
        private ToolStripMenuItem miNewFunction = new ToolStripMenuItem(GraphMessages.NEW_FUNCTION);
        private ToolStripMenuItem miImportFunction = new ToolStripMenuItem(GraphMessages.IMPORT_FUNCTION);
        private ToolStripMenuItem miEditFunction = new ToolStripMenuItem(GraphMessages.EDIT_FUNCTION);
        private ToolStripMenuItem miFunctionSize = new ToolStripMenuItem(GraphMessages.CHANGE_AREA_SIZE);
        private ToolStripMenuItem miDeleteFunction = new ToolStripMenuItem(GraphMessages.DELETE_FUNCTION);
        //MenuItems of the Variables menu
        private ToolStripMenuItem miVariables = new ToolStripMenuItem(GraphMessages.VARIABLES);
        private ToolStripMenuItem miNewVariable = new ToolStripMenuItem(GraphMessages.NEW_VARIABLE);
        private ToolStripMenuItem miShowVariables = new ToolStripMenuItem(GraphMessages.VARIABLES);
        //MenuItems of the Simulation menu
        private ToolStripMenuItem miSimulation = new ToolStripMenuItem(GraphMessages.SIMULATION);
        private ToolStripMenuItem miActivate = new ToolStripMenuItem(GraphMessages.ACTIVATE);
        private ToolStripMenuItem miDesactivate = new ToolStripMenuItem(GraphMessages.DESACTIVATE);
        private ToolStripMenuItem miRun = new ToolStripMenuItem(GraphMessages.RUN);
        private ToolStripMenuItem miAnimate = new ToolStripMenuItem(GraphMessages.ANIMATE);
        private ToolStripMenuItem miPause = new ToolStripMenuItem(GraphMessages.PAUSE);
        private ToolStripMenuItem miReset = new ToolStripMenuItem(GraphMessages.RESET);
        private ToolStripMenuItem miStepIn = new ToolStripMenuItem(GraphMessages.STEP_IN);
        private ToolStripMenuItem miStepOver = new ToolStripMenuItem(GraphMessages.STEP_OVER);
        //Toolbar buttons
        private Moway.Template.Controls.ToolBarButtonSelector tbbSelect;
        private Moway.Template.Controls.ToolBarButtonSelector tbbConnect;
        private Moway.Template.Controls.ToolBarButton tbbNote;
        private Moway.Template.Controls.ToolBarButton tbbCheckDiagrams;
        private Moway.Template.Controls.ToolBarButton tbbProgramMoway;
        /// <summary>
        /// <summary>
        /// Clipboard for copy and paste operations
        /// </summary>
        private GraphClipboard clipboard = new GraphClipboard();
        /// <summary>
        /// Graphic Moway Simulator
        /// </summary>
        private GraphSimulator simulator = GraphSimulator.GetSimulator();
        /// <summary>
        /// Dialogs to open and save projects/files
        /// </summary>
        private OpenFileDialog importDiagramDialog = new OpenFileDialog();
        private SaveFileDialog exportPngDialog = new SaveFileDialog();
        private SaveFileDialog exportJpgDialog = new SaveFileDialog();
        private SaveFileDialog exportPdfDialog = new SaveFileDialog();

        #endregion

        #region Properties

        /// <summary>
        /// Project Name
        /// </summary>
        public override string ProjectName { get { return this.project.Name; } }
        /// <summary>
        /// Return the list of boxes of this type of project
        /// </summary>
        public override List<MowayBox> Boxes
        {
            get
            {
                List<MowayBox> boxes = new List<MowayBox>();
                boxes.Add(this.toolBox);
                boxes.Add(this.workBox);
                if (this.resultsBox.Visible)
                    boxes.Add(this.resultsBox);
                return boxes;
            }
        }
        /// <summary>
        /// Returns the list of vertical panels
        /// </summary>
        public override List<SharePanel> Panels
        {
            get
            {
                List<SharePanel> panels = new List<SharePanel>();
                if (this.propertiesPanel.Visible)
                    panels.Add(this.propertiesPanel);
                if (this.simulationPanel != null)
                    panels.Add(this.simulationPanel);
                return panels;
            }
        }
        /// <summary>
        /// Project path
        /// </summary>
        public override string ProjectPath { get { return this.project.ProjectPath + this.project.Name + ".mwp"; } }
        /// <summary>
        /// Status of possible operations on open function
        /// </summary>
        public override bool UndoEnabled { get { return this.graphFunctionSelected.OperationState[Operation.Undo]; } }
        public override bool RedoEnabled { get { return this.graphFunctionSelected.OperationState[Operation.Redo]; } }
        public override bool CopyEnabled { get { return this.graphFunctionSelected.OperationState[Operation.Copy]; } }
        public override bool CutEnabled { get { return this.graphFunctionSelected.OperationState[Operation.Cut]; } }
        public override bool PasteEnabled { get { return !this.clipboard.IsEmpty; } }
        public override bool RemoveEnabled { get { return this.graphFunctionSelected.OperationState[Operation.Delete]; } }
        /// <summary>
        /// Logical Project
        /// </summary>
        public static GraphProject Project { get { return graphManager.project; } }
        /// <summary>
        /// Clipboard for copy/paste operations
        /// </summary>
        public static GraphClipboard Clipboard { get { return graphManager.clipboard; } }
        
        #endregion



        private GraphManager()
        {
            this.LoadToolBarButtons();
            this.LoadMenuItems();

            this.toolBox.InitInsert += new ToolEventHandler(ToolBox_InitInsert);
            this.toolBox.DoInsert += new PointEventHandler(ToolBox_DoInsert);
            this.toolBox.CancelInsert += new EventHandler(ToolBox_CancelInsert);

            this.workBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.workBox.TabPageSelected += new GraphTabButtonEventHandler(WorkBox_TabPageSelected);
            this.workBox.CreateTabPage += new EventHandler(WorkBox_CreateTabPage);
            this.workBox.RemoveTabPage += new GraphTabButtonEventHandler(WorkBox_RemoveTabPage);
            this.workBox.RenameTabPage += new GraphTabButtonEventHandler(WorkBox_ChangeTabPageName);
            this.workBox.ScrollValuesChanged += new EventHandler(WorkBox_ScrollValuesChanged);
            this.workBox.WorkAreaMouseEnter += new EventHandler(WorkBox_WorkAreaMouseEnter);
            this.workBox.WorkAreaMouseLeave += new EventHandler(WorkBox_WorkAreaMouseLeave);
            this.workBox.WorkAreaMouseMove += new MouseEventHandler(WorkBox_WorkAreaMouseMove);
            this.workBox.WorkAreaMouseDown += new MouseEventHandler(WorkBox_WorkAreaMouseDown);
            this.workBox.WorkAreaMouseUp += new MouseEventHandler(WorkBox_WorkAreaMouseUp);
            this.workBox.WorkAreaDoubleClick += new MouseEventHandler(WorkBox_WorkAreaDoubleClick);

            this.resultsBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.resultsBox.Visible = false;
            this.resultsBox.BoxClosed += new EventHandler(ResultsBox_BoxClosed);

            this.propertiesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;

            this.clipboard.ClipboardChanged += new EventHandler(Clipboard_ClipboardChanged);

            this.simulator.StateChanged += new EventHandler(Simulator_StateChanged);
            this.simulator.SimulationFinished += new EventHandler(Simulator_SimulationFinished);

            //ImportDiagramDialog initialization
            this.importDiagramDialog.Filter = GraphMessages.IMPORT_FILTER;
            this.importDiagramDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\mOproj";
            //Initializing file Export dialogs
            this.exportPngDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.exportPngDialog.Filter = GraphMessages.EXPORT_PNG_FILTER;
            this.exportJpgDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.exportJpgDialog.Filter = GraphMessages.EXPORT_JPG_FILTER;
            this.exportPdfDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.exportPdfDialog.Filter = GraphMessages.EXPORT_PDF_FILTER;
        }

        #region Implementation for the Singleton pattern

        private static GraphManager graphManager = null;

        public static GraphManager GetManager()
        {
            if (graphManager == null)
                graphManager = new GraphManager();
            return graphManager;
        }

        #endregion

        #region Private initialization methods

        private void LoadMenuItems()
        {
            this.miExportPng.Click += new EventHandler(MiExportPng_Click);
            this.miExportJpg.Click += new EventHandler(MiExportJpg_Click);
            this.miExportPdf.Click += new EventHandler(MiExportPdf_Click);
            this.miExport.DropDownItems.AddRange(new ToolStripItem[] { this.miExportPng, this.miExportJpg, this.miExportPdf });
            this.mowayMenuItems.Add(this.miExport);

            this.miViewProperties.Checked = true;
            this.miViewProperties.Click += new EventHandler(MiViewProperties_Click);
            this.miViewResults.Click += new EventHandler(MiViewResults_Click);
            this.viewMenuItems.AddRange(new ToolStripItem[] { this.miViewProperties, new ToolStripSeparator(), this.miViewResults });

            this.miCheckDiagram.Click += new EventHandler(MiCheckDiagram_Click);
            this.miCheckDiagram.ShortcutKeys = Keys.F7;
            this.miCompile.Click += new EventHandler(MiCompile_Click);
            this.miCompile.ShortcutKeys = Keys.F8;
            this.miProgram.Click += new EventHandler(MiProgram_Click);
            this.miProgram.ShortcutKeys = Keys.F9;
            this.miViewCode.Click += new EventHandler(MiViewCode_Click);
            this.miProperties.Click += new EventHandler(MiProperties_Click);
            this.miProject.DropDownItems.AddRange(new ToolStripItem[] { this.miCheckDiagram, this.miCompile, this.miProgram, new ToolStripSeparator(), this.miViewCode, new ToolStripSeparator(), this.miProperties });
            this.menuItems.Add(this.miProject);

            this.miNewFunction.Click += new EventHandler(MiNewFunction_Click);
            this.miImportFunction.Click += new EventHandler(MiImportFunction_Click);
            this.miImportFunction.Visible = false;
            this.miEditFunction.Click += new EventHandler(MiEditFunction_Click);
            this.miFunctionSize.Click += new EventHandler(MiFunctionSize_Click);
            this.miDeleteFunction.Click += new EventHandler(MiDeleteFunction_Click);
            this.miFunctions.DropDownItems.AddRange(new ToolStripItem[] { this.miNewFunction, this.miImportFunction, new ToolStripSeparator(), this.miEditFunction, this.miFunctionSize, this.miDeleteFunction });
            this.menuItems.Add(this.miFunctions);

            this.miNewVariable.Click += new EventHandler(MiNewVariable_Click);
            this.miShowVariables.Click += new EventHandler(MiShowVariables_Click);
            this.miVariables.DropDownItems.AddRange(new ToolStripItem[] { this.miNewVariable, this.miShowVariables });
            this.menuItems.Add(miVariables);

            this.miActivate.Click += new EventHandler(MiActivate_Click);
            this.miDesactivate.Enabled = false;
            this.miDesactivate.Click += new EventHandler(MiDesactivate_Click);
            this.miRun.Enabled = false;
            this.miRun.ShortcutKeys = Keys.F5;
            this.miRun.Click += new EventHandler(MiRun_Click);
            this.miAnimate.Enabled = false;
            this.miAnimate.ShortcutKeys = Keys.F6;
            this.miAnimate.Click += new EventHandler(MiAnimate_Click);
            this.miPause.Enabled = false;
            this.miPause.ShortcutKeys = Keys.Control | Keys.F5;
            this.miPause.Click += new EventHandler(MiPause_Click);
            this.miReset.Enabled = false;
            this.miReset.Click += new EventHandler(MiReset_Click);
            this.miStepIn.Enabled = false;
            this.miStepIn.ShortcutKeys = Keys.F10;
            this.miStepIn.Click += new EventHandler(MiStepIn_Click);
            this.miStepOver.Enabled = false;
            this.miStepOver.ShortcutKeys = Keys.F11;
            this.miStepOver.Click += new EventHandler(MiStepOver_Click);
            this.miSimulation.DropDownItems.AddRange(new ToolStripItem[] { this.miActivate, this.miDesactivate, new ToolStripSeparator(), this.miRun, this.miAnimate, this.miPause, this.miReset, this.miStepIn, this.miStepOver });
            this.menuItems.Add(this.miSimulation);
        }

        private void LoadToolBarButtons()
        {
            ImageList selectImages = new ImageList();
            selectImages.ImageSize = new Size(26, 26);
            selectImages.Images.Add(ToolBarImages.select_normal);
            selectImages.Images.Add(ToolBarImages.select_down);
            selectImages.Images.Add(ToolBarImages.select_disabled);
            selectImages.Images.Add(ToolBarImages.select_normal_selected);
            selectImages.Images.Add(ToolBarImages.select_down_selected);
            this.tbbSelect = new Moway.Template.Controls.ToolBarButtonSelector(selectImages, GraphMessages.CURSOR_TOOL, true, true);
            this.tbbSelect.SelectedChanged += new EventHandler(TbbSelect_SelectedChanged);

            ImageList connectImages = new ImageList();
            connectImages.ImageSize = new Size(29, 29);
            connectImages.Images.Add(ToolBarImages.connect_normal);
            connectImages.Images.Add(ToolBarImages.connect_down);
            connectImages.Images.Add(ToolBarImages.connect_disabled);
            connectImages.Images.Add(ToolBarImages.connect_normal_selected);
            connectImages.Images.Add(ToolBarImages.connect_down_selected);
            this.tbbConnect = new Moway.Template.Controls.ToolBarButtonSelector(connectImages, GraphMessages.CONNECT_TOOL, false, true);
            this.tbbConnect.SelectedChanged += new EventHandler(TbbConnect_SelectedChanged);

            ImageList noteImages = new ImageList();
            noteImages.ImageSize = new Size(29, 29);
            noteImages.Images.Add(ToolBarImages.note_normal);
            noteImages.Images.Add(ToolBarImages.note_down);
            noteImages.Images.Add(ToolBarImages.note_disabled);
            this.tbbNote = new Moway.Template.Controls.ToolBarButton(noteImages, GraphMessages.INSERT_NOTE);
            this.tbbNote.Enabled = false;
            this.tbbNote.Click += new EventHandler(TbbInsertNote_Click);

            ImageList checkDiagramsImages = new ImageList();
            checkDiagramsImages.ImageSize = new Size(29, 29);
            checkDiagramsImages.Images.Add(ToolBarImages.checkDiagram_normal);
            checkDiagramsImages.Images.Add(ToolBarImages.checkDiagram_down);
            checkDiagramsImages.Images.Add(ToolBarImages.checkDiagram_disabled);
            this.tbbCheckDiagrams = new Moway.Template.Controls.ToolBarButton(checkDiagramsImages, GraphMessages.CHECK_DIAGRAMS);
            this.tbbCheckDiagrams.Click += new EventHandler(TbbCheckDiagrams_Click);

            ImageList programImages = new ImageList();
            programImages.ImageSize = new Size(29, 29);
            programImages.Images.Add(ToolBarImages.program_normal);
            programImages.Images.Add(ToolBarImages.program_down);
            programImages.Images.Add(ToolBarImages.program_disabled);
            this.tbbProgramMoway = new Moway.Template.Controls.ToolBarButton(programImages, GraphMessages.PROGRAM_MOWAY);
            this.tbbProgramMoway.Click += new EventHandler(TbbProgramMoway_Click);

            this.toolBarItems.Add(new ToolBarSeparator());
            this.toolBarItems.Add(this.tbbSelect);
            this.toolBarItems.Add(this.tbbConnect);
            //this.toolBarItems.Add(this.tbbNote);
            this.toolBarItems.Add(new ToolBarSeparator());
            this.toolBarItems.Add(this.tbbCheckDiagrams);
            this.toolBarItems.Add(this.tbbProgramMoway);
        }

        #endregion

        #region Public methods

        public override void NewProject()
        {
            this.project = new GraphProject();
            GraphDiagram graphDiagram = new GraphDiagram(((GraphProject)project).MainFunction);
            this.mainFunction = graphDiagram;
            graphFunctions.Add(graphDiagram.Name, graphDiagram);

            this.RegisterGraphFunctionEvents(graphDiagram);
            this.workBox.ChangeContextMenu(graphDiagram.ContextMenu);
            this.workBox.ChangeCursor(graphDiagram.Cursor);
            this.workBox.AddTabButton(((GraphProject)project).MainFunction.Name, false, true);
        }

        public override void NewProject(string name, string path)
        {
            this.project = new GraphProject(name, path);
            GraphDiagram graphDiagram = new GraphDiagram(((GraphProject)project).MainFunction);
            this.mainFunction = graphDiagram;
            graphFunctions.Add(graphDiagram.Name, graphDiagram);
            this.project.SaveProject();
            this.SaveGraphDiagrams();

            this.RegisterGraphFunctionEvents(graphDiagram);
            this.workBox.ChangeContextMenu(graphDiagram.ContextMenu);
            this.workBox.ChangeCursor(graphDiagram.Cursor);
            this.workBox.AddTabButton(((GraphProject)project).MainFunction.Name, false, true);
        }

        public override void OpenProject(string projectFile)
        {
            string name = Path.GetFileNameWithoutExtension(projectFile);
            string path = Path.GetDirectoryName(projectFile);
            //Verifies that the project file directory exists
            if (!Directory.Exists(path + "\\" + name + "-files"))
                throw new ProjectException("Project files don't exists");

            XmlElement properties = null;
            List<Diagram> diagrams = new List<Diagram>();
            SortedList<string, Variable> variables = new SortedList<string, Variable>();

            XmlDocument document = new XmlDocument();
            document.Load(projectFile);
            XmlNodeList projectProp = document.GetElementsByTagName("mowayProject");
            foreach (XmlElement nodo in projectProp[0].ChildNodes)
            {
                switch (nodo.Name)
                {
                    case "type":
                        break;
                    case "properties":
                        properties = nodo;
                        break;
                    case "variables":
                        foreach (XmlElement variableData in nodo.ChildNodes)
                        {
                            Variable variable = new Variable(variableData.ChildNodes[0].InnerText, System.Convert.ToByte(variableData.ChildNodes[1].InnerText));
                            variables.Add(variable.Name, variable);
                        }
                        break;
                    case "functions":
                        //Empty diagrams are first created so that "call" actions can be created
                        foreach (XmlElement function in nodo.ChildNodes)
                        {
                            string diagramFile = path + "\\" + name + "-files\\" + function.InnerText + ".mdg";
                            if (File.Exists(diagramFile))
                                this.graphFunctions.Add(function.InnerText, new GraphDiagram());
                        }
                        //The diagrams are now loaded
                        foreach (XmlElement function in nodo.ChildNodes)
                        {
                            string diagramFile = path + "\\" + name + "-files\\" + function.InnerText + ".mdg";
                            if (function.Name == "main")
                            {
                                this.mainFunction = this.graphFunctions[function.InnerText];
                                this.graphFunctions[function.InnerText].LoadGraphDiagram(diagramFile, variables, false);
                            }
                            else
                            {
                                diagrams.Add(this.graphFunctions[function.InnerText].Diagram);
                                this.graphFunctions[function.InnerText].LoadGraphDiagram(diagramFile, variables, true);
                            }
                        }
                        break;
                    default:
                        throw new ProjectException("Error al abrir el fichero de proyecto");
                }
            }
            if ((properties == null) || (this.mainFunction == null))
                throw new ProjectException("Error al cargar las Properties y/o el diagrama principal del proyecto");
            //Reaching this point means that the project has been successfully opened
            this.project = new GraphProject(name, path, properties, this.mainFunction.Diagram, diagrams, variables);
            //The main function is first loaded and then the rest
            this.RegisterGraphFunctionEvents(this.mainFunction);
            this.workBox.AddTabButton(this.mainFunction.Name, false, true);
            foreach (GraphDiagram graphDiagram in this.graphFunctions.Values)
                if (graphDiagram != this.mainFunction)
                {
                    this.RegisterGraphFunctionEvents(graphDiagram);
                    this.workBox.AddTabButton(graphDiagram.Name, true, false);
                }
        }

        public override void SaveProject()
        {
            this.project.SaveProject();
            this.SaveGraphDiagrams();
            this.projectChanged = false;
        }

        public override void SaveProjectAs(string fileName)
        {
            this.project.SaveProject(fileName);
            this.SaveGraphDiagrams();
            this.projectChanged = false;
        }

        public override void CloseProject()
        {
            if (this.simulator.State == SimState.Running)
                throw new SimulatorException("Simulator ir alerady running");
            else if (this.simulator.State != SimState.Inactive)
                this.DeactivateSimulator();
            this.mainFunction = null;
            this.graphFunctions.Clear();
            this.graphFunctionSelected = null;
            this.workBox.RemoveAllTabButtons();
        }

        public override void Copy()
        {
            this.graphFunctionSelected.Copy();
        }

        public override void Cut()
        {
            this.graphFunctionSelected.Cut();
        }

        public override void Paste()
        {
            this.graphFunctionSelected.Paste();
        }

        public override void Delete()
        {
            this.graphFunctionSelected.Delete();
        }

        public override void Undo()
        {
            this.graphFunctionSelected.Undo();
        }

        public override void KeyPress(Keys modifier, Keys key)
        {
            this.graphFunctionSelected.KeyPress(modifier, key);
        }

        public override void UpdateClientArea(Rectangle screenRectangle)
        {
            this.toolBox.Size = new Size(TOOLBOX_WIDTH, screenRectangle.Height);
            this.toolBox.Location = new Point(screenRectangle.X, screenRectangle.Y);

            if (this.resultsBox.Visible)
            {
                this.resultsBox.Size = new Size(screenRectangle.Width - TOOLBOX_WIDTH, 130);
                this.resultsBox.Location = new Point(screenRectangle.X + TOOLBOX_WIDTH, screenRectangle.Bottom - this.resultsBox.Height);
            }

            if (this.resultsBox.Visible)
                this.workBox.Size = new Size(screenRectangle.Width - TOOLBOX_WIDTH, screenRectangle.Height - this.resultsBox.Height);
            else
                this.workBox.Size = new Size(screenRectangle.Width - TOOLBOX_WIDTH, screenRectangle.Height);
            this.workBox.Location = new Point(screenRectangle.X + TOOLBOX_WIDTH, screenRectangle.Y);
        }

        public override PrintDocument GetPrintDocument()
        {
            return new GraphPrintDocument(this.project.ProjectFileName, this.project.Owner, this.graphFunctionSelected, new List<GraphDiagram>(this.graphFunctions.Values));
        }

        #endregion

        #region Events de las opciones del menú mOwayWorld

        void MiExportPdf_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.exportPdfDialog.ShowDialog())
            {
                //Document is generated in PDF
                GraphPdfDocument pdf = new GraphPdfDocument(this.project.ProjectFileName, this.project.Owner, this.graphFunctionSelected);
                //Saved to the specified path
                pdf.Save(this.exportPdfDialog.FileName);
            }
        }

        void MiExportJpg_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.exportJpgDialog.ShowDialog())
            {
                //Gets the codec for images png
                ImageCodecInfo jpgCodec = GraphManager.GetEncoder("image/jpeg");
                //Parameters are configured
                EncoderParameters encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                //The image is saved
                this.graphFunctionSelected.DiagramBitmap.Save(this.exportJpgDialog.FileName, jpgCodec, encoderParameters);
            }
        }

        void MiExportPng_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.exportPngDialog.ShowDialog())
            {
                //Gets the codec for images png
                ImageCodecInfo pngCodec = GraphManager.GetEncoder("image/png");
                //Parameters are configured 
                EncoderParameters encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                //The image is saved
                this.graphFunctionSelected.DiagramBitmap.Save(this.exportPngDialog.FileName, pngCodec, encoderParameters);
            }
        }

        #endregion

        #region Events de las opciones del menú View

        void MiViewResults_Click(object sender, EventArgs e)
        {
            if (!this.resultsBox.Visible)
                this.OpenResultBox();
            else
            {
                this.resultsBox.Visible = false;
                this.miViewResults.Checked = false;
                this.workBox.Size = new Size(this.workBox.Width, this.workBox.Height + this.resultsBox.Height);

            }
        }

        void MiViewProperties_Click(object sender, EventArgs e)
        {
            if (this.propertiesPanel.Visible)
            {
                this.propertiesPanel.Visible = false;
                this.miViewProperties.Checked = false;
            }
            else
            {
                this.propertiesPanel.Visible = true;
                this.miViewProperties.Checked = true;
            }
        }

        #endregion

        #region Events de los MenuItems del menú de proyecto

        void MiCheckDiagram_Click(object sender, EventArgs e)
        {
            CheckDiagrams();
        }

        void MiViewCode_Click(object sender, EventArgs e)
        {
            this.resultsBox.Clear();
            CompileProcessForm compileFormProcess = new CompileProcessForm(this.project);
            compileFormProcess.DiagramErrors += new ProcessEventHandler(ProcessForm_DiagramErrors);
            if (DialogResult.OK == compileFormProcess.ShowDialog())
            {
                ViewCodeForm viewCodeForm = new ViewCodeForm(this.project.AsmFile);
                viewCodeForm.ShowDialog();
            }
            compileFormProcess.DiagramErrors -= ProcessForm_DiagramErrors;
        }

        void MiCompile_Click(object sender, EventArgs e)
        {
            this.resultsBox.Clear();
            CompileProcessForm compileProccessForm = new CompileProcessForm(this.project);
            compileProccessForm.DiagramErrors += new ProcessEventHandler(ProcessForm_DiagramErrors);
            compileProccessForm.ShowDialog();
            compileProccessForm.DiagramErrors -= ProcessForm_DiagramErrors;
        }

        void MiProgram_Click(object sender, EventArgs e)
        {
            ProgramMoway();
        }

        void MiProperties_Click(object sender, EventArgs e)
        {
            ProjectPropertiesForm propertiesForm = new ProjectPropertiesForm(this.project);
            propertiesForm.ShowDialog();
        }

        #endregion

        #region Events de los MenuItems del menú de funciones

        void MiNewFunction_Click(object sender, EventArgs e)
        {
            this.CreateFunction();
        }

        void MiEditFunction_Click(object sender, EventArgs e)
        {
            this.EditFunction();
        }

        void MiFunctionSize_Click(object sender, EventArgs e)
        {
            EditAreaSizeForm functionSizeForm = new EditAreaSizeForm(this.graphFunctionSelected);
            functionSizeForm.ShowDialog();
        }

        void MiImportFunction_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.importDiagramDialog.ShowDialog())
            {
            }
        }

        void MiDeleteFunction_Click(object sender, EventArgs e)
        {
            this.DeleteFunction();
        }

        #endregion

        #region Events de los MenuItems del menú de variables

        void MiShowVariables_Click(object sender, EventArgs e)
        {
            VariablesForm variablesForm = new VariablesForm();
            variablesForm.ShowDialog();
        }

        void MiNewVariable_Click(object sender, EventArgs e)
        {
            NewVariableForm newVariableForm = new NewVariableForm();
            if (DialogResult.OK == newVariableForm.ShowDialog())
                GraphManager.AddVariable(newVariableForm.VariableCreated);
        }

        #endregion

        #region Evento de los MenuItems del menú de simulación

        void MiActivate_Click(object sender, EventArgs e)
        {
            this.miActivate.Enabled = false;
            this.miDesactivate.Enabled = true;
            //The simulator is created
            List<GraphDiagram> functions = new List<GraphDiagram>();
            foreach (GraphDiagram function in this.graphFunctions.Values)
                functions.Add(function);
            this.simulator.ActivateSimulator(this.mainFunction, functions, this.project.Variables);
            //The simulation panel is created and shown
            this.simulationPanel = new SimulatorPanel(this.simulator);
            this.simulationPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            this.simulationPanel.Run_Click += new EventHandler(SimulationPanel_Run_Click);
            this.simulationPanel.Animate_Click += new EventHandler(SimulationPanel_Animate_Click);
            this.simulationPanel.Pause_Click += new EventHandler(SimulationPanel_Pause_Click);
            this.simulationPanel.Reset_Click += new EventHandler(SimulationPanel_Reset_Click);
            this.simulationPanel.StepIn_Click += new EventHandler(SimulationPanel_StepIn_Click);
            this.simulationPanel.StepOver_Click += new EventHandler(SimulationPanel_StepOver_Click);
            //The simulator buttons are enabled
            this.miRun.Enabled = true;
            this.miReset.Enabled = true;
            this.miStepIn.Enabled = true;
            this.miStepOver.Enabled = true;
        }

        void MiDesactivate_Click(object sender, EventArgs e)
        {
            DeactivateSimulator();
        }

        void MiRun_Click(object sender, EventArgs e)
        {
            this.RunSimulation();
        }

        void MiAnimate_Click(object sender, EventArgs e)
        {
            this.AnimateSimulation();
        }

        void MiPause_Click(object sender, EventArgs e)
        {
            this.PauseSimulation();
        }

        void MiReset_Click(object sender, EventArgs e)
        {
            this.ResetSimulation();
        }

        void MiStepIn_Click(object sender, EventArgs e)
        {
            this.SimulationStepIn();
        }

        void MiStepOver_Click(object sender, EventArgs e)
        {
            this.SimulationStepOver();
        }

        #endregion

        #region Events de los botones de la barra de herramientas

        void TbbProgramMoway_Click(object sender, EventArgs e)
        {
            this.ProgramMoway();
        }

        void TbbCheckDiagrams_Click(object sender, EventArgs e)
        {
            this.CheckDiagrams();
        }

        void TbbInsertNote_Click(object sender, EventArgs e)
        {
        }

        void TbbConnect_SelectedChanged(object sender, EventArgs e)
        {
            this.graphFunctionSelected.ConnectMode();
            this.tbbSelect.Selected = false;
        }

        void TbbSelect_SelectedChanged(object sender, EventArgs e)
        {
            this.graphFunctionSelected.SelectMode();
            this.tbbConnect.Selected = false;
        }

        #endregion

        #region Events generados por el simulador

        void Simulator_SimulationFinished(object sender, EventArgs e)
        {
            if (this.toolBox.InvokeRequired)
                this.toolBox.Invoke(new EventHandler(this.Simulator_SimulationFinished), new object[] { sender, e });
            else
                MowayMessageBox.Show(GraphMessages.SIMULATION_FINISHED, GraphMessages.SIMULATION, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void Simulator_StateChanged(object sender, EventArgs e)
        {
            if (this.toolBox.InvokeRequired)
                this.toolBox.Invoke(new EventHandler(this.Simulator_StateChanged), new object[] { sender, e });
            else
            {
                //Simulator Options Updated
                switch (this.simulator.State)
                {
                    case SimState.Running:
                        this.miDesactivate.Enabled = false;
                        this.miRun.Enabled = false;
                        this.miAnimate.Enabled = false;
                        this.miPause.Enabled = true;
                        this.miReset.Enabled = false;
                        this.miStepIn.Enabled = false;
                        this.miStepOver.Enabled = false;
                        break;
                    case SimState.Pause:
                        this.miDesactivate.Enabled = true;
                        this.miRun.Enabled = true;
                        this.miAnimate.Enabled = true;
                        this.miPause.Enabled = false;
                        this.miReset.Enabled = true;
                        this.miStepIn.Enabled = true;
                        this.miStepOver.Enabled = true;
                        break;
                    case SimState.Stop:
                        this.miDesactivate.Enabled = true;
                        this.miRun.Enabled = false;
                        this.miAnimate.Enabled = false;
                        this.miPause.Enabled = false;
                        this.miReset.Enabled = true;
                        this.miStepIn.Enabled = false;
                        this.miStepOver.Enabled = false;
                        break;
                }
                //Then update the rest of the options of the menus, buttons...
                if (this.simulator.State == SimState.Running)
                {
                    this.toolBox.Enabled = false;
                    this.workBox.Enabled = false;
                    this.propertiesPanel.Enabled = false;
                    this.resultsBox.Enabled = false;
                    this.miExport.Enabled = false;
                    this.miCheckDiagram.Enabled = false;
                    this.miCompile.Enabled = false;
                    this.miProgram.Enabled = false;
                    this.miViewCode.Enabled = false;
                    this.miProperties.Enabled = false;
                    this.miNewFunction.Enabled = false;
                    this.miImportFunction.Enabled = false;
                    this.miEditFunction.Enabled = false;
                    this.miFunctionSize.Enabled = false;
                    this.miDeleteFunction.Enabled = false;
                    this.miNewVariable.Enabled = false;
                    this.miShowVariables.Enabled = false;
                    this.tbbSelect.Enabled = false;
                    this.tbbConnect.Enabled = false;
                    this.tbbCheckDiagrams.Enabled = false;
                    this.tbbProgramMoway.Enabled = false;
                    this.tbbConnect.Enabled = false;
                }
                else
                {
                    this.toolBox.Enabled = true;
                    this.workBox.Enabled = true;
                    this.propertiesPanel.Enabled = true;
                    this.resultsBox.Enabled = true;
                    this.miExport.Enabled = true;
                    this.miCheckDiagram.Enabled = true;
                    this.miCompile.Enabled = true;
                    this.miProgram.Enabled = true;
                    this.miViewCode.Enabled = true;
                    this.miProperties.Enabled = true;
                    this.miNewFunction.Enabled = true;
                    this.miImportFunction.Enabled = true;
                    this.miEditFunction.Enabled = true;
                    this.miFunctionSize.Enabled = true;
                    this.miDeleteFunction.Enabled = true;
                    this.miNewVariable.Enabled = true;
                    this.miShowVariables.Enabled = true;
                    this.tbbSelect.Enabled = true;
                    this.tbbConnect.Enabled = true;
                    this.tbbCheckDiagrams.Enabled = true;
                    this.tbbProgramMoway.Enabled = true;
                    this.tbbConnect.Enabled = true;
                }
            }
        }

        #endregion

        #region Private methods

        private void RegisterGraphFunctionEvents(GraphDiagram graphFunction)
        {
            graphFunction.DiagramChanged += new EventHandler(GraphFunction_DiagramChanged);
            graphFunction.SurfaceChanged += new SurfaceEventHandler(GraphFunction_SurfaceChanged);
            graphFunction.CursorChanged += new CursorEventHandler(GraphFunction_CursorChanged);
            graphFunction.ContextMenuChanged += new ContextMenuEventHandler(GraphFunction_ContextMenuChanged);
            graphFunction.OperationDisabled += new OperationEventHandler(GraphFunction_OperationDisabled);
            graphFunction.ElementSelectedChanged += new EventHandler(GraphFunction_ElementSelectedChanged);
            graphFunction.ActionSettingChanged += new EventHandler(GraphFunction_ActionSettingChanged);
        }

        private void UnregisterGraphFuntionEvents(GraphDiagram graphFunction)
        {
            graphFunction.DiagramChanged -= this.GraphFunction_DiagramChanged;
            graphFunction.SurfaceChanged -= this.GraphFunction_SurfaceChanged;
            graphFunction.CursorChanged -= this.GraphFunction_CursorChanged;
            graphFunction.ContextMenuChanged -= this.GraphFunction_ContextMenuChanged;
            graphFunction.OperationDisabled -= this.GraphFunction_OperationDisabled;
            graphFunction.ElementSelectedChanged -= this.GraphFunction_ElementSelectedChanged;
            graphFunction.ActionSettingChanged -= this.GraphFunction_ActionSettingChanged;
        }

        private void SaveGraphDiagrams()
        {
            if (!Directory.Exists(this.project.ProjectPath + "\\" + this.project.Name + "-files"))
                Directory.CreateDirectory(this.project.ProjectPath + "\\" + this.project.Name + "-files");
            foreach (GraphDiagram graphDiagram in this.graphFunctions.Values)
                graphDiagram.SaveGraphDiagram(this.project.ProjectPath + "\\" + this.project.Name + "-files");
        }

        private void ProgramMoway()
        {
            if (this.project.ProjectPath == "")
                MowayMessageBox.Show("You have to save the project before programming mOway", "Program mOway", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.resultsBox.Clear();
                ProgramProcessForm programProcessForm = new ProgramProcessForm((GraphProject)this.project);
                programProcessForm.DiagramErrors += new ProcessEventHandler(ProcessForm_DiagramErrors);
                programProcessForm.ShowDialog();
                programProcessForm.DiagramErrors -= ProcessForm_DiagramErrors;
            }
        }

        private bool CheckDiagrams()
        {
            this.resultsBox.Clear();
            CheckProcessForm checkProcessForm = new CheckProcessForm(this.project);
            checkProcessForm.DiagramErrors += new ProcessEventHandler(ProcessForm_DiagramErrors);
            DialogResult result = checkProcessForm.ShowDialog();
            checkProcessForm.DiagramErrors -= ProcessForm_DiagramErrors;
            if (result == DialogResult.OK)
                return true;
            else
                return false;
        }

        private void CreateFunction()
        {
            NewFunctionForm newFunctionForm = new NewFunctionForm();
            if (DialogResult.OK == newFunctionForm.ShowDialog())
            {
                this.project.AddFunction(newFunctionForm.DiagramCreated);
                GraphDiagram graphDiagram = new GraphDiagram(newFunctionForm.DiagramCreated);
                this.RegisterGraphFunctionEvents(graphDiagram);
                this.graphFunctions.Add(graphDiagram.Name, graphDiagram);
                this.workBox.AddTabButton(newFunctionForm.DiagramCreated.Name, true, true);
                if (this.simulator.State != SimState.Inactive)
                    this.simulator.AddFunction(graphDiagram);
                this.projectChanged = true;
            }
        }

        private void EditFunction()
        {
            string prevName = this.graphFunctionSelected.Diagram.Name;
            EditFunctionForm editFunctionForm = new EditFunctionForm(this.graphFunctionSelected.Diagram);
            if (DialogResult.OK == editFunctionForm.ShowDialog())
            {
                this.graphFunctions.Remove(prevName);
                this.graphFunctions.Add(this.graphFunctionSelected.Diagram.Name, this.graphFunctionSelected);
                this.workBox.ChangeSelectedTabButtonName(editFunctionForm.DiagramUpdated.Name);
                if (this.simulator.State != SimState.Inactive)
                    this.simulator.UpdateFunction(prevName, this.graphFunctionSelected);
                this.projectChanged = true;
            }
        }

        private void DeleteFunction()
        {
            //It saves the function to delete to delete it from the simulation at the end
            GraphDiagram graphFunction = this.graphFunctionSelected;
            if (this.project.FunctionInUsed(this.graphFunctionSelected.Diagram))
                MowayMessageBox.Show(GraphMessages.FUNCTION_IN_USE, GraphMessages.DELETE_FUNCTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (DialogResult.Yes == MowayMessageBox.Show(GraphMessages.DELETEFUNCTION_WARNING + "\r\n" + GraphMessages.CONTINUE_DELETE, GraphMessages.DELETE_FUNCTION, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                UnregisterGraphFuntionEvents(this.graphFunctionSelected);
                graphFunctions.Remove(this.graphFunctionSelected.Name);
                this.project.RemoveFunction(this.graphFunctionSelected.Name);
                this.workBox.RemoveSelectedTabButton();
                if (this.simulator.State != SimState.Inactive)
                    this.simulator.RemoveFunction(graphFunction);
                this.projectChanged = true;
            }
        }

        private void UpdatePropertiesPanel(GraphDiagram graphDiagram)
        {
            //If there are 0 selected items or more than one selected item, the Properties box panel is hidden
            if (this.graphFunctionSelected.ElementSelected.Count != 1)
                this.propertiesPanel.ClosePanel();
            else //If there is only one item selected...
                if ((this.graphFunctionSelected.ElementSelected[0] is GraphConditional) || (this.graphFunctionSelected.ElementSelected[0] is GraphModule))
                //The panel is displayed for those who have
                this.propertiesPanel.LoadPanel(ActionFactory.GetActionPanel(this.graphFunctionSelected.ElementSelected[0].Element));
                else
                    this.propertiesPanel.ClosePanel();
        }

        private void OpenResultBox()
        {
            this.resultsBox.Visible = true;
            this.miViewResults.Checked = true;
            this.workBox.Size = new Size(this.workBox.Width, this.workBox.Height - this.resultsBox.Height);
            this.resultsBox.Location = new Point(TOOLBOX_WIDTH, this.workBox.Bottom);
            this.resultsBox.Size = new Size(this.workBox.Width, this.resultsBox.Height);
        }

        private void DeactivateSimulator()
        {
            this.miActivate.Enabled = true;
            this.miDesactivate.Enabled = false;
            this.simulator.DeactivateSimulator();
            //The simulation panel is disabled and hidden
            this.simulationPanel.Run_Click -= this.SimulationPanel_Run_Click;
            this.simulationPanel.Pause_Click -= this.SimulationPanel_Pause_Click;
            this.simulationPanel.Reset_Click -= this.SimulationPanel_Reset_Click;
            this.simulationPanel.StepIn_Click -= this.SimulationPanel_StepIn_Click;
            this.simulationPanel.StepOver_Click -= this.SimulationPanel_StepOver_Click;
            this.simulationPanel = null;
            //The simulator buttons are disabled
            this.miRun.Enabled = false;
            this.miAnimate.Enabled = false;
            this.miReset.Enabled = false;
            this.miStepIn.Enabled = false;
            this.miStepOver.Enabled = false;
        }

        #endregion

        #region Private simulation methods

        private void RunSimulation()
        {
            if (this.simulator.RequireValidate)
                if (this.CheckDiagrams())
                    this.simulator.FunctionsValidated();
                else
                    return;
            this.simulator.Run();
        }

        private void AnimateSimulation()
        {
            if (this.simulator.RequireValidate)
                if (this.CheckDiagrams())
                    this.simulator.FunctionsValidated();
                else
                    return;
            this.simulator.Animate();
        }

        private void PauseSimulation()
        {
            this.simulator.Pause();
        }

        private void ResetSimulation()
        {
            this.simulator.Reset();
        }

        private void SimulationStepIn()
        {
            if (this.simulator.RequireValidate)
                if (this.CheckDiagrams())
                    this.simulator.FunctionsValidated();
                else
                    return;
            this.simulator.StepIn();
        }

        private void SimulationStepOver()
        {
            if (this.simulator.RequireValidate)
                if (this.CheckDiagrams())
                    this.simulator.FunctionsValidated();
                else
                    return;
            this.simulator.StepOver();       
        }

        #endregion

        #region Captured events of the WorkBox

        void WorkBox_ChangeTabPageName(object sender, GraphTabButtonEventArgs e)
        {
            this.EditFunction();
        }

        void WorkBox_RemoveTabPage(object sender, GraphTabButtonEventArgs e)
        {
            this.DeleteFunction();
        }

        void WorkBox_CreateTabPage(object sender, EventArgs e)
        {
            this.CreateFunction();
        }

        void WorkBox_ScrollValuesChanged(object sender, EventArgs e)
        {
            this.graphFunctionSelected.UpdateScrollValues(this.workBox.VerticalScrollValue, this.workBox.HorizontalScrollValue);
        }

        void WorkBox_WorkAreaDoubleClick(object sender, MouseEventArgs e)
        {
            this.graphFunctionSelected.MouseDoubleClick(e);
        }

        void WorkBox_WorkAreaMouseLeave(object sender, EventArgs e)
        {
            this.graphFunctionSelected.MouseLeave();
        }

        void WorkBox_WorkAreaMouseEnter(object sender, EventArgs e)
        {
            this.graphFunctionSelected.MouseEnter();
        }

        void WorkBox_WorkAreaMouseUp(object sender, MouseEventArgs e)
        {
            this.graphFunctionSelected.MouseUp(e);
        }

        void WorkBox_WorkAreaMouseMove(object sender, MouseEventArgs e)
        {
            this.graphFunctionSelected.MouseMove(e);
        }

        void WorkBox_WorkAreaMouseDown(object sender, MouseEventArgs e)
        {
            this.graphFunctionSelected.MouseDown(e);
        }

        void WorkBox_TabPageSelected(object sender, GraphTabButtonEventArgs e)
        {
            this.SelectGraphFunction(e.Button.Text);
        }

        private void SelectGraphFunction(string name)
        {
            if (this.graphFunctionSelected != null)
                this.graphFunctionSelected.LostFocus();
            this.graphFunctionSelected = this.graphFunctions[name];
            if (this.graphFunctionSelected.OpMode == OperationMode.Select)
            {
                this.tbbSelect.Selected = true;
                this.tbbConnect.Selected = false;
            }
            else
            {
                this.tbbSelect.Selected = false;
                this.tbbConnect.Selected = true;
            }
            //The Properties window is updated
            this.UpdatePropertiesPanel(this.graphFunctionSelected);
            this.workBox.ChangeContextMenu(this.graphFunctionSelected.ContextMenu);
            this.workBox.UpdateSurface(graphFunctionSelected.Surface);
            this.workBox.UpdateScrollValues(this.graphFunctionSelected.VScrollValue, this.graphFunctionSelected.HScrollValue);
            if (this.graphFunctionSelected.Diagram.IsFunction)
                this.miDeleteFunction.Enabled = true;
            else
                this.miDeleteFunction.Enabled = false;
            //The status of the operations is updated
            if (this.graphFunctionSelected.OperationState[Operation.Copy])
            {
            }

            if (this.graphFunctionSelected.OperationState[Operation.Cut])
            {
            }


            if (this.graphFunctionSelected.OperationState[Operation.Delete])
            {

            }
            if (this.graphFunctionSelected.OperationState[Operation.Undo])
            {

            }
            if (this.graphFunctionSelected.OperationState[Operation.Settings])
            {
            }
        }

        #endregion

        #region Captured events of the ToolBox

        void ToolBox_InitInsert(object sender, ToolEventArgs e)
        {
            this.graphFunctionSelected.InitInsert(e.Tool);
            this.workBox.EnableMouseEvents(e.Rectangle);
        }

        void ToolBox_DoInsert(object sender, PointEventArgs e)
        {
            this.workBox.DisableMouseEvents();
            this.graphFunctionSelected.DoInsert();
        }

        void ToolBox_CancelInsert(object sender, EventArgs e)
        {
            this.graphFunctionSelected.CancelInsert();
            this.workBox.DisableMouseEvents();
        }

        #endregion

        #region Events of the ResultBox

        void ResultsBox_BoxClosed(object sender, EventArgs e)
        {
            this.miViewResults.Checked = false;
            this.workBox.Size = new Size(this.workBox.Width, this.workBox.Height + this.resultsBox.Height);
        }

        #endregion

        #region Captured events of ProcessForm

        void ProcessForm_DiagramErrors(object sender, ProcessEventArgs e)
        {
            if (!this.resultsBox.Visible)
                this.OpenResultBox();
            this.resultsBox.ShowErrors(e.Errors);
        }

        #endregion

        #region Events captured from the simulation panel

        void SimulationPanel_Run_Click(object sender, EventArgs e)
        {
            this.RunSimulation();
        }

        void SimulationPanel_Animate_Click(object sender, EventArgs e)
        {
            this.AnimateSimulation();
        }

        void SimulationPanel_Pause_Click(object sender, EventArgs e)
        {
            this.PauseSimulation();
        }

        void SimulationPanel_Reset_Click(object sender, EventArgs e)
        {
            this.ResetSimulation();
        }

        void SimulationPanel_StepIn_Click(object sender, EventArgs e)
        {
            this.SimulationStepIn();
        }

        void SimulationPanel_StepOver_Click(object sender, EventArgs e)
        {
            this.SimulationStepOver();
        }

        #endregion

        #region Static methods for the control of variables

        public static void AddVariable(Variable variable)
        {
            graphManager.project.AddVariable(variable);
            graphManager.propertiesPanel.AddVariable(variable);
            if (graphManager.simulator.State != SimState.Inactive)
                graphManager.simulator.AddVariable(variable);
            graphManager.projectChanged = true;
        }

        public static void UpdateVariable(Variable variable, string name, byte initValue)
        {
            string prevName = variable.Name;
            if ((variable.Name != name) || (variable.InitValue != initValue))
            {
                graphManager.project.UpdateVariable(variable, name, initValue);
                if (graphManager.simulator.State != SimState.Inactive)
                    graphManager.simulator.UpdateVariable(prevName, variable);
                graphManager.projectChanged = true;
            }
        }

        public static Variable GetVariable(string name)
        {
            return graphManager.project.GetVariable(name);
        }

        public static bool ConstainVariable(string name)
        {
            return graphManager.project.ConstainVariable(name);
        }

        public static bool RemoveVariable(string name)
        {
            Variable variable = graphManager.project.GetVariable(name);
            if (graphManager.project.RemoveVariable(name))
            {
                if (graphManager.simulator.State != SimState.Inactive)
                    graphManager.simulator.RemoveVariable(variable);
                graphManager.projectChanged = true;
                return true;
            }
            return false;
        }

        #endregion

        #region Static methods for the control of subroutines

        public static List<Diagram> GetFunctions()
        {
            return graphManager.project.Subfunctions;
        }

        public static Diagram GetFunction(string name)
        {
            return graphManager.graphFunctions[name].Diagram;
        }

        public static bool ConstainFunction(string name)
        {
            return graphManager.project.ConstainFunction(name);
        }

        #endregion

        #region Captured events of the PresentGraphFunction

        void GraphFunction_ElementSelectedChanged(object sender, EventArgs e)
        {
            UpdatePropertiesPanel((GraphDiagram)sender);
        }

        void GraphFunction_ActionSettingChanged(object sender, EventArgs e)
        {
            this.propertiesPanel.UpdatePanelProperties();
        }

        void GraphFunction_DiagramChanged(object sender, EventArgs e)
        {
            this.projectChanged = true;
            if (this.simulator != null)
                this.simulator.RequireValidate = true;
        }

        void GraphFunction_SurfaceChanged(object sender, SurfaceEventArgs e)
        {
            if ((GraphDiagram)sender == this.graphFunctionSelected)
                this.workBox.UpdateSurface(e.Surface);
            else
                this.workBox.SelectTabButton(((GraphDiagram)sender).Name);
        }

        void GraphFunction_CursorChanged(object sender, CursorEventArgs e)
        {
            this.workBox.ChangeCursor(e.Cursor);
        }

        void GraphFunction_ContextMenuChanged(object sender, ContextMenuEventArgs e)
        {
            this.workBox.ChangeContextMenu(e.Menu);
        }

        void GraphFunction_OperationEnabled(object sender, OperationEventArgs e)
        {

        }

        void GraphFunction_OperationDisabled(object sender, OperationEventArgs e)
        {

        }

        #endregion

        #region Events captured from the Clipboard

        void Clipboard_ClipboardChanged(object sender, EventArgs e)
        {
            if (this.clipboard.IsEmpty)
            {
            }
            else
            {
                foreach (GraphDiagram diagram in this.graphFunctions.Values)
                    diagram.EnablePaste();
            }
        }

        #endregion
    }
}