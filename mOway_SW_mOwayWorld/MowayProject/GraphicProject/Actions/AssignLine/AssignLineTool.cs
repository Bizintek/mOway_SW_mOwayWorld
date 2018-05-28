using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.AssignLine
{
    public class AssignLineTool : Tool
    {
        public AssignLineTool(string key)
        {
            this.index = Convert.ToInt32(AssignLine.Index);
            this.key = key;
            this.text = AssignLine.ToolText;
            this.type = ToolType.Basic;
            if (AssignLine.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = AssignLine.Group;
            this.icon = AssignLine.ToolIcon;
            this.toolTipText = AssignLine.ToolTipText;
        }
    }
}
