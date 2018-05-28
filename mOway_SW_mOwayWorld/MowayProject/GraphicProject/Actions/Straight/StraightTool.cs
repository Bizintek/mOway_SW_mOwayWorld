using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.Straight
{
    public class StraightMoveTool : Tool
    {
        public StraightMoveTool(string key)
        {
            this.index = Convert.ToInt32(Straight.Index);
            this.key = key;
            this.text = Straight.ToolText;
            this.type = ToolType.Basic;
            if (Straight.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = Straight.Group;
            this.icon = Straight.ToolIcon;
            this.toolTipText = Straight.ToolTipText;
        }
    }
}
