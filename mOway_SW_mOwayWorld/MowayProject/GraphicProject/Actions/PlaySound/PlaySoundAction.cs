using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.PlaySound
{
    public class PlaySoundAction : Module
    {
        #region Attributes

        private Variable frequencyVariable = null;
        private decimal frecuencyValue = 244.14M;
        private FlowchartControl flowchartControl = FlowchartControl.Continuously;
        private Variable timeVariable = null;
        private decimal timeValue = 0.1M;
        private bool waitFinish = false;

        #endregion

        #region Properties

        public Variable FrequencyVariable { get { return this.frequencyVariable; } }
        public decimal FrecuencyValue { get { return this.frecuencyValue; } }
        public FlowchartControl FlowchartControl { get { return this.flowchartControl; } }
        public Variable TimeVariable { get { return this.timeVariable; } }
        public decimal TimeValue { get { return this.timeValue; } }
        public bool WaitFinish { get { return this.waitFinish; } }

        #endregion

        public PlaySoundAction(string key)
        {
            this.key = key;
        }

        public PlaySoundAction(string key, Variable frequencyVariable, decimal frecuencyValue, FlowchartControl flowchartControl, Variable timeVariable, decimal timeValue, bool waitFinish)
        {
            this.key = key;
            this.frequencyVariable = frequencyVariable;
            this.frecuencyValue = frecuencyValue;
            this.flowchartControl = flowchartControl;
            this.timeVariable = timeVariable;
            this.timeValue = timeValue;
            this.waitFinish = waitFinish;
        }

        public PlaySoundAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                    case "frequencyVariable":
                        if (property.InnerText != "none")
                            this.frequencyVariable = variables[property.InnerText];
                        break;
                    case "frecuencyValue":
                        this.frecuencyValue = System.Convert.ToDecimal(property.InnerText.Replace(',', '.'), new System.Globalization.CultureInfo("en-GB"));
                        break;
                    case "flowchartControl":
                        this.flowchartControl = (FlowchartControl)Enum.Parse(typeof(FlowchartControl), property.InnerText);
                        break;
                    case "timeVariable":
                        if (property.InnerText != "none")
                            this.timeVariable = variables[property.InnerText];
                        break;
                    case "timeValue":
                        this.timeValue = System.Convert.ToDecimal(property.InnerText.Replace(',', '.'), new System.Globalization.CultureInfo("en-GB"));
                        break;
                    case "waitFinish":
                        this.waitFinish = System.Convert.ToBoolean(property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(Variable frequencyVariable, decimal frecuencyValue, FlowchartControl flowchartControl, Variable timeVariable, decimal timeValue, bool waitFinish)
        {
            this.frequencyVariable = frequencyVariable;
            this.frecuencyValue = frecuencyValue;
            this.flowchartControl = flowchartControl;
            this.timeVariable = timeVariable;
            this.timeValue = timeValue;
            this.waitFinish = waitFinish;
        }

        public override bool VariableUsed(Variable variable)
        {
            if ((this.frequencyVariable == variable) || (this.timeVariable == variable))
                return true;
            else
                return false;
        }

        public override Element Clone()
        {
            return new PlaySoundAction(this.key, this.frequencyVariable, this.frecuencyValue, this.flowchartControl, this.timeVariable, this.timeValue, this.waitFinish);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            if (this.frequencyVariable == null)
                file.WriteElementString("frequencyVariable", "none");
            else
                file.WriteElementString("frequencyVariable", this.frequencyVariable.Name);
            file.WriteElementString("frecuencyValue", this.frecuencyValue.ToString());
            file.WriteElementString("flowchartControl", this.flowchartControl.ToString());
            if (this.timeVariable == null)
                file.WriteElementString("timeVariable", "none");
            else
                file.WriteElementString("timeVariable", this.timeVariable.Name);
            file.WriteElementString("timeValue", this.timeValue.ToString());
            file.WriteElementString("waitFinish", this.waitFinish.ToString());
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";************Module Speaker*********************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");

            if (frequencyVariable == null)
            {
                writer.WriteLine("  movlw   ." + (byte)((4000000 / (decimal)(frecuencyValue * 64)) - 1));
                writer.WriteLine("  movwf	SEN_SPEAKER_FREQ");
            }
            else
            {
                writer.WriteLine("  movf   " + frequencyVariable.Name + ",W");
                writer.WriteLine("  movwf	SEN_SPEAKER_FREQ");
            }
            if (flowchartControl != FlowchartControl.Continuously)
            {
                writer.WriteLine("  movlw	SPEAKER_TIME");
                writer.WriteLine("  movwf	SEN_SPEAKER_ON_OFF");
                if (timeVariable == null)
                {
                    writer.WriteLine("  movlw   ." + (byte)(timeValue * 10));
                    writer.WriteLine("  movwf	SEN_SPEAKER_TIME");
                }
                else
                {
                    writer.WriteLine("  movf   " + timeVariable.Name + ",W");
                    writer.WriteLine("  movwf	SEN_SPEAKER_TIME");
                }
            }
            else if (flowchartControl == FlowchartControl.Continuously)
            {
                writer.WriteLine("  movlw	SPEAKER_ON");
                writer.WriteLine("  movwf	SEN_SPEAKER_ON_OFF");
            }
            writer.WriteLine("  call	SEN_SPEAKER");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            // Value of the frequency
            if (frequencyVariable == null)
                mowayModel.Sound.UpdateSound(DigitalState.On, frecuencyValue);                            
            else            
                mowayModel.Sound.UpdateSound(DigitalState.On, mowayModel.GetRegister(frequencyVariable.Name).Value);

            // Execution time
            if (flowchartControl != FlowchartControl.Continuously)
            {                
                if (timeVariable == null)
                    System.Threading.Thread.Sleep((int)(this.timeValue * 1000));
                else                
                    System.Threading.Thread.Sleep((int)(mowayModel.GetRegister(this.timeVariable.Name).Value * 1000));

                //  Stop sound after run time
                mowayModel.Sound.UpdateSound(DigitalState.Off, 0);
            }
            else if (flowchartControl == FlowchartControl.Continuously)
            { }
        }

    }
}
