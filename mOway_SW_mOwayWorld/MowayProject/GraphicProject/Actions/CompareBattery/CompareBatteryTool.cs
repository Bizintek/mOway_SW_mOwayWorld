using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.CompareBattery
{
    public class CompareBatteryTool : Tool
    {
        public CompareBatteryTool(string key)
        {
            this.index = Convert.ToInt32(CompareBattery.Index);
            this.key = key;
            this.text = CompareBattery.ToolText;
            this.type = ToolType.Basic;
            if (CompareBattery.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = CompareBattery.Group;
            this.icon = CompareBattery.ToolIcon;
            this.toolTipText = CompareBattery.ToolTipText;
        }
    }
}
