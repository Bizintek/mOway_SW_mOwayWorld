using System;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Graphics;

using Moway.Project.GraphicProject.Actions;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

using Moway.Simulator;

namespace Moway.Project.GraphicProject.GraphLayout.Elements
{
    public abstract class GraphConditional : GraphElement
    {
        #region Constants

        private static Point[] AREA = new Point[] { new Point(11, 29), new Point(46, 11), new Point(55, 11), new Point(90, 29), new Point(90, 46), new Point(55, 64), new Point(46, 64), new Point(11, 46) };

        #endregion

        #region Attributes

        protected Connector nextTrue = null;
        protected Connector nextFalse = null;

        #endregion

        #region Properties

        public override GraphElement Next { get { throw new GraphException("This property is innaccesible"); } }
        public GraphElement NextTrue
        {
            get
            {
                if (this.nextTrue == null)
                    return null;
                else
                    return (GraphElement)this.nextTrue.Connections[0];
            }
        }
        public GraphElement NextFalse
        {
            get
            {
                if (this.nextFalse == null)
                    return null;
                else
                    return (GraphElement)this.nextFalse.Connections[0];
            }
        }
        public override Point Center 
        {
            get { return base.Center; }
            set
            {
                base.Center = value;
                this.rectangles.Clear();
                this.rectangles.Add(new Rectangle(this.Position.X + 10, this.Position.Y + 10, this.Width - 20, this.Height - 20));
            }
        }

        #endregion

        public GraphConditional(string key)
        {
            this.key = key;
            this.element = ActionFactory.GetAction(this.key);
            this.Surface = new SdlDotNet.Graphics.Surface(new Size(102, 76));
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Transparent = true;
            this.TransparentColor = GraphDiagram.TRASPARENT_COLOR;

            CreateConnectors();
        }

        private void CreateConnectors()
        {
            this.connectors.Add(new Connector(0, this, new Point(51, 11), GraphSide.Top));
            this.connectors.Add(new Connector(1, this, new Point(51, 63), GraphSide.Bottom));
            this.connectors.Add(new Connector(2, this, new Point(12, 38), GraphSide.Left));
            this.connectors.Add(new Connector(3, this, new Point(90, 38), GraphSide.Right));
        }

        public GraphConditional(string key, Element element, Point center)
        {
            this.key = key;
            this.element = element;
            this.Surface = new SdlDotNet.Graphics.Surface(new Size(102, 76));
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Transparent = true;
            this.TransparentColor = GraphDiagram.TRASPARENT_COLOR;
            this.Center = center;

            CreateConnectors();
        }

        #region Public methods

        public ConditionalOut GetPredefOut(Connector connector)
        {
            if (!this.connectors.Contains(connector))
                throw new GraphException("This conditional don't have the connector");
            else
                if (this.nextTrue == connector)
                    return ConditionalOut.True;
                else if (this.nextFalse == connector)
                    return ConditionalOut.False;
                else if ((this.nextTrue != null) && (this.nextFalse == null))
                    return ConditionalOut.False;
                else
                    return ConditionalOut.True;
        }

        public override List<Connector> GetPrevConnectors()
        {
            List<Connector> connectors = new List<Connector>();
            foreach (Connector connector in this.connectors)
                if ((this.nextTrue != connector) && (this.nextFalse != connector))
                    connectors.Add(connector);
            return connectors;
        }

        public override bool EnablePrevConnectors()
        {
            bool joinEnabled = false;
            foreach (Connector join in this.connectors)
                if ((this.nextTrue != join) && (this.nextFalse != join))
                {
                    joinEnabled = true;
                    join.Visible = true;
                }
            this.Surface.Blit(this.connectors);
            return joinEnabled;
        }

        public override void AddNext(Connector conector, GraphArrow arrow)
        {
                throw new GraphException("Innaccesible method");
        }

        public void AddNext(GraphSide side, GraphArrow arrow, ConditionalOut outLine)
        {
            Connector connector = (Connector)this.connectors[(int)side];
            if (outLine == ConditionalOut.True)
                this.AddNextTrue(connector, arrow);
            else
                this.AddNextFalse(connector, arrow);
            ((Conditional)this.element).AddNext(arrow.Element, outLine);
            arrow.Element.AddPrevious(this.element);
        }

        public void AddNext(Connector conector, GraphArrow arrow, ConditionalOut outLine)
        {
            if (!this.connectors.Contains(conector))
                throw new GraphException("This element don't have the conector");
            if (outLine == ConditionalOut.True)
                this.AddNextTrue(conector, arrow);
            else
                this.AddNextFalse(conector, arrow);
            ((Conditional)this.element).AddNext(arrow.Element, outLine);
            arrow.Element.AddPrevious(this.element);
        }

        public override void RemoveNext(Connector connector, GraphArrow arrow)
        {
            if (!this.connectors.Contains(connector))
                throw new GraphException("This element don't have the conector");
            if ((this.nextTrue != connector) && (this.nextFalse != connector))
                throw new GraphException("This connector isn't next true or false");
            connector.RemoveArrow(arrow);
            if (this.nextTrue == connector)
            {
                this.nextTrue = null;
                this.DrawOutIcon(new Surface(ElementGraphics.eraseGraphic), connector.Side);
            }
            else
            {
                this.nextFalse = null;
                this.DrawOutIcon(new Surface(ElementGraphics.eraseGraphic), connector.Side);
            }
            this.element.RemoveNext(arrow.Element);
            arrow.Element.RemovePrevious(this.element);
        }

