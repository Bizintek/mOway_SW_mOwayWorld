using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.StopMovement
{
    public class StopMovementTool : Tool
    {
        public StopMovementTool(string key)
        {
            this.index = Convert.ToInt32(StopMovement.Index);
            this.key = key;
            this.text = StopMovement.ToolText;
            this.type = ToolType.Basic;
            if (StopMovement.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = StopMovement.Group;
            this.icon = StopMovement.ToolIcon;
            this.toolTipText = StopMovement.ToolTipText;
        }
    }
}
