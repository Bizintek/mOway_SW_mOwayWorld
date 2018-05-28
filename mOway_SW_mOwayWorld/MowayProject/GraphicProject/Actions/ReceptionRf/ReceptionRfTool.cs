using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.ReceptionRf
{
    public class ReceptionRfTool : Tool
    {
        public ReceptionRfTool(string key)
        {
            this.index = Convert.ToInt32(ReceptionRf.Index);
            this.key = key;
            this.text = ReceptionRf.ToolText;
            this.type = ToolType.Basic;
            if (ReceptionRf.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = ReceptionRf.Group;
            this.icon = ReceptionRf.ToolIcon;
            this.toolTipText = ReceptionRf.ToolTipText;

        }
    }
}