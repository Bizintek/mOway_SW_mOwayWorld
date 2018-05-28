using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.StopRf
{
    public class StopRfTool : Tool
    {
        public StopRfTool(string key)
        {
            this.index = Convert.ToInt32(StopRf.Index);
            this.key = key;
            this.text = StopRf.ToolText;
            this.type = ToolType.Basic;
            if (StopRf.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = StopRf.Group;
            this.icon = StopRf.ToolIcon;
            this.toolTipText = StopRf.ToolTipText;

        }
    }
}