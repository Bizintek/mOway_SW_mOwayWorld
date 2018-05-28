using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.StartRf
{
    public class StartRfTool : Tool
    {
        public StartRfTool(string key)
        {
            this.index = Convert.ToInt32(StartRf.Index);
            this.key = key;
            this.text = StartRf.ToolText;
            this.type = ToolType.Basic;
            if (StartRf.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = StartRf.Group;
            this.icon = StartRf.ToolIcon;
            this.toolTipText = StartRf.ToolTipText;

        }
    }
}