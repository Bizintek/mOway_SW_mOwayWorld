﻿namespace Moway.Template.Controls
{
    partial class ToolBarButton
    {
        /// <summary> 
        /// Variable of the designer required.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean the resources that are being used.
        /// </summary>
        /// <param name="disposing">true if the managed resources should be removed; false otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code generated by the Component Designer

        /// <summary> 
        /// Method necessary to support the Designer. It can not be modified 
        /// the content of the method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ToolBarButton
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImageIndex = 0;
            this.Size = new System.Drawing.Size(39, 39);
            this.UseVisualStyleBackColor = false;
            this.MouseLeave += new System.EventHandler(this.ToolBarButton_MouseLeave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolBarButton_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ToolBarButton_MouseUp);
            this.MouseEnter += new System.EventHandler(this.ToolBarButton_MouseEnter);
            this.ResumeLayout(false);

        }

        #endregion


    }
}
