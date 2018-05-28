using System;
using System.Collections.Generic;
using System.Text;

namespace Moway.Processes
{
    /// <summary>
    /// Operation inside the process
    /// </summary>
    public enum ProcessOperation { None, Program, Close };
    /// <summary>
    /// Operation Status
    /// </summary>
    public enum OperationState { Running = 0, Finish, Error };
}
