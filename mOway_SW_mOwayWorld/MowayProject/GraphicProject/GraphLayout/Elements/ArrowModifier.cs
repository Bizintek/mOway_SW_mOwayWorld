using System;
using System.Drawing;
using System.Text;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;

namespace Moway.Project.GraphicProject.GraphLayout.Elements
{
    public class ArrowModifier : Sprite
    {
        #region Constants

        private int TOLERANCE = 1;

        #endregion

        public ArrowModifier() { }

        public override bool IntersectsWith(Point point)
        {
            if ((point.X >= this.Left - TOLERANCE) && (point.X <= this.Right + TOLERANCE) && (point.Y >= this.Top - TOLERANCE) && (point.Y <= this.Bottom + TOLERANCE))
                return true;
            return false;
        }
    }

    public class SquareModifier : ArrowModifier
    {
        public SquareModifier(Point position)
        {
            this.Surface = new Surface(ElementGraphics.squareModifierGraphic);
            this.Center = position;
            this.Visible = false;
        }
    }

    public class HorizontalModifier : ArrowModifier
    {
        public HorizontalModifier(Point position)
        {
            this.Surface = new Surface(ElementGraphics.horizontalModifierGraphic);
            this.Center = position;
            this.Visible = false;
        }
    }

    public class VerticalModifier : ArrowModifier
    {
        public VerticalModifier(Point position)
        {
            this.Surface = new Surface(ElementGraphics.verticalModifierGraphic);
            this.Center = position;
            this.Visible = false;
        }
    }

    public class ConnectorModifier : ArrowModifier
    {
        #region Constants

        private int RADIOUS = 6;

        #endregion

        public ConnectorModifier(Point position)
        {
            this.Surface = new Surface(ElementGraphics.connectorGraphic);
            this.Center = position;
            this.Visible = false;
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
