using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Template.Controls;

namespace Moway.Project.GraphicProject.Actions
{
    public partial class PropertiesPanel : SharePanel
    {
        #region Attributes

        private ActionPanel presentPanel = null;

        #endregion

        #region Properties

        public override string Tittle { get { return PropertiesMessages.TITTLE; } }
        public override string ShortTittle { get { return PropertiesMessages.SHORT_TITTLE; } }

        #endregion

        public PropertiesPanel()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        }

        public void LoadPanel(ActionPanel panel)
        {
            this.ClosePanel();
            this.presentPanel = panel;
            this.Controls.Add(this.presentPanel);
            this.presentPanel.Location = new Point(4, 5);
            this.lMessage.Visible = false;
        }

        public void UpdatePanelProperties()
        {
            if (this.presentPanel != null)
                this.presentPanel.UpdateSettings();
        }

        public void ClosePanel()
        {
            if (this.presentPanel != null)
            {
                this.Controls.Remove(this.presentPanel);
                this.lMessage.Visible = true;
            }
        }

        public void AddVariable(Variable variable)
        {
            if (this.presentPanel != null)
                this.presentPanel.AddVariable(variable);
        }
    }
}
