using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.SetOut
{
    public class SetOutAction : Module
    {
        #region Attributes

        private IoValue[] lineValue = { IoValue.NoChange, IoValue.NoChange, IoValue.NoChange, IoValue.NoChange, IoValue.NoChange, IoValue.NoChange };

        #endregion

        #region Properties

        public IoValue[] LineValue { get { return this.lineValue; } }

        #endregion

        public SetOutAction(string key)
        {
            this.key = key;
        }

        public SetOutAction(string key, IoValue[] lineValue)
        {
            this.key = key;
            this.lineValue = lineValue;
        }

        public SetOutAction(string key, XmlElement properties)
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
                    case "lineValues":
                        foreach (XmlElement lineValue in property.ChildNodes)
                            this.lineValue[System.Convert.ToInt32(lineValue.Name[4])-48] = (IoValue)Enum.Parse(typeof(IoValue), lineValue.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(IoValue[] lineValue)
        {
            this.lineValue = lineValue;
        }

        public override Element Clone()
        {
            return new SetOutAction(this.key, this.lineValue);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteStartElement("lineValues");
            for (int i = 0; i < this.lineValue.Length; i++)
                file.WriteElementString("line"+i, this.lineValue[i].ToString());
            file.WriteEndElement();
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";*********************Module IO Module Set Out*********************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");

            if (lineValue[0] == IoValue.On)
            {
                writer.WriteLine("      banksel	    PORTH	 ");
                writer.WriteLine("      bsf	        CE_PIN	 ");
            }
            else if (lineValue[0] == IoValue.Off)
            {
                writer.WriteLine("      banksel	        PORTH	 ");
                writer.WriteLine("      bcf	        CE_PIN	 ");
            }
            else if (lineValue[0] == IoValue.Toggle)
            {
                writer.WriteLine("      banksel	    PORTH	 ");
                writer.WriteLine("      btg       CE_PIN");
            }
            writer.WriteLine("");


            if (lineValue[1] == IoValue.On)
            {
                writer.WriteLine("      banksel	    PORTF	 ");
                writer.WriteLine("      bsf	        CSN_PIN	 ");
            }
            else if (lineValue[1] == IoValue.Off)
            {
                writer.WriteLine("      banksel	    PORTF	 ");
                writer.WriteLine("      bcf	        CSN_PIN	 ");
            }
            else if (lineValue[1] == IoValue.Toggle)
            {
                writer.WriteLine("      banksel	    PORTF	 ");
                writer.WriteLine("      btg        CSN_PIN 	 ");
            }
            writer.WriteLine("");


            if (lineValue[2] == IoValue.On)
            {
                writer.WriteLine("      banksel	    PORTC	 ");
                writer.WriteLine("      bsf	        SCK_PIN	 ");
            }
            else if (lineValue[2] == IoValue.Off)
            {
                writer.WriteLine("      banksel	    PORTC	 ");
                writer.WriteLine("      bcf	        SCK_PIN	 ");
            }
            else if (lineValue[2] == IoValue.Toggle)
            {
                writer.WriteLine("      banksel	    PORTC	 ");
                writer.WriteLine("      btg	        SCK_PIN	 ");
            }
            writer.WriteLine("");


            if (lineValue[3] == IoValue.On)
            {
                writer.WriteLine("      banksel	    PORTC	 ");
                writer.WriteLine("      bsf	        SDO_PIN	 ");
            }
            else if (lineValue[3] == IoValue.Off)
            {
                writer.WriteLine("      banksel	    PORTC	 ");
                writer.WriteLine("      bcf	        SDO_PIN	 ");
            }
            else if (lineValue[3] == IoValue.Toggle)
            {
                writer.WriteLine("      banksel	    PORTC	 ");
                writer.WriteLine("      btg         SDO_PIN	 ");
            }
            writer.WriteLine("");


            if (lineValue[4] == IoValue.On)
            {
                writer.WriteLine("      banksel	    PORTC	 ");
                writer.WriteLine("      bsf	        SDI_PIN	 ");
            }
            else if (lineValue[4] == IoValue.Off)
            {
                writer.WriteLine("      banksel	    PORTC	 ");
                writer.WriteLine("      bcf	        SDI_PIN	 ");
            }
            else if (lineValue[4] == IoValue.Toggle)
            {
                writer.WriteLine("      banksel	    PORTC	 ");
                writer.WriteLine("      btg	        SDI_PIN	 ");
            }
            writer.WriteLine("");



            if (lineValue[5] == IoValue.On)
            {
                writer.WriteLine("      banksel	    PORTB	 ");
                writer.WriteLine("      bsf	        IRQ_PIN	 ");
            }
            else if (lineValue[5] == IoValue.Off)
            {
                writer.WriteLine("      banksel	    PORTB	 ");
                writer.WriteLine("      bcf	        IRQ_PIN	 ");
            }
            else if (lineValue[5] == IoValue.Toggle)
            {
                writer.WriteLine("      banksel	    PORTB	 ");
                writer.WriteLine("      btg	        IRQ_PIN	 ");
            }
            writer.WriteLine("");
            writer.WriteLine("      banksel	    AUX_00	 ");

            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            
        }
    }
}
