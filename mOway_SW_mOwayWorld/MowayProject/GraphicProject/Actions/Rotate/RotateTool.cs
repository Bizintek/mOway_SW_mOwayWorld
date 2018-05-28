using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.Rotate
{
    public class RotateTool : Tool
    {
        public RotateTool(string key)
        {
            this.index = Convert.ToInt32(Rotate.Index);
            this.key = key;
            this.text = Rotate.ToolText;
            this.type = ToolType.Basic;
            if (Rotate.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = Rotate.Group;
            this.icon = Rotate.ToolIcon;
            this.toolTipText = Rotate.ToolTipText;
        }
    }
}
