using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.AssignObstacle
{
    public class AssignObstacleTool : Tool
    {
        public AssignObstacleTool(string key)
        {
            this.index = Convert.ToInt32(AssignObstacle.Index);
            this.key = key;
            this.text = AssignObstacle.ToolText;
            this.type = ToolType.Basic;
            if (AssignObstacle.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = AssignObstacle.Group;
            this.icon = AssignObstacle.ToolIcon;
            this.toolTipText = AssignObstacle.ToolTipText;
        }
    }
}
