using System;
using System.Xml;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Imaging;

using Moway.Template;
using Moway.Template.Controls;
using Moway.Project.GraphicProject;
using Moway.Simulator;

namespace Moway.Project
{
    /// <summary>
    /// Enumerating Project Types
    /// </summary>
    public enum ProjectType { Graphical, Code_C, Code_Asm }
    /// <summary>
    /// Enumerating languages for a project
    /// </summary>
    public enum Language { Assembler, C }

    /// <summary>
    /// Abstract class of a project manager
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public abstract class ProjectManager
    {
        #region Attributes

        /// <summary>
        /// Indicates if the project has changed and requires it to be saved
        /// </summary>
        protected bool projectChanged = false;
        /// <summary>
        /// List of items for the MoWay menu of the main form
        /// </summary>
        protected List<ToolStripItem> mowayMenuItems = new List<ToolStripItem>();
        /// <summary>
        /// List of items for the View menu of the main form
        /// </summary>
        protected List<ToolStripItem> viewMenuItems = new List<ToolStripItem>();
        /// <summary>
        /// List of items for the general menu of the main form
        /// </summary>
        protected List<ToolStripItem> menuItems = new List<ToolStripItem>();
        /// <summary>
        /// List of buttons for the main form toolbar
        /// </summary>
        protected List<IToolBarItem> toolBarItems = new List<IToolBarItem>();

        #endregion

        #region Properties

        /// <summary>
        /// Project Name
        /// </summary>
        public virtual string ProjectName { get { throw new ProjectException("This property is unaccesible"); } }
        /// <summary>
        /// Path of the project
        /// </summary>
        public virtual string ProjectPath { get { throw new ProjectException("This property is unaccesible"); } }
        /// <summary>
        /// Indicates if the project has changed and requires it to be saved
        /// </summary>
        public bool ProjectChanged { get { return this.projectChanged; } }
        /// <summary>
        /// List of items for the MoWay menu of the main form
        /// </summary>
        public List<ToolStripItem> MowayMenuItems { get { return this.mowayMenuItems; } }
        /// <summary>
        /// List of items for the View menu of the main form
        /// </summary>
        public List<ToolStripItem> ViewMenuItems { get { return this.viewMenuItems; } }
        /// <summary>
        /// List of items for the general menu of the main form
        /// </summary>
        public List<ToolStripItem> MenuItems { get { return this.menuItems; } }
        /// <summary>
        /// List of items for the general menu of the main form
        /// </summary>
        public List<IToolBarItem> ToolBarItems { get { return this.toolBarItems; } }
        /// <summary>
        /// Boxes of the project to be displayed in the main form
        /// </summary>
        public virtual List<MowayBox> Boxes { get { throw new ProjectException("This property is unaccesible"); } }
        /// <summary>
        /// Shared panels for the main form vertical panel
        /// </summary>
        public virtual List<SharePanel> Panels { get { throw new ProjectException("This property is unaccesible"); } }
        /// <summary>
        /// Undo operation status
        /// </summary>
        public virtual bool UndoEnabled { get { throw new ProjectException("This property is unaccesible"); } }
        /// <summary>
        /// Redo operation status
        /// </summary>
        public virtual bool RedoEnabled { get { throw new ProjectException("This property is unaccesible"); } }
        /// <summary>
        /// Copy operation status
        /// </summary>
        public virtual bool CopyEnabled { get { throw new ProjectException("This property is unaccesible"); } }
        /// <summary>
        /// Cut operation status
        /// </summary>
        public virtual bool CutEnabled { get { throw new ProjectException("This property is unaccesible"); } }
        /// <summary>
        /// Paste operation status
        /// </summary>
        public virtual bool PasteEnabled { get { throw new ProjectException("This property is unaccesible"); } }
        /// <summary>
        /// Remove operation status
        /// </summary>
        public virtual bool RemoveEnabled { get { throw new ProjectException("This property is unaccesible"); } }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when an operation is enabled
        /// </summary>
        public virtual event OperationEventHandler OperationEnabled { add { } remove { } }
        /// <summary>
        /// Occurs when an operation is disabled
        /// </summary>
        public virtual event OperationEventHandler OperationDisabled { add { } remove { } }
        /// <summary>
        /// Occurs when a shared panel must be displayed
        /// </summary>
        public virtual event SharePanelEventHandler PanelShown { add { } remove { } }
        /// <summary>
        /// Occurs when a shared panel must be hidden
        /// </summary>
        public virtual event SharePanelEventHandler PanelClosed { add { } remove { } }
        /// <summary>
        /// Occurs when a new project Box must be displayed
        /// </summary>
        public virtual event BoxEventHandler BoxShown { add { } remove { } }
        /// <summary>
        /// Occurs when a project Box must be hidden
        /// </summary>
        public virtual event BoxEventHandler BoxClosed { add { } remove { } }
        /// <summary>
        /// Occurs when the simulator changes state
        /// </summary>
        public virtual event SimStateEventHandler SimulatorStateChanged { add { } remove { } }

        #endregion

        #region Virtual methods to be implemented by all classes that inherit from this

        /// <summary>
        /// Create a new Empty project
        /// </summary>
        public virtual void NewProject()
        {
            throw new ProjectException("This method is unaccesible");
        }

        /// <summary>
        /// Create a new project based in a name and a route
        /// </summary>
        /// <param name="name">Project Name</param>
        /// <param name="path">Path of the project</param>
        public virtual void NewProject(string name, string path)
        {
            throw new ProjectException("This method is unaccesible");
        }

        /// <summary>
        /// Open a project
        /// </summary>
        /// <param name="projectFile">Project root File</param>
        public virtual void OpenProject(string projectFile)
        {
            throw new ProjectException("This method is unaccesible");
        }

        /// <summary>
        /// Save a project
        /// </summary>
        public virtual void SaveProject()
        {
            throw new ProjectException("This method is unaccesible");
        }

        /// <summary>
        /// Save a project with a given name
        /// </summary>
        /// <param name="fileName"></param>
        public virtual void SaveProjectAs(string fileName)
        {
            throw new ProjectException("This method is unaccesible");
        }

        /// <summary>
        /// Close the project
        /// </summary>
        public virtual void CloseProject()
        {
            throw new ProjectException("This method is unaccesible");
        }

        /// <summary>
        /// Execute the Copy action
        /// </summary>
        public virtual void Copy()
        {
            throw new ProjectException("This method is unaccesible");
        }

        /// <summary>
        /// Execute the Cut action
        /// </summary>
        public virtual void Cut()
        {
            throw new ProjectException("This method is unaccesible");
        }

        /// <summary>
        /// Execute the Paste action
        /// </summary>
        public virtual void Paste()
        {
            throw new ProjectException("This method is unaccesible");
        }

        /// <summary>
        /// Execute the Delete action
        /// </summary>
        public virtual void Delete()
        {
            throw new ProjectException("This method is unaccesible");
        }

        /// <summary>
        /// Execute the SelectAll action
        /// </summary>
        public virtual void SelectAll()
        {
            throw new ProjectException("This method is unaccesible");
        }

        /// <summary>
        /// Execute the Undo action
        /// </summary>
        public virtual void Undo()
        {
            throw new ProjectException("This method is unaccesible");
        }

        /// <summary>
        /// Execute the Redo action
        /// </summary>
        public virtual void Redo()
        {
            throw new ProjectException("This method is unaccesible");
        }

        /// <summary>
        /// Propagates the keystroke event
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="key"></param>
        public virtual void KeyPress(Keys modifier, Keys key) { }

        /// <summary>
        /// Update the customer area for the boxes
        /// </summary>
        /// <param name="area"></param>
        public virtual void UpdateClientArea(Rectangle area)
        {
            throw new ProjectException("This method is unaccesible");
        }

        /// <summary>
        /// Returns a printable document
        /// </summary>
        /// <returns></returns>
        public virtual PrintDocument GetPrintDocument()
        {
            throw new ProjectException("This method is unaccesible");
        }

        #endregion

        #region Static public methods 

        /// <summary>
        /// Returns a project manager based on the type of projects
        /// </summary>
        /// <param name="type">Kind of project</param>
        /// <returns>Project Manager</returns>
        public static ProjectManager GetManager(ProjectType type)
        {
            ProjectManager projectManager = null;
            switch (type)
            {
                case ProjectType.Graphical:
                    projectManager = GraphManager.GetManager();
                    break;
                default:
                    throw new ProjectException("Project type doesn't exist");
            }
            return projectManager;
        }

        /// <summary>
        /// Returns a project manager based on a draft file
        /// </summary>
        /// <param name="projectFile">Project File</param>
        /// <returns>Project Manager</returns>
        public static ProjectManager GetManager(string projectFile)
        {
            ProjectManager projectManager = null;

            XmlDocument document = new XmlDocument();
            document.Load(projectFile);
            XmlNodeList projectProp = document.GetElementsByTagName("mowayProject");
            if ((projectProp.Count == 1) && (projectProp[0].FirstChild.Name == "type"))
            {
                switch (projectProp[0].FirstChild.InnerText)
                {
                    case "graphic":
                        projectManager = GraphManager.GetManager();
                        break;
                    default:
                        throw new ProjectException("Error al abrir el proyecto");
                }
            }
            else
                throw new ProjectException("Error al abrir el proyecto");
            return projectManager;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a specific image encoder
        /// </summary>
        /// <param name="mimeType">Encoder Name</param>
        /// <returns>Image encoder</returns>
        public static ImageCodecInfo GetEncoder(string mimeType)
        {
            ImageCodecInfo codec = null;
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            int i = 0;
            codec = codecs[i];
            while (codec.MimeType != mimeType)
            {
                i++;
                codec = codecs[i];
            }
            return codec;
        }

        #endregion
    }
}
