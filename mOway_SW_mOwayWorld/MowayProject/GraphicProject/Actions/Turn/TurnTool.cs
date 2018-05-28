using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.Turn
{
    public class TurnTool : Tool
    {
        public TurnTool(string key)
        {
            this.index = Convert.ToInt32(Turn.Index);
            this.key = key;
            this.text = Turn.ToolText;
            this.type = ToolType.Basic;
            if (Turn.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = Turn.Group;
            this.icon = Turn.ToolIcon;
            this.toolTipText = Turn.ToolTipText;
        }
    }
}
