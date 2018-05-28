using System;
using System.Drawing;
using System.Xml;

using SdlDotNet.Graphics;

using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Obstacle
{
    public class ObstacleGraphic : GraphConditional
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
                    base.Selected = value;
                    if (base.selected)
                        this.Surface.Blit(new Surface(Obstacle.GraphicIconSelected));
                    else
                    {
                        this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                        this.Surface.Blit(new Surface(Obstacle.GraphicIcon));
                        this.DrawOutIcons();
                    }
                }
            }
        }
        public ObstacleGraphic(string key)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(Obstacle.NeedInit);
            this.Surface.Blit(new Surface(Obstacle.GraphicIcon));
        }

        public ObstacleGraphic(string key, XmlElement elementData)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(Obstacle.NeedInit);
            this.Surface.Blit(new Surface(Obstacle.GraphicIcon));
            foreach (XmlElement nodo in elementData)
            {
                switch (nodo.Name)
                {
                    case "position":
                        this.Center = new Point(System.Convert.ToInt32(nodo.ChildNodes[0].InnerText), System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                        break;
                    case "properties":
                        this.element = new ObstacleAction(key, nodo);
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

        public ObstacleGraphic(string key, ObstacleAction element, Point center)
            : base(key, element, center)
        {
            this.needInit = System.Convert.ToBoolean(Obstacle.NeedInit);
            this.Surface.Blit(new Surface(Obstacle.GraphicIcon));
        }

        public override void EnableConnector(Connector connector)
        {
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(Obstacle.GraphicIcon));
            this.DrawOutIcons();
            base.EnableConnector(connector);
        }

        public override void DisableConnectors()
        {
            base.DisableConnectors();
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(Obstacle.GraphicIcon));
            this.DrawOutIcons();
        }

        public override GraphElement Clone()
        {
            return new ObstacleGraphic(this.key, (ObstacleAction)this.element.Clone(), this.Center);
        }
    }
}
