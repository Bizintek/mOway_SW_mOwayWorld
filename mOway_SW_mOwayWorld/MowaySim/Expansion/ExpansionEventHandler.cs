using System;
using System.Collections.Generic;
using System.Text;

namespace Moway.Simulator.Expansion
{
    public delegate void ExpansionEventHandler(object sender, ExpansionEventArgs e);

    public class ExpansionEventArgs
    {
        #region Attributes

        private int index;
        private IoConfig config;
        private DigitalState state;

        #endregion

        #region Properties

        public int Index { get { return this.index; } }
        public IoConfig Config { get { return this.config; } }
        public DigitalState State { get { return this.state; } }

        #endregion

        public ExpansionEventArgs(int index, IoConfig config, DigitalState state)
        {
            this.index = index;
            this.config = config;
            this.state = state;
        }
    }
}
