using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// Toolbar for MOwayWorld
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class MowayToolBar : Panel
    {
        /// <summary>
        /// Builder
        /// </summary>
        public MowayToolBar()
        {
            InitializeComponent();
            this.pbLogo.Location = new Point(800, 0);
        }

        #region Public methods

        /// <summary>
        /// Add a list of items to the controls
        /// </summary>
        /// <param name="items">List of items to add</param>
        public void AddItems(List<IToolBarItem> items)
        {
            int xLocation = 430;
            foreach (IToolBarItem item in items)
            {
                if (item is ToolBarButton)
                {
                    item.Location = new Point(xLocation + 3, 0);
                    xLocation += 40;
                }
                else
                {
                    item.Location = new Point(xLocation + 7, 8);
                    xLocation += 10;
                }
                this.Controls.Add((Control)item);
            }
        }

        /// <summary>
        /// Removes a set of items from the control
        /// </summary>
        /// <param name="items">List of items to delete</param>
        public void RemoveItems(List<IToolBarItem> items)
        {
            foreach (IToolBarItem item in items)
                this.Controls.Remove((Control)item);
        }

        #endregion
    }
}
