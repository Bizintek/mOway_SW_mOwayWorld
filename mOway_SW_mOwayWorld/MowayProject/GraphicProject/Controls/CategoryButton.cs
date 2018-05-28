using System;
using System.Windows.Forms;

using Moway.Template;

namespace Moway.Project.GraphicProject.Controls
{
    /// <summary>
    /// Represents the top button in a group's actions box
    /// </summary>
    public partial class CategoryButton : Button
    {
        /// <summary>
        /// Builder
        /// </summary>
        public CategoryButton():base()
        {
            InitializeComponent();

            if (System.Environment.OSVersion.Platform == PlatformID.Unix)
                this.Font = new System.Drawing.Font("Sans", 8, System.Drawing.FontStyle.Regular);

            //To avoid the button effect with the focus
            this.SetStyle(ControlStyles.Selectable, false);
        }

        /// <summary>
        /// To avoid the effect of the focus about the button
        /// </summary>
        protected override bool ShowFocusCues { get { return false; } }
    }
}
