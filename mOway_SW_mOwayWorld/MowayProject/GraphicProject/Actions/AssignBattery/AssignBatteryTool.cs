using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.AssignBattery
{
    public class AssignBatteryTool : Tool
    {
        public AssignBatteryTool(string key)
        {
            this.index = Convert.ToInt32(AssignBattery.Index);
            this.key = key;
            this.text = AssignBattery.ToolText;
            this.type = ToolType.Basic;
            if (AssignBattery.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = AssignBattery.Group;
            this.icon = AssignBattery.ToolIcon;
            this.toolTipText = AssignBattery.ToolTipText;
        }
    }
}
