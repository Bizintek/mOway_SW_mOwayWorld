using System;

namespace Moway.Project.GraphicProject.Actions
{
    public class ActionFormException : Exception
    {
        private string caption;

        public string Caption {get{return this.caption;}}

        public ActionFormException(string message, string caption)
            : base(message)
        {
            this.caption = caption;
        }
    }
}
