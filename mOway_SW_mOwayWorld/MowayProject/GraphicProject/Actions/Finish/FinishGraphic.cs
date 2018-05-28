using System;
using System.Drawing;
using System.Xml;

using SdlDotNet.Graphics;

using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Finish
{
    public class FinishGraphic : GraphFinish
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
                        this.Surface.Blit(new Surface(Finish.GraphicIconSelected));
                    else
                    {
                        this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                        this.Surface.Blit(new Surface(Finish.GraphicIcon));
                    }
                }

            }
        }
        public FinishGraphic(string key)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(Finish.NeedInit);
            this.Surface.Blit(new Surface(Finish.GraphicIcon));
            this.element = ActionFactory.GetAction(this.key);
        }

        public FinishGraphic(string key, FinishAction element, Point center)
            : base(key, center)
        {
            this.needInit = System.Convert.ToBoolean(Finish.NeedInit);
            this.Surface.Blit(new Surface(Finish.GraphicIcon));
            this.element = element;
        }

        public FinishGraphic(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(Finish.NeedInit);
            this.Surface.Blit(new Surface(Finish.GraphicIcon));
            this.element = ActionFactory.GetAction(this.key);
            foreach (XmlElement nodo in elementData)
            {
                switch (nodo.Name)
                {
                    case "position":
                        this.Center = new Point(System.Convert.ToInt32(nodo.ChildNodes[0].InnerText), System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                        break;
                    case "properties":
                        this.element = new FinishAction(key, nodo);
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
            this.Surface.Blit(new Surface(Finish.GraphicIcon));
        }

        public override GraphElement Clone()
        {
            return new FinishGraphic(this.key, (FinishAction)this.element.Clone(), this.Center);
        }
    }
}
