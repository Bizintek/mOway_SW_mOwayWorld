using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.AssignAngle
{
    public class AssignAngleTool : Tool
    {
        public AssignAngleTool(string key)
        {
            this.index = Convert.ToInt32(AssignAngle.Index);
            this.key = key;
            this.text = AssignAngle.ToolText;
            this.type = ToolType.Basic;
            if (AssignAngle.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = AssignAngle.Group;
            this.icon = AssignAngle.ToolIcon;
            this.toolTipText = AssignAngle.ToolTipText;
        }
    }
}
