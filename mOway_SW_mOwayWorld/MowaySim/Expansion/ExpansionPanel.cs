using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Moway.Simulator.Expansion
{
    public partial class ExpansionPanel : ModulePanel
    {
        #region Properties

        public new string Name { get { return ExpansionMessages.NAME; } }

        #endregion


        public ExpansionPanel(MowayModel mowayModel): base(mowayModel)
        {
            InitializeComponent();
        }
    }
}
