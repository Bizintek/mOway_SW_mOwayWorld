using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.CompareObstacle
{
    public class CompareObstacleTool : Tool
    {
        public CompareObstacleTool(string key)
        {
            this.index = Convert.ToInt32(CompareObstacle.Index);
            this.key = key;
            this.text = CompareObstacle.ToolText;
            this.type = ToolType.Basic;
            if (CompareObstacle.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = CompareObstacle.Group;
            this.icon = CompareObstacle.ToolIcon;
            this.toolTipText = CompareObstacle.ToolTipText;
        }
    }
}
