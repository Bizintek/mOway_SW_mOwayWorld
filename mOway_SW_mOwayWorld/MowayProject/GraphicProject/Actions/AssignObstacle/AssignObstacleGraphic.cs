using System;
using System.Drawing;
using System.Xml;

using SdlDotNet.Graphics;

using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.AssignObstacle
{
    public class AssignObstacleGraphic : GraphModule
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
                        this.Surface.Blit(new Surface(AssignObstacle.GraphicIconSelected));
                    else
                    {
                        this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                        this.Surface.Blit(new Surface(AssignObstacle.GraphicIcon));
                    }
                }
            }
        }
        public AssignObstacleGraphic(string key)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(AssignObstacle.NeedInit);
            this.Surface.Blit(new Surface(AssignObstacle.GraphicIcon));
        }

        public AssignObstacleGraphic(string key, AssignObstacleAction element, Point center)
            : base(key, element, center)
        {
            this.needInit = System.Convert.ToBoolean(AssignObstacle.NeedInit);
            this.Surface.Blit(new Surface(AssignObstacle.GraphicIcon));
        }

        public AssignObstacleGraphic(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(AssignObstacle.NeedInit);
            this.Surface.Blit(new Surface(AssignObstacle.GraphicIcon));
            foreach (XmlElement nodo in elementData)
            {
                switch (nodo.Name)
                {
                    case "position":
                        this.Center = new Point(System.Convert.ToInt32(nodo.ChildNodes[0].InnerText), System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                        break;
                    case "properties":
                        this.element = new AssignObstacleAction(key, nodo, variables);
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
            this.Surface.Blit(new Surface(AssignObstacle.GraphicIcon));
        }

        public override void DisableConnectors()
        {
            base.DisableConnectors();
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(AssignObstacle.GraphicIcon));
        }

        public override GraphElement Clone()
        {
            return new AssignObstacleGraphic(this.key, (AssignObstacleAction)this.element.Clone(), this.Center);
        }
    }
}
