﻿using System;
using System.Xml;
using System.Drawing;

using SdlDotNet.Graphics;

using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Pause
{
    public class PauseGraphic : GraphModule
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
                        this.Surface.Blit(new Surface(Pause.GraphicIconSelected));
                    else
                    {
                        this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                        this.Surface.Blit(new Surface(Pause.GraphicIcon));
                    }
                }
            }
        }
        public PauseGraphic(string key)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(Pause.NeedInit);
            this.Surface.Blit(new Surface(Pause.GraphicIcon));
        }

        public PauseGraphic(string key, PauseAction element, Point center)
            : base(key, element, center)
        {
            this.needInit = System.Convert.ToBoolean(Pause.NeedInit);
            this.Surface.Blit(new Surface(Pause.GraphicIcon));
        }

        public override void EnableConnector(Connector connector)
        {
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Blit(new Surface(Pause.GraphicIcon));
            base.EnableConnector(connector);
        }
        public PauseGraphic(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
            : base(key)
        {
            this.needInit = System.Convert.ToBoolean(Pause.NeedInit);
            this.Surface.Blit(new Surface(Pause.GraphicIcon));
            foreach (XmlElement nodo in elementData)
            {
                switch (nodo.Name)
                {
                    case "position":
                        this.Center = new Point(System.Convert.ToInt32(nodo.ChildNodes[0].InnerText), System.Convert.ToInt32(nodo.ChildNodes[1].InnerText));
                        break;
                    case "properties":
                        this.element = new PauseAction(key, nodo, variables);
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
            this.Surface.Blit(new Surface(Pause.GraphicIcon));
        }

        public override GraphElement Clone()
        {
            return new PauseGraphic(this.key, (PauseAction)this.element.Clone(), this.Center);
        }
    }
}
