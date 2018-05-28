using System;
using System.Collections.Generic;
using System.Text;

namespace Moway.Project.GraphicProject.Processes
{
    /// <summary>
    /// Operation within the process
    /// </summary>
    public enum ProcessOperation { None, Check, Generate, Compile, Program, Close };
    /// <summary>
    /// Operation Status
    /// </summary>
    public enum OperationState { Running = 0, Finish, Error, Warning };
}
