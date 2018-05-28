using System;
using System.Drawing;
using System.Windows.Forms;

namespace Moway.Template
{
    /// <summary>
    /// Form has been modified so that it will do the alert message times
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class MowayMessageBox : Form
    {
        #region Properties

        /// <summary>
        /// It indicates if the box has been activated, of without showing the notice again
        /// </summary>
        public bool ShowAgain { get { return !this.cbShowAgain.Checked; } }

        #endregion

        #region Reconfiguration to disable the Close button of the form

        private const int CP_NOCLOSE_BUTTON = 0x200;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ClassStyle = createParams.ClassStyle | CP_NOCLOSE_BUTTON;
                return createParams;
            }
        }

        #endregion

        private MowayMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, bool showAgain)
        {
            InitializeComponent();
            this.Text = caption;
            this.lBoxMessage.Text = text;
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    this.bOk.Visible = true;
                    if (!showAgain)
                        this.bOk.Location = new Point(280, 85);
                    break;
                case MessageBoxButtons.OKCancel:
                    this.bOk.Location = new Point(180, 100);
                    this.bOk.Visible = true;
                    this.bCancel.Visible = true;
                    if (!showAgain)
                    {
                        this.bOk.Location = new Point(180, 85);
                        this.bCancel.Location = new Point(280, 85);
                    }
                    break;
                case MessageBoxButtons.YesNo:
                    this.bYes.Visible = true;
                    this.bNo.Visible = true;
                    if (!showAgain)
                    {
                        this.bYes.Location = new Point(180, 85);
                        this.bNo.Location = new Point(280, 85);
                    }
                    break;
                case MessageBoxButtons.YesNoCancel:
                    this.bYes.Location = new Point(80, 100);
                    this.bYes.Visible = true;
                    this.bNo.Location = new Point(180, 100);
                    this.bNo.Visible = true;
                    this.bCancel.Visible = true;
                    if (!showAgain)
                    {
                        this.bYes.Location = new Point(80, 85);
                        this.bNo.Location = new Point(180, 85);
                        this.bCancel.Location = new Point(280, 85);
                    }
                    break;
                case MessageBoxButtons.RetryCancel:
                    this.bRetry.Visible = true;
                    this.bCancel.Visible = true;
                    if (!showAgain)
                    {
                        this.bRetry.Location = new Point(180, 85);
                        this.bCancel.Location = new Point(280, 85);
                    }
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    this.bIgnore.Visible = true;
                    this.bRetry.Visible = true;
                    this.bIgnore.Visible = true;
                    if (!showAgain)
                    {
                        this.bIgnore.Location = new Point(80, 85);
                        this.bRetry.Location = new Point(180, 85);
                        this.bIgnore.Location = new Point(280, 85);
                    }
                    break;
            }
            //Not controlled some but because they are the same in reality
            switch (icon)
            {
                case MessageBoxIcon.None:
                    this.pbBoxIcon.Visible = false;
                    this.lBoxMessage.Size = new Size(335, 45);
                    this.lBoxMessage.Location = new Point(20, 15);
                    break;
                case MessageBoxIcon.Information:
                    this.pbBoxIcon.Image = this.boxIcons.Images[0];
                    break;
                case MessageBoxIcon.Error:
                    this.pbBoxIcon.Image = this.boxIcons.Images[1];
                    break;
                case MessageBoxIcon.Warning:
                    this.pbBoxIcon.Image = this.boxIcons.Images[2];
                    break;
                case MessageBoxIcon.Question:
                    this.pbBoxIcon.Image = this.boxIcons.Images[3];
                    break;
            }
            if (!showAgain)
            {
                this.cbShowAgain.Visible = false;
                this.Size = new Size(380, 150);
            }
        }

        #region Recoding of the static methods Show

        /// <summary>
        /// Static method that creates the reminder window and displays the message window
        /// </summary>
        /// <param name="text">Window text</param>
        /// <param name="caption">Title of the window</param>
        /// <param name="buttons">Buttons to show in the window</param>
        /// <param name="icon">Icon to show in the window</param>
        /// <param name="showAgain">Indicates whether the message is re-displayed (it is a data passed by reference)</showAgain>
        /// <returns>Form result</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, ref bool showAgain)
        {
            MowayMessageBox mowayMessageBox = new MowayMessageBox(text, caption, buttons, icon, true);
            DialogResult result = mowayMessageBox.ShowDialog();
            showAgain = mowayMessageBox.ShowAgain;
            return result;
        }

        /// <summary>
        /// Static method that creates the reminder window and displays the message window
        /// </summary>
        /// <param name="text">Window text</param>
        /// <param name="caption">Title of the window</param>
        /// <param name="buttons">Buttons to show in the window</param>
        /// <param name="icon">Icon to show in the window</param>
        /// <param name="showAgain">Indicates whether the message is re-displayed (it is a data passed by reference)</showAgain>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            MowayMessageBox mowayMessageBox = new MowayMessageBox(text, caption, buttons, icon, false);
            return mowayMessageBox.ShowDialog();
        }

        /// <summary>
        /// Static method that creates the reminder window and displays the message window
        /// </summary>
        /// <param name="text">Window text</param>
        /// <param name="caption">Title of the window</param>
        /// <param name="buttons">Buttons to show in the window</param>
        /// <param name="showAgain">Indicates whether the message is re-displayed (it is a data passed by reference)</showAgain>
        /// <returns>Form result</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, ref bool showAgain)
        {
            MowayMessageBox mowayMessageBox = new MowayMessageBox(text, caption, buttons, MessageBoxIcon.None, true);
            DialogResult result = mowayMessageBox.ShowDialog();
            showAgain = mowayMessageBox.ShowAgain;
            return result;
        }

        /// <summary>
        /// Static method that creates the reminder window and displays the message window
        /// </summary>
        /// <param name="text">Control events</param>
        /// <param name="caption">Title of the window</param>
        /// <param name="buttons">Buttons to show in the window</param>
        /// <returns>Form result</returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            MowayMessageBox mowayMessageBox = new MowayMessageBox(text, caption, buttons, MessageBoxIcon.None, false);
            return mowayMessageBox.ShowDialog();
        }

        /// <summary>
        /// Static method that creates the reminder window and displays the message window
        /// </summary>
        /// <param name="text">Control events</param>
        /// <param name="caption">Title of the window</param>
        /// <param name="showAgain">Indicates whether the message is re-displayed (it is a data passed by reference)</showAgain>
        /// <returns>Form result</returns>
        public static DialogResult Show(string text, string caption, ref bool showAgain)
        {
            MowayMessageBox mowayMessageBox = new MowayMessageBox(text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, true);
            DialogResult result = mowayMessageBox.ShowDialog();
            showAgain = mowayMessageBox.ShowAgain;
            return result;
        }

        /// <summary>
        /// Static method that creates the reminder window and displays the message window
        /// </summary>
        /// <param name="text">Control events</param>
        /// <param name="caption">Title of the window</param>
        /// <returns>Form result</returns>
        public static DialogResult Show(string text, string caption)
        {
            MowayMessageBox mowayMessageBox = new MowayMessageBox(text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, false);
            return mowayMessageBox.ShowDialog();
        }

        #endregion

        #region Events of the different buttons on the form

        /// <summary>
        /// Occurs when the OK button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Occurs when the Yes button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        /// <summary>
        /// Occurs when the No button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        /// <summary>
        /// Occurs when the Retry button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BRetry_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        /// <summary>
        /// Occurs when the Ignore button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BIgnore_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
            this.Close();
        }

        /// <summary>
        /// Occurs when the Abort button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BAbort_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        /// <summary>
        /// Occurs when the Cancel button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
