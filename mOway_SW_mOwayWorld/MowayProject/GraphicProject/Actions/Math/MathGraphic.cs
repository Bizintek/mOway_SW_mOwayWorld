using System;
using System.Drawing;
using System.Xml;

using SdlDotNet.Graphics;

using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Math
{
    public class MathGraphic : GraphModule
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
                        this.Surface.Blit(new Surface(Math.GraphicIconSelected));
                    else
                    {
                        this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                        this.Surface.Blit(new Surface(Math.GraphicIcon));
                    }
                }
            }
        }
        public MathGraphic(string key)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(Math.NeedInit);
            this.Surface.Blit(new Surface(Math.GraphicIcon));
        }

        public MathGraphic(string key, MathAction element, Point center)
            : base(key, element, center)
        {
            this.needInit = System.Convert.ToBoolean(Math.NeedInit);
            this.Surface.Blit(new Surface(Math.GraphicIcon));
        }

        public override void EnableConnector(Connector connector)
        {
            this.needInit = System.Convert.ToBoolean(Math.NeedInit);
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(Math.GraphicIcon));
            base.EnableConnector(connector);
        }

        public MathGraphic(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
            : base(key)
        {
            this.Surface.Blit(new Surface(Math.GraphicIcon));
            foreach (XmlElement nodo in elementData)
            {
                switch (nodo.Name)
                {
                    case "position":
                        this.Center = new Point(System.Convert.ToInt32(nodo.ChildNodes[0].InnerText), System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                        break;
                    case "properties":
                        this.element = new MathAction(key, nodo, variables);
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
            this.Surface.Blit(new Surface(Math.GraphicIcon));
        }

        public override GraphElement Clone()
        {
            return new MathGraphic(this.key, (MathAction)this.element.Clone(), this.Center);
        }
    }
}
