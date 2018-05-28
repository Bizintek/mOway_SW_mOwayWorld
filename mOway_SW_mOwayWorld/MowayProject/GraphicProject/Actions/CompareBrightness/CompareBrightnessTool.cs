using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.CompareBrightness
{
    public class CompareBrightnessTool : Tool
    {
        public CompareBrightnessTool(string key)
        {
            this.index = Convert.ToInt32(CompareBrightness.Index);
            this.key = key;
            this.text = CompareBrightness.ToolText;
            this.type = ToolType.Basic;
            if (CompareBrightness.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = CompareBrightness.Group;
            this.icon = CompareBrightness.ToolIcon;
            this.toolTipText = CompareBrightness.ToolTipText;
        }
    }
}
