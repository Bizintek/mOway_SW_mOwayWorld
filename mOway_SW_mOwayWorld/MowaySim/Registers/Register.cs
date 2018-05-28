using System;

namespace Moway.Simulator.Registers
{
    /// <summary>
    /// Represents a log of the memory of the simulated MOway
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class Register : IComparable
    {
        #region Attributes

        /// <summary>
        /// Log name
        /// </summary>
        private string name;
        /// <summary>
        /// Log Value
        /// </summary>
        private byte value;

        #endregion

        #region Properties

        /// <summary>
        /// Log name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                if (this.NameChanged != null)
                    this.NameChanged(this, new EventArgs());
            }
        }
        /// <summary>
        /// Log Value
        /// </summary>
        public byte Value
        {
            get { return this.value; }
            set { 
                this.value = value;
                if (this.ValueChanged != null)
                    this.ValueChanged(this, new EventArgs());
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Change in Log name
        /// </summary>
        public event EventHandler NameChanged;
        /// <summary>
        /// Change in Log value
        /// </summary>
        public event EventHandler ValueChanged;

        #endregion

        /// <summary>
        /// Builder a log
        /// </summary>
        /// <param name="name">Log name</param>
        /// <param name="value">Log Value</param>
        public Register(string name, byte value)
        {
            this.name = name;
            this.value = value;
        }

        #region Public methods

        /// <summary>
        /// Compare the name of the record with another data
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(Object obj)
        {
            return String.Compare(this.name, ((Register)obj).name);
        }

        #endregion


        /// <summary>
        /// Rewriting the ToString method for debugging more easily
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.name;
        }

    }
}
