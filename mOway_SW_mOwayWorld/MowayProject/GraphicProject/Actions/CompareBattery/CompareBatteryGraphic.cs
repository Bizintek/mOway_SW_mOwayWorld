using System;
using System.Drawing;
using System.Xml;

using SdlDotNet.Graphics;

using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.CompareBattery
{
    public class CompareBatteryGraphic : GraphConditional
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
                        this.Surface.Blit(new Surface(CompareBattery.GraphicIconSelected));
                    else
                    {
                        this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                        this.Surface.Blit(new Surface(CompareBattery.GraphicIcon));
                        this.DrawOutIcons();
                    }
                }
            }
        }

        public CompareBatteryGraphic(string key)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(CompareBattery.NeedInit);
            this.Surface.Blit(new Surface(CompareBattery.GraphicIcon));
        }

        public CompareBatteryGraphic(string key, CompareBatteryAction element, Point center)
            : base(key, element, center)
        {
            this.needInit = System.Convert.ToBoolean(CompareBattery.NeedInit);
            this.Surface.Blit(new Surface(CompareBattery.GraphicIcon));
        }

        public CompareBatteryGraphic(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(CompareBattery.NeedInit);
            this.Surface.Blit(new Surface(CompareBattery.GraphicIcon));
            foreach (XmlElement nodo in elementData)
            {
                switch (nodo.Name)
                {
                    case "position":
                        this.Center = new Point(System.Convert.ToInt32(nodo.ChildNodes[0].InnerText), System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                        break;
                    case "properties":
                        this.element = new CompareBatteryAction(key, nodo, variables);
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
            this.Surface.Blit(new Surface(CompareBattery.GraphicIcon));
            this.DrawOutIcons();
            base.EnableConnector(connector);
        }

        public override void DisableConnectors()
        {
            base.DisableConnectors();
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(CompareBattery.GraphicIcon));
            this.DrawOutIcons();
        }

        public override GraphElement Clone()
        {
            return new CompareBatteryGraphic(this.key, (CompareBatteryAction)this.element.Clone(), this.Center);
        }
    }
}
