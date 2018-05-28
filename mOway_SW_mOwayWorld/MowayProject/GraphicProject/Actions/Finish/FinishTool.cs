using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.Finish
{
    public class FinishTool: Tool
    {
        public FinishTool(string key)
        {
            this.index = Convert.ToInt32(Finish.Index);
            this.key = key;
            this.text = Finish.ToolText;
            this.type = ToolType.Basic;
            if (Finish.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = Finish.Group;
            this.icon = Finish.ToolIcon;
            this.toolTipText = Finish.ToolTipText;
        }
    }
}
