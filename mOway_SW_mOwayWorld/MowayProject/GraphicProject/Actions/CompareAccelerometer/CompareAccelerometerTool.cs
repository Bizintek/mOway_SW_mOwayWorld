using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.CompareAccelerometer
{
    public class CompareAccelerometerTool : Tool
    {
        public CompareAccelerometerTool(string key)
        {
            this.index = Convert.ToInt32(CompareAccelerometer.Index);
            this.key = key;
            this.text = CompareAccelerometer.ToolText;
            this.type = ToolType.Basic;
            if (CompareAccelerometer.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = CompareAccelerometer.Group;
            this.icon = CompareAccelerometer.ToolIcon;
            this.toolTipText = CompareAccelerometer.ToolTipText;
        }
    }
}
