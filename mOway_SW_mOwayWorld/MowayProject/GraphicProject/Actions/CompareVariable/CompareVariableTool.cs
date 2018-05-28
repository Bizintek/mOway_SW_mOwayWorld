using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.CompareVariable
{
    public class CompareVariableTool : Tool
    {
        public CompareVariableTool(string key)
        {
            this.index = Convert.ToInt32(CompareVariable.Index);
            this.key = key;
            this.text = CompareVariable.ToolText;
            this.type = ToolType.Basic;
            if (CompareVariable.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = CompareVariable.Group;
            this.icon = CompareVariable.ToolIcon;
            this.toolTipText = CompareVariable.ToolTipText;
        }
    }
}