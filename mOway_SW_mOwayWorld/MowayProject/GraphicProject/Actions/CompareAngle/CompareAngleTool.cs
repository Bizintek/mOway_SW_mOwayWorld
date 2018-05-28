using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.CompareAngle
{
    public class CompareAngleTool : Tool
    {
        public CompareAngleTool(string key)
        {
            this.index = Convert.ToInt32(CompareAngle.Index);
            this.key = key;
            this.text = CompareAngle.ToolText;
            this.type = ToolType.Basic;
            if (CompareAngle.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = CompareAngle.Group;
            this.icon = CompareAngle.ToolIcon;
            this.toolTipText = CompareAngle.ToolTipText;
        }
    }
}
