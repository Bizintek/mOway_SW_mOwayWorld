using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.Obstacle
{
    public class ObstacleTool : Tool
    {
        public ObstacleTool(string key)
        {
            this.index = Convert.ToInt32(Obstacle.Index);
            this.key = key;
            this.text = Obstacle.ToolText;
            this.type = ToolType.Basic;
            if (Obstacle.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = Obstacle.Group;
            this.icon = Obstacle.ToolIcon;
            this.toolTipText = Obstacle.ToolTipText;
        }
    }
}
