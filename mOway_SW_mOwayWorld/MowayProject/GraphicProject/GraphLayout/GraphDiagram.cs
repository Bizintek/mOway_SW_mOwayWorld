using System;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using SdlDotNet.Graphics;

using Moway.Template;
using Moway.Project.GraphicProject.Actions;
using Moway.Project.GraphicProject.Actions.Start;
using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Project.GraphicProject.GraphLayout.Elements;
using Moway.Project.GraphicProject.GraphLayout.Operations;

namespace Moway.Project.GraphicProject.GraphLayout
{
    public enum OperationMode { Select, Connect }
    public enum AreaFormat { A3_Vertical, A3_Horizontal, A4_Vertical, A4_Horizontal };

    /// <summary>
    /// It is the graphical representation of a diagram, along with the execution of the operations on the same
    /// </summary>
    public class GraphDiagram
    {
        #region Constants

        public static Point START_LOCATION = new Point(311, 44);
        /// <summary>
        /// Default Color for selection
        /// </summary>
        public static Color SELECTED_COLOR = Color.FromArgb(255, 0, 0);
        /// <summary>
        /// Color for creating transparencies
        /// </summary>
        public static Color TRASPARENT_COLOR = Color.FromArgb(200, 205, 250);
        /// <summary>
        /// Color for creating arrows
        /// </summary>
        public static Color ARROWS_COLOR = Color.FromArgb(51, 72, 137);
        private Size[] AreaSizes = new Size[] { new Size(1120, 1602), new Size(1600, 1116), new Size(800, 1116), new Size(1120, 792) };

        #endregion

        #region Attributes

        /// <summary>
        /// Logical diagram to which represents the GraphDrawing
        /// </summary>
        private Diagram diagram;
        private StartGraphic graphStart;
        private AreaFormat areaFormat;
        /// <summary>
        /// Diagram of the GraphDrawing layer
        /// </summary>
        private GraphLayer diagramLayer;
        /// <summary>
        /// Top layer of the GraphDiagram
        /// </summary>
        private GraphLayer selectLayer;
        /// <summary>
        /// Top layer of the GraphDiagram
        /// </summary>
        private GraphLayer tempLayer;
        /// <summary>
        /// Top layer for simulator images
        /// </summary>
        private GraphLayer simulatorLayer;
        /// <summary>
        /// Operation that is running on the GraphDrawing
        /// </summary>
        private IOperation operation = null;
        /// <summary>
        /// Surface of background for the GraphDrawing
        /// </summary>
        private Surface bgSurface;
        /// <summary>
        /// Temporary Surface that includes the background and the diagram layer
        /// </summary>
        private Surface diagramSurface;
        /// <summary>
        /// Temporary Surface that includes the background, the diagram layer, and the selection layer
        /// </summary>
        private Surface selectSurface;
        /// <summary>
        /// Temporary Surface that includes the background, the diagram layer, the selection layer, and the simulator
        /// </summary>
        private Surface simulatorSurface;
        private int vScrollValue = 0;
        private int hScrollValue = 0;
        /// <summary>
        /// Saves the enabled or not state of operations
        /// </summary>
        private SortedList<Operation, bool> operationState = new SortedList<Operation, bool>();
        private OperationMode opMode = OperationMode.Select;
        private System.Collections.Generic.Stack<IOperation> undoStack = new Stack<IOperation>();

        #endregion

        #region Properties

        public string Name { get { return this.diagram.Name; } }
        public AreaFormat AreaFormat { get { return this.areaFormat; } }
        public Diagram Diagram { get { return this.diagram; } }
        public GraphElement StartElement { get { return this.graphStart; } }
        public int HScrollValue { get { return this.hScrollValue; } }
        public int VScrollValue { get { return this.vScrollValue; } }
        /// <summary>
        /// Surface of the GraphDrawing
        /// </summary>
        public Surface Surface
        {
            get
            {
                //The surface is created from the simulation surface of the diagram
                Surface surface = new Surface(this.simulatorSurface);
                //The temporary layer is added if it is visible
                if (this.tempLayer.Visible)
                    surface.Blit(this.tempLayer.Surface, new Point(0, 0));
                return surface;
            }
        }
        public GraphLayer SimulatorLayer { get { return this.simulatorLayer; } }
        public Bitmap DiagramBitmap
        {
            get
            {

                return this.diagramSurface.Bitmap;
            }
        }
        /// <summary>
        /// Contextual menu for the GraphDrawing
        /// </summary>
        public ContextMenu ContextMenu { get { return this.operation.ContextMenu; } }
        public Cursor Cursor { get { return this.operation.InitCursor; } }
        public OperationMode OpMode
        {
            get
            {
                if (this.operation is Connect)
                    return OperationMode.Connect;
                else
                    return OperationMode.Select;
            }
        }
        public List<GraphElement> ElementSelected { get { return this.selectLayer.Elements; } }
        public SortedList<Operation, bool> OperationState { get { return this.operationState; } }

        #endregion

        #region Events

        public event EventHandler DiagramChanged;
        /// <summary>
        /// Evento de cambio en el Surface del GraphDrawing
        /// </summary>
        public event SurfaceEventHandler SurfaceChanged;
        /// <summary>
        /// Evento de cambio de cursor para el GraphDrawing
        /// </summary>
        public event CursorEventHandler CursorChanged;
        /// <summary>
        /// Evento de cambio de menú contextual para el GraphDrawing
        /// </summary>
        public event ContextMenuEventHandler ContextMenuChanged;
        /// <summary>
        /// Enables an operation to be performed on the GraphDrawing
        /// </summary>
        public event OperationEventHandler OperationEnabled;
        /// <summary>
        /// DesEnables an operation to be performed on the GraphDrawing
        /// </summary>
        public event OperationEventHandler OperationDisabled;
        /// <summary>
        /// Se produce cuando cambian los elementos seleccionados
        /// </summary>
        public event EventHandler ElementSelectedChanged;

        public event EventHandler ActionSettingChanged;

        #endregion

