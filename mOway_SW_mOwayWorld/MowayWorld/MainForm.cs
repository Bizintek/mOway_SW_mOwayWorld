using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Threading;
using Moway.Processes;
using Moway.Panels;
using Moway.Template;
using Moway.Template.Controls;
using Moway.Project;
using Moway.Forms;
using Moway.Controller;
using Moway.Camera;
using Moway.Server;

using Moway.Simulator;

namespace Moway
{
    /// <summary>
    /// Main form of the application
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class MainForm : Form
    {
        #region Attributes

        /// <summary>
        /// The currently open project manager
        /// </summary>
        private ProjectManager projectManager = null;
        /// <summary>
        /// Side panel for RF communication module
        /// </summary>
        private CommunicationPanel communicationPanel = new CommunicationPanel();
        /// <summary>
        /// Side panel for the capture of video
        /// </summary>
        private CameraPanel cameraPanel = new CameraPanel();
        /// <summary>
        /// Side panel for the server module
        /// </summary>
        private ServerPanel serverPanel = new ServerPanel();
    
        #endregion

        string moprojPF = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\mOwayPack v3\mOway Robot\mOproj";
        static string moprojMD = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\mOproj";
        static string tempFolder = moprojMD + @"\Temp";        
        string scratchPF = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\mOwayPack v3\mOway Robot\Scratch Projects";
        string scratchMD = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Scratch projects\mOway Robot";

        /// <summary>
        /// Builder of the main form that opens an empty graphic project
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.InitializeForm();
            //the diagram editor opens directly with an empty project
            this.LoadProjectManager(ProjectManager.GetManager(ProjectType.Graphical));
            this.projectManager.NewProject();
            this.miSaveProject.Enabled = true;
            this.miSaveProjectAs.Enabled = true;
            this.miCloseProject.Enabled = true;

            // Create "mOproj" folder if it doesn't exist            
            if (Directory.Exists(moprojPF))
                CopyDir.Copy(moprojPF, moprojMD);

            System.Threading.Thread.Sleep(100);
            if (Directory.Exists(scratchPF) && !Directory.Exists(scratchMD))
                CopyDir.Copy(scratchPF, scratchMD);      
        }

        /// <summary>
        /// Builder of the main form that opens the project passed as parameter
        /// </summary>
        /// <param name="projectFile"></param>
        public MainForm(string projectFile)
        {
            InitializeComponent();
            this.InitializeForm();
            //Opens the project passed as parameter
            this.OpenProject(projectFile);

            // Create "mOproj" folder if it doesn't exist            
            if (Directory.Exists(moprojPF) && !Directory.Exists(moprojMD))
                CopyDir.Copy(moprojPF, moprojMD);

            System.Threading.Thread.Sleep(100);
            if (Directory.Exists(scratchPF) && !Directory.Exists(scratchMD))
                CopyDir.Copy(scratchPF, scratchMD);      
        }

        #region Initializations

