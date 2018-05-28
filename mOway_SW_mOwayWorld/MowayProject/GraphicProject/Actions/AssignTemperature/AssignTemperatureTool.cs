using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.AssignTemperature
{
    public class AssignTemperatureTool : Tool
    {
        public AssignTemperatureTool(string key)
        {
            this.index = Convert.ToInt32(AssignTemperature.Index);
            this.key = key;
            this.text = AssignTemperature.ToolText;
            this.type = ToolType.Basic;
            if (AssignTemperature.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = AssignTemperature.Group;
            this.icon = AssignTemperature.ToolIcon;
            this.toolTipText = AssignTemperature.ToolTipText;
        }
    }
}
