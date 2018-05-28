using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.AssignSpeed
{
    public class AssignSpeedTool : Tool
    {
        public AssignSpeedTool(string key)
        {
            this.index = Convert.ToInt32(AssignSpeed.Index);
            this.key = key;
            this.text = AssignSpeed.ToolText;
            this.type = ToolType.Basic;
            if (AssignSpeed.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = AssignSpeed.Group;
            this.icon = AssignSpeed.ToolIcon;
            this.toolTipText = AssignSpeed.ToolTipText;
        }
    }
}
