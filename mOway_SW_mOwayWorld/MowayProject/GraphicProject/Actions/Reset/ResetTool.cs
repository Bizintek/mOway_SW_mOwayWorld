using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.Reset
{
    public class ResetTool : Tool
    {
        public ResetTool(string key)
        {
            this.index = Convert.ToInt32(Reset.Index);
            this.key = key;
            this.text = Reset.ToolText;
            this.type = ToolType.Basic;
            if (Reset.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = Reset.Group;
            this.icon = Reset.ToolIcon;
            this.toolTipText = Reset.ToolTipText;

        }
    }
}
