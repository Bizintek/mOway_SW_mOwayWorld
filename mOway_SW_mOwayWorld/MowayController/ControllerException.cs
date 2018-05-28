using System;

namespace Moway.Controller
{
    public class ControllerException : Exception
    {
        public ControllerException(string message)
            : base(message)
        {
        }
    }
}
