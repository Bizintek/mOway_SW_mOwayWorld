using System;
using System.Drawing;
using System.Text;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    public class TempGraphSegment : Sprite
    {
        #region Attributes

        private Point startPoint;
        private Point endPoint;

        #endregion

        public TempGraphSegment(Point startPoint, Point endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.Surface = new Surface(new Size(1, 1));
            this.Position = new Point(-1, -1);
        }

        public void UpdateArrow(Point location)
        {

        }
    }
}
