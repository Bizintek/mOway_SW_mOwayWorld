using System;
using System.Xml;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;

using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.StopRf
{
    public class StopRfGraphic : GraphModule
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
                        this.Surface.Blit(new Surface(StopRf.GraphicIconSelected));
                    else
                    {
                        this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                        this.Surface.Blit(new Surface(StopRf.GraphicIcon));
                    }
                }
            }
        }
        public StopRfGraphic(string key)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(StopRf.NeedInit);
            this.Surface.Blit(new Surface(StopRf.GraphicIcon));
        }

        public StopRfGraphic(string key, StopRfAction element, Point center)
            : base(key, element, center)
        {
            this.needInit = System.Convert.ToBoolean(StopRf.NeedInit);
            this.Surface.Blit(new Surface(StopRf.GraphicIcon));
        }

        public StopRfGraphic(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(StopRf.NeedInit);
            this.Surface.Blit(new Surface(StopRf.GraphicIcon));
            foreach (XmlElement nodo in elementData)
            {
                switch (nodo.Name)
                {
                    case "position":
                        this.Center = new Point(System.Convert.ToInt32(nodo.ChildNodes[0].InnerText), System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                        break;
                    case "properties":
                        this.element = new StopRfAction(key, nodo);
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
            this.Surface.Blit(new Surface(StopRf.GraphicIcon));
            base.EnableConnector(connector);
        }

        public override void DisableConnectors()
        {
            base.DisableConnectors();
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(StopRf.GraphicIcon));
        }

        public override GraphElement Clone()
        {
            return new StopRfGraphic(this.key, (StopRfAction)this.element.Clone(), this.Center);
        }
    }
}
