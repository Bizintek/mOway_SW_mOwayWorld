using System;
using System.Drawing;
using System.Xml;

using SdlDotNet.Graphics;

using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.CompareTemperature
{
    public class CompareTemperatureGraphic : GraphConditional
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
                        this.Surface.Blit(new Surface(CompareTemperature.GraphicIconSelected));
                    else
                    {
                        this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                        this.Surface.Blit(new Surface(CompareTemperature.GraphicIcon));
                        this.DrawOutIcons();
                    }
                }
            }
        }
        public CompareTemperatureGraphic(string key)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(CompareTemperature.NeedInit);
            this.Surface.Blit(new Surface(CompareTemperature.GraphicIcon));
        }

        public CompareTemperatureGraphic(string key, CompareTemperatureAction element, Point center)
            : base(key, element, center)
        {
            this.needInit = System.Convert.ToBoolean(CompareTemperature.NeedInit);
            this.Surface.Blit(new Surface(CompareTemperature.GraphicIcon));
        }

        public override void EnableConnector(Connector connector)
        {
            this.needInit = System.Convert.ToBoolean(CompareTemperature.NeedInit);
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(CompareTemperature.GraphicIcon));
            this.DrawOutIcons();
            base.EnableConnector(connector);
        }

        public CompareTemperatureGraphic(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
            : base(key)
        {
            this.Surface.Blit(new Surface(CompareTemperature.GraphicIcon));
            foreach (XmlElement nodo in elementData)
            {
                switch (nodo.Name)
                {
                    case "position":
                        this.Center = new Point(System.Convert.ToInt32(nodo.ChildNodes[0].InnerText), System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                        break;
                    case "properties":
                        this.element = new CompareTemperatureAction(key, nodo, variables);
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
            this.Surface.Blit(new Surface(CompareTemperature.GraphicIcon));
            this.DrawOutIcons();
        }

        public override GraphElement Clone()
        {
            return new CompareTemperatureGraphic(this.key, (CompareTemperatureAction)this.element.Clone(), this.Center);
        }
    }
}
