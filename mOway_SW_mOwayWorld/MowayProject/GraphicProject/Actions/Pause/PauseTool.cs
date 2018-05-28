using System;

namespace Moway.Project.GraphicProject.Actions.Pause
{
    /// <summary>
    /// Tool of the action "Pause"
    /// </summary>
    public class PauseTool : Tool
    {
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="key">Action key</param>
        public PauseTool(string key)
        {
            this.index = Convert.ToInt32(Pause.Index);
            this.key = key;
            this.text = Pause.ToolText;
            this.type = ToolType.Basic;
            if (Pause.Type == "Advanced")
                this.type = ToolType.Advanced;
            this.group = Pause.Group;
            this.icon = Pause.ToolIcon;
            this.toolTipText = Pause.ToolTipText;

        }
    }
}
