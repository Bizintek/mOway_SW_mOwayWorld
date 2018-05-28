using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.AssignTime
{
    public class CurveTool : Tool
    {
        public CurveTool(string key)
        {
            this.index = Convert.ToInt32(AssignTime.Index);
            this.key = key;
            this.text = AssignTime.ToolText;
            this.type = ToolType.Basic;
            if (AssignTime.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = AssignTime.Group;
            this.icon = AssignTime.ToolIcon;
            this.toolTipText = AssignTime.ToolTipText;
        }
    }
}
