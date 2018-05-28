using System;
using System.Drawing;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;

namespace Moway.Project.GraphicProject.GraphLayout.Elements
{
    public abstract class ArrowSegment : Sprite
    {
        #region Attributes

        protected Point startPoint;
        protected Point endPoint;
        protected GraphSide prevSide;
        protected bool selected = false;
        protected ArrowModifier modifier;

        #endregion

        #region Properties

        public Point StartPoint
        {
            get { return this.startPoint; }
            set { this.startPoint = value; }
        }
        public Point EndPoint
        {
            get { return this.endPoint; }
            set { this.endPoint = value; }
        }
        public ArrowModifier Modifier { get { return this.modifier; } }
        public virtual bool Selected
        {
            get { return this.selected; }
            set
            {
                if (this.selected != value)
                {
                    this.selected = value;
                    this.UpdateSegment();
                }
            }
        }

        #endregion

        public ArrowSegment(Point startPoint, Point endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        public virtual void UpdatePrevPoint(Point point)
        {
            this.prevSide = this.CalculePrevSide(point);
            this.UpdateSegment();
        }

        protected virtual void UpdateSegment() { }

        public virtual bool EnableModifiers()
        {
            modifier.Visible = true;
            this.UpdateSegment();
            return true;
        }

        public virtual void DisableModifiers()
        {
            modifier.Visible = false;
            this.UpdateSegment();
        }

        protected GraphSide CalculePrevSide(Point prevPoint)
        {
            if (prevPoint.X != startPoint.X)
                if (prevPoint.X < this.startPoint.X)
                    return GraphSide.Left;
                else
                    return GraphSide.Right;
            else if (prevPoint.Y < this.startPoint.Y)
                return GraphSide.Top;
            else
                return GraphSide.Bottom;
        }

        public override bool IntersectsWith(Point point)
        {
            if ((point.X >= this.Left + 3) && (point.X <= this.Right - 3) && (point.Y >= this.Top + 3) && (point.Y <= this.Bottom - 3))
                return true;
            Point relativePoint = new Point(point.X - this.Position.X, point.Y - this.Position.Y);
            if (modifier.Visible && (modifier.IntersectsWith(relativePoint)))
                return true;
            return false;
        }

        public ArrowModifier GetModifier(Point point)
        {
            Point relativePoint = new Point(point.X - this.Position.X, point.Y - this.Position.Y);
            if (modifier.Visible && (modifier.IntersectsWith(relativePoint)))
                return modifier;
            return null;
        }
    }

    public class StartSegment : ArrowSegment
    {
        #region Attributes

        private GraphSide startSide;

        #endregion

        public StartSegment(Connector connector, Point startPoint, Point endPoint, Point arrowPosition)
            : base(startPoint, endPoint)
        {
            this.startSide = connector.Side;
            switch (this.startSide)
            {
                case GraphSide.Right:
                    this.Surface = new Surface(this.endPoint.X - this.startPoint.X + 4, 10);
                    this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                    this.Surface.Blit(new Surface(ArrowGraphics.StartRightGraphic), new Point(4, 0));
                    this.Position = new Point(this.startPoint.X - arrowPosition.X - 4, this.startPoint.Y - arrowPosition.Y - 5);
                    this.modifier = new ConnectorModifier(new Point(4, 5));
                    break;
                case GraphSide.Top:
                    this.Surface = new Surface(10, this.startPoint.Y - this.endPoint.Y + 4);
                    this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                    this.Surface.Blit(new Surface(ArrowGraphics.StartTopGraphic), new Point(0, this.Surface.Height - 24));
                    this.Position = new Point(this.endPoint.X - arrowPosition.X - 5, this.endPoint.Y - arrowPosition.Y);
                    this.modifier = new ConnectorModifier(new Point(5, this.Surface.Height - 4));
                    break;
                case GraphSide.Left:
                    this.Surface = new Surface(this.startPoint.X - this.endPoint.X + 4, 10);
                    this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                    this.Surface.Blit(new Surface(ArrowGraphics.StartLeftGraphic), new Point(this.Width - 24, 0));
                    this.Position = new Point(this.endPoint.X - arrowPosition.X, this.endPoint.Y - arrowPosition.Y - 5);
                    this.modifier = new ConnectorModifier(new Point(this.Surface.Width - 4, 5));
                    break;
                case GraphSide.Bottom:
                    this.Surface = new Surface(10, this.endPoint.Y - this.startPoint.Y + 4);
                    this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                    this.Surface.Blit(new Surface(ArrowGraphics.StartBottomGraphic), new Point(0, 4));
                    this.Position = new Point(this.startPoint.X - arrowPosition.X - 5, this.startPoint.Y - arrowPosition.Y - 4);
                    this.modifier = new ConnectorModifier(new Point(5, 4));
                    break;
            }
            this.Transparent = true;
            this.TransparentColor = GraphDiagram.TRASPARENT_COLOR;
        }

