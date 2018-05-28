using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.CompareTemperature
{
    public class CompareTemperatureTool : Tool
    {
        public CompareTemperatureTool(string key)
        {
            this.index = Convert.ToInt32(CompareTemperature.Index);
            this.key = key;
            this.text = CompareTemperature.ToolText;
            this.type = ToolType.Basic;
            if (CompareTemperature.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = CompareTemperature.Group;
            this.icon = CompareTemperature.ToolIcon;
            this.toolTipText = CompareTemperature.ToolTipText;
        }
    }
}
