using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Pause
{
    /// <summary>
    /// "Pause" action of logical level
    /// </summary>
    public class PauseAction : Module
    {
        #region Attributes

        /// <summary>
        /// Variable to establish time, null in case of being constant
        /// </summary>
        private Variable timeVariable = null;
        /// <summary>
        /// Literal value for a constant time
        /// </summary>
        private decimal timeValue = 1;

        #endregion

        #region Properties

        /// <summary>
        /// Variable to establish time, null in case of being constant
        /// </summary>
        public Variable TimeVariable { get { return this.timeVariable; } }
        /// <summary>
        /// Literal value for a constant time
        /// </summary>
        public decimal TimeValue { get { return this.timeValue; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="key">Action key</param>
        public PauseAction(string key)
        {
            this.key = key;
        }

        public PauseAction(string key, Variable timeVariable, decimal timeValue)
        {
            this.key = key;
            this.timeVariable = timeVariable;
            this.timeValue = timeValue;
        }

        public PauseAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
        {
            this.key = key;
            if (properties.Name != "properties")
                throw new ActionException("Can't create the action");
            foreach (XmlElement property in properties.ChildNodes)
            {
                switch (property.Name)
                {
                    case "version":
                        break;
                    case "timeVariable":
                        if (property.InnerText != "none")
                            this.timeVariable = variables[property.InnerText];
                        break;
                    case "timeValue":
                        this.timeValue = System.Convert.ToDecimal(property.InnerText.Replace(',', '.'), new System.Globalization.CultureInfo("en-GB"));
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        /// <summary>
        /// Update the Properties of the action
        /// </summary>
        /// <param name="timeVariable">Variable to establish time, null in case of being constant</param>
        /// <param name="timeValue">Literal value for a constant time</param>
        public void UpdateSettings(Variable timeVariable, decimal timeValue)
        {
            this.timeVariable = timeVariable;
            this.timeValue = timeValue;
        }

        public override bool VariableUsed(Variable variable)
        {
            if (this.timeVariable == variable)
                return true;
            else
                return false;
        }

        public override Element Clone()
        {
            return new PauseAction(this.key, this.timeVariable, this.timeValue);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            if (this.timeVariable == null)
                file.WriteElementString("timeVariable", "none");
            else
                file.WriteElementString("timeVariable", this.timeVariable.Name);
            file.WriteElementString("timeValue", this.timeValue.ToString());
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";************Module Pause***********************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");

            if (this.timeVariable == null)
            {
                writer.WriteLine("  banksel	    AUX_00	 ");
                writer.WriteLine("  movlw   ." + (byte)(this.timeValue * 20));
                writer.WriteLine("  movwf   AUX_00");
                writer.WriteLine("  call    Delay_50ms_mOwayGUI");

            }
            else
            {
                writer.WriteLine("  banksel	    AUX_00	 ");
                writer.WriteLine("  movf  " + this.timeVariable.Name + ",W");
                writer.WriteLine("  movwf   AUX_00");
                writer.WriteLine("  call    Delay_50ms_mOwayGUI");
            }
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            if (this.timeVariable == null)
                System.Threading.Thread.Sleep((int)(this.timeValue * 1000));
            else
                System.Threading.Thread.Sleep((int)(mowayModel.GetRegister(this.timeVariable.Name).Value * 1000));
        }
    }
}
