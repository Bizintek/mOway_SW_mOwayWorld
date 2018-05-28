using System;
using System.Xml;
using System.Drawing;

using SdlDotNet.Graphics;

using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Start
{
    public class StartGraphic : GraphStart
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
                        this.Surface.Blit(new Surface(Start.GraphicIconSelected));
                    else
                    {
                        this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                        this.Surface.Blit(new Surface(Start.GraphicIcon));
                    }
                }
            }
        }

        public StartGraphic(DiagramLayout.Elements.Start start)
            : base()
        {
            this.key = Start.Key;
            this.Surface.Blit(new Surface(Start.GraphicIcon));
            this.element = start;
        }
      

        public StartGraphic(string key, XmlNode xmlElement)
            : base()
        {
            this.key = key;
            this.Surface.Blit(new Surface(Start.GraphicIcon));
            this.element = new StartAction();
            foreach (XmlElement nodo in xmlElement)
            {
                switch (nodo.Name)
                { 
                    case "position":
                        this.Center = new Point(System.Convert.ToInt32(nodo.ChildNodes[0].InnerText), System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                        break;
                    case "properties":
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
            this.Surface.Blit(new Surface(Start.GraphicIcon));
            base.EnableConnector(connector);
        }

        public override void DisableConnectors()
        {
            base.DisableConnectors();
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(Start.GraphicIcon));
        }
    }
}
