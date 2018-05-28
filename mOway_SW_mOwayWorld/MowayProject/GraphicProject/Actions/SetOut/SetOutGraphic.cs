using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;

using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.SetOut
{
    public class SetOutGraphic : GraphModule
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
                        this.Surface.Blit(new Surface(SetOut.GraphicIconSelected));
                    else
                    {
                        this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                        this.Surface.Blit(new Surface(SetOut.GraphicIcon));
                    }
                }
            }
        }
        public SetOutGraphic(string key)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(SetOut.NeedInit);
            this.Surface.Blit(new Surface(SetOut.GraphicIcon));
        }

        public SetOutGraphic(string key, SetOutAction element, Point center)
            : base(key, element, center)
        {
            this.needInit = System.Convert.ToBoolean(SetOut.NeedInit);
            this.Surface.Blit(new Surface(SetOut.GraphicIcon));
        }

        public override void EnableConnector(Connector connector)
        {
            this.needInit = System.Convert.ToBoolean(SetOut.NeedInit);
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(SetOut.GraphicIcon));
            base.EnableConnector(connector);
        }

        public SetOutGraphic(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
            : base(key)
        {
            this.Surface.Blit(new Surface(SetOut.GraphicIcon));
            foreach (XmlElement nodo in elementData)
            {
                switch (nodo.Name)
                {
                    case "position":
                        this.Center = new Point(System.Convert.ToInt32(nodo.ChildNodes[0].InnerText), System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                        break;
                    case "properties":
                        this.element = new SetOutAction(key, nodo);
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
            this.Surface.Blit(new Surface(SetOut.GraphicIcon));
        }

        public override GraphElement Clone()
        {
            return new SetOutGraphic(this.key, (SetOutAction)this.element.Clone(), this.Center);
        }
    }
}
