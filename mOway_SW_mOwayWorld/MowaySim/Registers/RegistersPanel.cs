using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Moway.Simulator.Registers
{
    /// <summary>
    /// Registers panel for the simulated mOway
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class RegistersPanel : ModulePanel
    {
        #region Constants

        /// <summary>
        /// Value of the scroll of the list of registers
        /// </summary>
        private int HSCROLL_STEP = 24;

        #endregion

        #region Attributes

        /// <summary>
        /// List of registers sorted by name
        /// </summary>
        private SortedList<Register, RegisterListViewItem> registers = new SortedList<Register, RegisterListViewItem>();
        /// <summary>
        /// Selected register
        /// </summary>
        private RegisterListViewItem itemSelected = null;

        #endregion

        /// <summary>
        /// Builder of the register panel of the mOway simulated
        /// </summary>
        /// <param name="mowayModel">Model of the mOway simulated</param>
        internal RegistersPanel(MowayModel mowayModel)
            : base(mowayModel)
        {
            InitializeComponent();
            //Registers events are logged
            mowayModel.RegisterAdded += new RegisterEventHandler(MowayModel_RegisterAdded);
            mowayModel.RegisterRemoved += new RegisterEventHandler(MowayModel_RegisterRemoved);
            //All registers of the simulated MOway are included in the list of registers
            foreach (Register register in mowayModel.Registers)
                AddRegisterItem(register);
            //The items in the register list are updated
            this.UpdateItems();
        }

        #region Form Events

        /// <summary>
        /// Selection of an item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Item_ItemSelected(object sender, EventArgs e)
        {
            if (this.itemSelected != (RegisterListViewItem)sender)
            {
                if (this.itemSelected != null)
                    this.itemSelected.Selected = false;
                this.itemSelected = (RegisterListViewItem)sender;
            }
        }

        /// <summary>
        /// Click on the Items panel (deselect the selected item)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PContainer_Click(object sender, EventArgs e)
        {
            if (this.itemSelected != null)
            {
                this.itemSelected.Selected = false;
                this.itemSelected = null;
            }
        }

        /// <summary>
        /// Change of panel size of items (enables or disables the scroll vertical)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PItems_SizeChanged(object sender, EventArgs e)
        {
            if (this.pItems.Height > this.pContainer.Height)
            {
                this.verticalScrollBar.Enabled = true;
                this.verticalScrollBar.MaximumValue = ((this.pItems.Height - this.pContainer.Height) / HSCROLL_STEP) + 1;
            }
            else
                this.verticalScrollBar.Enabled = false;
        }

        /// <summary>
        /// Change in value of the scroll vertically
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerticalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            this.pItems.Location = new Point(this.pItems.Location.X, -(this.pItems.Height - this.pContainer.Height) * this.verticalScrollBar.Value / this.verticalScrollBar.MaximumValue);
        }

        #endregion

        #region Events of MowayModel

        /// <summary>
        /// Occurs when a model register has been removed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void MowayModel_RegisterRemoved(object sender, RegisterEventArgs args)
        {
            RegisterListViewItem item = this.registers[args.Register];
            this.registers.Remove(args.Register);
            this.pItems.Controls.Remove(item);
            this.UpdateItems();
        }

        /// <summary>
        /// Occurs when a new register has been added to the model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void MowayModel_RegisterAdded(object sender, RegisterEventArgs args)
        {
            this.AddRegisterItem(args.Register);
            this.UpdateItems();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Generates the name of the panel
        /// </summary>
        /// <returns>Panel name</returns>
        public override string ToString()
        {
            return RegistersMessages.NAME;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Add a new register to the list of registers
        /// </summary>
        /// <param name="register"></param>
        private void AddRegisterItem(Register register)
        {
            RegisterListViewItem item = new RegisterListViewItem(register);
            item.Size = new Size(this.pItems.Width - 2, 18);
            item.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            item.ItemSelected += new EventHandler(Item_ItemSelected);
            this.registers.Add(register, item);
            this.pItems.Controls.Add(item);
        }

        /// <summary>
        /// Updates the display of the registers in the list
        /// </summary>
        private void UpdateItems()
        {
            int i = 0;
            for (; i < this.registers.Count; i++)
                this.registers.Values[i].Location = new Point(1, i * 19 + 1);
            this.pItems.Size = new Size(this.pItems.Width, i * 19 + 1);
        }

        #endregion
    }
}
