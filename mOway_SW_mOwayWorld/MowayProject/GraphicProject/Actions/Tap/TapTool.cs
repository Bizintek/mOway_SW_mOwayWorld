using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.Tap
{
    public class TapTool : Tool
    {
        public TapTool(string key)
        {
            this.index = Convert.ToInt32(Tap.Index);
            this.key = key;
            this.text = Tap.ToolText;
            this.type = ToolType.Basic;
            if (Tap.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = Tap.Group;
            this.icon = Tap.ToolIcon;
            this.toolTipText = Tap.ToolTipText;
        }
    }
}
