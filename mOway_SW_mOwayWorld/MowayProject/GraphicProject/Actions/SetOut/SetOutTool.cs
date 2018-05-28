using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.SetOut
{
    public class SetOutTool : Tool
    {
        public SetOutTool(string key)
        {
            this.index = Convert.ToInt32(SetOut.Index);
            this.key = key;
            this.text = SetOut.ToolText;
            this.type = ToolType.Basic;
            if (SetOut.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = SetOut.Group;
            this.icon = SetOut.ToolIcon;
            this.toolTipText = SetOut.ToolTipText;
        }
    }
}