using System;
using System.Drawing;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// GroupBox customized for mOwayWorld
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class MowayGroupBox : GroupBox
    {
        #region Properties

        /// <summary>
        /// This method is rewritten to update the images and the title tag
        /// </summary>
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
                if (base.RightToLeft == RightToLeft.Yes)
                {
                    this.pbTopLeft.Image = this.imageList.Images[0];
                    this.pbTopRight.Image = this.imageList.Images[1];
                    this.pbBottomRight.Image = this.imageList.Images[2];
                    this.pbBottomLeft.Image = this.imageList.Images[3];
                    this.lTittle.Location = new Point(this.Width - this.lTittle.Width - 19, 1);
                }
                else
                {
                    this.pbTopLeft.Image = null;
                    this.pbTopRight.Image = null;
                    this.pbBottomRight.Image = null;
                    this.pbBottomLeft.Image = null;
                    this.lTittle.Location = new Point(17, 1);
                }
            }
        }
        /// <summary>
        /// Rewritten this property to display the text in the label
        /// </summary>
        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                this.lTittle.Text = this.Text;
                if (base.RightToLeft == RightToLeft.Yes)
                    this.lTittle.Location = new Point(this.Width - this.lTittle.Width - 19, 1);
            }
        }

        /// <summary>
        /// This property is rewritten because it is necessary to update the positions and sizes of the images from here
        /// </summary>
        public new Size Size
        {
            get { return base.Size; }
            set
            {
                base.Size = new Size(value.Width, value.Height);
                this.pbTop.Size = new Size(this.Width - 30, 15);
                this.pbTopRight.Location = new Point(this.Width - 15, 0);
                this.pbRight.Location = new Point(this.Width - 15, 15);
                this.pbRight.Size = new Size(15, this.Height - 30);
                this.pbBottomRight.Location = new Point(this.Width - 15, this.Height - 15);
                this.pbBottom.Location = new Point(15, this.Height - 15);
                this.pbBottom.Size = new Size(this.Width - 30, 15);
                this.pbBottomLeft.Location = new Point(0, this.Height - 15);
                this.pbLeft.Size = new Size(15, this.Height - 30);
            }
        }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public MowayGroupBox()
        {
            InitializeComponent();
        }
    }
}