        public override void UpdatePrevPoint(Point point)
        {
            throw new Exception("this method van not be calle");
        }

        protected override void UpdateSegment()
        {
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            switch (this.startSide)
            {
                case GraphSide.Right:
                    if (!this.selected)
                        this.Surface.Blit(new Surface(ArrowGraphics.StartRightGraphic), new Point(4, 0));
                    else
                        this.Surface.Blit(new Surface(ArrowGraphics.StartRightGraphicSelected), new Point(4, 0));
                    break;
                case GraphSide.Top:
                    if (!this.selected)
                        this.Surface.Blit(new Surface(ArrowGraphics.StartTopGraphic), new Point(0, this.Surface.Height - 24));
                    else
                        this.Surface.Blit(new Surface(ArrowGraphics.StartTopGraphicSelected), new Point(0, this.Surface.Height - 24));
                    break;
                case GraphSide.Left:
                    if (!this.selected)
                        this.Surface.Blit(new Surface(ArrowGraphics.StartLeftGraphic), new Point(this.Width - 24, 0));
                    else
                        this.Surface.Blit(new Surface(ArrowGraphics.StartLeftGraphicSelected), new Point(this.Width - 24, 0));
                    break;
                case GraphSide.Bottom:
                    if (!this.selected)
                        this.Surface.Blit(new Surface(ArrowGraphics.StartBottomGraphic), new Point(0, 4));
                    else
                        this.Surface.Blit(new Surface(ArrowGraphics.StartBottomGraphicSelected), new Point(0, 4));
                    break;
            }
            this.Surface.Blit(this.modifier);
        }
    }

