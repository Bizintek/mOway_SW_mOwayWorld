using System;
using System.Drawing;
using System.Xml;

using SdlDotNet.Graphics;

using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.AssignTime
{
    public class AssignTimeGraphic : GraphModule
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
                        this.Surface.Blit(new Surface(AssignTime.GraphicIconSelected));
                    else
                    {
                        this.Surface.Blit(new Surface(AssignTime.GraphicIcon));
                        this.Surface = new Surface(AssignTime.GraphicIcon);
                    }
                }
            }
        }

        public AssignTimeGraphic(string key)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(AssignTime.NeedInit);
            this.Surface.Blit(new Surface(AssignTime.GraphicIcon));
        }

        public AssignTimeGraphic(string key, AssignTimeAction element, Point center)
            : base(key, element, center)
        {
            this.needInit = System.Convert.ToBoolean(AssignTime.NeedInit);
            this.Surface.Blit(new Surface(AssignTime.GraphicIcon));
        }

        public override void EnableConnector(Connector connector)
        {
            this.needInit = System.Convert.ToBoolean(AssignTime.NeedInit);
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(AssignTime.GraphicIcon));
            base.EnableConnector(connector);
        }

        public AssignTimeGraphic(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
            : base(key)
        {
            this.Surface.Blit(new Surface(AssignTime.GraphicIcon));
            foreach (XmlElement nodo in elementData)
            {
                switch (nodo.Name)
                {
                    case "position":
                        this.Center = new Point(System.Convert.ToInt32(nodo.ChildNodes[0].InnerText), System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                        break;
                    case "properties":
                        this.element = new AssignTimeAction(key, nodo, variables);
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
            this.Surface.Blit(new Surface(AssignTime.GraphicIcon));
        }

        public override GraphElement Clone()
        {
            return new AssignTimeGraphic(this.key, (AssignTimeAction)this.element.Clone(), this.Center);
        }
    }
}
