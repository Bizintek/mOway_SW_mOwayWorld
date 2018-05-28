using System;
using System.Xml;
using System.Collections.Generic;

using Moway.Project.GraphicProject.Controls;

namespace Moway.Project.GraphicProject.Actions
{
    /// <summary>
    /// Represents the groups of actions of the graphic project
    /// </summary>
    public class Category
    {
        #region Attributes

        /// <summary>
        /// Group name
        /// </summary>
        private string name;
        private string label;
        /// <summary>
        /// Graphic configuration of the group for its visual representation
        /// </summary>
        private CategoryColorSettings guiSettings;

        #endregion

        #region Static Attributes

        private static List<Category> categories;

        #endregion

        #region Properties

        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get { return this.name; } }
        public string Label { get { return this.label; } }
        /// <summary>
        /// Graphic configuration of the group for its visual representation
        /// </summary>
        public CategoryColorSettings GuiSetting
        {
            get { return this.guiSettings; }
            set { this.guiSettings = value; }
        }

        #endregion

        private Category(string name, CategoryColors color)
        {
            this.name = name;
            this.label = Categories.ResourceManager.GetString(name);
            this.guiSettings = new CategoryColorSettings(color);
        }

        public static void ResetCategories()
        {
            categories = null;
        }

        public static void LoadCategories()
        {
            categories = new List<Category>();
            categories.Add(new Category("actions", CategoryColors.Orange));
            categories.Add(new Category("sensors", CategoryColors.Red));
            categories.Add(new Category("data", CategoryColors.Purple));
            categories.Add(new Category("flow", CategoryColors.Blue));
            categories.Add(new Category("expansion", CategoryColors.Green));
        }

        public static Category GetCategory(string name)
        {
            if (categories == null)
                LoadCategories();
            foreach (Category category in categories)
                if (category.name == name)
                    return category;
            return null;
        }

        /// <summary>
        /// Returns the list of action groups for the graphical project
        /// </summary>
        /// <returns>List of actions</returns>
        public static List<Category> GetCategories()
        {
            if (categories == null)
                LoadCategories();
            return categories;
        }
    }
}
