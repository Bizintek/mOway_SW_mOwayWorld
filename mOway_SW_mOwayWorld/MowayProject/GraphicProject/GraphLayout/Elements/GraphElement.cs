using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

using SdlDotNet.Graphics.Sprites;

using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Simulator;

namespace Moway.Project.GraphicProject.GraphLayout.Elements
{
    /// <summary>
    /// Represents an arrow-type action
    /// </summary>
    /// <LastRevision>18.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public abstract class GraphElement : Sprite
    {
        #region Attributes

        /// <summary>
        /// Graphic element key
        /// </summary>
        protected string key;
        /// <summary>
        /// Indicates whether the action requires initialization
        /// </summary>
        protected bool needInit = false;
        /// <summary>
        /// Logical element that represents
        /// </summary>
        protected Element element = null;
        /// <summary>
        /// Indicates if the item is selected
        /// </summary>
        protected bool selected = false;
        /// <summary>
        /// Next graphic element
        /// </summary>
        protected Connector next = null;
        /// <summary>
        /// List of previous graphic elements
        /// </summary>
        protected List<Connector> previous = new List<Connector>();
        /// <summary>
        /// List of element connectors
        /// </summary>
        protected SpriteCollection connectors = new SpriteCollection();
        /// <summary>
        /// List of spaces occupied by the element
        /// </summary>
        protected List<Rectangle> rectangles = new List<Rectangle>();

        #endregion

        #region Properties

        /// <summary>
        /// Graphic element key
        /// </summary>
        public string Key { get { return this.key; } }
        /// <summary>
        /// Indicates whether the action requires initialization
        /// </summary>
        public bool NeedInit { get { return this.needInit; } }
        /// <summary>
        /// Logical element that represents
        /// </summary>
        public Element Element { get { return this.element; } }
        /// <summary>
        /// Indicates if the item is selected
        /// </summary>
        public virtual bool Selected
        {
            get { return this.selected; }
            set { this.selected = value; }
        }
        /// <summary>
        /// List of previous graphic elements
        /// </summary>
        public virtual GraphElement Next
        {
            get
            {
                if (this.next == null)
                    return null;
                else
                    return (GraphElement)this.next.Connections[0];
            }
        }
        /// <summary>
        /// List of previous graphic elements
        /// </summary>
        public virtual List<GraphElement> Previous
        {
            get
            {
                List<GraphElement> prevElements = new List<GraphElement>();
                foreach (Connector connector in this.previous)
                    foreach (GraphElement e in connector.Connections)
                        prevElements.Add(e);
                return prevElements;
            }
        }
        /// <summary>
        /// List of spaces occupied by the element
        /// </summary>
        public virtual List<Rectangle> Rectangles { get { return this.rectangles; } }
        /// <summary>
        /// Position of the center of the element
        /// </summary>
        public virtual new Point Center
        {
            get { return base.Center; }
            set { base.Center = value; }
        }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public GraphElement() { }

        #region Public methods

        /// <summary>
        /// Returns the connector for the next element
        /// </summary>
        /// <returns>Next connector</returns>
        public virtual Connector GetNextConnector()
        {
            return this.next;
        }

        /// <summary>
        /// Returns the connector for the previous element represented by a graphic arrow
        /// </summary>
        /// <param name="graphArrow">Graphic arrow</param>
        /// <returns>Previous connector</returns>
        public virtual Connector GetPrevConnector(GraphArrow graphArrow)
        {
            foreach (Connector connector in this.connectors)
                if (connector.Connections.Contains(graphArrow))
                    return connector;
            return null;
        }

        /// <summary>
        ///Add a following element represented by an arrow to a certain side of the element
        /// </summary>
        /// <param name="side">Side of the element where the following element is added</param>
        /// <param name="arrow"> Next item represented by an arrow</param>
        /// <returns>Connector where the following element has been included</returns>
        public virtual Connector AddNext(GraphSide side, GraphArrow arrow)
        {
            if (this.next == null)
            {
                this.next = (Connector)this.connectors[(int)side];
                this.next.AddArrow(arrow);
                this.element.AddNext(arrow.element);
                arrow.element.AddPrevious(this.element);
                return this.next;
            }
            else
                throw new GraphException("The next output should be null");
        }

        /// <summary>
        /// Add a following element represented by an arrow in a particular connector
        /// </summary>
        /// <param name="connector">Connector where the following element has been included</param>
        /// <param name="arrow">Next item represented by an arrow</param>
        public virtual void AddNext(Connector connector, GraphArrow arrow)
        {
            if (!this.connectors.Contains(connector))
                throw new GraphException("The element don't have this conector");
            if (this.next == null)
            {
                this.next = connector;
                connector.AddArrow(arrow);
                this.element.AddNext(arrow.element);
                arrow.element.AddPrevious(this.element);
            }
            else
                throw new GraphException("The next output shoulb be null");
        }

        public virtual void RemoveNext(Connector connector, GraphArrow arrow)
        {
            if (!this.connectors.Contains(connector))
                throw new GraphException("This element don't have the conector");
            if (this.next != connector)
                throw new GraphException("This connector isn't next");
            connector.RemoveArrow(arrow);
            this.element.RemoveNext(arrow.element);
            arrow.element.RemovePrevious(this.element);
            this.next = null;
        }

        public virtual void AddPrevious(GraphSide side, GraphArrow arrow)
        {
            Connector connector = (Connector)this.connectors[(int)side];
            if (!this.previous.Contains(connector))
                this.previous.Add(connector);
            connector.AddArrow(arrow);
            this.element.AddPrevious(arrow.element);
            arrow.element.AddNext(this.element);
        }

        public virtual void AddPrevious(Connector connector, GraphArrow arrow)
        {
            if (!this.connectors.Contains(connector))
                throw new GraphException("This element don't have the conector");
            if (!this.previous.Contains(connector))
                this.previous.Add(connector);
            connector.AddArrow(arrow);
            this.element.AddPrevious(arrow.element);
            arrow.element.AddNext(this.element);
        }

        public virtual void RemovePrevious(Connector connector, GraphArrow arrow)
        {
            if (!this.connectors.Contains(connector))
                throw new GraphException("This element don't have the conector");
            if (!this.previous.Contains(connector))
                throw new GraphException("This connector isn't a previous");
            connector.RemoveArrow(arrow);
            this.element.RemovePrevious(arrow.element);
            arrow.Element.RemoveNext(this.element);
            if (connector.Connections.Count == 0)
                this.previous.Remove(connector);
        }

        public virtual GraphElement Clone() 
        {
            throw new GraphException("Clone method no defined");
        }

        public virtual bool ContainsIn(Rectangle rectangle)
        {
            return false;
        }

        public override bool IntersectsWith(Sprite sprite)
        {
            foreach (Rectangle rectangle in this.rectangles)
                if (sprite.IntersectsWith(rectangle))
                    return true;
            return false;
        }

        public override bool IntersectsWith(Rectangle rectangle)
        {
            foreach (Rectangle rectangle2 in this.rectangles)
                if (rectangle2.IntersectsWith(rectangle))
                    return true;
            return false;
        }

        public virtual bool IntersectsWithConnector(Point location)
        {
            Point relativeLocation = new Point(location.X - this.Position.X, location.Y - this.Position.Y);
            foreach (Connector connector in this.connectors)
                if ((connector.Visible) && (connector.IntersectsWith(relativeLocation)))
                    return true;
            return false;
        }

        public virtual bool IntersectsWithConnector(Connector connector, Point location)
        {
            if (this.connectors.Contains(connector))
            {
                Point relativeLocation = new Point(location.X - this.Position.X, location.Y - this.Position.Y);
                if ((connector.Visible) && (connector.IntersectsWith(relativeLocation)))
                    return true;
                else
                    return false;
            }
            else
                throw new GraphException("This element don't have the join");
        }

        public virtual Connector GetConnector(GraphSide side)
        {
            return (Connector)this.connectors[(int)side];
        }

        public virtual Connector GetConnector(int idConnector)
        {
            return (Connector)this.connectors[idConnector];
        }

        public virtual Connector GetConnector(Point location)
        {
            Point relativeLocation = new Point(location.X - this.Position.X, location.Y - this.Position.Y);
            foreach (Connector join in this.connectors)
                if ((join.Visible) && (join.IntersectsWith(relativeLocation)))
                    return join;
            return null;
        }

        public virtual List<Connector> GetNextConnectors()
        {
            List<Connector> connectors = new List<Connector>();
            foreach (Connector connector in this.connectors)
                if (!this.previous.Contains(connector))
                    connectors.Add(connector);
            return connectors;
        }

        public virtual List<Connector> GetPrevConnectors()
        {
            List<Connector> connectors = new List<Connector>();
            foreach (Connector connector in this.connectors)
                if (this.next != connector)
                    connectors.Add(connector);
            return connectors;
        }

        public virtual bool EnableNextConnectors()
        {
            bool connectorEnabled = false;
            foreach (Connector join in this.connectors)
                if (!this.previous.Contains(join))
                {
                    connectorEnabled = true;
                    join.Visible = true;
                }
            this.Surface.Blit(this.connectors);
            return connectorEnabled;
        }

        public virtual void EnableConnector(Connector connector) 
        { 
            if (this.connectors.Contains(connector))
            {
                foreach (Connector elementJoin in this.connectors)
                    elementJoin.Visible = false;
                connector.Visible = true;
                this.Surface.Blit(this.connectors);
            }
            else
                throw new GraphException("This element don't have the join");
        }

        public virtual bool EnablePrevConnectors()
        {
            bool connectorEnabled = false;
            foreach (Connector connector in this.connectors)
                if (this.next != connector)
                {
                    connectorEnabled = true;
                    connector.Visible = true;
                }
            this.Surface.Blit(this.connectors);
            return connectorEnabled;
        }

        public virtual void DisableConnectors()
        {
            foreach (Connector connector in this.connectors)
                connector.Visible = false;
        }

        public virtual void Simulate(MowayModel mowayModel)
        {
            this.element.Simulate(mowayModel);
        }

        public virtual void SaveInFile(XmlWriter file, int elementId, Hashtable elementsId)
        {
            throw new GraphException("SaveActionInFlie method no defined");
        }

        #endregion
    }
}
