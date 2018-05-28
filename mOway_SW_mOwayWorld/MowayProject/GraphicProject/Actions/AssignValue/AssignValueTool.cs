using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.AssignValue
{
    public class AssignValueTool : Tool
    {
        public AssignValueTool(string key)
        {
            this.index = Convert.ToInt32(AssignValue.Index);
            this.key = key;
            this.text = AssignValue.ToolText;
            this.type = ToolType.Basic;
            if (AssignValue.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = AssignValue.Group;
            this.icon = AssignValue.ToolIcon;
            this.toolTipText = AssignValue.ToolTipText;
        }
    }
}
