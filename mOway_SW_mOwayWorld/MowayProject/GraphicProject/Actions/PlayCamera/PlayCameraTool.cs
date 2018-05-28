using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.PlayCamera
{
    public class PlayCameraTool : Tool
    {
        public PlayCameraTool(string key)
        {
            this.index = Convert.ToInt32(PlayCamera.Index);
            this.key = key;
            this.text = PlayCamera.ToolText;
            this.type = ToolType.Basic;
            if (PlayCamera.Type == "Advanced")
                this.type = ToolType.Basic;
            this.group = PlayCamera.Group;
            this.icon = PlayCamera.ToolIcon;
            this.toolTipText = PlayCamera.ToolTipText;
        }
    }
}
