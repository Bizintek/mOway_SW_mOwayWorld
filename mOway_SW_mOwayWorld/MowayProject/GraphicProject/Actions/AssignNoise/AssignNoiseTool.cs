using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.AssignNoise
{
    public class AssignNoiseTool : Tool
    {
        public AssignNoiseTool(string key)
        {
            this.index = Convert.ToInt32(AssignNoise.Index);
            this.key = key;
            this.text = AssignNoise.ToolText;
            this.type = ToolType.Basic;
            if (AssignNoise.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = AssignNoise.Group;
            this.icon = AssignNoise.ToolIcon;
            this.toolTipText = AssignNoise.ToolTipText;
        }
    }
}
