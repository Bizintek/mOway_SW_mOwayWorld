using System;
using System.Drawing;
using System.Collections.Generic;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;

namespace Moway.Project.GraphicProject.GraphLayout.Elements
{
    public enum GraphSide { Top, Bottom, Left, Right}

    public class GraphConnector : Sprite
    {
        #region Constantes

        private const int RADIOUS = 10;

        #endregion

        #region Atributos

        private int idConnector;
        private GraphElement parent;
        private List<GraphArrow> connections = new List<GraphArrow>();
        private GraphSide side;

        #endregion

        #region Propiedades

        public int IdConnector { get { return this.idConnector; } }
        public GraphElement Parent { get { return this.parent; } }
        public List<GraphArrow> Connections { get { return this.connections; } }
        public bool IsEmpty { get { return (this.connections.Count == 0) ? true : false; } }
        public GraphSide Side { get { return this.side; } }
        public Point AbsCenter { get { return new Point(this.parent.Position.X + this.Center.X, this.parent.Position.Y + this.Center.Y); } }

        #endregion

        public GraphConnector(int idConnector, GraphElement parent, Point position, GraphSide side)
        {
            this.idConnector = idConnector;
            this.parent = parent;
            this.side = side;
            this.Surface = new Surface(ElementGraphics.connectorGraphic);
            this.Center = position;
            this.Visible = false;
        }

        public void AddArrow(GraphArrow arrow)
        {
                this.connections.Add(arrow);
        }

        public void RemoveArrow(GraphArrow arrow)
        {
            if (!this.connections.Contains(arrow))
                throw new GraphException("This connector don't have the arrow");
            this.connections.Remove(arrow);
        }

        public override bool IntersectsWith(Point point)
        {
            //se calculo la posición del puntos desde el centro del elemento
            Point p = new Point(point.X - this.Center.X, point.Y - this.Center.Y);
            //se calcula la distancia desde el centro hasta el punto
            double d = Math.Sqrt((p.X * p.X) + (p.Y * p.Y));
            //si la distancia es menor de 17, el ratón está dentro del elemento
            if (d < RADIOUS)
                return true;
            else
                return false;

            /* Esta condición es para tratarla como un cuadrado
             * if ((point.X >= this.Center.X - TOLERANCE) && (point.X <= this.Center.X + TOLERANCE) && (point.Y >= this.Center.Y - TOLERANCE) && (point.Y <= this.Center.Y + TOLERANCE))
                return true;
            else
                return false;*/
           }
    }
}

