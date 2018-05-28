using System;
using System.Drawing;
using System.Resources;

namespace Moway.Project.GraphicProject.Actions
{
    public enum ToolType { Basic, Advanced }

    public abstract class Tool : IComparable
    {
        #region Attributes

        protected int index;
        protected string key;
        protected string text;
        protected ToolType type;
        protected string group;
        protected Image icon;
        protected string toolTipText;

        #endregion

        #region Properties

        /// <summary>
        /// Internal Identificativo of the action / tool
        /// </summary>
        public string Key { get { return this.key; } }
        /// <summary>
        /// Text of the tool to show in the toolbar
        /// </summary>
        public string Text { get { return this.text; } }
        /// <summary>
        /// Tool type/action (Basic or Advanced)
        /// </summary>
        public ToolType Type { get { return this.type; } }
        /// <summary>
        /// Tool/Action Group to organize in toolbar
        /// </summary>
        public string Group { get { return this.group; } }
        /// <summary>
        /// Icon of the tool to show in the toolbar
        /// </summary>
        public Image Icon { get { return this.icon; } }
        /// <summary>
        /// Text for tool ToolTip in toolbar
        /// </summary>
        public string ToolTipText { get { return this.toolTipText; } }

        #endregion

        /// <summary>
        /// Implements the IComparable interface comparison method
        /// </summary>
        /// <param name="o">Object with which to compare</param>
        /// <returns>0 if they are equal, negative value if it is less than the object passed 
        /// as a parameter and positive value otherwise</returns>
        public int CompareTo(object o)
        {
            try
            {
                Tool tool = (Tool)o;
                if (this.index > tool.index)
                    return 1;
                else if (this.index < tool.index)
                    return -1;
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
