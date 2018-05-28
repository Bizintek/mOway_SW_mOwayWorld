using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.CheckIn
{
    public class CheckInTool : Tool
    {
        public CheckInTool(string key)
        {
            this.index = Convert.ToInt32(CheckIn.Index);
            this.key = key;
            this.text = CheckIn.ToolText;
            this.type = ToolType.Basic;
            if (CheckIn.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = CheckIn.Group;
            this.icon = CheckIn.ToolIcon;
            this.toolTipText = CheckIn.ToolTipText;
        }
    }
}