    public class LineSegment : ArrowSegment
    {
        public LineSegment(Point startPoint, Point endPoint, Point prevPoint, Point arrowPosition)
            : base(startPoint, endPoint)
        {
            this.prevSide = this.CalculePrevSide(prevPoint);
            if (this.startPoint.X != this.endPoint.X)
            {
                //horizontal arrow
                this.Surface = new Surface(Math.Abs(this.startPoint.X - this.endPoint.X) + 4, 10);
                for (int i = 0; i < this.Width; i += 20)
                    this.Surface.Blit(new Surface(ArrowGraphics.LineHorizontalGraphic), new Point(i, 0));
                if (this.prevSide == GraphSide.Top)
                    if (this.startPoint.X < this.endPoint.X)
                        this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomLeftGraphic), new Point(0, 3));
                    else
                        this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomRightGraphic), new Point(this.Width - 4, 3));
                else if (this.prevSide == GraphSide.Bottom)
                    if (this.startPoint.X < this.endPoint.X)
                        this.Surface.Blit(new Surface(ArrowGraphics.CornerTopLeftGraphic), new Point(0, 3));
                    else
                        this.Surface.Blit(new Surface(ArrowGraphics.CornerTopRightGraphic), new Point(this.Width - 4, 3));
                this.Position = new Point(Math.Min(this.startPoint.X, this.endPoint.X) - arrowPosition.X - 2, this.startPoint.Y - arrowPosition.Y - 5);
                this.modifier = new HorizontalModifier(new Point(this.Size.Width / 2, this.Size.Height / 2));
            }
            else
            {
                //vertical arrow
                this.Surface = new Surface(10, Math.Abs(this.startPoint.Y - this.endPoint.Y) + 4);
                for (int i = 0; i < this.Height; i += 20)
                    this.Surface.Blit(new Surface(ArrowGraphics.LineVerticalGraphic), new Point(0, i));
                if (this.prevSide == GraphSide.Right)
                    if (this.startPoint.Y < this.endPoint.Y)
                        this.Surface.Blit(new Surface(ArrowGraphics.CornerTopLeftGraphic), new Point(3, 0));
                    else
                        this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomLeftGraphic), new Point(3, this.Height - 4));
                else if (this.prevSide == GraphSide.Left)
                    if (this.startPoint.Y < this.endPoint.Y)
                        this.Surface.Blit(new Surface(ArrowGraphics.CornerTopRightGraphic), new Point(3, 0));
                    else
                        this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomRightGraphic), new Point(3, this.Height - 4));
                this.Position = new Point(this.startPoint.X - arrowPosition.X - 5, Math.Min(this.startPoint.Y, this.endPoint.Y) - arrowPosition.Y - 2);
                this.modifier = new VerticalModifier(new Point(this.Size.Width / 2, this.Size.Height / 2));
            }
            this.Transparent = true;
            this.TransparentColor = GraphDiagram.TRASPARENT_COLOR;
        }


        protected override void UpdateSegment()
        {
            if (this.startPoint.X != this.endPoint.X)
            {
                //horizontal arrow
                for (int i = 0; i < this.Width; i += 20)
                    if (!this.selected)
                        this.Surface.Blit(new Surface(ArrowGraphics.LineHorizontalGraphic), new Point(i, 0));
                    else
                        this.Surface.Blit(new Surface(ArrowGraphics.LineHorizontalGraphicSelected), new Point(i, 0));
                if (this.prevSide == GraphSide.Top)
                    if (this.startPoint.X < this.endPoint.X)
                        if (!this.selected)
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomLeftGraphic), new Point(0, 3));
                        else
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomLeftGraphicSelected), new Point(0, 3));
                    else
                        if (!this.selected)
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomRightGraphic), new Point(this.Width - 4, 3));
                        else
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomRightGraphicSelected), new Point(this.Width - 4, 3));
                else if (this.prevSide == GraphSide.Bottom)
                    if (this.startPoint.X < this.endPoint.X)
                        if (!this.selected)
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerTopLeftGraphic), new Point(0, 3));
                        else
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerTopLeftGraphicSelected), new Point(0, 3));
                    else
                        if (!this.selected)
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerTopRightGraphic), new Point(this.Width - 4, 3));
                        else
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerTopRightGraphicSelected), new Point(this.Width - 4, 3));
            }
            else
            {
                //vertical arrow
                for (int i = 0; i < this.Height; i += 20)
                    if (!this.selected)
                        this.Surface.Blit(new Surface(ArrowGraphics.LineVerticalGraphic), new Point(0, i));
                    else
                        this.Surface.Blit(new Surface(ArrowGraphics.LineVerticalGraphicSelected), new Point(0, i));
                if (this.prevSide == GraphSide.Right)
                    if (this.startPoint.Y < this.endPoint.Y)
                        if (!this.selected)
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerTopLeftGraphic), new Point(3, 0));
                        else
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerTopLeftGraphicSelected), new Point(3, 0));
                    else
                        if (!this.selected)
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomLeftGraphic), new Point(3, this.Height - 4));
                        else
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomLeftGraphicSelected), new Point(3, this.Height - 4));
                else if (this.prevSide == GraphSide.Left)
                    if (this.startPoint.Y < this.endPoint.Y)
                        if (!this.selected)
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerTopRightGraphic), new Point(3, 0));
                        else
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerTopRightGraphicSelected), new Point(3, 0));
                    else
                        if (!this.selected)
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomRightGraphic), new Point(3, this.Height - 4));
                        else
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomRightGraphicSelected), new Point(3, this.Height - 4));
            }
            this.Surface.Blit(this.modifier);
        }
    }

    public class EndSegment : ArrowSegment
    {
        #region Attributes

        private GraphSide endSide;

        #endregion

        public EndSegment(Connector connector, Point startPoint, Point endPoint, Point prevPoint, Point arrowPosition)
            : base(startPoint, endPoint)
        {
            this.endSide = connector.Side;
            this.prevSide = this.CalculePrevSide(prevPoint);
            switch (this.endSide)
            {
                case GraphSide.Right:
                    this.Surface = new Surface(this.startPoint.X - this.endPoint.X + 6, 10);
                    this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                    this.Surface.Blit(new Surface(ArrowGraphics.EndRightGraphic), new Point(4, 0));
                    if (this.prevSide == GraphSide.Top)
                        this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomRightGraphic), new Point(this.Width - 4, 3));
                    else if (this.prevSide == GraphSide.Bottom)
                        this.Surface.Blit(new Surface(ArrowGraphics.CornerTopRightGraphic), new Point(this.Width - 4, 3));
                    this.Position = new Point(this.endPoint.X - arrowPosition.X - 4, this.endPoint.Y - arrowPosition.Y - 5);
                    this.modifier = new ConnectorModifier(new Point(4, 5));
                    break;
                case GraphSide.Top:
                    this.Surface = new Surface(10, this.endPoint.Y - this.startPoint.Y + 6);
                    this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                    this.Surface.Blit(new Surface(ArrowGraphics.EndTopGraphic), new Point(0, this.Height - 26));
                    if (this.prevSide == GraphSide.Right)
                        this.Surface.Blit(new Surface(ArrowGraphics.CornerTopLeftGraphic), new Point(3, 0));
                    else if (this.prevSide == GraphSide.Left)
                        this.Surface.Blit(new Surface(ArrowGraphics.CornerTopRightGraphic), new Point(3, 0));
                    this.Position = new Point(this.startPoint.X - arrowPosition.X - 5, this.startPoint.Y - arrowPosition.Y - 2);
                    this.modifier = new ConnectorModifier(new Point(5, this.Surface.Height - 4));
                    break;
                case GraphSide.Left:
                    this.Surface = new Surface(this.endPoint.X - this.startPoint.X + 6, 10);
                    this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                    this.Surface.Blit(new Surface(ArrowGraphics.EndLeftGraphic), new Point(this.Width - 24, 0));
                    if (this.prevSide == GraphSide.Top)
                        this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomLeftGraphic), new Point(0, 3));
                    else if (this.prevSide == GraphSide.Bottom)
                        this.Surface.Blit(new Surface(ArrowGraphics.CornerTopLeftGraphic), new Point(0, 3));
                    this.Position = new Point(this.startPoint.X - arrowPosition.X - 2, this.startPoint.Y - arrowPosition.Y - 5);
                    this.modifier = new ConnectorModifier(new Point(this.Surface.Width - 4, 5));
                    break;
                case GraphSide.Bottom:
                    this.Surface = new Surface(10, this.startPoint.Y - this.endPoint.Y + 6);
                    this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
                    this.Surface.Blit(new Surface(ArrowGraphics.EndBottomGraphic), new Point(0, 4));
                    if (this.prevSide == GraphSide.Right)
                        this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomLeftGraphic), new Point(3, this.Height - 4));
                    else if (this.prevSide == GraphSide.Left)
                        this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomRightGraphic), new Point(3, this.Height - 4));
                    this.Position = new Point(this.endPoint.X - arrowPosition.X - 5, this.endPoint.Y - arrowPosition.Y - 4);
                    this.modifier = new ConnectorModifier(new Point(5, 4));
                    break;
            }
            this.Transparent = true;
            this.TransparentColor = GraphDiagram.TRASPARENT_COLOR;
        }

        protected override void UpdateSegment()
        {
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            switch (this.endSide)
            {
                case GraphSide.Right:
                    if (!this.selected)
                        this.Surface.Blit(new Surface(ArrowGraphics.EndRightGraphic), new Point(4, 0));
                    else
                        this.Surface.Blit(new Surface(ArrowGraphics.EndRightGraphicSelected), new Point(4, 0));
                    if (this.prevSide == GraphSide.Top)
                        if (!this.selected)
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomRightGraphic), new Point(this.Width - 4, 3));
                        else
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomRightGraphicSelected), new Point(this.Width - 4, 3));
                    else if (this.prevSide == GraphSide.Bottom)
                        if (!this.selected)
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerTopRightGraphic), new Point(this.Width - 4, 3));
                        else
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerTopRightGraphicSelected), new Point(this.Width - 4, 3));
                    break;
                case GraphSide.Top:
                    if (!this.selected)
                        this.Surface.Blit(new Surface(ArrowGraphics.EndTopGraphic), new Point(0, this.Height - 26));
                    else
                        this.Surface.Blit(new Surface(ArrowGraphics.EndTopGraphicSelected), new Point(0, this.Height - 26));
                    if (this.prevSide == GraphSide.Right)
                        if (!this.selected)
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerTopLeftGraphic), new Point(3, 0));
                        else
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerTopLeftGraphicSelected), new Point(3, 0));
                    else if (this.prevSide == GraphSide.Left)
                        if (!this.selected)
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerTopRightGraphic), new Point(3, 0));
                        else
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerTopRightGraphicSelected), new Point(3, 0));
                    break;
                case GraphSide.Left:
                    if (!this.selected)
                        this.Surface.Blit(new Surface(ArrowGraphics.EndLeftGraphic), new Point(this.Width - 24, 0));
                    else
                        this.Surface.Blit(new Surface(ArrowGraphics.EndLeftGraphicSelected), new Point(this.Width - 24, 0));
                    if (this.prevSide == GraphSide.Top)
                        if (!this.selected)
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomLeftGraphic), new Point(0, 3));
                        else
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomLeftGraphicSelected), new Point(0, 3));
                    else if (this.prevSide == GraphSide.Bottom)
                        if (!this.selected)
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerTopLeftGraphic), new Point(0, 3));
                        else
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerTopLeftGraphicSelected), new Point(0, 3));
                    break;
                case GraphSide.Bottom:
                    if (!this.selected)
                        this.Surface.Blit(new Surface(ArrowGraphics.EndBottomGraphic), new Point(0, 4));
                    else
                        this.Surface.Blit(new Surface(ArrowGraphics.EndBottomGraphicSelected), new Point(0, 4));
                    if (this.prevSide == GraphSide.Right)
                        if (!this.selected)
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomLeftGraphic), new Point(3, this.Height - 4));
                        else
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomLeftGraphicSelected), new Point(3, this.Height - 4));
                    else if (this.prevSide == GraphSide.Left)
                        if (!this.selected)
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomRightGraphic), new Point(3, this.Height - 4));
                        else
                            this.Surface.Blit(new Surface(ArrowGraphics.CornerBottomRightGraphicSelected), new Point(3, this.Height - 4));
                    break;
            }
            this.Surface.Blit(this.modifier);
        }
    }
}
