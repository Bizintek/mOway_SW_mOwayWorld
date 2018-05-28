using System;
using System.Collections.Generic;
using System.Text;

namespace Moway.Server.Processes
{
    public enum ProcessOp { None, Program, Close };
    public enum ProcessState { Running = 0, Finish, Error };
}