        public override bool IntersectsWith(Point point)
        {
            //the relative point is calculated with respect to the point of origin of the Sprite
            Point p = new Point(point.X - this.Position.X, point.Y - this.Position.Y);

            double angle = 0;
            Point p1 = new Point();
            Point p2 = new Point();

            for (int cont = 0; cont < AREA.Length; cont++)
            {
                p1.X = AREA[cont].X - p.X;
                p1.Y = AREA[cont].Y - p.Y;
                p2.X = AREA[(cont + 1) % (AREA.Length)].X - p.X;
                p2.Y = AREA[(cont + 1) % (AREA.Length)].Y - p.Y;
                angle += Angle2D(p1.X, p1.Y, p2.X, p2.Y);
            }

            bool intersect = (!(Math.Abs(angle) < Math.PI));
            if (!intersect)
            {
                p = new Point(point.X - this.Position.X, point.Y - this.Position.Y);
                for (int i = 0; i < 4; i++)
                    if ((this.connectors[i].Visible) && this.connectors[i].IntersectsWith(p))
                        return true;
            }
            return intersect;
        }


        public override bool ContainsIn(Rectangle rectangle)
        {
            if (((this.Center.X - 41) > rectangle.Left) && ((this.Center.X + 41) < rectangle.Right) && ((this.Center.Y - 28) > rectangle.Top) && ((this.Center.Y + 28) < rectangle.Bottom))
                return true;
            return false;
        }

    
        public virtual new bool Simulate(MowayModel mowayModel)        
        {
            return ((Conditional)this.element).Simulate(mowayModel);
        }

      

        public override void SaveInFile(XmlWriter file, int elementId, Hashtable elementsId)
        {
            file.WriteElementString("id", elementId.ToString());
            file.WriteElementString("key", this.key);

            file.WriteStartElement("conditional");
            file.WriteStartElement("position");
            file.WriteElementString("x", this.Center.X.ToString());
            file.WriteElementString("y", this.Center.Y.ToString());
            file.WriteEndElement();
            this.element.SaveInFile(file);
            file.WriteStartElement("previous");
            foreach (Connector connector in this.previous)
                foreach (GraphElement prevElement in connector.Connections)
                {
                    int id;
                    if (elementsId.ContainsKey(prevElement))
                        id = (int)elementsId[prevElement];
                    else
                    {
                        id = GraphDiagram.GetElementId();
                        elementsId.Add(prevElement, id);
                    }
                    file.WriteElementString("elementId", id.ToString());
                    file.WriteElementString("connectorId", connector.IdConnector.ToString());
                }
            file.WriteEndElement();

            file.WriteStartElement("nextTrue");
            if (this.NextTrue != null)
            {
                int id;
                if (elementsId.ContainsKey(this.NextTrue))
                    id = (int)elementsId[this.NextTrue];
                else
                {
                    id = GraphDiagram.GetElementId();
                    elementsId.Add(this.NextTrue, id);
                }
                file.WriteElementString("elementId", id.ToString());
                file.WriteElementString("connectorId", this.nextTrue.IdConnector.ToString());
            }
            file.WriteEndElement();
            file.WriteStartElement("nextFalse");
            if (this.NextFalse != null)
            {
                int id;
                if (elementsId.ContainsKey(this.NextFalse))
                    id = (int)elementsId[this.NextFalse];
                else
                {
                    id = GraphDiagram.GetElementId();
                    elementsId.Add(this.NextFalse, id);
                }
                file.WriteElementString("elementId", id.ToString());
                file.WriteElementString("connectorId", this.nextFalse.IdConnector.ToString());
            }
            file.WriteEndElement();
            file.WriteEndElement();
        }

        #endregion

        #region Private methods

        private void AddNextTrue(Connector conector, GraphArrow arrow)
        {
            if (this.nextTrue == null)
            {
                this.nextTrue = conector;
                conector.AddArrow(arrow);
                this.DrawOutIcons();
            }
            else
                throw new GraphException("It's necessary that next true is free");
        }

        private void AddNextFalse(Connector conector, GraphArrow arrow)
        {
            if (this.nextFalse == null)
            {
                this.nextFalse = conector;
                conector.AddArrow(arrow);
                this.DrawOutIcons();
            }
            else
                throw new GraphException("It's necessary that next false is free");
        }

        protected void DrawOutIcons()
        {
            if (this.nextTrue != null)
                DrawOutIcon(new Surface(ElementGraphics.trueGraphic), this.nextTrue.Side);
            if (this.nextFalse != null)
                DrawOutIcon(new Surface(ElementGraphics.falseGraphic), this.nextFalse.Side);
        }

        private void DrawOutIcon(Surface graphic, GraphSide side)
        {
            switch (side)
            {
                case GraphSide.Top:
                    this.Surface.Blit(graphic, new Point(54, 0));
                    break;
                case GraphSide.Bottom:
                    this.Surface.Blit(graphic, new Point(54, 65));
                    break;
                case GraphSide.Left:
                    this.Surface.Blit(graphic, new Point(0, 41));
                    break;
                case GraphSide.Right:
                    this.Surface.Blit(graphic, new Point(93, 26));
                    break;
            }
        }
        #endregion

        #region Static methods

        private static double Angle2D(double x1, double y1, double x2, double y2)
        {
            double dtheta, theta1, theta2;
            double twopi = 8.0 * Math.Atan(1.0);
            theta1 = Math.Atan2(y1, x1);
            theta2 = Math.Atan2(y2, x2);
            dtheta = theta2 - theta1;

            while (dtheta > Math.PI)
                dtheta -= twopi;

            while (dtheta < (-Math.PI))
                dtheta += twopi;

            return (dtheta);
        }

        #endregion

    }
}
