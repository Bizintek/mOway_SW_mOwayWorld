using System;
using System.Xml;
using System.Drawing;
using System.Collections;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Graphics.Primitives;

using Moway.Project.GraphicProject.Actions;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.GraphLayout.Elements
{
    public abstract class GraphModule : GraphElement
    {
        public override Point Center
        {
            get { return base.Center; }
            set
            {
                base.Center = value;
                this.rectangles.Clear();
                this.rectangles.Add(new Rectangle(this.Position.X - 1, this.Position.Y - 1, this.Width + 2, this.Height + 2));
            }
        }

        public GraphModule(string key)
        {
            this.key = key;
            this.element = ActionFactory.GetAction(this.key);
            this.Surface = new Surface(new Size(80, 54));
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Transparent = true;
            this.Surface.TransparentColor = GraphDiagram.TRASPARENT_COLOR;

            CreateConnectors();
        }

        private void CreateConnectors()
        {
            this.connectors.Add(new Connector(0, this, new Point(40, 4), GraphSide.Top));
            this.connectors.Add(new Connector(1, this, new Point(40, 50), GraphSide.Bottom));
            this.connectors.Add(new Connector(2, this, new Point(4, 27), GraphSide.Left));
            this.connectors.Add(new Connector(3, this, new Point(76, 27), GraphSide.Right));
        }

        public GraphModule(string key, Element element, Point center)
        {
            this.key = key;
            this.element = element;
            this.Surface = new Surface(new Size(80, 54));
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Transparent = true;
            this.Surface.TransparentColor = GraphDiagram.TRASPARENT_COLOR;
            this.Center = center;

            CreateConnectors();
        }

        public override bool IntersectsWith(Point point)
        {
            // the position of the points from the center of the element is calculated
                        Point p = new Point(point.X - this.Center.X, point.Y - this.Center.Y);
            //the points on the x and y axes are checked
            if ((Math.Abs(p.X) < 37) && (Math.Abs(p.Y) < 25))
                return true;
            else return this.IntersectsWithConnector(point);
        }

        public override bool ContainsIn(Rectangle rectangle)
        {
            if (((this.Center.X - 38) > rectangle.Left) && ((this.Center.X + 38) < rectangle.Right) && ((this.Center.Y - 25) > rectangle.Top) && ((this.Center.Y + 25) < rectangle.Bottom))
                return true;
            return false;
        }
        
        public override void SaveInFile(XmlWriter file, int elementId, Hashtable elementsId)
        {
            file.WriteElementString("id", elementId.ToString());
            file.WriteElementString("key", this.key);

            file.WriteStartElement("module");
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
