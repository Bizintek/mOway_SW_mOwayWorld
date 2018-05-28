using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using Moway.Template.Controls;

namespace Moway.Project.GraphicProject.Actions.ConfigIo
{
    public partial class ConfigIoPanel : ActionPanel
    {
        #region Attributes

        private ConfigIoAction action;
        private MowayComboBox[] cbTypes;
        private MowayComboBox[] cbValues;

        #endregion

        public ConfigIoPanel(ConfigIoAction action)
        {
            InitializeComponent();
            this.action = action;
            this.cbTypes = new MowayComboBox[] { this.cbType0, this.cbType1, this.cbType2, this.cbType3, this.cbType4, this.cbType5 };
            this.cbValues = new MowayComboBox[] { this.cbValue0, this.cbValue1, this.cbValue2, this.cbValue3, this.cbValue4, this.cbValue5 };
        }

        protected override void LoadSettings()
        {
            for (int i = 0; i < 6; i++)
                if (this.action.LineType[i] == IoType.Output)
                {
                    this.cbTypes[i].SelectedIndex = (int)IoType.Output;
                    if (this.action.LineValue[i] == IoValue.On)
                        this.cbValues[i].SelectedIndex = 0;
                    else
                        this.cbValues[i].SelectedIndex = 1;
                }
                else
                {
                    this.cbTypes[i].SelectedIndex = (int)IoType.Input;
                    this.cbValues[i].SelectedIndex = 0;
                }
        }

        protected override void SaveSettings()
        {
            IoType[] lineDir = { IoType.Input, IoType.Input, IoType.Input, IoType.Input, IoType.Input, IoType.Input };
            IoValue[] lineValue = { IoValue.On, IoValue.On, IoValue.On, IoValue.On, IoValue.On, IoValue.On };
            for (int i = 0; i < 6; i++)
                if (this.cbTypes[i].SelectedIndex == (int)IoType.Output)
                {
                    lineDir[i] = IoType.Output;
                    if (this.cbValues[i].SelectedIndex == 1)
                        lineValue[i] = IoValue.Off;
                }
            this.action.UpdateSettings(lineDir, lineValue);
        }

        private void CbType0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbType0.SelectedIndex == (int)IoType.Input)
                this.cbValue0.Enabled = false;
            else
                this.cbValue0.Enabled = true;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbType1.SelectedIndex == (int)IoType.Input)
                this.cbValue1.Enabled = false;
            else
                this.cbValue1.Enabled = true;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void Cbtype2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbType2.SelectedIndex == (int)IoType.Input)
                this.cbValue2.Enabled = false;
            else
                this.cbValue2.Enabled = true;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbType3.SelectedIndex == (int)IoType.Input)
                this.cbValue3.Enabled = false;
            else
                this.cbValue3.Enabled = true;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbType4.SelectedIndex == (int)IoType.Input)
                this.cbValue4.Enabled = false;
            else
                this.cbValue4.Enabled = true;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbType5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbType5.SelectedIndex == (int)IoType.Input)
                this.cbValue5.Enabled = false;
            else
                this.cbValue5.Enabled = true;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }
    }
}