        public GraphDiagram()
        {
            this.diagram = new Diagram();
        }

        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Builder of the GraphDrawing
        /// </summary>
        /// <param name="diagram">Logical diagram to which it represents</param>
        public GraphDiagram(Diagram diagram)
        {
            this.diagram = diagram;
            this.areaFormat = AreaFormat.A4_Vertical;
            //The Background Surface is created
            this.bgSurface = this.CreateBgSurface(this.AreaSizes[(int)this.areaFormat]);
            //The diagram layer is created and made visible
            this.diagramLayer = new GraphLayer(this.AreaSizes[(int)this.areaFormat]);
            this.diagramLayer.SurfaceChanged += new EventHandler(DiagramLayer_SurfaceChanged);
            //The selection layer is created and it is hidden
            this.selectLayer = new GraphLayer(this.AreaSizes[(int)this.areaFormat]);
            this.selectLayer.Visible = false;
            this.selectLayer.SurfaceChanged += new EventHandler(SelectLayer_SurfaceChanged);
            //The simulator layer is created
            this.simulatorLayer = new GraphLayer(this.AreaSizes[(int)this.areaFormat]);
            this.simulatorLayer.Visible = false;
            this.simulatorLayer.SurfaceChanged += new EventHandler(SimulatorLayer_SurfaceChanged);
            //The temporary layer is created and it is hidden
            this.tempLayer = new GraphLayer(this.AreaSizes[(int)this.areaFormat]);
            this.tempLayer.Visible = false;
            this.tempLayer.SurfaceChanged += new EventHandler(TempLayer_SurfaceChanged);
            //The Start element is created based on the diagram, is located and added to the diagram layer
            this.graphStart = new StartGraphic(this.diagram.Start);
            this.graphStart.Center = START_LOCATION;
            this.diagramLayer.AddElement(graphStart);
            //The diagram layer is updated for the first time
            this.diagramLayer.UpdateSurface();
            //Operations states are initialized for this diagram
            this.InitializeOperationState();
            //Basic Operation Nop (do nothing) is charged
            this.LoadOperation(new Nop(this.diagramLayer, this.tempLayer));
        }

        public void LoadGraphDiagram(string diagramFile, SortedList<string, Variable> variables, bool isFunction)
        {
            string name = "";
            string description = "";
            Size size = new Size(-1, -1);
            SortedList<string, XmlElement> id_XmlElements = new SortedList<string, XmlElement>();

            XmlDocument document = new XmlDocument();
            document.Load(diagramFile);
            XmlNodeList diagram = document.GetElementsByTagName("diagram");
            if (diagram.Count != 1)
                throw new GraphException("Open Diagram: More than one diagram in a single diagram file");
            foreach (XmlElement diagramData in diagram[0].ChildNodes)
            {
                switch (diagramData.Name)
                {
                    case "name":
                        name = diagramData.InnerText;
                        break;
                    case "description":
                        description = diagramData.InnerText;
                        break;
                    case "areaFormat":
                        this.areaFormat = (AreaFormat)Enum.Parse(typeof(AreaFormat), diagramData.InnerText);
                        size = this.AreaSizes[(int)this.areaFormat];
                        break;
                    case "size":
                        this.areaFormat = AreaFormat.A4_Vertical;
                        size = this.AreaSizes[(int)this.areaFormat];
                        break;
                    case "elements":
                        foreach (XmlElement xmlElement in diagramData.ChildNodes)
                        {
                            if (xmlElement.Name != "element")
                                throw new GraphException("Open Diagram: Element is not specified correctly");
                            if (xmlElement.ChildNodes[0].Name == "id")
                                id_XmlElements.Add(xmlElement.ChildNodes[0].InnerText, xmlElement);
                            else
                                throw new GraphException("Open Diagram: Element ID do not exist");
                        }
                        break;
                }
            }
            //Check that a name and size have been assigned
            if (name == "")
                throw new GraphException("Open Diagram: Diagram name is not specified");
            if (size.Width == -1)
                throw new GraphException("Open Diagram: Diagram size is not specified");
            //The structure of elements in the diagram is created
            SortedList<string, GraphElement> id_GraphElements = new SortedList<string, GraphElement>();
            List<GraphElement> graphElements = new List<GraphElement>();
            List<Element> elements = new List<Element>();
            foreach (string idElement in id_XmlElements.Keys)
            {
                if (!id_GraphElements.ContainsKey(idElement))
                {
                    GraphElement graphElement = GraphDiagram.CreateGraphElement(id_XmlElements[idElement], graphElements, elements, id_XmlElements, id_GraphElements, variables);
                    if (graphElement is StartGraphic)
                        this.graphStart = (StartGraphic)graphElement;
                    else
                        elements.Add(graphElement.Element);
                    graphElements.Add(graphElement);
                    id_GraphElements.Add(idElement, graphElement);
                }
            }
            if (graphStart == null)
                throw new GraphException("Open Diagram: Start element is not specified");
            this.diagram.LoadDiagram(name, description, (DiagramLayout.Elements.Start)this.graphStart.Element, elements, isFunction);
            //The diagram layer is created and it is visible
            this.diagramLayer = new GraphLayer(size, graphElements);
            this.diagramLayer.SurfaceChanged += new EventHandler(DiagramLayer_SurfaceChanged);
            //The selection layer is created and hidden
            this.selectLayer = new GraphLayer(size);
            this.selectLayer.Visible = false;
            this.selectLayer.SurfaceChanged += new EventHandler(SelectLayer_SurfaceChanged);
            //The simulator layer is created
            this.simulatorLayer = new GraphLayer(size);
            this.simulatorLayer.Visible = false;
            this.simulatorLayer.SurfaceChanged += new EventHandler(SimulatorLayer_SurfaceChanged);
            //The temporary layer is created and hidden
            this.tempLayer = new GraphLayer(size);
            this.tempLayer.Visible = false;
            this.tempLayer.SurfaceChanged += new EventHandler(TempLayer_SurfaceChanged);
            //The Background Surface is created
            this.bgSurface = new Surface(size);
            Surface s = new Surface(Backgrounds.bgWorkArea);
            for (int i = 0; i < this.bgSurface.Width; i += 144)
                for (int j = 0; j < this.bgSurface.Height; j += 144)
                    this.bgSurface.Blit(s, new Point(i, j));
            //The diagram layer is updated for the first time
            this.diagramLayer.UpdateSurface();
            //Operations states are initialized for this diagram
            this.InitializeOperationState();
            //Basic Operation Nop (do nothing) is charged
            this.LoadOperation(new Nop(this.diagramLayer, this.tempLayer));
        }

