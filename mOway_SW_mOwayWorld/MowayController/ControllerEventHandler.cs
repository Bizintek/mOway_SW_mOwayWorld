using System;

namespace Moway.Controller
{
    public delegate void ControllerEventHandler(object sender, ControllerEventArgs e);

    public class ControllerEventArgs : EventArgs
    {
        #region

        private string firmware;
        private int battery;

        #endregion

        #region Properties

        public string Firmware { get { return this.firmware; } }
        public int Battery { get { return this.battery; } }

        #endregion

        public ControllerEventArgs(string firmware, int battery)
        {
            this.firmware = firmware;
            this.battery = battery;
        }
    }
}
