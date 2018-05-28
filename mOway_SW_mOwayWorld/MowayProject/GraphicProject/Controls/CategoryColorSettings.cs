using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Controls
{
    /// <summary>
    /// Colors for the categories of actions
    /// </summary>
    public enum CategoryColors { Gray = 0, Green, Yellow, Orange, Red, Purple, Blue }

    /// <summary>
    /// Colors for the different categories of actions
    /// </summary>
    /// <LastRevision>27.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class CategoryColorSettings
    {
        #region Definition of default colors

        private const int DEF_COLOR = 0; //What is the color Gray

        /// <summary>
        /// Default background color of the actions box
        /// </summary>
        private readonly Color[] defBackColor = { Color.FromArgb(234, 234, 234), Color.FromArgb(158, 219, 175), 
                                                    Color.FromArgb(238, 232, 112), Color.FromArgb(241, 183, 121), 
                                                    Color.FromArgb(233, 140, 140), Color.FromArgb(215, 148, 232), 
                                                    Color.FromArgb(146, 163, 221) };
        /// <summary>
        /// Default border color of the action box
        /// </summary>
        private readonly Color[] defBorderColor = { Color.FromArgb(207, 207, 207), Color.FromArgb(133, 185, 147), 
                                                      Color.FromArgb(202, 197, 95), Color.FromArgb(203, 154, 102), 
                                                      Color.FromArgb(197, 118, 118), Color.FromArgb(182, 125, 195), 
                                                      Color.FromArgb(123, 138, 186) };
        /// <summary>
        ///Default color of the effect for the group button over
        /// </summary>
        private readonly Color[] defCategoryButtonOverColor = { Color.FromArgb(180, 180, 180), Color.FromArgb(117, 162, 129),  
                                                                  Color.FromArgb(177, 173, 84), Color.FromArgb(178, 135, 89),
                                                                  Color.FromArgb(173, 104, 104), Color.FromArgb(159, 110, 171), 
                                                                  Color.FromArgb(108, 121, 164) };
        /// <summary>
        /// Default color of the effect for the group button Down
        /// </summary>
        private readonly Color[] defCategoryButtonDownColor = { Color.FromArgb(200, 200, 200), Color.FromArgb(117, 162, 129), 
                                                                  Color.FromArgb(177, 173, 84), Color.FromArgb(178, 135, 89), 
                                                                  Color.FromArgb(173, 104, 104), Color.FromArgb(159, 110, 171), 
                                                                  Color.FromArgb(108, 121, 164) };
        /// <summary>
        /// Default color of the effect for the Over of the action button
        /// </summary>
        private readonly Color[] defActionButtonOverColor = {  Color.FromArgb(207, 207, 207), Color.FromArgb(133, 185, 147), 
                                                                Color.FromArgb(202, 197, 95), Color.FromArgb(203, 154, 102), 
                                                                Color.FromArgb(197, 118, 118), Color.FromArgb(182, 125, 195), 
                                                                Color.FromArgb(123, 138, 186) };

        #endregion

        #region Attributes

        /// <summary>
        /// Background color of the action box
        /// </summary>
        private Color backColor;
        /// <summary>
        /// Border color of the action box
        /// </summary>
        private Color borderColor;
        /// <summary>
        /// Effect color for group button over
        /// </summary>
        private Color categoryButtonOverColor;
        /// <summary>
        /// Effect color for the group button Down
        /// </summary>
        private Color categoryButtonDownColor;
        /// <summary>
        /// Effect color for the Over of the action button
        /// </summary>
        private Color actionButtonOverColor;

        #endregion

        #region Properties

        /// <summary>
        /// Background color of the action box
        /// </summary>
        public Color BackColor
        {
            get { return this.backColor; }
            set { this.backColor = value; }
        }
        /// <summary>
        /// Edge color of the action box
        /// </summary>
        public Color BorderColor
        {
            get { return this.borderColor; }
            set { this.borderColor = value; }
        }
        /// <summary>
        /// Effect color for group button over
        /// </summary>
        public Color CategoryButtonOverColor
        {
            get { return this.categoryButtonOverColor; }
            set { this.categoryButtonOverColor = value; }
        }
        /// <summary>
        /// Effect color for the group button Down
        /// </summary>
        public Color CategoryButtonDownColor
        {
            get { return this.categoryButtonDownColor; }
            set { this.categoryButtonDownColor = value; }
        }
        /// <summary>
        /// Effect color for the Over of the action button
        /// </summary>
        public Color ActionButtonOverColor
        {
            get { return this.actionButtonOverColor; }
            set { this.actionButtonOverColor = value; }
        }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public CategoryColorSettings()
        {
            this.backColor = this.defBackColor[DEF_COLOR];
            this.borderColor = this.defBorderColor[DEF_COLOR];
            this.categoryButtonOverColor = this.defCategoryButtonOverColor[DEF_COLOR];
            this.categoryButtonDownColor = this.defCategoryButtonDownColor[DEF_COLOR];
            this.actionButtonOverColor = this.defActionButtonOverColor[DEF_COLOR];
        }

        /// <summary>
        /// Builder that defines the default color range of the group
        /// </summary>
        /// <param name="color">Default color for the group</param>
        public CategoryColorSettings(CategoryColors color)
        {
            this.backColor = this.defBackColor[(int)color];
            this.borderColor = this.defBorderColor[(int)color];
            this.categoryButtonOverColor = this.defCategoryButtonOverColor[(int)color];
            this.categoryButtonDownColor = this.defCategoryButtonDownColor[(int)color];
            this.actionButtonOverColor = this.defActionButtonOverColor[(int)color];
        }
    }
}
