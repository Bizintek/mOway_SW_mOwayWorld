using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.CompareNoise
{
    public class CompareNoiseTool : Tool
    {
        public CompareNoiseTool(string key)
        {
            this.index = Convert.ToInt32(CompareNoise.Index);
            this.key = key;
            this.text = CompareNoise.ToolText;
            this.type = ToolType.Basic;
            if (CompareNoise.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = CompareNoise.Group;
            this.icon = CompareNoise.ToolIcon;
            this.toolTipText = CompareNoise.ToolTipText;
        }
    }
}
