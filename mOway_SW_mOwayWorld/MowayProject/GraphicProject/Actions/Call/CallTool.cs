using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.Call
{
    public class CallTool : Tool
    {
        public CallTool(string key)
        {
            this.index = Convert.ToInt32(Call.Index);
            this.key = key;
            this.text = Call.ToolText;
            this.type = ToolType.Basic;
            if (Call.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = Call.Group;
            this.icon = Call.ToolIcon;
            this.toolTipText = Call.ToolTipText;
        }
    }
}