        public void SaveGraphDiagram(string path)
        {
            Hashtable elementsId = new Hashtable();
            GraphDiagram.ResetElementId();
            XmlWriter file = new XmlTextWriter(path + "\\" + this.diagram.Name + ".mdg", new System.Text.ASCIIEncoding());
            file.WriteStartDocument();

            file.WriteStartElement("diagram");
            file.WriteElementString("name", this.diagram.Name);
            file.WriteElementString("description", this.diagram.Description);
            file.WriteElementString("areaFormat", this.areaFormat.ToString());
            file.WriteStartElement("size");
            file.WriteElementString("width", this.Surface.Width.ToString());
            file.WriteElementString("height", this.Surface.Height.ToString());
            file.WriteEndElement();
            file.WriteStartElement("elements");
            foreach (GraphElement element in this.diagramLayer.Elements)
            {
                int elementId;
                if (elementsId.ContainsKey(element))
                    elementId = (int)elementsId[element];
                else
                {
                    elementId = GraphDiagram.GetElementId();
                    elementsId.Add(element, elementId);
                }
                file.WriteStartElement("element");
                element.SaveInFile(file, elementId, elementsId);
                file.WriteEndElement();
            }
            file.WriteEndElement();

            file.WriteEndDocument();
            file.Close();
        }

        private static int elementId = 0;

        public static void ResetElementId()
        {
            elementId = 0;
        }
        public static int GetElementId()
        {
            elementId++;
            return elementId;
        }

        #region Surface Update Methods

        /// <summary>
        /// Diagram Layer Surface Change Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DiagramLayer_SurfaceChanged(object sender, EventArgs e)
        {
            //The surface is created from the background
            Surface surface = new Surface(this.bgSurface);
            surface.Blit(this.diagramLayer.Surface);
            //The temporary surface of the diagram is saved
            this.diagramSurface = new Surface(surface);
            //Add the selection layer if visible
            if (this.selectLayer.Visible)
            {
                surface.Blit(this.selectLayer.Surface);
                //The temporary surface of selection is saved
                this.selectSurface = new Surface(surface);
            }
            else
                this.selectSurface = this.diagramSurface;
            //The simulator layer is added if it is visible
            if (this.simulatorLayer.Visible)
            {
                surface.Blit(this.simulatorLayer.Surface);
                //The temporary surface of selection is saved
                this.simulatorSurface = new Surface(surface);
            }
            else
                this.simulatorSurface = this.diagramSurface;
            //The temporary layer is added if it is visible
            if (this.tempLayer.Visible)
                surface.Blit(this.tempLayer.Surface, this.tempLayer.Location);
            //GraphDrawing Surface Change Event launched
            if (this.SurfaceChanged != null)
                this.SurfaceChanged(this, new SurfaceEventArgs(surface));
        }

        /// <summary>
        /// Temporary layer surface Change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SelectLayer_SurfaceChanged(object sender, EventArgs e)
        {
            //The surface is created from the temporal surface of the diagram
            Surface surface = new Surface(this.diagramSurface);
            //The temporary layer is added if it is visible
            if (this.selectLayer.Visible)
            {
                surface.Blit(this.selectLayer.Surface);
                //The temporary surface of selection is saved
                this.selectSurface = new Surface(surface);
            }
            else
                this.selectSurface = this.diagramSurface;
            //The simulator layer is added if it is visible
            if (this.simulatorLayer.Visible)
            {
                surface.Blit(this.simulatorLayer.Surface);
                //The temporary surface of selection is saved
                this.simulatorSurface = new Surface(surface);
            }
            else
                this.simulatorSurface = this.selectSurface;
            //The temporary layer is added if it is visible
            if (this.tempLayer.Visible)
                surface.Blit(this.tempLayer.Surface, this.tempLayer.Location);
            //GraphDrawing Surface Change Event launched
            if (this.SurfaceChanged != null)
                this.SurfaceChanged(this, new SurfaceEventArgs(surface));
        }

        void SimulatorLayer_SurfaceChanged(object sender, EventArgs e)
        {
            //The surface is created from the temporal surface of the diagram
            Surface surface = new Surface(this.selectSurface);
            //The simulator layer is added if it is visible
            if (this.simulatorLayer.Visible)
            {
                surface.Blit(this.simulatorLayer.Surface);
                //The temporary surface of simulation is saved
                this.simulatorSurface = new Surface(surface);
            }
            else
                this.simulatorSurface = this.selectSurface;
            //The temporary layer is added if it is visible
            if (this.tempLayer.Visible)
                surface.Blit(this.tempLayer.Surface, this.tempLayer.Location);
            //GraphDrawing Surface Change Event launched
            if (this.SurfaceChanged != null)
                this.SurfaceChanged(this, new SurfaceEventArgs(surface));
        }

        void TempLayer_SurfaceChanged(object sender, EventArgs e)
        {
            //The surface is created from the temporal surface of the diagram
            Surface surface = new Surface(this.simulatorSurface);
            //The temporary layer is added if it is visible
            if (this.tempLayer.Visible)
                surface.Blit(this.tempLayer.Surface, this.tempLayer.Location);
            //GraphDrawing Surface Change Event launched
            if (this.SurfaceChanged != null)
                this.SurfaceChanged(this, new SurfaceEventArgs(surface));
        }


        #endregion

        #region Operation Event Care Methods

        /// <summary>
        /// Cursor Update event for GraphDrawing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Operation_CursorChanged(object sender, CursorEventArgs e)
        {
            if (this.CursorChanged != null)
                this.CursorChanged(this, e);
        }

        /// <summary>
        /// Event of operation completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Operation_OperationFinished(object sender, OperationEventArgs e)
        {
            switch (e.Operation)
            {
                case Operation.Copy:
                    this.LoadOperation(new Select(this.diagramLayer, this.selectLayer));
                    break;
                case Operation.DragDrop:
                    this.undoStack.Push((IOperation)sender);
                    if (this.undoStack.Count == 1)
                    {
                       this.operationState[Operation.Undo] = true;
                        if (this.OperationEnabled != null)
                            this.OperationEnabled(this, new OperationEventArgs(Operation.Undo));
                    }
                    this.LoadOperation(new Select(this.diagramLayer, this.selectLayer));
                    break;
                case Operation.Connect:
                    this.undoStack.Push((IOperation)sender);
                    if (this.undoStack.Count == 1)
                    {
                        this.operationState[Operation.Undo] = true;
                        if (this.OperationEnabled != null)
                           this.OperationEnabled(this, new OperationEventArgs(Operation.Undo));
                    }
                    this.LoadOperation(new Connect(this.diagram, this.diagramLayer, this.tempLayer));
                    break;
                case Operation.Insert:
                case Operation.Paste:
                    this.undoStack.Push((IOperation)sender);
                    if (this.undoStack.Count == 1)
                    {
                        this.operationState[Operation.Undo] = true;
                        if (this.OperationEnabled != null)
                            this.OperationEnabled(this, new OperationEventArgs(Operation.Undo));
                    }
                    if (this.opMode == OperationMode.Select)
                        this.LoadOperation(new Nop(this.diagramLayer, this.tempLayer));
                    else
                        this.LoadOperation(new Connect(this.diagram, this.diagramLayer, this.tempLayer));
                    break;
                case Operation.Delete:
                case Operation.Cut:
                case Operation.InsertArrow:
                    this.undoStack.Push((IOperation)sender);
                    if (this.undoStack.Count == 1)
                    {
                        this.operationState[Operation.Undo] = true;
                        if (this.OperationEnabled != null)
                            this.OperationEnabled(this, new OperationEventArgs(Operation.Undo));
                    }
                    this.LoadOperation(new Nop(this.diagramLayer, this.tempLayer));
                    break;
                case Operation.ModifyArrow:
                case Operation.Reconnect:
                    this.undoStack.Push((IOperation)sender);
                    if (this.undoStack.Count == 1)
                    {
                        this.operationState[Operation.Undo] = true;
                        if (this.OperationEnabled != null)
                            this.OperationEnabled(this, new OperationEventArgs(Operation.Undo));
                    }
                    this.LoadOperation(new Nop(this.diagramLayer, this.tempLayer));
                    break;
                default:
                    this.LoadOperation(new Nop(this.diagramLayer, this.tempLayer));
                    break;
            }
        }

