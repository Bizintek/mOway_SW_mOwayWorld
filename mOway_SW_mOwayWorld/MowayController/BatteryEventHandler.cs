using System;

namespace Moway.Controller
{
    public delegate void BatteryEventHandler(object sender, BatteryEventArgs e);

    public class BatteryEventArgs : EventArgs
    {
        #region Attributes

        private int battery;

        #endregion

        #region Properties

        public int Battery { get { return this.battery; } }

        #endregion

        public BatteryEventArgs(int battery)
        {
            this.battery = battery;
        }
    }
}
