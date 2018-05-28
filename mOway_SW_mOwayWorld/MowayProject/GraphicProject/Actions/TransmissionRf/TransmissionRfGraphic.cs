using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;

using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.TransmissionRf
{
    public class TransmissionRfGraphic : GraphConditional
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
                        this.Surface.Blit(new Surface(TransmissionRf.GraphicIconSelected));
                    else
                    {
                        this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                        this.Surface.Blit(new Surface(TransmissionRf.GraphicIcon));
                        this.DrawOutIcons();
                    }
                }
            }
        }
        public TransmissionRfGraphic(string key)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(TransmissionRf.NeedInit);
            this.Surface.Blit(new Surface(TransmissionRf.GraphicIcon));
        }

        public TransmissionRfGraphic(string key, TransmissionRfAction element, Point center)
            : base(key, element, center)
        {
            this.needInit = System.Convert.ToBoolean(TransmissionRf.NeedInit);
            this.Surface.Blit(new Surface(TransmissionRf.GraphicIcon));
        }

        public override void EnableConnector(Connector connector)
        {
            this.needInit = System.Convert.ToBoolean(TransmissionRf.NeedInit);
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(TransmissionRf.GraphicIcon));
            this.DrawOutIcons();
            base.EnableConnector(connector);
        }

        public TransmissionRfGraphic(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
            : base(key)
        {
            this.Surface.Blit(new Surface(TransmissionRf.GraphicIcon));
            foreach (XmlElement nodo in elementData)
            {
                switch (nodo.Name)
                {
                    case "position":
                        this.Center = new Point(System.Convert.ToInt32(nodo.ChildNodes[0].InnerText), System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                        break;
                    case "properties":
                        this.element = new TransmissionRfAction(key, nodo, variables);
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

        public override void DisableConnectors()
        {
            base.DisableConnectors();
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(TransmissionRf.GraphicIcon));
            this.DrawOutIcons();
        }

        public override GraphElement Clone()
        {
            return new TransmissionRfGraphic(this.key, (TransmissionRfAction)this.element.Clone(), this.Center);
        }
    }
}
