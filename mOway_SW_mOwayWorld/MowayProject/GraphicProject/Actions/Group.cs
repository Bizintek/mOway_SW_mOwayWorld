using System;
using System.Drawing;
using System.Collections.Generic;

namespace Moway.Project.GraphicProject.Actions
{
    public class Group
    {
        #region Attributes

        private string name;
        private string text;
        private Image icon;
        private string toolTipText;

        #endregion

        #region Static Attributes

        private static List<Group> groups = null;

        #endregion

        #region Properties

        public string Name { get { return this.name; } }
        public string Text { get { return this.text; } }
        public Image Icon { get { return this.icon; } }
        public string ToolTipText { get { return this.toolTipText; } }

        #endregion

        private Group(string name)
        {
            this.name = name;
            this.text = Groups.ResourceManager.GetString(name+"Text");
            this.icon = (Image)Groups.ResourceManager.GetObject(name+"ToolIcon");
            this.toolTipText = Groups.ResourceManager.GetString(name + "ToolTipText");
        }

        #region Static public methods

        public static void LoadGroups()
        {
            groups = new List<Group>();            
            groups.Add(new Group("movement"));
            groups.Add(new Group("sound"));
            groups.Add(new Group("assign"));
            groups.Add(new Group("compare"));
            groups.Add(new Group("subroutine"));
            groups.Add(new Group("moduleIo"));
            groups.Add(new Group("moduleRf"));
            groups.Add(new Group("camera"));
        }

        public static Group GetGroup(string name)
        {
            if (groups == null)
                LoadGroups();
            foreach (Group group in groups)
                if (group.name == name)
                    return group;
            return null;
        }

        #endregion
    }
}
