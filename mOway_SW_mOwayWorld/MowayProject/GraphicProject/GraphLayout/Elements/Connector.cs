using System;
using System.Drawing;
using System.Collections.Generic;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;

namespace Moway.Project.GraphicProject.GraphLayout.Elements
{
    public enum GraphSide { Top, Bottom, Left, Right}

    public class Connector : Sprite
    {
        #region Constants

        private const int RADIOUS = 8;

        #endregion

        #region Attributes

        private int idConnector;
        private GraphElement parent;
        private List<GraphArrow> connections = new List<GraphArrow>();
        private GraphSide side;

        #endregion

        #region Properties

        public int IdConnector { get { return this.idConnector; } }
        public GraphElement Parent { get { return this.parent; } }
        public List<GraphArrow> Connections { get { return this.connections; } }
        public bool IsEmpty { get { return (this.connections.Count == 0) ? true : false; } }
        public GraphSide Side { get { return this.side; } }
        public Point AbsCenter { get { return new Point(this.parent.Position.X + this.Center.X, this.parent.Position.Y + this.Center.Y); } }

        #endregion

        public Connector(int idConnector, GraphElement parent, Point position, GraphSide side)
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
            //the position of the points from the center of the element was calculated
            Point p = new Point(point.X - this.Center.X, point.Y - this.Center.Y);
            //the distance from the center to the point is calculated
            double d = Math.Sqrt((p.X * p.X) + (p.Y * p.Y));
            //if the distance is less than 17, the mouse is inside the element
            if (d < RADIOUS)
                return true;
            else
                return false;
        }
    }
}

