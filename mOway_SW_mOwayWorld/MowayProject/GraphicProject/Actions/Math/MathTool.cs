using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.Math
{
    public class MathTool : Tool
    {
        public MathTool(string key)
        {
            this.index = Convert.ToInt32(Math.Index);
            this.key = key;
            this.text = Math.ToolText;
            this.type = ToolType.Basic;
            if (Math.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = Math.Group;
            this.icon = Math.ToolIcon;
            this.toolTipText = Math.ToolTipText;
        }
    }
}
