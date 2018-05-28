using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.AssignAccelerometer
{
    public class AssignAccelerometerTool : Tool
    {
        public AssignAccelerometerTool(string key)
        {
            this.index = Convert.ToInt32(AssignAccelerometer.Index);
            this.key = key;
            this.text = AssignAccelerometer.ToolText;
            this.type = ToolType.Basic;
            if (AssignAccelerometer.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = AssignAccelerometer.Group;
            this.icon = AssignAccelerometer.ToolIcon;
            this.toolTipText = AssignAccelerometer.ToolTipText;
        }
    }
}