        /// <summary>
        /// Event of operation cancelled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Operation_OperationCanceled(object sender, OperationEventArgs e)
        {
            switch (e.Operation)
            {
                case Operation.Delete:
                case Operation.Cut:
                case Operation.Copy:
                case Operation.DragDrop:
                    this.LoadOperation(new Select(this.diagramLayer, this.selectLayer));
                    break;
                case Operation.Connect:
                    this.LoadOperation(new Connect(this.diagram, this.diagramLayer, this.tempLayer));
                    break;
                case Operation.Insert:
                case Operation.Paste:
                    if (this.opMode == OperationMode.Select)
                        this.LoadOperation(new Nop(this.diagramLayer, this.tempLayer));
                    else
                        this.LoadOperation(new Connect(this.diagram, this.diagramLayer, this.tempLayer));
                    break;
                case Operation.InsertArrow:
                default:
                    this.LoadOperation(new Nop(this.diagramLayer, this.tempLayer));
                    break;
            }
        }

        /// <summary>
        /// Event to launch a new operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Operation_NewOperation(object sender, OperationEventArgs e)
        {
            switch (e.Operation)
            {
                case Operation.Delete:
                    this.LoadOperation(new Delete(this.diagram, this.diagramLayer, this.selectLayer));
                    try
                    {
                        this.operation.Do();
                    }
                    catch (OperationException exception)
                    {
                        if (exception.Message.Contains("Nop"))
                            this.LoadOperation(new Nop(this.diagramLayer, this.tempLayer));
                        else
                            this.LoadOperation(new Select(this.diagramLayer, this.selectLayer));
                    }
                    break;
                case Operation.Settings:
                    if (this.selectLayer.Elements.Count == 1)
                    {
                        GraphElement element = (GraphElement)this.selectLayer.Elements[0];
                        if ((element is GraphModule) || (element is GraphConditional))
                        {
                            this.ShowActionForm(element);
                        }
                    }
                    break;
                case Operation.Copy:
                    this.Copy();
                    break;
                case Operation.Cut:
                    this.Cut();
                    break;
                case Operation.Paste:
                    this.Paste();
                    break;
            }
        }

        void Operation_OperationDisabled(object sender, OperationEventArgs e)
        {
            if ((bool)this.operationState[e.Operation] != false)
            {
                this.operationState[e.Operation] = false;
                if (this.OperationDisabled != null)
                    this.OperationDisabled(this, e);
            }
        }

        void Operation_OperationEnabled(object sender, OperationEventArgs e)
        {
            if ((bool)this.operationState[e.Operation] != true)
            {
                this.operationState[e.Operation] = true;
                if (this.OperationEnabled != null)
                    this.OperationEnabled(this, e);
            }
        }

        #endregion

        #region Public methods for the change of the properties of the GraphDrawing

        public void ChangeSize(AreaFormat areaFormat)
        {
            if (this.areaFormat != areaFormat)
            {
                if (!this.ValidateNewSize(areaFormat))
                    throw new ProjectException("Elements outside the workArea");
                this.areaFormat = areaFormat;
                this.bgSurface = this.CreateBgSurface(this.AreaSizes[(int)this.areaFormat]);
                this.diagramLayer.ChangeSize(this.AreaSizes[(int)this.areaFormat]);
                this.selectLayer.ChangeSize(this.AreaSizes[(int)this.areaFormat]);
                this.tempLayer.ChangeSize(this.AreaSizes[(int)this.areaFormat]);
                this.DiagramLayer_SurfaceChanged(null, null);

            }
        }

        public void UpdateScrollValues(int vScrollValue, int hScrollValue)
        {
            this.vScrollValue = vScrollValue;
            this.hScrollValue = hScrollValue;
        }

        #endregion

        #region Public methods for launching operations

        public void LostFocus()
        {
            this.operation.LostFocus();
        }

        public void EnablePaste()
        {
            this.operation.EnablePaste();
        }

        public void InitInsert(Tool tool)
        {
            this.operation.Cancel();
            GraphElement element = ActionFactory.GetGraphAction(tool.Key);
            this.LoadOperation(new InsertElement(this.diagram, this.diagramLayer, this.tempLayer, element));
        }

        public void DoInsert()
        {
            if (this.operation is InsertElement)
                this.operation.Do();
        }

        public void CancelInsert()
        {
            if (this.operation is InsertElement)
                ((InsertElement)this.operation).PreCancel();
        }

        public void ConnectMode()
        {
            if (this.opMode != OperationMode.Connect)
            {
                this.opMode = OperationMode.Connect;
                this.operation.Cancel();
                this.LoadOperation(new Connect(this.diagram, this.diagramLayer, this.tempLayer));
            }
        }

        public void SelectMode()
        {
            if (this.opMode != OperationMode.Select)
            {
                this.opMode = OperationMode.Select;
                this.operation.Cancel();
                this.LoadOperation(new Nop(this.diagramLayer, this.tempLayer));
            }
        }

        public void Delete()
        {
            if (this.operation is Select)
            {
                this.LoadOperation(new Delete(this.diagram, this.diagramLayer, this.selectLayer));
                try
                {
                    this.operation.Do();
                }
                catch (OperationException exception)
                {
                    if (exception.Message.Contains("Nop"))
                        this.LoadOperation(new Nop(this.diagramLayer, this.tempLayer));
                    else
                        this.LoadOperation(new Select(this.diagramLayer, this.selectLayer));
                }
            }
        }

