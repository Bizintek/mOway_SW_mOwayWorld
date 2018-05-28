using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions
{
    public partial class ActionPanel : UserControl
    {
        protected const int PANEL_WIDTH = 220;

        protected bool autoSave = false;

        public new Size Size
        {
            set { base.Size = new Size(PANEL_WIDTH, value.Height); }
            get { return base.Size; }
        }

        public ActionPanel()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        }

        public void UpdateSettings()
        {
            this.autoSave = false;
            this.LoadSettings();
            this.autoSave = true;
        }

        public virtual void AddVariable(Variable variable) { }

        protected virtual void LoadSettings() { }

        protected virtual void SaveSettings() { }

        private void ActionPanel_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Variable variable in GraphManager.Project.Variables)
                    this.AddVariable(variable);
            }
            catch { }
            this.LoadSettings();
            this.autoSave = true;
        }
    }
}
