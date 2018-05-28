using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Template.Controls;

namespace Moway.Project.GraphicProject.Actions.ConfigIo
{
    public partial class ConfigIoForm : ActionForm
    {
        #region Attributes

        private ConfigIoAction action;
        private MowayOnOff[] ooTypes;
        private MowayComboBox[] cbValues;
        private PictureBox[] pbInputs;
        private PictureBox[] pbOutputs;

        #endregion

        public ConfigIoForm(ConfigIoAction action)
        {
            InitializeComponent();
            this.helpTopic = ConfigIo.HelpTopic;
this.action = action;
            this.ooTypes = new MowayOnOff[] { this.ooType0, this.ooType1, this.ooType2, this.ooType3, this.ooType4, this.ooType5 };
            this.cbValues = new MowayComboBox[] { this.cbValue0, this.cbValue1, this.cbValue2, this.cbValue3, this.cbValue4, this.cbValue5 };
            this.pbInputs = new PictureBox[] { this.pbInput0, this.pbInput1, this.pbInput2, this.pbInput3, this.pbInput4, this.pbInput5 };
            this.pbOutputs = new PictureBox[] { this.pbOut0, this.pbOutput1, this.pbOutput2, this.pbOutput3, this.pbOutput4, this.pbOutput5 };
        }

        protected override void LoadSettings()
        {
            for (int i = 0; i < 6; i++)
                if (this.action.LineType[i] == IoType.Output)
                {
                    this.ooTypes[i].State = false;
                    if (this.action.LineValue[i] == IoValue.On)
                        this.cbValues[i].SelectedIndex = 0;
                    else
                        this.cbValues[i].SelectedIndex = 1;
                }
                else
                    this.cbValues[i].SelectedIndex = 0;
        }

        protected override void SaveSettings()
        {
            IoType[] lineDir = { IoType.Input, IoType.Input, IoType.Input, IoType.Input, IoType.Input, IoType.Input };
            IoValue[] lineValue = { IoValue.On, IoValue.On, IoValue.On, IoValue.On, IoValue.On, IoValue.On};
            for (int i = 0; i < 6; i++)
                if (this.ooTypes[i].State == false)
                {
                    lineDir[i] = IoType.Output;
                    if (this.cbValues[i].SelectedIndex == 1)
                        lineValue[i] = IoValue.Off;
                }
            this.action.UpdateSettings(lineDir, lineValue);
        }

        private void ooTypes_StateChanged(int index)
        {
            if (this.ooTypes[index].State)
            {
                this.pbInputs[index].Visible = true;
                this.pbOutputs[index].Visible = false;
                this.cbValues[index].Enabled = false;
            }
            else
            {
                this.pbInputs[index].Visible = false;
                this.pbOutputs[index].Visible = true;
                this.cbValues[index].Enabled = true;
            }
        }

        private void ooType0_StateChanged(object sender, EventArgs e)
        {
            this.ooTypes_StateChanged(0);
        }

        private void ooType1_StateChanged(object sender, EventArgs e)
        {
            this.ooTypes_StateChanged(1);
        }

        private void ooType2_StateChanged(object sender, EventArgs e)
        {
            this.ooTypes_StateChanged(2);
        }

        private void ooType3_StateChanged(object sender, EventArgs e)
        {
            this.ooTypes_StateChanged(3);
        }

        private void ooType4_StateChanged(object sender, EventArgs e)
        {
            this.ooTypes_StateChanged(4);
        }

        private void ooType5_StateChanged(object sender, EventArgs e)
        {
            this.ooTypes_StateChanged(5);
        }
    }
}
