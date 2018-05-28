using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.StopCamera
{
    public class StopCameraTool : Tool
    {
        public StopCameraTool(string key)
        {
            this.index = Convert.ToInt32(StopCamera.Index);
            this.key = key;
            this.text = StopCamera.ToolText;
            this.type = ToolType.Basic;
            if (StopCamera.Type == "Advanced")
                this.type = ToolType.Basic;
            this.group = StopCamera.Group;
            this.icon = StopCamera.ToolIcon;
            this.toolTipText = StopCamera.ToolTipText;
        }
    }
}
