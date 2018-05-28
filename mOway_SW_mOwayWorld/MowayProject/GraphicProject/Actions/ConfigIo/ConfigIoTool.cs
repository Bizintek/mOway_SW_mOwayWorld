using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions.ConfigIo
{
    public class ConfigIoTool : Tool
    {
        public ConfigIoTool(string key)
        {
            this.index = Convert.ToInt32(ConfigIo.Index);
            this.key = key;
            this.text = ConfigIo.ToolText;
            this.type = ToolType.Basic;
            if (ConfigIo.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = ConfigIo.Group;
            this.icon = ConfigIo.ToolIcon;
            this.toolTipText = ConfigIo.ToolTipText;
        }
    }
}
