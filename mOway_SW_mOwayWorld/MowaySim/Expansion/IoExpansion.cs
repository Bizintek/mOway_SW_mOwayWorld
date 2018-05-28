using System;
using System.Collections.Generic;
using System.Text;

namespace Moway.Simulator.Expansion
{
    /// <summary>
    /// I/O pin configuration
    /// </summary>
    public enum IoConfig { Input, Output };

    public class IoExpansion
    {
        #region Attributes

        private IoConfig[] linesConfig = { IoConfig.Input, IoConfig.Input, IoConfig.Input, IoConfig.Input, IoConfig.Input, IoConfig.Input };
        private DigitalState[] linesState = { DigitalState.Off, DigitalState.Off, DigitalState.Off, DigitalState.Off, DigitalState.Off, DigitalState.Off };

        #endregion

        #region Attributes

        public IoConfig[] LinesConfig { get { return this.linesConfig; } }
        public DigitalState[] LinesState { get { return this.linesState; } }

        #endregion

        #region Events

        public event ExpansionEventHandler IoChanged;

        #endregion

        internal IoExpansion() { }

        internal void UpdateInputLine(int index, DigitalState state)
        {
            if (this.linesConfig[index] == IoConfig.Output)
                throw new SimulatorException("Only can be changed input lines");
            this.linesState[index] = state;
        }

        public void UpdateLines(IoConfig[] linesConfig, DigitalState[] linesState)
        {
            if ((linesConfig.Length != 6) || (linesState.Length != 6))
                throw new SimulatorException("Arguments dont have 6 IO lines");
            for (int i = 0; i < 6; i++)
            {
                if (this.linesConfig[i] != linesConfig[i])
                {
                    this.linesConfig[i] = linesConfig[i];
                    if (this.linesConfig[i] == IoConfig.Output)
                        this.linesState[i] = linesState[i];
                    if (this.IoChanged != null)
                        this.IoChanged(this, new ExpansionEventArgs(i, this.linesConfig[i], this.linesState[i]));
                }
                else if (this.linesConfig[i] == IoConfig.Output)
                {
                    this.linesState[i] = linesState[i];
                    if (this.IoChanged != null)
                        this.IoChanged(this, new ExpansionEventArgs(i, this.linesConfig[i], this.linesState[i]));
                }
            }
        }

        internal void Reset()
        {
            this.linesConfig = new IoConfig[] { IoConfig.Input, IoConfig.Input, IoConfig.Input, IoConfig.Input, IoConfig.Input, IoConfig.Input };
            this.linesState = new DigitalState[] { DigitalState.Off, DigitalState.Off, DigitalState.Off, DigitalState.Off, DigitalState.Off, DigitalState.Off };
        }
    }
}
