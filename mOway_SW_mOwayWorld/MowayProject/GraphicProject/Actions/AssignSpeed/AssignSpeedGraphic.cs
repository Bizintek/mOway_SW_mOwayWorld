using System;
using System.Xml;
using System.Drawing;

using SdlDotNet.Graphics;

using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.AssignSpeed
{
    public class AssignSpeedGraphic : GraphModule
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
                        this.Surface.Blit(new Surface(AssignSpeed.GraphicIconSelected));
                    else
                    {
                        this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                        this.Surface.Blit(new Surface(AssignSpeed.GraphicIcon));
                    }
                }
            }
        }
        public AssignSpeedGraphic(string key)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(AssignSpeed.NeedInit);
            this.Surface.Blit(new Surface(AssignSpeed.GraphicIcon));
        }

        public AssignSpeedGraphic(string key, AssignSpeedAction element, Point center)
            : base(key, element, center)
        {
            this.needInit = System.Convert.ToBoolean(AssignSpeed.NeedInit);
            this.Surface.Blit(new Surface(AssignSpeed.GraphicIcon));
        }

        public override void EnableConnector(Connector connector)
        {
            this.needInit = System.Convert.ToBoolean(AssignSpeed.NeedInit);
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(AssignSpeed.GraphicIcon));
            base.EnableConnector(connector);
        }

        public AssignSpeedGraphic(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
            : base(key)
        {
            this.Surface.Blit(new Surface(AssignSpeed.GraphicIcon));
            foreach (XmlElement nodo in elementData)
            {
                switch (nodo.Name)
                {
                    case "position":
                        this.Center = new Point(System.Convert.ToInt32(nodo.ChildNodes[0].InnerText), System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                        break;
                    case "properties":
                        this.element = new AssignSpeedAction(key, nodo, variables);
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

        public override void DisableConnectors()
        {
            base.DisableConnectors();
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(AssignSpeed.GraphicIcon));
        }

        public override GraphElement Clone()
        {
            return new AssignSpeedGraphic(this.key, (AssignSpeedAction)this.element.Clone(), this.Center);
        }
    }
}
