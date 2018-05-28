using System;

namespace Moway.Project.GraphicProject.Actions
{
    public class ActionException : Exception
    {
        public ActionException(string message)
            : base(message)
        {
        }
    }
}
