using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;

using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.StartRf
{
    public class StartRfGraphic : GraphConditional
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
                        this.Surface.Blit(new Surface(StartRf.GraphicIconSelected));
                    else
                    {
                        this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                        this.Surface.Blit(new Surface(StartRf.GraphicIcon));
                        this.DrawOutIcons();
                    }
                }
            }
        }
        public StartRfGraphic(string key)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(StartRf.NeedInit);
            this.Surface.Blit(new Surface(StartRf.GraphicIcon));
        }

        public StartRfGraphic(string key, StartRfAction element, Point center)
            : base(key, element, center)
        {
            this.needInit = System.Convert.ToBoolean(StartRf.NeedInit);
            this.Surface.Blit(new Surface(StartRf.GraphicIcon));
        }

        public StartRfGraphic(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(StartRf.NeedInit);
            this.Surface.Blit(new Surface(StartRf.GraphicIcon));
            foreach (XmlElement nodo in elementData)
            {
                switch (nodo.Name)
                {
                    case "position":
                        this.Center = new Point(System.Convert.ToInt32(nodo.ChildNodes[0].InnerText), System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                        break;
                    case "properties":
                        this.element = new StartRfAction(key, nodo);
                        break;
                    case "previous":
                        break;
                    case "nextTrue":
                        break;
                    case "nextFalse":
                        break;
                    default:
                        throw new GraphException("Error al crear GraphStart");
                }
            }
        }

        public override void EnableConnector(Connector connector)
        {
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(StartRf.GraphicIcon));
            this.DrawOutIcons();
            base.EnableConnector(connector);
        }

        public override void DisableConnectors()
        {
            base.DisableConnectors();
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(StartRf.GraphicIcon));
            this.DrawOutIcons();
        }

        public override GraphElement Clone()
        {
            return new StartRfGraphic(this.key, (StartRfAction)this.element.Clone(), this.Center);
        }
    }
}
