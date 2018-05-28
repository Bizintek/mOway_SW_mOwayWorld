using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.CompareLine
{
    public class CompareLineTool : Tool
    {
        public CompareLineTool(string key)
        {
            this.index = Convert.ToInt32(CompareLine.Index);
            this.key = key;
            this.text = CompareLine.ToolText;
            this.type = ToolType.Basic;
            if (CompareLine.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = CompareLine.Group;
            this.icon = CompareLine.ToolIcon;
            this.toolTipText = CompareLine.ToolTipText;
        }
    }
}
