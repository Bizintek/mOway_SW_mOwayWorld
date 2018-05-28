using System;
using System.Globalization;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// NumericUpDown customized for mOwayWorld
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class MowayNumericUpDown : UserControl
    {
        #region Attributes

        /// <summary>
        /// Value of the NumericUpDown
        /// </summary>
        private decimal value = 1;
        /// <summary>
        /// Previous value, to avoid sending unnecessary ValueChanged events
        /// </summary>
        private decimal prevValue = 1;
        /// <summary>
        /// NumericUpDown Increase
        /// </summary>
        private decimal increment = 1;
        /// <summary>
        /// Minimum value for NumericUpDown
        /// </summary>
        private decimal minimum = 0;
        /// <summary>
        /// Maximum value for the NumericUpDown
        /// </summary>
        private decimal maximum = 100;
        /// <summary>
        /// Number of decimals to display in the NumericUpDown
        /// </summary>
        private int decimalPlaces = 0;

        #endregion

        #region Properties

        /// <summary>
        /// This property is rewritten to affect all the elements that compose in NumericUpDown
        /// </summary>
        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                this.bUp.Enabled = base.Enabled;
                this.bDown.Enabled = base.Enabled;
                this.textBox.Enabled = base.Enabled;
                if (base.Enabled)
                    this.BackColor = Color.White;
                else
                    this.BackColor = SystemColors.Control;
            }
        }
        /// <summary>
        /// This property is rewritten so that the height of the control is always the same
        /// </summary>
        public new Size Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                base.Size = new Size(value.Width, 21);
            }
        }
        /// <summary>
        /// Value of the NumericUpDown
        /// </summary>
        public decimal Value
        {
            get { return this.value; }
            set {
                this.prevValue = this.value;
                this.value = value;
                this.OnValueChange();
                this.ShowValue();
            }
        }
        /// <summary>
        /// NumericUpDown Increase
        /// </summary>
        public decimal Increment
        {
            get { return this.increment; }
            set{this.increment = value;}
        }
        /// <summary>
        /// Minimum value for NumericUpDown
        /// </summary>
        public decimal Minimum
        {
            get { return this.minimum; }
            set {
                this.prevValue = this.value;
                this.minimum = value;
                this.OnValueChange();
                this.ShowValue();
            }
        }
        /// <summary>
        /// Maximum value for the NumericUpDown
        /// </summary>
        public decimal Maximum
        {
            get { return this.maximum; }
            set
            {
                this.prevValue = this.value;
                this.maximum = value;
                this.OnValueChange();
                this.ShowValue();
            }
        }
        /// <summary>
        /// Number of decimals to display in the NumericUpDown
        /// </summary>
        public int DecimalPlaces
        {
            get { return this.decimalPlaces; }
            set
            {
                this.decimalPlaces = value;
                this.ShowValue();
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the Value of the NumericUpDown changes
        /// </summary>
        public event EventHandler ValueChanged;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public MowayNumericUpDown()
        {
            InitializeComponent();
            this.textBox.LostFocus+=new EventHandler(TextBox_LostFocus);
        }

        #region Redefining methods

        /// <summary>
        /// Causes the LostFocus event in the TextBox to have an effect on the control itself
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
        }

        /// <summary>
        /// Paints the control frame
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(MowayColors.Border), 2), e.ClipRectangle);
            e.Graphics.DrawLine(new Pen(new SolidBrush(MowayColors.Border), 1), new Point(this.Width - 12, 10), new Point(this.Width, 10));
        }

        #endregion

        #region Control events

        /// <summary>
        /// Event of clicking with the left mouse button on the up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BUp_MouseDown(object sender, MouseEventArgs e)
        {
            this.bDown.Enabled = true;
            this.prevValue = this.value;
            this.value += increment;
            this.OnValueChange();
            if (this.value < this.maximum)
                this.timer.Enabled = true;
            this.ShowValue();
        }

        /// <summary>
        /// Event of clicking with the left mouse button on the down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDown_MouseDown(object sender, MouseEventArgs e)
        {
            this.bUp.Enabled = true;
            this.prevValue = this.value;
            this.value -= increment;
            this.OnValueChange();
            if (this.value > this.minimum)
                this.timer.Enabled = true;
            this.ShowValue();
        }

        /// <summary>
        /// Left mouse button release event en el Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BUp_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.timer.Interval = 500;
                this.timer.Enabled = false;
            }
        }

        /// <summary>
        /// Left mouse button release event en el botón Up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
                private void BDown_MouseUp(object sender, MouseEventArgs e)
        {
            this.timer.Interval = 500;
            this.timer.Enabled = false;
        }

        /// <summary>
        /// This timer causes the autoincrement when you press and hold the left mouse button on the buttons Up and Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.timer.Interval = 50;
            if (this.bUp.Focused)
            {
                this.prevValue = this.value;
                this.value += increment;
                this.OnValueChange();
                if (this.value >= this.maximum)
                    this.timer.Enabled = false;
            }
            else
            {
                this.prevValue = this.value;
                this.value -= increment;
                this.OnValueChange();
                if (this.value <= this.minimum)
                    this.timer.Enabled = false;
            }
            this.ShowValue();
        }

        /// <summary>
        /// It allows to control the NumericUpDown in the buttons of the keyboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                try
                {
                    this.prevValue = this.value;
                    this.value = Math.Round((System.Convert.ToDecimal(this.textBox.Text) / this.increment), 0) * this.increment;
                    this.OnValueChange();
                    this.ShowValue();
                }
                catch
                {
                    this.ShowValue();
                }
            else if (e.KeyCode == Keys.Up)
            {
                this.prevValue = value;
                this.value += this.increment;
                this.OnValueChange();
                this.ShowValue();
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.prevValue = value;
                this.value -= this.increment;
                this.OnValueChange();
                this.ShowValue();
            }
        }

        /// <summary>
        /// Validate the key pressed in the TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && (e.KeyChar != CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]) && (e.KeyChar != '-'))
                e.Handled = true;
        }

        /// <summary>
        /// Generates the value when the TextBox loses focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TextBox_LostFocus(object sender, System.EventArgs e)
        {
            try
            {
                this.prevValue = this.value;
                this.value = Math.Round((System.Convert.ToDecimal(this.textBox.Text) / this.increment), 0) * this.increment;
                this.OnValueChange();
                this.ShowValue();
            }
            catch
            {
                this.ShowValue();
            }
        }

        /// <summary>
        /// Validates the Value of the NumericUpDown
        /// </summary>
        private void OnValueChange()
        {
            if (this.value <= this.minimum)
            {
                this.value = this.minimum;
                this.bDown.Enabled = false;
            }
            else
                this.bDown.Enabled = true;
            if (this.value >= this.maximum)
            {
                this.value = this.maximum;
                this.bUp.Enabled = false;
            }
            else
                this.bUp.Enabled = true;
            //If the value has changed from the previous value, the event is thrown
            if ((this.prevValue != this.value) && (this.ValueChanged != null))
                this.ValueChanged(this, new EventArgs());
        }

        #endregion

        #region Private methods

        /// <summary>
        ///Displays the Value of the NumericUpDown in the TextBox
        /// </summary>
        private void ShowValue()
        {
            string format = "0";
            if (this.decimalPlaces != 0)
            {
                format += ".";
                for (int i = 0; i < this.decimalPlaces; i++)
                {
                    format += "0";
                }
            }
            this.textBox.Text = this.value.ToString(format);
        }

        #endregion
    }
}
