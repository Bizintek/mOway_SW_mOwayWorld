using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.CompareTime
{
    public class CompareTimeTool : Tool
    {
        public CompareTimeTool(string key)
        {
            this.index = Convert.ToInt32(CompareTime.Index);
            this.key = key;
            this.text = CompareTime.ToolText;
            this.type = ToolType.Basic;
            if (CompareTime.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = CompareTime.Group;
            this.icon = CompareTime.ToolIcon;
            this.toolTipText = CompareTime.ToolTipText;
        }
    }
}