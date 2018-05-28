using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.Noise
{
    public class NoiseTool : Tool
    {
        public NoiseTool(string key)
        {
            this.index = Convert.ToInt32(Noise.Index);
            this.key = key;
            this.text = Noise.ToolText;
            this.type = ToolType.Basic;
            if (Noise.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = Noise.Group;
            this.icon = Noise.ToolIcon;
            this.toolTipText = Noise.ToolTipText;
        }
    }
}
