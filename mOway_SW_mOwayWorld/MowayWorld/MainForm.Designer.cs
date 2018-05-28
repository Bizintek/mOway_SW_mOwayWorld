namespace Moway
{
    partial class MainForm
    {
        /// <summary>
        /// Variable of the designer required.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean the resources that are being used.
        /// </summary>
        /// <param name="disposing">true if the managed resources should be removed; false otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Method necessary to support the Designer. It can not be modified
        /// the content of the method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.miMowayWorld = new System.Windows.Forms.ToolStripMenuItem();
            this.miNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.miCloseProject = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.miSaveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveProjectAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.miPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.miProgramHex = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miCut = new System.Windows.Forms.ToolStripMenuItem();
            this.miCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.miPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.miRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.miView = new System.Windows.Forms.ToolStripMenuItem();
            this.miCommunications = new System.Windows.Forms.ToolStripMenuItem();
            this.miMowayCam = new System.Windows.Forms.ToolStripMenuItem();
            this.miMowayServer = new System.Windows.Forms.ToolStripMenuItem();
            this.miMowayScratch = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.miCastellano = new System.Windows.Forms.ToolStripMenuItem();
            this.miNederlands = new System.Windows.Forms.ToolStripMenuItem();
            this.miRussian = new System.Windows.Forms.ToolStripMenuItem();
            this.miChinese = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.miContent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.miCheckUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectDialog = new System.Windows.Forms.SaveFileDialog();
            this.openProjectDialog = new System.Windows.Forms.OpenFileDialog();
            this.newImages = new System.Windows.Forms.ImageList(this.components);
            this.openImages = new System.Windows.Forms.ImageList(this.components);
            this.saveImages = new System.Windows.Forms.ImageList(this.components);
            this.cutImages = new System.Windows.Forms.ImageList(this.components);
            this.copyImages = new System.Windows.Forms.ImageList(this.components);
            this.pasteImages = new System.Windows.Forms.ImageList(this.components);
            this.undoImages = new System.Windows.Forms.ImageList(this.components);
            this.redoImages = new System.Windows.Forms.ImageList(this.components);
            this.rcImages = new System.Windows.Forms.ImageList(this.components);
            this.mowayState = new System.Windows.Forms.ImageList(this.components);
            this.batterySate = new System.Windows.Forms.ImageList(this.components);
            this.openHexFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.communicationsImages = new System.Windows.Forms.ImageList(this.components);
            this.mowayScratchImages = new System.Windows.Forms.ImageList(this.components);
            this.cameraImages = new System.Windows.Forms.ImageList(this.components);
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.verticalBox = new Moway.Template.MowayShareBox();
            this.toolBar = new Moway.Template.Controls.MowayToolBar();
            this.tbbMowayScratch = new Moway.Template.Controls.ToolBarButtonSelector();
            this.tbbCamera = new Moway.Template.Controls.ToolBarButtonSelector();
            this.tbbCommunications = new Moway.Template.Controls.ToolBarButtonSelector();
            this.tbbOpen = new Moway.Template.Controls.ToolBarButton();
            this.toolBarSeparator3 = new Moway.Template.Controls.ToolBarSeparator();
            this.toolBarSeparator2 = new Moway.Template.Controls.ToolBarSeparator();
            this.tbbCopy = new Moway.Template.Controls.ToolBarButton();
            this.tbbUndo = new Moway.Template.Controls.ToolBarButton();
            this.tbbPaste = new Moway.Template.Controls.ToolBarButton();
            this.tbbRc = new Moway.Template.Controls.ToolBarButtonSelector();
            this.toolBarSeparator1 = new Moway.Template.Controls.ToolBarSeparator();
            this.tbbSave = new Moway.Template.Controls.ToolBarButton();
            this.tbbNew = new Moway.Template.Controls.ToolBarButton();
            this.tbbCut = new Moway.Template.Controls.ToolBarButton();
            this.statusStrip = new Moway.Template.Controls.MowayStatusBar();
            this.pbBatteryState = new System.Windows.Forms.PictureBox();
            this.pbMowayState = new System.Windows.Forms.PictureBox();
            this.lBatteryState = new System.Windows.Forms.Label();
            this.lMowayState = new System.Windows.Forms.Label();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.toolTip = new Moway.Template.Controls.MowayToolTip();
            this.miOpenRc = new System.Windows.Forms.ToolStripMenuItem();
            this.miCloseRc = new System.Windows.Forms.ToolStripMenuItem();
            this.miMowayRc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBatteryState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMowayState)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMowayWorld,
            this.miEdit,
            this.miView,
            this.miMowayRc,
            this.languageToolStripMenuItem,
            this.miHelp});
            this.menuStrip.Name = "menuStrip";
            this.helpProvider.SetShowHelp(this.menuStrip, ((bool)(resources.GetObject("menuStrip.ShowHelp"))));
            // 
            // miMowayWorld
            // 
            this.miMowayWorld.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNewProject,
            this.miOpenProject,
            this.miCloseProject,
            this.toolStripSeparator5,
            this.miSaveProject,
            this.miSaveProjectAs,
            this.toolStripSeparator4,
            this.miPrint,
            this.toolStripSeparator10,
            this.miProgramHex,
            this.toolStripSeparator1,
            this.miExit});
            this.miMowayWorld.MergeIndex = 10;
            this.miMowayWorld.Name = "miMowayWorld";
            resources.ApplyResources(this.miMowayWorld, "miMowayWorld");
            // 
            // miNewProject
            // 
            this.miNewProject.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.miNewProject, "miNewProject");
            this.miNewProject.Name = "miNewProject";
            this.miNewProject.Click += new System.EventHandler(this.NewProject_Click);
            // 
            // miOpenProject
            // 
            resources.ApplyResources(this.miOpenProject, "miOpenProject");
            this.miOpenProject.Name = "miOpenProject";
            this.miOpenProject.Click += new System.EventHandler(this.OpenProject_Click);
            // 
            // miCloseProject
            // 
            resources.ApplyResources(this.miCloseProject, "miCloseProject");
            this.miCloseProject.Name = "miCloseProject";
            this.miCloseProject.Click += new System.EventHandler(this.CloseProject_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // miSaveProject
            // 
            resources.ApplyResources(this.miSaveProject, "miSaveProject");
            this.miSaveProject.Name = "miSaveProject";
            this.miSaveProject.Click += new System.EventHandler(this.SaveProject_Click);
            // 
            // miSaveProjectAs
            // 
            resources.ApplyResources(this.miSaveProjectAs, "miSaveProjectAs");
            this.miSaveProjectAs.Name = "miSaveProjectAs";
            this.miSaveProjectAs.Click += new System.EventHandler(this.SaveProjectAs_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // miPrint
            // 
            this.miPrint.Name = "miPrint";
            resources.ApplyResources(this.miPrint, "miPrint");
            this.miPrint.Click += new System.EventHandler(this.MiPrint_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            // 
            // miProgramHex
            // 
            this.miProgramHex.Name = "miProgramHex";
            resources.ApplyResources(this.miProgramHex, "miProgramHex");
            this.miProgramHex.Click += new System.EventHandler(this.ProgramHex_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            resources.ApplyResources(this.miExit, "miExit");
            this.miExit.Click += new System.EventHandler(this.MiExit_Click);
            // 
            // miEdit
            // 
            this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miUndo,
            this.toolStripSeparator2,
            this.miCut,
            this.miCopy,
            this.miPaste,
            this.miRemove,
            this.toolStripSeparator3,
            this.miSelectAll});
            this.miEdit.Name = "miEdit";
            resources.ApplyResources(this.miEdit, "miEdit");
            // 
            // miUndo
            // 
            resources.ApplyResources(this.miUndo, "miUndo");
            this.miUndo.Name = "miUndo";
            this.miUndo.Click += new System.EventHandler(this.MiUndo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // miCut
            // 
            resources.ApplyResources(this.miCut, "miCut");
            this.miCut.Name = "miCut";
            this.miCut.Click += new System.EventHandler(this.MiCut_Click);
            // 
            // miCopy
            // 
            resources.ApplyResources(this.miCopy, "miCopy");
            this.miCopy.Name = "miCopy";
            this.miCopy.Click += new System.EventHandler(this.MiCopy_Click);
            // 
            // miPaste
            // 
            resources.ApplyResources(this.miPaste, "miPaste");
            this.miPaste.Name = "miPaste";
            this.miPaste.Click += new System.EventHandler(this.MiPaste_Click);
            // 
            // miRemove
            // 
            resources.ApplyResources(this.miRemove, "miRemove");
            this.miRemove.Name = "miRemove";
            this.miRemove.Click += new System.EventHandler(this.MiRemove_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // miSelectAll
            // 
            resources.ApplyResources(this.miSelectAll, "miSelectAll");
            this.miSelectAll.Name = "miSelectAll";
            this.miSelectAll.Click += new System.EventHandler(this.MiSelectAll_Click);
            // 
            // miView
            // 
            this.miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCommunications,
            this.miMowayCam,
            this.miMowayServer,
            this.miMowayScratch});
            this.miView.Name = "miView";
            resources.ApplyResources(this.miView, "miView");
            // 
            // miCommunications
            // 
            this.miCommunications.Name = "miCommunications";
            resources.ApplyResources(this.miCommunications, "miCommunications");
            this.miCommunications.Click += new System.EventHandler(this.MiCommunications_Click);
            // 
            // miMowayCam
            // 
            this.miMowayCam.Name = "miMowayCam";
            resources.ApplyResources(this.miMowayCam, "miMowayCam");
            this.miMowayCam.Click += new System.EventHandler(this.MiMowayCam_Click);
            // 
            // miMowayServer
            // 
            this.miMowayServer.Name = "miMowayServer";
            resources.ApplyResources(this.miMowayServer, "miMowayServer");
            this.miMowayServer.Click += new System.EventHandler(this.MiMowayServer_Click);

            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEnglish,
            this.miCastellano,
            this.miNederlands,
            this.miRussian,
            this.miChinese});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // miEnglish
            // 
            this.miEnglish.Name = "miEnglish";
            resources.ApplyResources(this.miEnglish, "miEnglish");
            this.miEnglish.Click += new System.EventHandler(this.MiEnglish_Click);
            // 
            // miCastellano
            // 
            this.miCastellano.Name = "miCastellano";
            resources.ApplyResources(this.miCastellano, "miCastellano");
            this.miCastellano.Click += new System.EventHandler(this.MiCastellano_Click);
            // 
            // miNederlands
            // 
            this.miNederlands.Name = "miNederlands";
            resources.ApplyResources(this.miNederlands, "miNederlands");
            this.miNederlands.Click += new System.EventHandler(this.MiNederlands_Click);
            // 
            // miRussian
            // 
            this.miRussian.Name = "miRussian";
            resources.ApplyResources(this.miRussian, "miRussian");
            this.miRussian.Click += new System.EventHandler(this.MiRussian_Click);
            // 
            // miChinese
            // 
            this.miChinese.Name = "miChinese";
            resources.ApplyResources(this.miChinese, "miChinese");
            this.miChinese.Click += new System.EventHandler(this.MiChinese_Click);
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSearch,
            this.miContent,
            this.toolStripSeparator8,
            this.miCheckUpdates,
            this.toolStripSeparator9,
            this.miAbout});
            this.miHelp.Name = "miHelp";
            resources.ApplyResources(this.miHelp, "miHelp");
            // 
            // miSearch
            // 
            this.miSearch.Name = "miSearch";
            resources.ApplyResources(this.miSearch, "miSearch");
            this.miSearch.Click += new System.EventHandler(this.MiSearch_Click);
            // 
            // miContent
            // 
            this.miContent.Name = "miContent";
            resources.ApplyResources(this.miContent, "miContent");
            this.miContent.Click += new System.EventHandler(this.MiContent_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // miCheckUpdates
            // 
            this.miCheckUpdates.Name = "miCheckUpdates";
            resources.ApplyResources(this.miCheckUpdates, "miCheckUpdates");
            this.miCheckUpdates.Click += new System.EventHandler(this.MiCheckUpdates_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            resources.ApplyResources(this.miAbout, "miAbout");
            this.miAbout.Click += new System.EventHandler(this.About_Click);
            // 
            // saveProjectDialog
            // 
            this.saveProjectDialog.DefaultExt = "mpj";
            resources.ApplyResources(this.saveProjectDialog, "saveProjectDialog");
            // 
            // openProjectDialog
            // 
            resources.ApplyResources(this.openProjectDialog, "openProjectDialog");
            // 
            // newImages
            // 
            this.newImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("newImages.ImageStream")));
            this.newImages.TransparentColor = System.Drawing.Color.Transparent;
            this.newImages.Images.SetKeyName(0, "new_normal.png");
            this.newImages.Images.SetKeyName(1, "new_down.png");
            this.newImages.Images.SetKeyName(2, "new_disabled.png");
            // 
            // openImages
            // 
            this.openImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("openImages.ImageStream")));
            this.openImages.TransparentColor = System.Drawing.Color.Transparent;
            this.openImages.Images.SetKeyName(0, "open_normal.png");
            this.openImages.Images.SetKeyName(1, "open_down.png");
            this.openImages.Images.SetKeyName(2, "open_disabled.png");
            // 
            // saveImages
            // 
            this.saveImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("saveImages.ImageStream")));
            this.saveImages.TransparentColor = System.Drawing.Color.Transparent;
            this.saveImages.Images.SetKeyName(0, "save_normal.png");
            this.saveImages.Images.SetKeyName(1, "save_down.png");
            this.saveImages.Images.SetKeyName(2, "save_disabled.png");
            // 
            // cutImages
            // 
            this.cutImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("cutImages.ImageStream")));
            this.cutImages.TransparentColor = System.Drawing.Color.Transparent;
            this.cutImages.Images.SetKeyName(0, "cut_normal.png");
            this.cutImages.Images.SetKeyName(1, "cut_down.png");
            this.cutImages.Images.SetKeyName(2, "cut_disabled.png");
            // 
            // copyImages
            // 
            this.copyImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("copyImages.ImageStream")));
            this.copyImages.TransparentColor = System.Drawing.Color.Transparent;
            this.copyImages.Images.SetKeyName(0, "copy_normal.png");
            this.copyImages.Images.SetKeyName(1, "copy_down.png");
            this.copyImages.Images.SetKeyName(2, "copy_disabled.png");
            // 
            // pasteImages
            // 
            this.pasteImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("pasteImages.ImageStream")));
            this.pasteImages.TransparentColor = System.Drawing.Color.Transparent;
            this.pasteImages.Images.SetKeyName(0, "paste_normal.png");
            this.pasteImages.Images.SetKeyName(1, "paste_down.png");
            this.pasteImages.Images.SetKeyName(2, "paste_disabled.png");
            // 
            // undoImages
            // 
            this.undoImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("undoImages.ImageStream")));
            this.undoImages.TransparentColor = System.Drawing.Color.Transparent;
            this.undoImages.Images.SetKeyName(0, "undo_normal.png");
            this.undoImages.Images.SetKeyName(1, "undo_down.png");
            this.undoImages.Images.SetKeyName(2, "undo_disabled.png");
            // 
            // redoImages
            // 
            this.redoImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("redoImages.ImageStream")));
            this.redoImages.TransparentColor = System.Drawing.Color.Transparent;
            this.redoImages.Images.SetKeyName(0, "redo_normal.png");
            this.redoImages.Images.SetKeyName(1, "redo_down.png");
            this.redoImages.Images.SetKeyName(2, "redo_disabled.png");
            // 
            // rcImages
            // 
            this.rcImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("rcImages.ImageStream")));
            this.rcImages.TransparentColor = System.Drawing.Color.Transparent;
            this.rcImages.Images.SetKeyName(0, "rc_normal.png");
            this.rcImages.Images.SetKeyName(1, "rc_down.png");
            this.rcImages.Images.SetKeyName(2, "rc_disabled.png");
            this.rcImages.Images.SetKeyName(3, "rc_normal_selected.png");
            this.rcImages.Images.SetKeyName(4, "rc_normal_selected_down.png");
            // 
            // mowayState
            // 
            this.mowayState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mowayState.ImageStream")));
            this.mowayState.TransparentColor = System.Drawing.Color.Transparent;
            this.mowayState.Images.SetKeyName(0, "mowayDisconnected.png");
            this.mowayState.Images.SetKeyName(1, "mowayConnected.png");
            this.mowayState.Images.SetKeyName(2, "mowayInProgramming.png");
            // 
            // batterySate
            // 
            this.batterySate.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("batterySate.ImageStream")));
            this.batterySate.TransparentColor = System.Drawing.Color.Transparent;
            this.batterySate.Images.SetKeyName(0, "batteryState0.png");
            this.batterySate.Images.SetKeyName(1, "batteryState1.png");
            this.batterySate.Images.SetKeyName(2, "batteryState2.png");
            this.batterySate.Images.SetKeyName(3, "batteryState3.png");
            this.batterySate.Images.SetKeyName(4, "batteryState4.png");
            this.batterySate.Images.SetKeyName(5, "batteryState5.png");
            this.batterySate.Images.SetKeyName(6, "batteryState6.png");
            this.batterySate.Images.SetKeyName(7, "batteryState7.png");
            // 
            // openHexFileDialog
            // 
            resources.ApplyResources(this.openHexFileDialog, "openHexFileDialog");
            // 
            // communicationsImages
            // 
            this.communicationsImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("communicationsImages.ImageStream")));
            this.communicationsImages.TransparentColor = System.Drawing.Color.Transparent;
            this.communicationsImages.Images.SetKeyName(0, "comunicacion_normal.png");
            this.communicationsImages.Images.SetKeyName(1, "comunicacion_down.png");
            this.communicationsImages.Images.SetKeyName(2, "comunicacion_disabled.png");
            this.communicationsImages.Images.SetKeyName(3, "comunicacion_selected.png");
            this.communicationsImages.Images.SetKeyName(4, "comunicacion_selected_down.png");
            // 
            // mowayScratchImages
            // 
            this.mowayScratchImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mowayScratchImages.ImageStream")));
            this.mowayScratchImages.TransparentColor = System.Drawing.Color.Transparent;
            this.mowayScratchImages.Images.SetKeyName(0, "mowayScratch_normal.png");
            this.mowayScratchImages.Images.SetKeyName(1, "mowayScratch_normal_down.png");
            this.mowayScratchImages.Images.SetKeyName(2, "mowayScratch_disabled.png");
            this.mowayScratchImages.Images.SetKeyName(3, "mowayScratch_selected.png");
            this.mowayScratchImages.Images.SetKeyName(4, "mowayScratch_selected_down.png");
            // 
            // cameraImages
            // 
            this.cameraImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("cameraImages.ImageStream")));
            this.cameraImages.TransparentColor = System.Drawing.Color.Transparent;
            this.cameraImages.Images.SetKeyName(0, "video_normal.png");
            this.cameraImages.Images.SetKeyName(1, "video_normal_down.png");
            this.cameraImages.Images.SetKeyName(2, "video_disabled.png");
            this.cameraImages.Images.SetKeyName(3, "video_normal_selected.png");
            this.cameraImages.Images.SetKeyName(4, "video_normal_selected_down.png");
            // 
            // helpProvider
            // 
            resources.ApplyResources(this.helpProvider, "helpProvider");
            // 
            // verticalBox
            // 
            this.verticalBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            resources.ApplyResources(this.verticalBox, "verticalBox");
            this.verticalBox.Name = "verticalBox";
            this.helpProvider.SetShowHelp(this.verticalBox, ((bool)(resources.GetObject("verticalBox.ShowHelp"))));
            // 
            // toolBar
            // 
            this.toolBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            resources.ApplyResources(this.toolBar, "toolBar");
            this.toolBar.Controls.Add(this.tbbMowayScratch);
            this.toolBar.Controls.Add(this.tbbCamera);
            this.toolBar.Controls.Add(this.tbbCommunications);
            this.toolBar.Controls.Add(this.tbbOpen);
            this.toolBar.Controls.Add(this.toolBarSeparator3);
            this.toolBar.Controls.Add(this.toolBarSeparator2);
            this.toolBar.Controls.Add(this.tbbCopy);
            this.toolBar.Controls.Add(this.tbbUndo);
            this.toolBar.Controls.Add(this.tbbPaste);
            this.toolBar.Controls.Add(this.tbbRc);
            this.toolBar.Controls.Add(this.toolBarSeparator1);
            this.toolBar.Controls.Add(this.tbbSave);
            this.toolBar.Controls.Add(this.tbbNew);
            this.toolBar.Controls.Add(this.tbbCut);
            this.toolBar.Name = "toolBar";
            this.helpProvider.SetShowHelp(this.toolBar, ((bool)(resources.GetObject("toolBar.ShowHelp"))));

            // 
            // tbbCamera
            // 
            this.tbbCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            resources.ApplyResources(this.tbbCamera, "tbbCamera");
            this.tbbCamera.FlatAppearance.BorderSize = 0;
            this.tbbCamera.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbCamera.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbCamera.ImageList = this.cameraImages;
            this.tbbCamera.Name = "tbbCamera";
            this.tbbCamera.Selected = false;
            this.helpProvider.SetShowHelp(this.tbbCamera, ((bool)(resources.GetObject("tbbCamera.ShowHelp"))));
            this.toolTip.SetToolTip(this.tbbCamera, resources.GetString("tbbCamera.ToolTip"));
            this.tbbCamera.UseVisualStyleBackColor = true;
            this.tbbCamera.SelectedChanged += new System.EventHandler(this.TbbCamera_SelectedChanged);
            // 
            // tbbCommunications
            // 
            this.tbbCommunications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            resources.ApplyResources(this.tbbCommunications, "tbbCommunications");
            this.tbbCommunications.FlatAppearance.BorderSize = 0;
            this.tbbCommunications.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbCommunications.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbCommunications.ImageList = this.communicationsImages;
            this.tbbCommunications.Name = "tbbCommunications";
            this.tbbCommunications.Selected = false;
            this.helpProvider.SetShowHelp(this.tbbCommunications, ((bool)(resources.GetObject("tbbCommunications.ShowHelp"))));
            this.toolTip.SetToolTip(this.tbbCommunications, resources.GetString("tbbCommunications.ToolTip"));
            this.tbbCommunications.UseVisualStyleBackColor = true;
            this.tbbCommunications.SelectedChanged += new System.EventHandler(this.TbbCommunications_SelectedChanged);
            // 
            // tbbOpen
            // 
            this.tbbOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            resources.ApplyResources(this.tbbOpen, "tbbOpen");
            this.tbbOpen.FlatAppearance.BorderSize = 0;
            this.tbbOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbOpen.ImageList = this.openImages;
            this.tbbOpen.Name = "tbbOpen";
            this.helpProvider.SetShowHelp(this.tbbOpen, ((bool)(resources.GetObject("tbbOpen.ShowHelp"))));
            this.toolTip.SetToolTip(this.tbbOpen, resources.GetString("tbbOpen.ToolTip"));
            this.tbbOpen.UseVisualStyleBackColor = true;
            this.tbbOpen.Click += new System.EventHandler(this.TbbOpen_Click);
            // 
            // toolBarSeparator3
            // 
            this.toolBarSeparator3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            resources.ApplyResources(this.toolBarSeparator3, "toolBarSeparator3");
            this.toolBarSeparator3.Name = "toolBarSeparator3";
            this.helpProvider.SetShowHelp(this.toolBarSeparator3, ((bool)(resources.GetObject("toolBarSeparator3.ShowHelp"))));
            // 
            // toolBarSeparator2
            // 
            this.toolBarSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            resources.ApplyResources(this.toolBarSeparator2, "toolBarSeparator2");
            this.toolBarSeparator2.Name = "toolBarSeparator2";
            this.helpProvider.SetShowHelp(this.toolBarSeparator2, ((bool)(resources.GetObject("toolBarSeparator2.ShowHelp"))));
            // 
            // tbbCopy
            // 
            this.tbbCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            resources.ApplyResources(this.tbbCopy, "tbbCopy");
            this.tbbCopy.FlatAppearance.BorderSize = 0;
            this.tbbCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbCopy.ImageList = this.copyImages;
            this.tbbCopy.Name = "tbbCopy";
            this.helpProvider.SetShowHelp(this.tbbCopy, ((bool)(resources.GetObject("tbbCopy.ShowHelp"))));
            this.toolTip.SetToolTip(this.tbbCopy, resources.GetString("tbbCopy.ToolTip"));
            this.tbbCopy.UseVisualStyleBackColor = true;
            this.tbbCopy.Click += new System.EventHandler(this.TbbCopy_Click);
            // 
            // tbbUndo
            // 
            this.tbbUndo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            resources.ApplyResources(this.tbbUndo, "tbbUndo");
            this.tbbUndo.FlatAppearance.BorderSize = 0;
            this.tbbUndo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbUndo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbUndo.ImageList = this.undoImages;
            this.tbbUndo.Name = "tbbUndo";
            this.helpProvider.SetShowHelp(this.tbbUndo, ((bool)(resources.GetObject("tbbUndo.ShowHelp"))));
            this.toolTip.SetToolTip(this.tbbUndo, resources.GetString("tbbUndo.ToolTip"));
            this.tbbUndo.UseVisualStyleBackColor = true;
            this.tbbUndo.Click += new System.EventHandler(this.TbbUndo_Click);
            // 
            // tbbPaste
            // 
            this.tbbPaste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            resources.ApplyResources(this.tbbPaste, "tbbPaste");
            this.tbbPaste.FlatAppearance.BorderSize = 0;
            this.tbbPaste.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbPaste.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbPaste.ImageList = this.pasteImages;
            this.tbbPaste.Name = "tbbPaste";
            this.helpProvider.SetShowHelp(this.tbbPaste, ((bool)(resources.GetObject("tbbPaste.ShowHelp"))));
            this.toolTip.SetToolTip(this.tbbPaste, resources.GetString("tbbPaste.ToolTip"));
            this.tbbPaste.UseVisualStyleBackColor = true;
            this.tbbPaste.Click += new System.EventHandler(this.TbbPaste_Click);

            // 
            // toolBarSeparator1
            // 
            this.toolBarSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            resources.ApplyResources(this.toolBarSeparator1, "toolBarSeparator1");
            this.toolBarSeparator1.Name = "toolBarSeparator1";
            this.helpProvider.SetShowHelp(this.toolBarSeparator1, ((bool)(resources.GetObject("toolBarSeparator1.ShowHelp"))));
            // 
            // tbbSave
            // 
            this.tbbSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            resources.ApplyResources(this.tbbSave, "tbbSave");
            this.tbbSave.FlatAppearance.BorderSize = 0;
            this.tbbSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbSave.ImageList = this.saveImages;
            this.tbbSave.Name = "tbbSave";
            this.helpProvider.SetShowHelp(this.tbbSave, ((bool)(resources.GetObject("tbbSave.ShowHelp"))));
            this.toolTip.SetToolTip(this.tbbSave, resources.GetString("tbbSave.ToolTip"));
            this.tbbSave.UseVisualStyleBackColor = true;
            this.tbbSave.Click += new System.EventHandler(this.TbbSave_Click);
            // 
            // tbbNew
            // 
            this.tbbNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            resources.ApplyResources(this.tbbNew, "tbbNew");
            this.tbbNew.FlatAppearance.BorderSize = 0;
            this.tbbNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbNew.ImageList = this.newImages;
            this.tbbNew.Name = "tbbNew";
            this.helpProvider.SetShowHelp(this.tbbNew, ((bool)(resources.GetObject("tbbNew.ShowHelp"))));
            this.toolTip.SetToolTip(this.tbbNew, resources.GetString("tbbNew.ToolTip"));
            this.tbbNew.UseVisualStyleBackColor = true;
            this.tbbNew.Click += new System.EventHandler(this.TbbNew_Click);
            // 
            // tbbCut
            // 
            this.tbbCut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            resources.ApplyResources(this.tbbCut, "tbbCut");
            this.tbbCut.FlatAppearance.BorderSize = 0;
            this.tbbCut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbCut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.tbbCut.ImageList = this.cutImages;
            this.tbbCut.Name = "tbbCut";
            this.helpProvider.SetShowHelp(this.tbbCut, ((bool)(resources.GetObject("tbbCut.ShowHelp"))));
            this.toolTip.SetToolTip(this.tbbCut, resources.GetString("tbbCut.ToolTip"));
            this.tbbCut.UseVisualStyleBackColor = true;
            this.tbbCut.Click += new System.EventHandler(this.TbbCut_Click);
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Controls.Add(this.pbBatteryState);
            this.statusStrip.Controls.Add(this.pbMowayState);
            this.statusStrip.Controls.Add(this.lBatteryState);
            this.statusStrip.Controls.Add(this.lMowayState);
            this.statusStrip.Name = "statusStrip";
            this.helpProvider.SetShowHelp(this.statusStrip, ((bool)(resources.GetObject("statusStrip.ShowHelp"))));
            // 
            // pbBatteryState
            // 
            resources.ApplyResources(this.pbBatteryState, "pbBatteryState");
            this.pbBatteryState.Name = "pbBatteryState";
            this.helpProvider.SetShowHelp(this.pbBatteryState, ((bool)(resources.GetObject("pbBatteryState.ShowHelp"))));
            this.pbBatteryState.TabStop = false;
            // 
            // pbMowayState
            // 
            resources.ApplyResources(this.pbMowayState, "pbMowayState");
            this.pbMowayState.Name = "pbMowayState";
            this.helpProvider.SetShowHelp(this.pbMowayState, ((bool)(resources.GetObject("pbMowayState.ShowHelp"))));
            this.pbMowayState.TabStop = false;
            // 
            // lBatteryState
            // 
            resources.ApplyResources(this.lBatteryState, "lBatteryState");
            this.lBatteryState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lBatteryState.Name = "lBatteryState";
            this.helpProvider.SetShowHelp(this.lBatteryState, ((bool)(resources.GetObject("lBatteryState.ShowHelp"))));
            // 
            // lMowayState
            // 
            resources.ApplyResources(this.lMowayState, "lMowayState");
            this.lMowayState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lMowayState.Name = "lMowayState";
            this.helpProvider.SetShowHelp(this.lMowayState, ((bool)(resources.GetObject("lMowayState.ShowHelp"))));
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;

            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.verticalBox);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.helpProvider.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBatteryState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMowayState)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem miMowayWorld;
        private System.Windows.Forms.ToolStripMenuItem miNewProject;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miOpenProject;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripMenuItem miUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miCut;
        private System.Windows.Forms.ToolStripMenuItem miCopy;
        private System.Windows.Forms.ToolStripMenuItem miPaste;
        private System.Windows.Forms.ToolStripMenuItem miRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem miSaveProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miProgramHex;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private Moway.Template.Controls.MowayStatusBar statusStrip;
        private System.Windows.Forms.ToolStripMenuItem miSaveProjectAs;
        private System.Windows.Forms.SaveFileDialog saveProjectDialog;
        private System.Windows.Forms.OpenFileDialog openProjectDialog;
        private System.Windows.Forms.ImageList newImages;
        private System.Windows.Forms.ImageList openImages;
        private System.Windows.Forms.ImageList saveImages;
        private System.Windows.Forms.ImageList cutImages;
        private System.Windows.Forms.ImageList copyImages;
        private System.Windows.Forms.ImageList pasteImages;
        private System.Windows.Forms.ImageList undoImages;
        private System.Windows.Forms.ImageList redoImages;
        private System.Windows.Forms.ImageList rcImages;
        private Moway.Template.Controls.MowayToolBar toolBar;
        private Moway.Template.Controls.ToolBarButton tbbNew;
        private Moway.Template.Controls.ToolBarButton tbbOpen;
        private Moway.Template.Controls.ToolBarButton tbbSave;
        private Moway.Template.Controls.ToolBarButton tbbCut;
        private Moway.Template.Controls.ToolBarSeparator toolBarSeparator1;
        private Moway.Template.Controls.ToolBarButton tbbCopy;
        private Moway.Template.Controls.ToolBarButton tbbUndo;
        private Moway.Template.Controls.ToolBarButton tbbPaste;
        private Moway.Template.Controls.ToolBarButtonSelector tbbRc;
        private Moway.Template.Controls.ToolBarSeparator toolBarSeparator3;
        private Moway.Template.Controls.ToolBarSeparator toolBarSeparator2;
        private System.Windows.Forms.PictureBox pbBatteryState;
        private System.Windows.Forms.ImageList mowayState;
        private System.Windows.Forms.Label lBatteryState;
        private System.Windows.Forms.PictureBox pbMowayState;
        private System.Windows.Forms.Label lMowayState;
        private System.Windows.Forms.ImageList batterySate;
        private Moway.Template.Controls.MowayToolTip toolTip;
        private System.Windows.Forms.OpenFileDialog openHexFileDialog;
        private System.Windows.Forms.ToolStripMenuItem miCloseProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem miSelectAll;
        private Moway.Template.Controls.ToolBarButtonSelector tbbCommunications;
        private System.Windows.Forms.ImageList communicationsImages;
        private Moway.Template.MowayShareBox verticalBox;
        private System.Windows.Forms.ToolStripMenuItem miCheckUpdates;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem miSearch;
        private System.Windows.Forms.ToolStripMenuItem miContent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.HelpProvider helpProvider;
        private System.Windows.Forms.ToolStripMenuItem miPrint;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem miView;
        private System.Windows.Forms.ToolStripMenuItem miCommunications;
        private System.Windows.Forms.ToolStripMenuItem miMowayCam;
        private System.Windows.Forms.ToolStripMenuItem miMowayServer;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miEnglish;
        private System.Windows.Forms.ToolStripMenuItem miCastellano;
        private System.Windows.Forms.ToolStripMenuItem miNederlands;
        private System.Windows.Forms.ToolStripMenuItem miRussian;
        private System.Windows.Forms.ToolStripMenuItem miChinese;
        private Moway.Template.Controls.ToolBarButtonSelector tbbCamera;
        private System.Windows.Forms.ImageList cameraImages;
        private System.Windows.Forms.ToolStripMenuItem miMowayScratch;
        private Moway.Template.Controls.ToolBarButtonSelector tbbMowayScratch;
        private System.Windows.Forms.ImageList mowayScratchImages;
        private System.Windows.Forms.ToolStripMenuItem miMowayRc;
        private System.Windows.Forms.ToolStripMenuItem miOpenRc;
        private System.Windows.Forms.ToolStripMenuItem miCloseRc;
    }
}

