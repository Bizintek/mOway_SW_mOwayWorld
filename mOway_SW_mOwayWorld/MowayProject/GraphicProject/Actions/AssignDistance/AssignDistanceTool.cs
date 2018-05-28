using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.AssignDistance
{
    public class AssignDistanceTool : Tool
    {
        public AssignDistanceTool(string key)
        {
            this.index = Convert.ToInt32(AssignDistance.Index);
            this.key = key;
            this.text = AssignDistance.ToolText;
            this.type = ToolType.Basic;
            if (AssignDistance.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = AssignDistance.Group;
            this.icon = AssignDistance.ToolIcon;
            this.toolTipText = AssignDistance.ToolTipText;
        }
    }
}
