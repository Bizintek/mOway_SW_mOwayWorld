using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.CompareDistance
{
    public class CompareDistanceTool : Tool
    {
        public CompareDistanceTool(string key)
        {
            this.index = Convert.ToInt32(CompareDistance.Index);
            this.key = key;
            this.text = CompareDistance.ToolText;
            this.type = ToolType.Basic;
            if (CompareDistance.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = CompareDistance.Group;
            this.icon = CompareDistance.ToolIcon;
            this.toolTipText = CompareDistance.ToolTipText;
        }
    }
}
