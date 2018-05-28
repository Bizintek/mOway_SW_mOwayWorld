using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using Moway.Template.Controls;

namespace Moway.Template
{
    /// <summary>
    /// Shared Panel for MOway World
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class MowayShareBox : MowayBox
    {
        #region Constants

        /// <summary>
        /// Fixed width for control
        /// </summary>
        private const int BOX_WIDTH = 240;
        /// <summary>
        /// Maximum number of integrated panels
        /// </summary>
        private const int MAX_PANELS = 3;

        #endregion

        #region Attributes

        /// <summary>
        /// Saves the selected panel number
        /// </summary>
        private int panelSelected = -1;
        /// <summary>
        /// It maintains the list of control panels
        /// </summary>
        private List<SharePanel> panels = new List<SharePanel>();

        #endregion

        #region Properties

        /// <summary>
        /// This property is rewritten so that the width of the control is the same as always
        /// </summary>
        public new Size Size
        {
            set { base.Size = new Size(BOX_WIDTH, value.Height); }
            get { return base.Size; }
        }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public MowayShareBox()
        {
            InitializeComponent();
        }

        #region Graphic events

        /// <summary>
        /// Selecting Panel 1 when there are 3 options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelSelector3_1_TabButtonClick(object sender, EventArgs e)
        {
            this.panelSelector3_2.Selected = false;
            this.panelSelector3_3.Selected = false;
            this.SelectPanel(0);
        }

        /// <summary>
        /// Selecting Panel 2 when there are 3 options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelSelector3_2_TabButtonClick(object sender, EventArgs e)
        {
            this.panelSelector3_1.Selected = false;
            this.panelSelector3_3.Selected = false;
            this.SelectPanel(1);
        }

        /// <summary>
        /// Selecting Panel 3 when there are 3 options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelSelector3_3_TabButtonClick(object sender, EventArgs e)
        {
            this.panelSelector3_1.Selected = false;
            this.panelSelector3_2.Selected = false;
            this.SelectPanel(2);
        }

        /// <summary>
        /// Selecting Panel 1 when there are 2 options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelSelector2_1_TabButtonClick(object sender, EventArgs e)
        {
            this.panelSelector2_2.Selected = false;
            this.SelectPanel(0);
        }

        /// <summary>
        /// Selecting Panel 2 when there are 2 options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelSelector2_2_TabButtonClick(object sender, EventArgs e)
        {
            this.panelSelector2_1.Selected = false;
            this.SelectPanel(1);
        }

        #endregion

        #region Public methods

        public bool IsEmpty()
        {
            if (this.panels.Count == 0)
                return true;
            return false;
        }

        /// <summary>
        /// Add a new panel to the control
        /// </summary>
        /// <param name="panel">Panel to include</param>
        public void AddPanel(SharePanel panel)
        {
            if (this.panels.Count >= MAX_PANELS)
                throw new Exception("This control can only have 3 panels");
            //The control is initialized and added to the Panel list
            panel.Location = new Point(6, 30);
            panel.Size = new Size(BOX_WIDTH - 12, this.Height - 60);
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(panel);
            this.panels.Add(panel);
            //Depending on the number of panels that have been incializa the control in different ways
            switch (this.panels.Count)
            {
                case 1:     //If the first panel displays the control and initializes the 2 1 and 3 1 panel selectors
                    base.Visible = true;
                    this.panelSelector2_1.Text = panel.Tittle;
                    this.panelSelector3_1.Text = panel.ShortTittle;
                    this.panelSelector3_1.ToolTip = panel.Tittle;
                    break;
                case 2:     //If there are already two panels, the 2 2 and 2 3 panel selectors are Inciailizan and the Panel2 is displayed.
                    this.panelSelector2_1.Selected = false;
                    this.panelSelector2_2.Selected = true;
                    this.panel2.Visible = true;
                    this.panelSelector2_2.Text = panel.Tittle;
                    this.panelSelector3_2.Text = panel.ShortTittle;
                    this.panelSelector3_2.ToolTip = panel.Tittle;
                    break;
                case 3:     //If there are three panels, the 3 3 selector is initialized, the Panel2 is hidden and the panel3 is displayed
                    this.panelSelector3_1.Selected = false;
                    this.panelSelector3_2.Selected = false;
                    this.panelSelector3_3.Selected = true;
                    this.panel2.Visible = false;
                    this.panel3.Visible = true;
                    this.panelSelector3_3.Text = panel.ShortTittle;
                    this.panelSelector3_3.ToolTip = panel.Tittle;
                    break;
            }
            //Selects the last panel included
            this.SelectPanel(this.panels.Count - 1);
        }

        /// <summary>
        /// Removes a control panel
        /// </summary>
        /// <param name="panel">Panel to delete</param>
        public void RemovePanel(SharePanel panel)
        {
            if (!this.panels.Contains(panel))
                throw new Exception("Control don't constain this panel");
            //Panel is deleted
            int index = this.panels.IndexOf(panel);
            this.panels.Remove(panel);
            this.Controls.Remove(panel);
            //Depending of the panels that are...
            switch (this.panels.Count)
            {
                case 0:     //If there is no panel left, the control will Self-hide
                    this.Visible = false;
                    this.panelSelected = -1;
                    break;
                case 1:     //If a panel remains, the Panel2 is hidden and the selector switches 2 1 and 3 1 are updated
                    this.panel2.Visible = false;
                    this.panelSelector2_1.Text = panels[0].Tittle;
                    this.panelSelector3_1.Text = panels[0].ShortTittle;
                    //Selects the single pane that there is
                    this.SelectPanel(0);
                    break;
                case 2:     //If two panels remain, the panel3 is hidden, the Panel2 is displayed and the selectors 2 1, 3 1, 2 2 and 3 2 are updated
                    this.panel2.Visible = true;
                    this.panel3.Visible = false;
                    this.panelSelector2_1.Text = panels[0].Tittle;
                    this.panelSelector3_1.Text = panels[0].ShortTittle;
                    this.panelSelector2_2.Text = panels[1].Tittle;
                    this.panelSelector3_2.Text = panels[1].ShortTittle;
                    //The new panel is selected based on the previously selected and the deleted panel
                    if (this.panelSelected == 2)
                        this.SelectPanel(1);
                    else if ((this.panelSelected == 1) && (index == 1))
                        this.SelectPanel(1);
                    else
                        this.SelectPanel(0);
                    break;
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Selects a panel identified by its position in the Panel list
        /// </summary>
        /// <param name="index">Selection Index</param>
        private void SelectPanel(int index)
        {
            this.panelSelected = index;
            this.panels[this.panelSelected].BringToFront();
            this.lTittle.Text = this.panels[this.panelSelected].Tittle;
        }

        #endregion
    }
}