        public void Copy()
        {
            if (this.operation is Select)
            {
                this.LoadOperation(new Copy(this.selectLayer));
                try
                {
                    this.operation.Do();
                }
                catch (OperationException exception)
                {
                    if (exception.Message.Contains("Nop"))
                        this.LoadOperation(new Nop(this.diagramLayer, this.tempLayer));
                    else
                        this.LoadOperation(new Select(this.diagramLayer, this.selectLayer));
                }
            }
        }

        public void Cut()
        {
            if (this.operation is Select)
            {
                this.LoadOperation(new Cut(this.diagram, this.diagramLayer, this.selectLayer));
                try
                {
                    this.operation.Do();
                }
                catch (OperationException exception)
                {
                    if (exception.Message.Contains("Nop"))
                        this.LoadOperation(new Nop(this.diagramLayer, this.tempLayer));
                    else
                        this.LoadOperation(new Select(this.diagramLayer, this.selectLayer));
                }
            }
        }

        public void Paste()
        {
            this.operation.Cancel();
            this.LoadOperation(new Paste(this.diagram, this.diagramLayer, this.tempLayer));
        }

        public void Undo()
        {
            this.operation.Cancel();
            IOperation operation = this.undoStack.Pop();
            operation.Undo();
            if (this.undoStack.Count == 0)
            {
                this.operationState[Operation.Undo] = false;
                if (this.OperationDisabled != null)
                    this.OperationDisabled(this, new OperationEventArgs(Operation.Undo));
            }
        }

        #endregion

        #region Public methods of mouse interaction

        public void MouseEnter()
        {
            this.operation.MouseEnter();
        }

        public void MouseLeave()
        {
            this.operation.MouseLeave();
        }

        public void MouseMove(MouseEventArgs e)
        {
            try
            {
                this.operation.MouseMove(e);
            }
            catch (OperationException exception)
            {
                switch (exception.Operation)
                {
                    case Operation.Nop:
                        this.LoadOperation(new SelectRectangle(this.diagramLayer, this.selectLayer, this.tempLayer, this.operation.InitMouseDownLocation));
                        this.operation.MouseMove(e);
                        break;
                    case Operation.Select:
                        this.LoadOperation(new DragDrop(this.diagramLayer, this.selectLayer, this.tempLayer, this.operation.InitMouseDownLocation));
                        this.operation.MouseMove(e);
                        break;
                }
            }
        }

        public void MouseUp(MouseEventArgs e)
        {
            try
            {
                this.operation.MouseUp(e);
            }
            catch (OperationException exception)
            {
                switch (exception.Operation)
                {
                    case Operation.SelectRectangle:
                        if (exception.Message.Contains("Select"))
                            this.LoadOperation(new Select(this.diagramLayer, this.selectLayer));
                        else
                            this.LoadOperation(new Nop(this.diagramLayer, this.tempLayer));
                        break;
                    case Operation.DragDrop:
                        this.LoadOperation(new Select(this.diagramLayer, this.selectLayer));
                        break;
                    case Operation.InsertArrow:
                        this.LoadOperation(new Nop(this.diagramLayer, this.tempLayer));
                        break;
                }
            }
        }

        public void MouseDown(MouseEventArgs e)
        {
            try
            {
                this.operation.MouseDown(e);
            }
            catch (OperationException exception)
            {
                switch (exception.Operation)
                {
                    case Operation.Nop:
                        if (exception.Message.Contains("Select"))
                        {
                            this.LoadOperation(new Select(this.diagramLayer, this.selectLayer));
                            this.operation.MouseDown(e);
                        }
                        else if (exception.Message.Contains("InsertArrow"))
                        {
                            this.LoadOperation(new InsertArrow(this.diagram, this.diagramLayer, this.tempLayer, this.operation.InitMouseDownLocation));
                            this.operation.MouseDown(e);
                        }
                        else if (exception.Message.Contains("ModifyArrow"))
                        {
                            this.LoadOperation(new ModifyArrow(this.diagramLayer, this.tempLayer, this.operation.InitMouseDownLocation));
                            this.operation.MouseDown(e);
                        }
                        else if (exception.Message.Contains("Reconnect"))
                        {
                            this.LoadOperation(new Reconnect(this.diagram, this.diagramLayer, this.tempLayer, this.operation.InitMouseDownLocation));
                            this.operation.MouseDown(e);
                        }
                        else
                            throw new GraphException(exception.Message);
                        break;
                    case Operation.Select:
                        this.LoadOperation(new Nop(this.diagramLayer, this.tempLayer));
                        this.operation.MouseDown(e);
                        break;
                }
            }
        }

        public void MouseDoubleClick(MouseEventArgs e)
        {
            if ((this.operation is Select) && (this.selectLayer.Elements.Count == 1))
            {
                GraphElement element = (GraphElement)this.selectLayer.Elements[0];
                if ((element.IntersectsWith(e.Location)) && ((element is GraphModule) || (element is GraphConditional)))
                {
                    ShowActionForm(element);
                }
            }
        }

