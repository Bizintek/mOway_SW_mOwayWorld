using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.StopSound
{
    public class StopSoundTool : Tool
    {
        public StopSoundTool(string key)
        {
            this.index = Convert.ToInt32(StopSound.Index);
            this.key = key;
            this.text = StopSound.ToolText;
            this.type = ToolType.Basic;
            if (StopSound.Type == "Advanced")
                this.type = ToolType.Basic;
            this.group = StopSound.Group;
            this.icon = StopSound.ToolIcon;
            this.toolTipText = StopSound.ToolTipText;
        }
    }
}
