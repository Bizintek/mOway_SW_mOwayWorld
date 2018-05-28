using System;
using System.Drawing;
using System.Text;

namespace Moway.Project.GraphicProject.GraphLayout
{
    public enum GridState { Free, Busy };

    public class GridLocation : IComparable
    {
        #region Atributos

        private Point location;
        private GridState state;
        private int value = System.Int32.MaxValue;

        #endregion

        #region Propiedades

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

        public GridLocation(Point location, GridState state)
        {
            this.location = location;
            this.state = state;
        }

        int IComparable.CompareTo(object o)
        {
            if (((GridLocation)o).value < this.value)
                return 1;
            else if (((GridLocation)o).value > this.value)
                return -1;
            return 0;
        }
    }
}
