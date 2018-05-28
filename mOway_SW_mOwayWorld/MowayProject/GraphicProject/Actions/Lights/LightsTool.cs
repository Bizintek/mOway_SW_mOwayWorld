using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.Lights
{
    public class LightsTool : Tool
    {
        public LightsTool(string key)
        {
            this.index = Convert.ToInt32(Lights.Index);
            this.key = key;
            this.text = Lights.ToolText;
            this.type = ToolType.Basic;
            if (Lights.Type == "Advanced")
                this.type = ToolType.Basic;
            this.group = Lights.Group;
            this.icon = Lights.ToolIcon;
            this.toolTipText = Lights.ToolTipText;
        }
    }
}
