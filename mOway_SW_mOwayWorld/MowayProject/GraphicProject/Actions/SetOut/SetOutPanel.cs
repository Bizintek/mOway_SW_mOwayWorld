using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using Moway.Template.Controls;

namespace Moway.Project.GraphicProject.Actions.SetOut
{
    public partial class SetOutPanel : ActionPanel
    {
        #region Attributes

        private SetOutAction action;
        private MowayComboBox[] cbValues;

        #endregion

        public SetOutPanel(SetOutAction action)
        {
            InitializeComponent();
            this.action = action;
            this.cbValues = new MowayComboBox[] { this.cbValue0, this.cbValue1, this.cbValue2, this.cbValue3, this.cbValue4, this.cbValue5 };
        }

        protected override void LoadSettings()
        {
            for (int i = 0; i < 6; i++)
                this.cbValues[i].SelectedIndex = (int)this.action.LineValue[i];
        }

        protected override void SaveSettings()
        {
            IoValue[] lineValue = { IoValue.NoChange, IoValue.NoChange, IoValue.NoChange, IoValue.NoChange, IoValue.NoChange, IoValue.NoChange };
            for (int i = 0; i < 6; i++)
                lineValue[i] = (IoValue)Enum.ToObject(typeof(IoValue), this.cbValues[i].SelectedIndex);
            this.action.UpdateSettings(lineValue);
        }

        private void CbValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }
    }
}
