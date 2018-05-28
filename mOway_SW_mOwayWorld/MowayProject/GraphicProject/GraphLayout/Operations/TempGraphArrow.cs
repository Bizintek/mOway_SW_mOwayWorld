using System;
using System.Drawing;
using System.Collections.Generic;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Graphics.Primitives;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    public class TempGraphArrow : Sprite
    {
        public TempGraphArrow()
        {
            this.Surface = new Surface(new Size(1, 1));
            this.Position = new Point(-1, -1);
        }

        public void UpdateArrow(Point initialPoint, Point finalPoint)
        {
            Point location = new Point(Math.Min(initialPoint.X, finalPoint.X), Math.Min(initialPoint.Y, finalPoint.Y));
            Size size = new Size(Math.Abs(finalPoint.X - initialPoint.X) + 1, Math.Abs(finalPoint.Y - initialPoint.Y) + 1);
            this.Surface = new Surface(size);
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Draw(new Line(new Point(initialPoint.X - location.X, initialPoint.Y - location.Y), new Point(finalPoint.X - location.X, finalPoint.Y - location.Y)), GraphDiagram.ARROWS_COLOR);
            //The color of transparency is indicated
            this.Transparent = true;
            this.TransparentColor = GraphDiagram.TRASPARENT_COLOR;
            this.Position = location;
        }

        public void UpdateArrow(List<Point> points, Color arrowColor)
        {
            Point minPoint = GraphDiagram.MinPoint(points);
            Point maxPoint = GraphDiagram.MaxPoint(points);
            Size size = new Size(maxPoint.X - minPoint.X + 1, maxPoint.Y - minPoint.Y + 1);

            this.Surface = new Surface(size);
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            for (int i = 0; i < (points.Count - 1); i++)
                this.Surface.Draw(new Line(new Point(points[i].X - minPoint.X, points[i].Y - minPoint.Y), new Point(points[i + 1].X - minPoint.X, points[i + 1].Y - minPoint.Y)), arrowColor);
            //The color of transparency is indicated
            this.Transparent = true;
            this.TransparentColor = GraphDiagram.TRASPARENT_COLOR;
            this.Position = minPoint;
        }
    }
}