        /// <summary>
        /// Initializes the form
        /// </summary>
        private void InitializeForm()
        {
            //It redefines the colors of the items of the main menu
            ToolStripManager.Renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColors());
            //Sets the startup folders
            this.openHexFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\mOproj";
            this.openProjectDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\mOproj";
            this.saveProjectDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\mOproj";
            //Enables the option Print current page and page settings
            this.printDialog.AllowCurrentPage = true;
            //It records events to update the mOway status
            Controller.Controller mController = Controller.Controller.GetController();
            mController.BatteryChanged += new BatteryEventHandler(MController_BatteryChanged);
            mController.MowayConnected += new ControllerEventHandler(MController_MowayConnected);
            mController.MowayDisconnected += new EventHandler(MController_MowayDisconnected);
            //the quick key is added to the option delete
            this.miRemove.ShortcutKeys = Keys.Delete;
            //marks the current language
            switch (CultureInfo.CurrentCulture.ToString())
            {
                case "es-ES":
                    this.miCastellano.Checked = true;
                    break;
                case "en-GB":
                    this.miEnglish.Checked = true;
                    break;
                case "nl-NL":
                    this.miNederlands.Checked = true;
                    break;
                case "ru-RU":
                    this.miRussian.Checked = true;
                    break;
                case "zh-CN":
                    this.miChinese.Checked = true;
                    break;
                default:
                    this.miEnglish.Checked = true;
                    break;
            }
            //Sets the path of the help file
            this.helpProvider.HelpNamespace = Application.StartupPath + "\\help\\" + this.helpProvider.HelpNamespace;
            //Check if the software must be updated
            Thread TCheckActual = new Thread(new ThreadStart(Check_actual));
            TCheckActual.CurrentCulture = CultureInfo.CurrentCulture;
            TCheckActual.CurrentUICulture = CultureInfo.CurrentCulture;
            TCheckActual.IsBackground = true;
            TCheckActual.Start();
        }

        #endregion

        #region Form Events

        /// <summary>
        /// The main form captures the press of a key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
        }

        /// <summary>
        /// The main form captures the press of a key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //If there is an open project, the key is passed to the manager
            if (projectManager != null)
                this.projectManager.KeyPress(e.Modifiers, e.KeyCode);
        }

        /// <summary>
        /// Occurs when the application is to be closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If there is an open project...
            if (this.projectManager != null)
            {
                //If the project has not been saved, the user is notified
                if (this.projectManager.ProjectChanged)
                    switch (MowayMessageBox.Show(MainMessages.PROJECT_NOT_SAVE + "\r\n" + MainMessages.SAVE_CHANGES, MainMessages.SAVE_PROJECT, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                    {
                        case DialogResult.Yes:
                            if (!this.SaveProject())
                            {
                                e.Cancel = true;
                                return;
                            }
                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            return;
                    }
                try
                {
                    //The project is closed
                    this.projectManager.CloseProject();
                }
                catch (SimulatorException)
                {
                    //If the simulator is running, it is not possible to close the application
                    MowayMessageBox.Show("Simulator is already running.\r\nCan't close the present project", "Close mOway World", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
            //The communication panel is closed if it is open
            if (this.verticalBox.Contains(this.communicationPanel))
                try
                {
                    this.communicationPanel.ForceCloseBox();
                }
                catch { }
            //The camera panel is closed if it is open
            if (this.verticalBox.Contains(this.cameraPanel))
                this.cameraPanel.CloseBox();
            //The server panel is closed if it is open
            if (this.verticalBox.Contains(this.serverPanel))
                this.serverPanel.CloseBox();
        }

        #endregion

        #region mOwayWorld menu events 

        /// <summary>
        /// Create New Project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewProject_Click(object sender, EventArgs e)
        {
            this.NewProject();
        }

        /// <summary>
        /// Open a project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenProject_Click(object sender, EventArgs e)
        {
            this.OpenProject();
        }

        /// <summary>
        /// Save a project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveProject_Click(object sender, EventArgs e)
        {
            this.SaveProject();
        }

        /// <summary>
        /// Save a project with a new name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveProjectAs_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.saveProjectDialog.ShowDialog())
            {
                //The directories of open and save dialogs are updated
                this.openProjectDialog.InitialDirectory = Path.GetDirectoryName(this.saveProjectDialog.FileName);
                this.saveProjectDialog.InitialDirectory = Path.GetDirectoryName(this.saveProjectDialog.FileName);
                this.projectManager.SaveProjectAs(this.saveProjectDialog.FileName);
                this.Text = " mOway World - " + this.projectManager.ProjectName;
            }
        }

        /// <summary>
        /// Close the open project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseProject_Click(object sender, EventArgs e)
        {
            this.CloseProject();
        }

        /// <summary>
        /// Download a file .hex to mOway
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgramHex_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.openHexFileDialog.ShowDialog())
            {
                // The initial directory of the open .hex dialog is updated
                this.openHexFileDialog.InitialDirectory = Path.GetDirectoryName(this.openHexFileDialog.FileName);
                ProgramProcessForm programProcessForm = new ProgramProcessForm(this.openHexFileDialog.FileName);
                // The recording form is opened, which will take care of the process
                programProcessForm.ShowDialog();
                this.openHexFileDialog.FileName = Path.GetFileName(this.openHexFileDialog.FileName);
            }
        }

        /// <summary>
        /// Print the current project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = this.projectManager.GetPrintDocument();
            this.printDialog.Document = printDoc;
            if (DialogResult.OK == this.printDialog.ShowDialog())
                ((iPrintDocument)printDoc).Print(this.printDialog.PrinterSettings.PrintRange);
        }

        /// <summary>
        /// The application is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Edit Menu Event

        /// <summary>
        /// Run a undo in the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiUndo_Click(object sender, EventArgs e)
        {
            if (this.projectManager != null)
                this.projectManager.Undo();
        }

        /// <summary>
        /// Run a redo in the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiRedo_Click(object sender, EventArgs e)
        {
            if (this.projectManager != null)
                this.projectManager.Redo();
        }

        /// <summary>
        /// Run a cut in the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiCut_Click(object sender, EventArgs e)
        {
            if (this.projectManager != null)
                this.projectManager.Cut();
        }

        /// <summary>
        /// Run a copy in the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiCopy_Click(object sender, EventArgs e)
        {
            if (this.projectManager != null)
                this.projectManager.Copy();
        }

        /// <summary>
        /// Run a paste in the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiPaste_Click(object sender, EventArgs e)
        {
            if (this.projectManager != null)
                this.projectManager.Paste();
        }

        /// <summary>
        /// Run a remove in the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiRemove_Click(object sender, EventArgs e)
        {
            if (this.projectManager != null)
                this.projectManager.Delete();
        }

        /// <summary>
        /// Run a select all in the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiSelectAll_Click(object sender, EventArgs e)
        {
            if (this.projectManager != null)
                this.projectManager.SelectAll();
        }

        #endregion

        #region View Menu Events

        /// <summary>
        /// Open or close the video capture panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiMowayCam_Click(object sender, EventArgs e)
        {
            if (!this.miMowayCam.Checked)
                this.OpenCameraPanel();
            else
                //Closes the panel of the Capture
                this.CloseCameraPanel();
        }

        /// <summary>
        /// Opens or closes the communications panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiCommunications_Click(object sender, EventArgs e)
        {
            if (!this.miCommunications.Checked)
                //Opens the Communications panel
                this.OpenCommunicationPanel();
            else
                //Closes the Communications panel
                this.CloseCommunicationPanel();
        }

        /// <summary>
        /// Opens or closes the server panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiMowayServer_Click(object sender, EventArgs e)
        {
            if (!this.miMowayServer.Checked)
            {
                this.OpenServerPanel();
            }
            else
                //Closes the panel of server
                this.CloseServerPanel();
        }

        #endregion

        #region RCControl Menu Event

        /// <summary>
        /// Open Radiocontrol Module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiOpenRc_Click(object sender, EventArgs e)
        {
            //Opens the Radiocontrol module
            this.OpenRcControl();
        }

        /// <summary>
        /// Close Radiocontrol Module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #endregion

        #region Help Menu Events

        /// <summary>
        /// Opens the Help in the search option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiSearch_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(null, this.helpProvider.HelpNamespace, HelpNavigator.Find, "");
        }

        /// <summary>
        /// Opens the Help in the content option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiContent_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(null, this.helpProvider.HelpNamespace);
        }

        /// <summary>
        /// Open the About window...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Check for any updates available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiCheckUpdates_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\pack_updater_v3.exe"))
            {
                try
                {
                    System.Diagnostics.Process.Start(Application.StartupPath + "\\pack_updater_v3.exe");
                }
                catch
                {
                    if (DialogResult.OK == MowayMessageBox.Show(MainMessages.UPDATER_ERROR, MainMessages.UPDATER, MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                        System.Diagnostics.Process.Start("http://www.moway-robot.com");
                }
            }
            else
                if (DialogResult.OK == MowayMessageBox.Show(MainMessages.UPDATER_ERROR, MainMessages.UPDATER, MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                    System.Diagnostics.Process.Start("http://www.moway-robot.com");
        }

        #endregion

        #region Language selection Options

        /// <summary>
        /// English language selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiEnglish_Click(object sender, EventArgs e)
        {
            if (MowayWorld.Default.Language != "en-GB")
            {
                MowayWorld.Default.Language = "en-GB";
                MowayWorld.Default.Save();

                if (DialogResult.Yes == MowayMessageBox.Show(MainMessages.CHANGE_LANGUAGE, MainMessages.CHANGE_LANGUAGE_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    this.Close();
            }
        }

        /// <summary>
        /// Spanish language selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiCastellano_Click(object sender, EventArgs e)
        {
            if (MowayWorld.Default.Language != "es-ES")
            {
                MowayWorld.Default.Language = "es-ES";
                MowayWorld.Default.Save();

                if (DialogResult.Yes == MowayMessageBox.Show(MainMessages.CHANGE_LANGUAGE, MainMessages.CHANGE_LANGUAGE_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    this.Close();
            }
        }

        /// <summary>
        /// Dutch language selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiNederlands_Click(object sender, EventArgs e)
        {
            if (MowayWorld.Default.Language != "nl-NL")
            {
                MowayWorld.Default.Language = "nl-NL";
                MowayWorld.Default.Save();

                if (DialogResult.Yes == MowayMessageBox.Show(MainMessages.CHANGE_LANGUAGE, MainMessages.CHANGE_LANGUAGE_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    this.Close();
            }
        }

        /// <summary>
        /// Selection of the Russian language
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiRussian_Click(object sender, EventArgs e)
        {
            if (MowayWorld.Default.Language != "ru-RU")
            {
                MowayWorld.Default.Language = "ru-RU";
                MowayWorld.Default.Save();

                if (DialogResult.Yes == MowayMessageBox.Show(MainMessages.CHANGE_LANGUAGE, MainMessages.CHANGE_LANGUAGE_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    this.Close();
            }
        }

        /// <summary>
        /// Chinese language selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiChinese_Click(object sender, EventArgs e)
        {
            if (MowayWorld.Default.Language != "zh-CN")
            {
                MowayWorld.Default.Language = "zh-CN";
                MowayWorld.Default.Save();

                if (DialogResult.Yes == MowayMessageBox.Show(MainMessages.CHANGE_LANGUAGE, MainMessages.CHANGE_LANGUAGE_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    this.Close();
            }
        }

        #endregion

        #region Events of the toolbar buttons

        /// <summary>
        /// Create New Project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbbNew_Click(object sender, EventArgs e)
        {
            this.NewProject();
        }

        /// <summary>
        /// Open a project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbbOpen_Click(object sender, EventArgs e)
        {
            this.OpenProject();
        }

        /// <summary>
        /// Save a project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbbSave_Click(object sender, EventArgs e)
        {
            this.SaveProject();
        }

        /// <summary>
        /// Cut option in the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbbCut_Click(object sender, EventArgs e)
        {
            if (this.projectManager != null)
                this.projectManager.Cut();
        }

        /// <summary>
        /// Copy option in the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbbCopy_Click(object sender, EventArgs e)
        {
            if (this.projectManager != null)
                this.projectManager.Copy();
        }

        /// <summary>
        /// Paste option in the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbbPaste_Click(object sender, EventArgs e)
        {
            if (this.projectManager != null)
                this.projectManager.Paste();
        }

        /// <summary>
        /// Undo option in the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbbUndo_Click(object sender, EventArgs e)
        {
            if (this.projectManager != null)
                this.projectManager.Undo();
        }

        /// <summary>
        /// Redo option in the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbbRedo_Click(object sender, EventArgs e)
        {
            if (this.projectManager != null)
                this.projectManager.Redo();
        }


        /// <summary>
        /// Open or close the camera module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void TbbCamera_SelectedChanged(object sender, EventArgs e)
        {
            if (!this.tbbCamera.Selected)
                this.OpenCameraPanel();
            else
                this.CloseCameraPanel();
        }


        /// <summary>
        /// Open or close the communication panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbbCommunications_SelectedChanged(object sender, EventArgs e)
        {
            if (!this.tbbCommunications.Selected)
                this.OpenCommunicationPanel();
            else
                this.CloseCommunicationPanel();
        }

        #endregion

        #region Moway Controller Events

        /// <summary>
        /// mOway disconnected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MController_MowayDisconnected(object sender, EventArgs e)
        {
            //The status is updated
            this.pbMowayState.Image = this.mowayState.Images[0];
            this.lMowayState.Text = MainMessages.DISCONNECTED;
            this.toolTip.SetToolTip(this.lMowayState, "");
            this.pbBatteryState.Image = this.batterySate.Images[0];
            this.lBatteryState.Text = "-";
        }

        /// <summary>
        /// mOway connected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MController_MowayConnected(object sender, ControllerEventArgs e)
        {
            //The status is updated including the firmware and the Battery Level
            this.pbMowayState.Image = this.mowayState.Images[1];
            this.lMowayState.Text = MainMessages.CONNECTED;
            this.toolTip.SetToolTip(this.lMowayState, "Firmware: " + e.Firmware);

            this.lBatteryState.Text = e.Battery + "%";
            if (e.Battery == 0)
                this.pbBatteryState.Image = this.batterySate.Images[1];
            else
                this.pbBatteryState.Image = this.batterySate.Images[e.Battery / 20 + 2];
        }

        /// <summary>
        /// Change in the value of the battery
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MController_BatteryChanged(object sender, BatteryEventArgs e)
        {
            //The new value is updated
            this.lBatteryState.Text = e.Battery + "%";
            if (e.Battery == 0)
                this.pbBatteryState.Image = this.batterySate.Images[1];
            else
                this.pbBatteryState.Image = this.batterySate.Images[e.Battery / 20 + 2];
        }

        #endregion

        #region Software Update

        /// <summary>
        /// Check the existence of pack updates
        /// </summary>
        private void Check_actual()
        {
            string strPackVerUrl = "https://www.minirobots.es/images/stories/mail/packver3.txt";
            string strPackVer = "";

            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create(strPackVerUrl);
                System.Net.WebResponse result = req.GetResponse();
                StreamReader sr = new StreamReader(result.GetResponseStream());
                strPackVer = sr.ReadLine();
            }
            catch { }

            if (strPackVer != "")
            {
                RegistryKey regkey = Registry.LocalMachine;

                // Checks the currently installed version in the registry.
                regkey = regkey.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\mOwayWorldPack");
                try
                {
                    string[] valnames = regkey.GetValueNames();
                    int i = 0;
                    foreach (string s in valnames)
                    {
                        if (valnames[i] == "DisplayVersion")
                        {
                            string val = (string)regkey.GetValue(valnames[i]);
                            if (val != strPackVer)

							// Only update if there is a later version
                            if ((strPackVer[0] > val[0]) ||
                                (strPackVer[0] == val[0] && strPackVer[2] > val[2]) ||
                                (strPackVer[0] == val[0] && strPackVer[2] == val[2] && strPackVer[4] > val[4]))
                                if (File.Exists(Application.StartupPath + "\\pack_updater_v3.exe"))
                                    try
                                    {
                                        System.Diagnostics.Process.Start(Application.StartupPath + "\\pack_updater_v3.exe");
                                    }
                                    catch
                                    {
                                        if (DialogResult.OK == MowayMessageBox.Show(MainMessages.UPDATER_ERROR, MainMessages.UPDATER, MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                                            System.Diagnostics.Process.Start("http://www.moway-robot.com");
                                    }
                                else
                                    if (DialogResult.OK == MowayMessageBox.Show(MainMessages.UPDATER_ERROR, MainMessages.UPDATER, MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                                        System.Diagnostics.Process.Start("http://www.moway-robot.com");
                        }
                        i++;
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        #endregion

        #region Events received from the ProjectManager

        /// <summary>
        /// Enabling operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProjectManager_OperationEnabled(object sender, OperationEventArgs e)
        {
            switch (e.Operation)
            {
                case Operation.Copy:
                    this.miCopy.Enabled = true;
                    this.tbbCopy.Enabled = true;
                    break;
                case Operation.Cut:
                    this.miCut.Enabled = true;
                    this.tbbCut.Enabled = true;
                    break;
                case Operation.Paste:
                    this.miPaste.Enabled = true;
                    this.tbbPaste.Enabled = true;
                    break;
                case Operation.Delete:
                    this.miRemove.Enabled = true;
                    break;
                case Operation.Undo:
                    this.tbbUndo.Enabled = true;
                    this.miUndo.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// Disabling Operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProjectManager_OperationDisabled(object sender, OperationEventArgs e)
        {
            switch (e.Operation)
            {
                case Operation.Copy:
                    this.miCopy.Enabled = false;
                    this.tbbCopy.Enabled = false;
                    break;
                case Operation.Cut:
                    this.miCut.Enabled = false;
                    this.tbbCut.Enabled = false;
                    break;
                case Operation.Paste:
                    this.miPaste.Enabled = false;
                    this.tbbPaste.Enabled = false;
                    break;
                case Operation.Delete:
                    this.miRemove.Enabled = false;
                    break;
                case Operation.Undo:
                    this.tbbUndo.Enabled = false;
                    this.miUndo.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// A new Box is shown in the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProjectManager_BoxShown(object sender, BoxEventArgs e)
        {
            this.Controls.Add(e.Box);
        }

        /// <summary>
        /// A Box of the form is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProjectManager_BoxClosed(object sender, BoxEventArgs e)
        {
            this.Controls.Remove(e.Box);
        }

        /// <summary>
        /// A panel is loaded into the Box of panels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProjectManager_OpenPanel(object sender, SharePanelEventArgs e)
        {
            //If it is the simulation panel, the rest of the panels must be closed
            if (e.Panel is SimulatorPanel)
            {
                //The communication panel is closed if it is open
                if (this.miCommunications.Checked)
                    this.CloseCommunicationPanel();
                this.miCommunications.Enabled = false;
                this.tbbCommunications.Enabled = false;
                //The Capturer panel is closed if it is open
                if (this.miMowayCam.Checked)
                    this.CloseCameraPanel();
                this.miMowayCam.Enabled = false;
                this.tbbCamera.Enabled = false;
                //The server panel is closed if it is open
                if (this.miMowayServer.Checked)
                    this.CloseServerPanel();
                this.miMowayServer.Enabled = false;
               
            }
            //The panel is added
            this.verticalBox.AddPanel(e.Panel);
            if (this.projectManager != null)
                this.projectManager.UpdateClientArea(new Rectangle(0, this.toolBar.Bottom, this.ClientSize.Width - this.verticalBox.Width + 1, this.statusStrip.Top - this.toolBar.Bottom - 1));
        }

        /// <summary>
        /// A panel box of panels is removed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProjectManager_ClosePanel(object sender, SharePanelEventArgs e)
        {
            //If it is the simulation panel, the rest of the panels are enabled
            if (e.Panel is SimulatorPanel)
            {
                this.miCommunications.Enabled = true;
                this.tbbCommunications.Enabled = true;
                this.miMowayCam.Enabled = true;
                this.tbbCamera.Enabled = true;
                this.miMowayServer.Enabled = true;
                this.miMowayScratch.Enabled = true;
                this.tbbMowayScratch.Enabled = true;
            }
            this.verticalBox.RemovePanel(e.Panel);
            if (!this.verticalBox.Visible)
                this.projectManager.UpdateClientArea(new Rectangle(0, this.toolBar.Bottom, this.ClientSize.Width, this.statusStrip.Top - this.toolBar.Bottom - 1));
        }

        /// <summary>
        /// Change of Simulator status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProjectManager_SimulatorStateChanged(object sender, SimStateEventArgs e)
        {
            //An invocation is launched to avoid problems with the threads
            if (this.tbbOpen.InvokeRequired)
                this.Invoke(new SimStateEventHandler(this.ProjectManager_SimulatorStateChanged), new object[] { sender, e });
            else
            {
                if (e.State == SimState.Running)
                {
                    this.miNewProject.Enabled = false;
                    this.tbbNew.Enabled = false;
                    this.miOpenProject.Enabled = false;
                    this.tbbOpen.Enabled = false;
                    this.miCloseProject.Enabled = false;
                    this.miPrint.Enabled = false;
                    this.miProgramHex.Enabled = false;
                    this.miUndo.Enabled = false;
                    this.tbbUndo.Enabled = false;
                    this.miCopy.Enabled = false;
                    this.tbbCopy.Enabled = false;
                    this.miCut.Enabled = false;
                    this.tbbCut.Enabled = false;
                    this.miPaste.Enabled = false;
                    this.tbbPaste.Enabled = false;
                    this.miRemove.Enabled = false;
                    this.miSelectAll.Enabled = false;
                    this.miOpenRc.Enabled = false;
                    this.tbbRc.Enabled = false;
                    this.miCheckUpdates.Enabled = false;
                }
                else
                {
                    this.miNewProject.Enabled = true;
                    this.tbbNew.Enabled = true;
                    this.miOpenProject.Enabled = true;
                    this.tbbOpen.Enabled = true;
                    this.miCloseProject.Enabled = true;
                    this.miPrint.Enabled = true;
                    this.miProgramHex.Enabled = true;
                    this.miUndo.Enabled = this.projectManager.UndoEnabled;
                    this.tbbUndo.Enabled = this.projectManager.UndoEnabled;
                    this.miCopy.Enabled = this.projectManager.CopyEnabled;
                    this.tbbCopy.Enabled = this.projectManager.CopyEnabled;
                    this.miCut.Enabled = this.projectManager.CutEnabled;
                    this.tbbCut.Enabled = this.projectManager.CutEnabled;
                    this.miPaste.Enabled = this.projectManager.PasteEnabled;
                    this.tbbPaste.Enabled = this.projectManager.PasteEnabled;
                    this.miRemove.Enabled = this.projectManager.RemoveEnabled;
                    this.miSelectAll.Enabled = true;
                    this.miOpenRc.Enabled = true;
                    this.tbbRc.Enabled = true;
                    this.miCheckUpdates.Enabled = true;
                }
                if (e.State != SimState.Inactive)
                {
                    this.miCommunications.Enabled = false;
                    this.tbbCommunications.Enabled = false;
                    this.miMowayCam.Enabled = false;
                    this.tbbCamera.Enabled = false;
                    this.miMowayServer.Enabled = false;
                    this.miMowayScratch.Enabled = false;
					this.tbbMowayScratch.Enabled = false;
                }
                else
                {
                    this.miCommunications.Enabled = true;
                    this.tbbCommunications.Enabled = true;
                    this.miMowayCam.Enabled = true;
                    this.tbbCamera.Enabled = true;
                    this.miMowayServer.Enabled = true;
                    this.miMowayScratch.Enabled = true;
					this.tbbMowayScratch.Enabled = true;
                }
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Load a project manager
        /// </summary>
        /// <param name="projectManager">Project Manager</param>
        private void LoadProjectManager(ProjectManager projectManager)
        {
            //If the managers are different..
            if (this.projectManager != projectManager)
            {
                //And the manager is different from null
                if (this.projectManager != null)
                    //The current manager is downloaded
                    this.DownloadProjectManager();
                //The new manager is loaded
                this.projectManager = projectManager;
                //this.projectManager.OperationEnabled += new OperationEventHandler(ProjectManager_OperationEnabled);
               // this.projectManager.OperationDisabled += new OperationEventHandler(ProjectManager_OperationDisabled);
                //this.projectManager.PanelShown += new SharePanelEventHandler(ProjectManager_OpenPanel);
               // this.projectManager.PanelClosed += new SharePanelEventHandler(ProjectManager_ClosePanel);
                //this.projectManager.BoxShown += new BoxEventHandler(ProjectManager_BoxShown);
              //  this.projectManager.BoxClosed += new BoxEventHandler(ProjectManager_BoxClosed);
                //this.projectManager.SimulatorStateChanged += new SimStateEventHandler(ProjectManager_SimulatorStateChanged);
                for (int i = 0; i < this.projectManager.MowayMenuItems.Count; i++)
                    this.miMowayWorld.DropDownItems.Insert(i + 9, this.projectManager.MowayMenuItems[i]);
                for (int i = 0; i < this.projectManager.ViewMenuItems.Count; i++)
                    this.miView.DropDownItems.Insert(i + 3, this.projectManager.ViewMenuItems[i]);
                for (int i = 0; i < this.projectManager.MenuItems.Count; i++)
                    this.MainMenuStrip.Items.Insert(i + 3, this.projectManager.MenuItems[i]);
                this.toolBar.AddItems(this.projectManager.ToolBarItems);
                foreach (Control control in this.projectManager.Boxes)
                    this.Controls.Add(control);
                foreach (SharePanel panel in this.projectManager.Panels)
                    this.verticalBox.AddPanel(panel);
                if (this.verticalBox.IsEmpty())
                    this.projectManager.UpdateClientArea(new Rectangle(0, this.toolBar.Bottom, this.ClientSize.Width, this.statusStrip.Top - this.toolBar.Bottom));
                else
                    this.projectManager.UpdateClientArea(new Rectangle(0, this.toolBar.Bottom, this.ClientSize.Width - this.verticalBox.Width + 1, this.statusStrip.Top - this.toolBar.Bottom));
                this.miCloseProject.Enabled = true;
            }
        }

        /// <summary>
        ///Download the current project manager
        /// </summary>
        private void DownloadProjectManager()
        {
           // this.projectManager.OperationEnabled -= this.ProjectManager_OperationEnabled;
            //this.projectManager.OperationDisabled -= this.ProjectManager_OperationDisabled;
            //this.projectManager.PanelShown -= this.ProjectManager_OpenPanel;
            //this.projectManager.PanelClosed -= this.ProjectManager_ClosePanel;
           // this.projectManager.BoxShown -= this.ProjectManager_BoxShown;
           // this.projectManager.BoxClosed -= this.ProjectManager_BoxClosed;
            //this.projectManager.SimulatorStateChanged -= this.ProjectManager_SimulatorStateChanged;

            foreach (ToolStripItem item in this.projectManager.MowayMenuItems)
                this.miMowayWorld.DropDownItems.Remove(item);
            foreach (ToolStripItem item in this.projectManager.ViewMenuItems)
                this.miView.DropDownItems.Remove(item);
            foreach (ToolStripItem item in this.projectManager.MenuItems)
                this.MainMenuStrip.Items.Remove(item);
            this.toolBar.RemoveItems(this.projectManager.ToolBarItems);
            foreach (Control control in this.projectManager.Boxes)
                this.Controls.Remove(control);
            foreach (SharePanel panel in this.projectManager.Panels)
                this.verticalBox.RemovePanel(panel);
            this.projectManager = null;
            this.miCloseProject.Enabled = false;
        }

        /// <summary>
        /// Create a new project
        /// </summary>
        private void NewProject()
        {
            //The form is displayed and if the project is created...
            NewProjectForm newProjectForm = new NewProjectForm();
            if (DialogResult.OK == newProjectForm.ShowDialog())
            {
            
                //If there is a project currently open, it is consulted if it is to be saved and closed
                if (this.projectManager != null)
                {
                    if (this.projectManager.ProjectChanged)
                        switch (MowayMessageBox.Show(MainMessages.PROJECT_NOT_SAVE + "\r\n" + MainMessages.SAVE_CHANGES, MainMessages.SAVE_PROJECT, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                        {
                            case DialogResult.Yes:
                                if (!this.SaveProject())
                                    return;
                                break;
                            //Pressing cancel does not create the new project
                            case DialogResult.Cancel:
                                return;
                        }
                    try
                    {
                        //The project is closed
                        this.projectManager.CloseProject();
                    }
                    catch (SimulatorException)
                    {
                        MowayMessageBox.Show("Simulator is already running.\r\nCan't close the present project", "New Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                //The new project manager is loaded
                this.LoadProjectManager(ProjectManager.GetManager(newProjectForm.ProjectType));
                //The new project is created
                this.projectManager.NewProject(newProjectForm.ProjectName, newProjectForm.ProjectPath);
                this.Text = " mOway World - " + this.projectManager.ProjectName;
                this.miSaveProject.Enabled = true;
                this.tbbSave.Enabled = true;
                this.miSaveProjectAs.Enabled = true;
                this.miCloseProject.Enabled = true;
            }
        }

        /// <summary>
        /// Open a project
        /// </summary>
        private void OpenProject()
        {
            //The project opening dialog is shown
            if (DialogResult.OK == this.openProjectDialog.ShowDialog())
            {
                //The directories of open and save dialogs are updated
                this.openProjectDialog.InitialDirectory = Path.GetDirectoryName(this.openProjectDialog.FileName);
                this.saveProjectDialog.InitialDirectory = Path.GetDirectoryName(this.openProjectDialog.FileName);

                //If there is a project currently open, it is consulted if it is to be saved and closed
                if (this.projectManager != null)
                {
                    if (this.projectManager.ProjectChanged)
                        switch (MowayMessageBox.Show(MainMessages.PROJECT_NOT_SAVE + "\r\n" + MainMessages.SAVE_CHANGES, MainMessages.SAVE_PROJECT, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                        {
                            case DialogResult.Yes:
                                if (!this.SaveProject())
                                    return;
                                break;
                            //Pressing cancel does not create the new project
                            case DialogResult.Cancel:
                                return;
                        }
                    try
                    {
                        //Close the project
                        this.projectManager.CloseProject();
                    }
                    catch (SimulatorException)
                    {
                        MowayMessageBox.Show("Simulator is already running.\r\nCan't close the present project", "Open Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                //The project is opened with the given route
                this.OpenProject(this.openProjectDialog.FileName);
            }
        }

        /// <summary>
        /// The project opens with the given path
        /// </summary>
        /// <param name="projectFile">Fichero de proyecto</param>
        private void OpenProject(string projectFile)
        {
            //The appropriate project manager is loaded
            this.LoadProjectManager(ProjectManager.GetManager(ProjectType.Graphical));
            try
            {
                //Opens the project
                this.projectManager.OpenProject(projectFile);
                this.Text = " mOway World - " + this.projectManager.ProjectName;
                //Delete the selected file (is better because it is rare to open the same project)
                this.openProjectDialog.FileName = "";
                this.miSaveProject.Enabled = true;
                this.tbbSave.Enabled = true;
                this.miSaveProjectAs.Enabled = true;
                this.miCloseProject.Enabled = true;
            }
            catch (ProjectException projectException)
            {
                //The project manager is downloaded
                this.DownloadProjectManager();
                //The error message is displayed
                switch (projectException.Message)
                {
                    case "Project files don't exists":
                        MowayMessageBox.Show(MainMessages.OPEN_PROJECT_DIRECTORY_ERROR, MainMessages.OPEN_PROJECT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MowayMessageBox.Show(MainMessages.OPEN_PROJECT_ERROR, MainMessages.OPEN_PROJECT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }

        /// <summary>
        /// Save a project
        /// </summary>
        /// <returns></returns>
        private bool SaveProject()
        {
            try
            {
                //The project is saved
                this.projectManager.SaveProject();
                this.Text = " mOway World - " + this.projectManager.ProjectName;
                return true;
            }
            catch //If exception occurs it is because it has never been saved before
            {
                //The dialog to save the project is shown
                if (DialogResult.OK == this.saveProjectDialog.ShowDialog())
                {
                    //The directories of open and save dialogs are updated
                    this.openProjectDialog.InitialDirectory = Path.GetDirectoryName(this.saveProjectDialog.FileName);
                    this.saveProjectDialog.InitialDirectory = Path.GetDirectoryName(this.saveProjectDialog.FileName);
                    //The project is saved
                    this.projectManager.SaveProjectAs(this.saveProjectDialog.FileName);
                    this.Text = " mOway World - " + this.projectManager.ProjectName;
                    return true;
                }
                else
                    return false;
            }
        }

        /// <summary>
        /// Close a project
        /// </summary>
        /// <returns></returns>
        private bool CloseProject()
        {
            //If the current project has not been saved, it is queried whether it should be saved
            if (this.projectManager.ProjectChanged)
                switch (MowayMessageBox.Show(MainMessages.PROJECT_NOT_SAVE + "\r\n" + MainMessages.SAVE_CHANGES, MainMessages.SAVE_PROJECT, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case DialogResult.Yes:
                        if (!this.SaveProject())
                            return false;
                        break;
                    //If you press Cancel does not close the project
                    case DialogResult.Cancel:
                        return false;
                }
            try
            {
                //The project is closed
                this.projectManager.CloseProject();
            }
            catch (SimulatorException)
            {
                MowayMessageBox.Show("Simulator is already running.\r\nCan't close the present project", "Close Project", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //The project manager is downloaded
            this.DownloadProjectManager();
            this.miSaveProject.Enabled = false;
            this.tbbSave.Enabled = false;
            this.miSaveProjectAs.Enabled = false;
            this.miCloseProject.Enabled = false;
            return true;
        }

        /// <summary>
        /// Displays the communications panel
        /// </summary>
        private void OpenCommunicationPanel()
        {
            //The communications panel is loaded
            this.miCommunications.Checked = true;
            this.tbbCommunications.Selected = true;
            this.miMowayServer.Enabled = false;
            this.miMowayScratch.Enabled = false;
			this.tbbMowayScratch.Enabled = false;
            this.verticalBox.AddPanel(this.communicationPanel);
            if (this.projectManager != null)
                this.projectManager.UpdateClientArea(new Rectangle(0, this.toolBar.Bottom, this.ClientSize.Width - this.verticalBox.Width + 1, this.statusStrip.Top - this.toolBar.Bottom - 1));
        }

        /// <summary>
        /// Hides communications panel
        /// </summary>
        private void CloseCommunicationPanel()
        {
            //If it closes properly
            if (this.communicationPanel.CloseBox())
            {
                this.miCommunications.Checked = false;
                this.tbbCommunications.Selected = false;
                this.miMowayScratch.Enabled = true;
				this.tbbMowayScratch.Enabled = true;
                this.miMowayServer.Enabled = true;
                
                this.verticalBox.RemovePanel(this.communicationPanel);
                if ((this.projectManager != null) && (!this.verticalBox.Visible))
                    this.projectManager.UpdateClientArea(new Rectangle(0, this.toolBar.Bottom, this.ClientSize.Width, this.statusStrip.Top - this.toolBar.Bottom - 1));
            }
        }

        /// <summary>
        /// Shows the camera pane
        /// </summary>
        private void OpenCameraPanel()
        {
            //Shows the camera panel
            this.miMowayCam.Checked = true;
            this.tbbCamera.Selected = true;
            this.verticalBox.AddPanel(this.cameraPanel);
            //Server panel is disabled
            if (this.projectManager != null)
                this.projectManager.UpdateClientArea(new Rectangle(0, this.toolBar.Bottom, this.ClientSize.Width - this.verticalBox.Width + 1, this.statusStrip.Top - this.toolBar.Bottom - 1));

        }

        /// <summary>
        /// Hides communications panel
        /// </summary>
        private void CloseCameraPanel()
        {
            //If it closes properly
            if (this.cameraPanel.CloseBox())
            {
                this.miMowayCam.Checked = false;
                this.tbbCamera.Selected = false;                
                this.verticalBox.RemovePanel(this.cameraPanel);
                if (this.projectManager != null)
                {
                    if (!this.verticalBox.Visible)
                        this.projectManager.UpdateClientArea(new Rectangle(0, this.toolBar.Bottom, this.ClientSize.Width, this.statusStrip.Top - this.toolBar.Bottom - 1));
                }

            }
        }

        /// <summary>
        /// Displays the server panel
        /// </summary>
        private void OpenServerPanel()
        {
            //The Server panel opens
            this.miMowayServer.Checked = true;
            this.verticalBox.AddPanel(this.serverPanel);
            //Other panels are disabled
            this.miCommunications.Enabled = false;
            this.tbbCommunications.Enabled = false;
            this.miMowayScratch.Enabled = false;  
			this.tbbMowayScratch.Enabled = false;			
            if (this.projectManager != null)
                this.projectManager.UpdateClientArea(new Rectangle(0, this.toolBar.Bottom, this.ClientSize.Width - this.verticalBox.Width + 1, this.statusStrip.Top - this.toolBar.Bottom - 1));
          
        }
        /// <summary>
        /// Hides the server panel
        /// </summary>
        private void CloseServerPanel()
        {
            //If it closes properly
            if (this.serverPanel.CloseBox())
            {
                this.miMowayServer.Checked = false;
                this.miCommunications.Enabled = true;
                this.tbbCommunications.Enabled = true;
                this.miMowayScratch.Enabled = true;
				this.tbbMowayScratch.Enabled = true;
                this.verticalBox.RemovePanel(this.serverPanel);
                if (this.projectManager != null)
                    if (!this.verticalBox.Visible)
                        this.projectManager.UpdateClientArea(new Rectangle(0, this.toolBar.Bottom, this.ClientSize.Width, this.statusStrip.Top - this.toolBar.Bottom - 1));
            }
        }


        /// <summary>
        /// Opens the Radio frequency module
        /// </summary>
        private void OpenRcControl()
        {
            //If the current project has not been saved, it is queried whether it should be saved
            if (this.projectManager != null)
                if (DialogResult.Yes == MowayMessageBox.Show(MainMessages.RC_WARNING_CLOSE + "\r\n" + MainMessages.CONTINUE, MainMessages.RC_CONTROL, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    //The project is closed and pressing cancel does not open the radio frequency module
                    if (!this.CloseProject())
                        return;
                }
                else
                {
                    //The toolbar button is deselected
                    this.tbbRc.Selected = false;
                    return;
                }
            //The communication panel is closed if it is open
            if (this.miCommunications.Checked)
            {
                if (!this.communicationPanel.CloseBox())
                    return;
                this.miCommunications.Checked = false;
                this.tbbCommunications.Selected = false;
                this.verticalBox.RemovePanel(this.communicationPanel);
            }
            //The server panel is closed if it is open
            if (this.miMowayServer.Checked)
            {
                if (!this.serverPanel.CloseBox())
                    return;
                this.miMowayServer.Checked = false;
                this.verticalBox.RemovePanel(this.serverPanel);
            }
        
            this.miOpenRc.Enabled = false;
            this.miCloseRc.Enabled = true;
            this.tbbRc.Selected = true;

            //Buttons that cannot be used are disabled
            this.miSaveProject.Enabled = false;
            this.tbbSave.Enabled = false;
            this.miSaveProjectAs.Enabled = false;
            this.miProgramHex.Enabled = false;
            this.miCommunications.Enabled = false;
            this.tbbCommunications.Enabled = false;
            this.miMowayServer.Enabled = false;
            this.miMowayScratch.Enabled = false;
            this.tbbMowayScratch.Enabled = false;
        }



        #endregion

      



    }

    /// <summary>
    /// Defines the colors of the items of the main menu of the application
    /// </summary>
    class CustomProfessionalColors : ProfessionalColorTable
    {
        /// <summary>
        /// Edge of the full menu
        /// </summary>
        public override Color MenuBorder { get { return Color.FromArgb(128, 128, 128); } }
        /// <summary>
        /// Edge of the item
        /// </summary>
        public override Color MenuItemBorder { get { return Color.FromArgb(128, 128, 128); } }
        /// <summary>
        /// Background of the selected first-level item
        /// </summary>
        public override Color MenuItemSelectedGradientBegin { get { return Color.FromArgb(250, 250, 250); } }
        public override Color MenuItemSelectedGradientEnd { get { return Color.FromArgb(250, 250, 250); } }
        /// <summary>
        /// Background of the first-level item selected/pressed
        /// </summary>
        public override Color MenuItemPressedGradientBegin { get { return Color.FromArgb(250, 250, 250); } }
        public override Color MenuItemPressedGradientMiddle { get { return Color.FromArgb(250, 250, 250); } }
        public override Color MenuItemPressedGradientEnd { get { return Color.FromArgb(250, 250, 250); } }
        /// <summary>
        /// Second Level item background
        /// </summary>
        public override Color MenuItemSelected { get { return Color.FromArgb(234, 234, 234); } }
        /// <summary>
        /// Separator Color
        /// </summary>
        public override Color SeparatorLight { get { return Color.FromArgb(128, 128, 128); } }
        public override Color SeparatorDark { get { return Color.FromArgb(128, 128, 128); } }
        /// <summary>
        /// Background of the menu image space
        /// </summary>
        public override Color ImageMarginGradientBegin { get { return Color.FromArgb(250, 250, 250); } }
        public override Color ImageMarginGradientEnd { get { return Color.FromArgb(250, 250, 250); } }
        public override Color ImageMarginGradientMiddle { get { return Color.FromArgb(250, 250, 250); } }
        /// <summary>
        /// Checking background of a MenuItem
        /// </summary>
        public override Color CheckBackground { get { return Color.FromArgb(234, 234, 234); } }
        public override Color CheckSelectedBackground { get { return Color.FromArgb(234, 234, 234); } }
        public override Color CheckPressedBackground { get { return Color.FromArgb(234, 234, 234); } }
    }

    public class CopyDir
    {
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it's new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                //Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}