using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.TransmissionRf
{
    public class TransmissionRfTool : Tool
    {
        public TransmissionRfTool(string key)
        {
            this.index = Convert.ToInt32(TransmissionRf.Index);
            this.key = key;
            this.text = TransmissionRf.ToolText;
            this.type = ToolType.Basic;
            if (TransmissionRf.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = TransmissionRf.Group;
            this.icon = TransmissionRf.ToolIcon;
            this.toolTipText = TransmissionRf.ToolTipText;

        }
    }
}