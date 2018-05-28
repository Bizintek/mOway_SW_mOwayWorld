using System;
using System.Drawing;
using System.Xml;

using SdlDotNet.Graphics;

using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.AssignDistance
{
    public class AssignDistanceGraphic : GraphModule
    {
        public override bool Selected
        {
            get
            {
                return base.Selected;
            }
            set
            {
                if (this.selected != value)
                {
                    this.selected = value;
                    if (this.selected)
                        this.Surface.Blit(new Surface(AssignDistance.GraphicIconSelected));
                    else
                    {
                        this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                        this.Surface.Blit(new Surface(AssignDistance.GraphicIcon));
                    }
                }
            }
        }

       public AssignDistanceGraphic(string key)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(AssignDistance.NeedInit);
            this.Surface.Blit(new Surface(AssignDistance.GraphicIcon));
        }

        public AssignDistanceGraphic(string key, AssignDistanceAction element, Point center)
            : base(key, element, center)
        {
            this.needInit = System.Convert.ToBoolean(AssignDistance.NeedInit);
            this.Surface.Blit(new Surface(AssignDistance.GraphicIcon));
        }

        public AssignDistanceGraphic(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(AssignDistance.NeedInit);
            this.Surface.Blit(new Surface(AssignDistance.GraphicIcon));
            foreach (XmlElement nodo in elementData)
            {
                switch (nodo.Name)
                {
                    case "position":
                        this.Center = new Point(System.Convert.ToInt32(nodo.ChildNodes[0].InnerText), System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                        break;
                    case "properties":
                        this.element = new AssignDistanceAction(key, nodo, variables);
                        break;
                    case "previous":
                        break;
                    case "next":
                        break;
                    default:
                        throw new GraphException("Error al crear GraphStart");
                }
            }
        }

        public override void EnableConnector(Connector connector)
        {
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(AssignDistance.GraphicIcon));
            base.EnableConnector(connector);
        }

        public override void DisableConnectors()
        {
            base.DisableConnectors();
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(AssignDistance.GraphicIcon));
        }

        public override GraphElement Clone()
        {
            return new AssignDistanceGraphic(this.key, (AssignDistanceAction)this.element.Clone(), this.Center);
        }
    }
}
