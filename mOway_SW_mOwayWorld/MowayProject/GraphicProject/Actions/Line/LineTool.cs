using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.Line
{
    public class LineTool : Tool
    {
        public LineTool(string key)
        {
            this.index = Convert.ToInt32(Line.Index);
            this.key = key;
            this.text = Line.ToolText;
            this.type = ToolType.Basic;
            if (Line.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = Line.Group;
            this.icon = Line.ToolIcon;
            this.toolTipText = Line.ToolTipText;
        }
    }
}
