using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.CompareSpeed
{
    public class CompareSpeedTool : Tool
    {
        public CompareSpeedTool(string key)
        {
            this.index = Convert.ToInt32(CompareSpeed.Index);
            this.key = key;
            this.text = CompareSpeed.ToolText;
            this.type = ToolType.Basic;
            if (CompareSpeed.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = CompareSpeed.Group;
            this.icon = CompareSpeed.ToolIcon;
            this.toolTipText = CompareSpeed.ToolTipText;
        }
    }
}