        private void ShowActionForm(GraphElement element)
        {
            try
            {
                ActionForm actionForm = ActionFactory.GetActionForm(element.Element);
                if (DialogResult.OK == actionForm.ShowDialog())
                    if (this.ActionSettingChanged != null)
                        this.ActionSettingChanged(this, new EventArgs());
            }
            catch (ActionFormException e)
            {
                MowayMessageBox.Show(e.Message, e.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Public methods of keyboard Interaction 

        public void KeyPress(Keys modifier, Keys key)
        {
            this.operation.KeyPress(modifier, key);
        }

        #endregion

        #region Private methods

        private Surface CreateBgSurface(Size size)
        {
            Surface tempSurface = new Surface(size);
            Surface s = new Surface(Backgrounds.bgWorkArea);
            for (int i = 0; i < tempSurface.Width; i += 144)
                for (int j = 0; j < tempSurface.Height; j += 144)
                    tempSurface.Blit(s, new Point(i, j));
            return tempSurface;
        }

        /// <summary>
        /// Loads a new operation on the GraphDrawing and updates the context
        /// </summary>
        /// <param name="operation"></param>
        private void LoadOperation(IOperation operation)
        {
            //The function of attention to events is disallocated and the operation
            if (this.operation != null)
            {
                this.operation.DiagramChanged -= this.Operation_DiagramChanged;
                this.operation.CursorChanged -= this.Operation_CursorChanged;
                this.operation.OperationFinished -= this.Operation_OperationFinished;
                this.operation.OperationCanceled -= this.Operation_OperationCanceled;
                this.operation.NewOperation -= this.Operation_NewOperation;
                this.operation.OperationEnabled -= this.Operation_OperationEnabled;
                this.operation.OperationDisabled -= this.Operation_OperationDisabled;
                this.operation.ElementSelectedChanged -= this.Operation_ElementSelectedChanged;
            }
            //The new operation is assigned
            this.operation = operation;
            //Event-care functions are assigned
            this.operation.DiagramChanged += new EventHandler(Operation_DiagramChanged);
            this.operation.CursorChanged += new CursorEventHandler(Operation_CursorChanged);
            this.operation.OperationFinished += new OperationEventHandler(Operation_OperationFinished);
            this.operation.OperationCanceled += new OperationEventHandler(Operation_OperationCanceled);
            this.operation.NewOperation += new OperationEventHandler(Operation_NewOperation);
            this.operation.OperationEnabled += new OperationEventHandler(Operation_OperationEnabled);
            this.operation.OperationDisabled += new OperationEventHandler(Operation_OperationDisabled);
            this.operation.ElementSelectedChanged += new EventHandler(Operation_ElementSelectedChanged);
            //The event is launched for the context menu update
            if (this.ContextMenuChanged != null)
                this.ContextMenuChanged(this, new ContextMenuEventArgs(this.operation.ContextMenu));
            //The event is launched for the context menu update
            if (this.CursorChanged != null)
                this.CursorChanged(this, new CursorEventArgs(this.operation.InitCursor));
        }

        void Operation_ElementSelectedChanged(object sender, EventArgs e)
        {
            if (this.ElementSelectedChanged != null)
                this.ElementSelectedChanged(this, new EventArgs());
        }

        void Operation_DiagramChanged(object sender, EventArgs e)
        {
            if (this.DiagramChanged != null)
                this.DiagramChanged(this, new EventArgs());
        }

        private void InitializeOperationState()
        {
            this.operationState.Add(Operation.Copy, false);
            this.operationState.Add(Operation.Cut, false);
            this.operationState.Add(Operation.Delete, false);
            this.operationState.Add(Operation.Settings, false);
            this.operationState.Add(Operation.Undo, false);
            this.operationState.Add(Operation.Redo, false);
        }

        public bool GetOperationState(Operation operation)
        {
            if (this.operationState.ContainsKey(operation))
                return (bool)this.operationState[operation];
            else
                throw new GraphException("Operation no exists");
        }

        public bool ValidateNewSize(AreaFormat areaFormat)
        {
            int height = this.AreaSizes[(int)this.areaFormat].Height;
            int width = this.AreaSizes[(int)this.areaFormat].Width;
            foreach (GraphElement element in this.diagramLayer.Elements)
                if ((element.Right > this.AreaSizes[(int)areaFormat].Width) || (element.Bottom > this.AreaSizes[(int)areaFormat].Height))
                    return false;
            return true;
        }

        #endregion

        #region Static public methods

        /// <summary>
        /// Looks for an element of a layer on which to intercede a given point
        /// </summary>
        /// <param name="layer">Layer to find the item for</param>
        /// <param name="location">Point position for Search</param>
        /// <returns>Found item, NULL is case of not finding any</returns>
        public static GraphElement GetElement(GraphLayer layer, Point location)
        {
            //The item is searched in the element layer already selected
            foreach (GraphElement element in layer.Elements)
                if (element.IntersectsWith(location))
                    return element;
            //If not found, NULL is returned
            return null;
        }

        public static Connector GetConnector(GraphLayer layer, Point location)
        {
            //The item is searched in the element layer already selected
            foreach (GraphElement element in layer.Elements)
                if (element.IntersectsWith(location))
                    return element.GetConnector(location);
            //If not found, NULL is returned
            return null;
        }

        //They are used to look for the following gridPoints depending on the side
        private static int[] DISPLACEMENTE_X = new int[] { 0, 0, -1, 1 };
        private static int[] DISPLACEMENTE_Y = new int[] { -1, 1, 0, 0 };

        /// <summary>
        /// Find the best route between two points avoiding the obstacles of the diagram mesh
        /// </summary>
        /// <param name="gridPoints">Diagram mesh with the status of your points</param>
        /// <param name="startPoint">Starting point for the routea</param>
        /// <param name="startDirection">Default address for the split point</param>
        /// <param name="endPoint">End Point gives route</param>
        /// <returns>A list of all the points of the route found</returns>
        public static List<GridPoint> GetGridPath(GridPoint[,] gridPoints, Point startPoint, GraphSide startDirection, Point endPoint)
        {
            //If the starting point is not aligned with the grid, you cannot search for the path
            if (((startPoint.X - (GraphLayer.HORIZONTAL_STEP / 2) + 1) % GraphLayer.HORIZONTAL_STEP != 0) || ((startPoint.Y - (GraphLayer.VERTICAL_STEP / 2) + 1) % GraphLayer.VERTICAL_STEP != 0))
                throw new DiagramException("Find Path: Start Point are not correct");

            //If the endpoint is not aligned with the grid, you cannot search for the path
            if (((endPoint.X - (GraphLayer.HORIZONTAL_STEP / 2) + 1) % GraphLayer.HORIZONTAL_STEP != 0) || ((endPoint.Y - (GraphLayer.VERTICAL_STEP / 2) + 1) % GraphLayer.VERTICAL_STEP != 0))
                throw new DiagramException("Find Path: End Point are not correct");

            //It will save the searched route
            List<GridPoint> path = new List<GridPoint>();
            //Keep items that are being used
            List<GridPoint> gridPointsUsed = new List<GridPoint>();
            //You get the final element to be able to do the end-of-route comparison
            GridPoint lastGridPoint = gridPoints[endPoint.X / GraphLayer.HORIZONTAL_STEP, endPoint.Y / GraphLayer.VERTICAL_STEP];
            //Be part of the startup items for the path search
            GridPoint presentPoint = gridPoints[startPoint.X / GraphLayer.HORIZONTAL_STEP, startPoint.Y / GraphLayer.VERTICAL_STEP];
            //The default address is saved
            GraphSide direction = startDirection;
            //The following code fixes the rare effect that occurs when the start and end are aligned
            switch (direction)
            {
                case GraphSide.Top:
                    if ((startPoint.X == endPoint.X) && (startPoint.Y < endPoint.Y))
                        direction = GraphSide.Right;
                    break;
                case GraphSide.Bottom:
                    if ((startPoint.X == endPoint.X) && (startPoint.Y > endPoint.Y))
                        direction = GraphSide.Right;
                    break;
                case GraphSide.Right:
                    if ((startPoint.Y == endPoint.Y) && (startPoint.X > endPoint.X))
                        direction = GraphSide.Bottom;
                    break;
                case GraphSide.Left:
                    if ((startPoint.Y == endPoint.Y) && (startPoint.X < endPoint.X))
                        direction = GraphSide.Bottom;
                    break;
            }

            //Add the exit point to the path and to the list of items used
            path.Add(gridPoints[startPoint.X / GraphLayer.HORIZONTAL_STEP, startPoint.Y / GraphLayer.VERTICAL_STEP]);
            gridPointsUsed.Add(presentPoint);

            //Until the end point of the route has been found....
            while (presentPoint != lastGridPoint)
            {
                //The new elements that come out in this iteration are first analyzed
                List<GridPoint> newGridPoints = new List<GridPoint>();
                Point presentGridLocation = new Point(presentPoint.Location.X / GraphLayer.HORIZONTAL_STEP, presentPoint.Location.Y / GraphLayer.VERTICAL_STEP);
                //They recover and analyze the 4 elements of around current point
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        GridPoint tempGridPoint = gridPoints[presentGridLocation.X + DISPLACEMENTE_X[i], presentGridLocation.Y + DISPLACEMENTE_Y[i]];
                        if ((tempGridPoint.State == GridState.Free) && (!gridPointsUsed.Contains(tempGridPoint)))
                        {
                            tempGridPoint.Value = Math.Abs(lastGridPoint.Location.X - tempGridPoint.Location.X) + Math.Abs(lastGridPoint.Location.Y - tempGridPoint.Location.Y);
                            if (direction == (GraphSide)Enum.ToObject(typeof(GraphSide), i))
                                tempGridPoint.Value += 5;
                            else
                                tempGridPoint.Value += 10;
                            newGridPoints.Add(tempGridPoint);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //Jumps when an item is requested outside the grid of the diagram, so it is dismissed
                        continue;
                    }
                }
                //If there is any point available to follow...
                if (newGridPoints.Count != 0)
                {
                    //Points are saved in the list of used
                    gridPointsUsed.AddRange(newGridPoints);
                    //Points are sorted based on their heuristic value
                    newGridPoints.Sort();
                    //The default address is updated
                    direction = GraphDiagram.GetDirection(presentPoint.Location, newGridPoints[0].Location);
                    //The new starting point is loaded for the next iteration and saved in the path
                    presentPoint = newGridPoints[0];
                    path.Add(presentPoint);
                }
                else
                    throw new DiagramException("FindPath: No points to follow");
            }
            //The obtained path is returned
            return path;
        }

        /// <summary>
        /// Returns the closest point within the diagram grid for the given connector (the position of the connector within the element is taken into account)
        /// </summary>
        /// <param name="connector">Connector for which to look for the point</param>
        /// <returns>Point into the grid</returns>
        public static Point GetNearGridPoint(Connector connector)
        {
            Point point = new Point(0, 0);
            //The additions and subtractions in right and left are because not all elements maintain the same distances
            switch (connector.Side)
            {
                case GraphSide.Right:
                    point = new Point((((connector.AbsCenter.X + 9) / GraphLayer.HORIZONTAL_STEP) * GraphLayer.HORIZONTAL_STEP) + (GraphLayer.HORIZONTAL_STEP / 2) - 1, connector.AbsCenter.Y);
                    break;
                case GraphSide.Top:
                    point = new Point(connector.AbsCenter.X, (((connector.AbsCenter.Y - 12) / GraphLayer.VERTICAL_STEP) * GraphLayer.VERTICAL_STEP) + (GraphLayer.VERTICAL_STEP / 2) - 1);
                    break;
                case GraphSide.Left:
                    point = new Point((((connector.AbsCenter.X - 8) / GraphLayer.HORIZONTAL_STEP) * GraphLayer.HORIZONTAL_STEP) + (GraphLayer.HORIZONTAL_STEP / 2) - 1, connector.AbsCenter.Y);
                    break;
                case GraphSide.Bottom:
                    point = new Point(connector.AbsCenter.X, (((connector.AbsCenter.Y + 12) / GraphLayer.VERTICAL_STEP) * GraphLayer.VERTICAL_STEP) + (GraphLayer.VERTICAL_STEP / 2) - 1);
                    break;
            }
            return point;
        }

        public static List<GraphElement> GetElementsToDelete(GraphLayer selectLayer)
        {
            List<GraphElement> elements = new List<GraphElement>();
            foreach (GraphElement element in selectLayer.Elements)
            {
                if (!elements.Contains(element))
                {
                    elements.Add(element);
                    if (element is GraphConditional)
                    {
                        if ((((GraphConditional)element).NextTrue != null) && (!elements.Contains(((GraphConditional)element).NextTrue)))
                            elements.Add(((GraphConditional)element).NextTrue);
                        if ((((GraphConditional)element).NextFalse != null) && (!elements.Contains(((GraphConditional)element).NextFalse)))
                            elements.Add(((GraphConditional)element).NextFalse);
                    }
                    else if ((element is GraphModule) || (element is GraphStart))
                    {
                        if ((element.Next != null) && (!elements.Contains(element.Next)))
                            elements.Add(element.Next);
                    }
                    if ((element is GraphConditional) || (element is GraphModule) || (element is GraphFinish))
                    {
                        foreach (GraphElement previous in element.Previous)
                            if (!elements.Contains(previous))
                                elements.Add(previous);
                    }
                }
            }
            return elements;
        }

        public static void DeleteElements(GraphLayer diagramLayer, Diagram diagram, List<GraphElement> elements)
        {
            //The arrows are disconnected
            foreach (GraphElement element in elements)
                if (element is GraphArrow)
                {
                    if (!elements.Contains(element.Next))
                        element.Next.RemovePrevious(((GraphArrow)element).FinalConnector, (GraphArrow)element);
                    //The arrows contains one and only one predecessor
                    if (!elements.Contains(element.Previous[0]))
                        ((GraphElement)element.Previous[0]).RemoveNext(((GraphArrow)element).InitConnector, (GraphArrow)element);
                }
            //Clears selected elements from the diagram layer
            diagramLayer.RemoveElements(elements);
            //Clears selected elements from the diagram
            foreach (GraphElement element in elements)
                diagram.RemoveElement(element.Element);
        }

        public static void DeleteElement(GraphLayer diagramLayer, Diagram diagram, GraphElement element)
        {
            //The arrows are disconnected
            if (element is GraphArrow)
            {
                element.Next.RemovePrevious(((GraphArrow)element).FinalConnector, (GraphArrow)element);
                ((GraphElement)element.Previous[0]).RemoveNext(((GraphArrow)element).InitConnector, (GraphArrow)element);
            }
            //Clears selected elements from the diagram layer
            diagramLayer.RemoveElement(element);
            //Clears selected elements from the diagram
            diagram.RemoveElement(element.Element);
        }


        /// <summary>
        /// Loading the selection layer to the list of items to be copied, the elements that meet the conditions 
        /// To be copied:
        ///   - It is not a Start element (exception occurs because it is not possible to copy) 
        ///   - if it is an arrow , the next item and at least one previous must be selected. 
        ///   - Any other selected item is copied.
        /// </summary>
        /// <returns>List of items to copy</returns>
        public static List<GraphElement> GetElementsToCopy(GraphLayer layer)
        {
            List<GraphElement> elements = new List<GraphElement>();
            foreach (GraphElement graphElement in layer.Elements)
            {
                if (graphElement is GraphStart)
                    throw new GraphException("Can't copy Start element");
                else if (graphElement is GraphArrow)
                {
                    if ((graphElement.Next != null) && (graphElement.Next.Selected))
                    {
                        foreach (GraphElement arrowPrev in graphElement.Previous)
                            if (arrowPrev.Selected)
                            {
                                elements.Add(graphElement);
                                break;
                            }
                    }
                }
                else
                    elements.Add(graphElement);
            }
            return elements;
        }

        public static List<GraphElement> CloneElements(List<GraphElement> elements)
        {
            Hashtable element_clone = new Hashtable();
            List<GraphElement> clonedElements = new List<GraphElement>();
            foreach (GraphElement graphElement in elements)
            {
                if (!element_clone.ContainsKey(graphElement))
                {
                    GraphElement cloneElement = null;
                    if (graphElement is GraphArrow)
                        cloneElement = ((GraphArrow)graphElement).Clone(elements, clonedElements, element_clone);
                    else
                        cloneElement = graphElement.Clone();
                    clonedElements.Add(cloneElement);
                    element_clone.Add(graphElement, cloneElement);
                }
            }
            return clonedElements;
        }

        public static bool ValidateCopy(List<GraphElement> elements)
        {
            foreach (GraphElement graphElement in elements)
                if (graphElement is GraphStart)
                    return false;
            return true;
        }

        public static bool ValidateDelete(List<GraphElement> elements)
        {
            foreach (GraphElement graphElement in elements)
                if (graphElement is GraphStart)
                    return false;
            return true;
        }

        public static bool ValidateSettings(List<GraphElement> elements)
        {
            if ((elements.Count == 1) && ((elements[0] is GraphModule) || (elements[0] is GraphConditional)))
                return true;
            return false;
        }

        public static GraphElement CreateGraphElement(XmlElement xmlElement, List<GraphElement> graphElements, List<Element> elements, SortedList<string, XmlElement> id_XmlElements, SortedList<string, GraphElement> id_GraphElements, SortedList<string, Variable> variables)
        {
            GraphElement graphElement = null;
            string key = "";
            //It gets the key
            if (xmlElement.ChildNodes[1].Name == "key")
                key = xmlElement.ChildNodes[1].InnerText;
            else
                throw new GraphException("Open Diagram: Element key do not exist");
            switch (xmlElement.ChildNodes[2].Name)
            {
                case "start":
                    graphElement = new StartGraphic(key, (XmlElement)xmlElement.ChildNodes[2]);
                    break;
                case "module":
                case "conditional":
                case "finish":
                    graphElement = ActionFactory.GetGraphAction(key, (XmlElement)xmlElement.ChildNodes[2], variables);
                    break;
                case "arrow":
                    graphElement = new GraphArrow("arrow", xmlElement.ChildNodes[0].InnerText, (XmlElement)xmlElement.ChildNodes[2], graphElements, elements, id_XmlElements, id_GraphElements, variables);
                    break;
            }
            return graphElement;
        }

        public static GraphArrow InsertArrow(Diagram diagram, GraphLayer diagramLayer, Connector initialConnector, Connector finalConnector, ConditionalOut conditionalOut, GridPoint[,] gridStatus)
        {
            GraphElement initialElement = initialConnector.Parent;
            GraphElement finalElement = finalConnector.Parent;

            GraphArrow arrow = new GraphArrow(initialConnector, finalConnector, gridStatus);
            if (initialElement is GraphConditional)
                ((GraphConditional)initialElement).AddNext(initialConnector, arrow, conditionalOut);
            else
                initialElement.AddNext(initialConnector, arrow);
            finalElement.AddPrevious(finalConnector, arrow);
            diagramLayer.AddElement(arrow);
            diagram.AddElement(arrow.Element);
            return arrow;
        }

        /// <summary>
        /// Returns the smallest point in X and Y axis of a list of points
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static Point MinPoint(List<Point> points)
        {
            if (points.Count == 2)
                return new Point(Math.Min(((Point)points[0]).X, ((Point)points[1]).X), Math.Min(((Point)points[0]).Y, ((Point)points[1]).Y));
            else
            {
                List<Point> rPoints = new List<Point>();
                for (int i = 1; i < points.Count; i++)
                    rPoints.Add(points[i]);
                Point minPoint = GraphDiagram.MinPoint(rPoints);
                return new Point(Math.Min(((Point)points[0]).X, minPoint.X), Math.Min(((Point)points[0]).Y, minPoint.Y));
            }
        }

        /// <summary>
        /// Returns the highest points in X and Y axis of a list of points
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static Point MaxPoint(List<Point> points)
        {
            if (points.Count == 2)
                return new Point(Math.Max(((Point)points[0]).X, ((Point)points[1]).X), Math.Max(((Point)points[0]).Y, ((Point)points[1]).Y));
            else
            {
                List<Point> rPoints = new List<Point>();
                for (int i = 1; i < points.Count; i++)
                    rPoints.Add(points[i]);
                Point maxPoint = GraphDiagram.MaxPoint(rPoints);
                return new Point(Math.Max(((Point)points[0]).X, maxPoint.X), Math.Max(((Point)points[0]).Y, maxPoint.Y));
            }
        }

        #endregion

        #region Static private methods

        private static GraphSide GetDirection(Point startPoint, Point endPoint)
        {
            if ((startPoint.X != endPoint.X) && (startPoint.Y != endPoint.Y))
                throw new DiagramException("GetDirection: startPoint and endPoint is not alignment");
            if (startPoint.X == endPoint.X)
                if (startPoint.Y > endPoint.Y)
                    return GraphSide.Top;
                else
                    return GraphSide.Bottom;
            else
                if (startPoint.X > endPoint.X)
                    return GraphSide.Left;
                else
                    return GraphSide.Right;
        }

        #endregion
    }
}
