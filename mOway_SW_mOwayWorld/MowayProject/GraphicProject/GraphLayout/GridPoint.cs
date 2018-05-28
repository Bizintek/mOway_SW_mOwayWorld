using System;
using System.Drawing;
using System.Text;

namespace Moway.Project.GraphicProject.GraphLayout
{
    public enum GridState { Free, Busy };

    public class GridPoint : IComparable
    {
        #region Attributes

        private Point location;
        private GridState state;
        private int value = System.Int32.MaxValue;

        #endregion

        #region Properties

        public Point Location { get { return this.location; } }
        public GridState State
        {
            set { this.state = value; }
            get { return this.state; }
        }
        public int Value
        {
            set { this.value = value; }
            get { return this.value; }
        }

        #endregion

        public GridPoint(Point location, GridState state)
        {
            this.location = location;
            this.state = state;
        }

        int IComparable.CompareTo(object o)
        {
            if (((GridPoint)o).value < this.value)
                return 1;
            else if (((GridPoint)o).value > this.value)
                return -1;
            return 0;
        }
    }
}
