using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.AssignBrightness
{
    public class AssignBrightnessTool : Tool
    {
        public AssignBrightnessTool(string key)
        {
            this.index = Convert.ToInt32(AssignBrightness.Index);
            this.key = key;
            this.text = AssignBrightness.ToolText;
            this.type = ToolType.Basic;
            if (AssignBrightness.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = AssignBrightness.Group;
            this.icon = AssignBrightness.ToolIcon;
            this.toolTipText = AssignBrightness.ToolTipText;
        }
    }
}
