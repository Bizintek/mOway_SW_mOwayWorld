using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.PlaySound
{
    public class PlaySoundTool : Tool
    {
        public PlaySoundTool(string key)
        {
            this.index = Convert.ToInt32(PlaySound.Index);
            this.key = key;
            this.text = PlaySound.ToolText;
            this.type = ToolType.Basic;
            if (PlaySound.Type == "Advanced")
                this.type = ToolType.Basic;
            this.group = PlaySound.Group;
            this.icon = PlaySound.ToolIcon;
            this.toolTipText = PlaySound.ToolTipText;
        }
    }
}
