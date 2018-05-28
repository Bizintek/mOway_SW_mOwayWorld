using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.Free
{
    public class FreeTool : Tool
    {
        public FreeTool(string key)
        {
            this.index = Convert.ToInt32(Free.Index);
            this.key = key;
            this.text = Free.ToolText;
            this.type = ToolType.Basic;
            if (Free.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = Free.Group;
            this.icon = Free.ToolIcon;
            this.toolTipText = Free.ToolTipText;
        }
    }
}
