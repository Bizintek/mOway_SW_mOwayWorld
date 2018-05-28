using System;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;

using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.GraphLayout.Elements
{
    public abstract class GraphStart : GraphElement
    {
        #region Constants

        private const int RADIOUS = 18;

        #endregion

        #region Properties

        public override List<GraphElement> Previous { get { throw new GraphException("This property is innaccesible"); } }
        public override Point Center
        {
            get { return base.Center; }
            set
            {
                base.Center = value;
                this.rectangles.Clear();
                this.rectangles.Add(new Rectangle(this.Position.X - 4, this.Position.Y - 7, this.Width + 8, this.Height + 14));
            }
        }

        #endregion

        public GraphStart()
        {
            this.Surface = new Surface(new Size(42, 42));
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Transparent = true;
            this.Surface.TransparentColor = GraphDiagram.TRASPARENT_COLOR;

            this.connectors.Add(new Connector(0, this, new Point(21, 5), GraphSide.Top));
            this.connectors.Add(new Connector(1, this, new Point(21, 37), GraphSide.Bottom));
            this.connectors.Add(new Connector(2, this, new Point(5, 21), GraphSide.Left));
            this.connectors.Add(new Connector(3, this, new Point(37, 21), GraphSide.Right));
        }

        public override void AddPrevious(Connector conector, GraphArrow arrow)
        {
            throw new GraphException("This methods is inaccesible");
        }

        public override void RemovePrevious(Connector connector, GraphArrow arrow)
        {
            throw new GraphException("This methods is inaccesible");
        }

        public override bool EnablePrevConnectors()
        {
            return false;
        }

        public override bool IntersectsWith(Point point)
        {
            //he position of the points from the center of the start element was calculated
            Point p = new Point(point.X - this.Center.X, point.Y - this.Center.Y);
            //the distance from the center to the point is calculated
            double d = Math.Sqrt((p.X * p.X) + (p.Y * p.Y));
            // if the distance is less than 17, the mouse is inside the element
            if (d < RADIOUS)
                return true;
            else
            {
                p = new Point(point.X - this.Position.X, point.Y - this.Position.Y);
                for (int i = 0; i < 4; i++)
                    if ((this.connectors[i].Visible) && this.connectors[i].IntersectsWith(p))
                        return true;
                return false;
            }
        }

        public override bool ContainsIn(Rectangle rectangle)
        {
            if (((this.Center.X - RADIOUS) > rectangle.Left) && ((this.Center.X + RADIOUS) < rectangle.Right) && ((this.Center.Y - RADIOUS) > rectangle.Top) && ((this.Center.Y + RADIOUS) < rectangle.Bottom))
                return true;
            return false;
        }

        public override void Simulate(Moway.Simulator.MowayModel mowayModel)
        {
            throw new GraphException("This method can not be called");
        }

        public override void SaveInFile(XmlWriter file, int elementId, Hashtable elementsId)
        {
            file.WriteElementString("id", elementId.ToString());
            file.WriteElementString("key", this.key);

            file.WriteStartElement("start");
            file.WriteStartElement("position");
            file.WriteElementString("x", this.Center.X.ToString());
            file.WriteElementString("y", this.Center.Y.ToString());
            file.WriteEndElement();
            file.WriteStartElement("next");
            if (this.Next != null)
            {
                int id;
                if (elementsId.ContainsKey(this.Next))
                    id = (int)elementsId[this.Next];
                else
                {
                    id = GraphDiagram.GetElementId();
                    elementsId.Add(this.Next, id);
                }
                file.WriteElementString("elementId", id.ToString());
                file.WriteElementString("connectorId", this.next.IdConnector.ToString());
            }
            file.WriteEndElement();

            file.WriteEndElement();
        }
    }
}
