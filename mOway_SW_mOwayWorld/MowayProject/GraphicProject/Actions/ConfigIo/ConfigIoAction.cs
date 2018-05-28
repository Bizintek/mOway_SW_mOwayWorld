using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.ConfigIo
{
    public class ConfigIoAction : Module
    {
        #region Attributes

        private IoType[] lineType = { IoType.Input, IoType.Input, IoType.Input, IoType.Input, IoType.Input, IoType.Input };
        private IoValue[] lineValue = { IoValue.On, IoValue.On, IoValue.On, IoValue.On, IoValue.On, IoValue.On };

        #endregion

        #region Properties

        public IoType[] LineType { get { return this.lineType; } }
        public IoValue[] LineValue { get { return this.lineValue; } }

        #endregion

        public ConfigIoAction(string key)
        {
            this.key = key;
        }

        public ConfigIoAction(string key, IoType[] lineType, IoValue[] lineValue)
        {
            this.key = key;
            this.lineType = lineType;
            this.lineValue = lineValue;
        }

        public ConfigIoAction(string key, XmlElement properties)
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
                    case "lineTypes":
                        foreach (XmlElement lineType in property.ChildNodes)
                            this.lineType[System.Convert.ToInt32(lineType.Name[4])-48] = (IoType)Enum.Parse(typeof(IoType), lineType.InnerText);
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

        public void UpdateSettings(IoType[] lineType, IoValue[] lineValue)
        {
            this.lineType = lineType;
            this.lineValue = lineValue;
        }

        public override Element Clone()
        {
            return new ConfigIoAction(this.key, this.lineType, this.lineValue);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteStartElement("lineTypes");
            for (int i = 0; i < this.lineType.Length; i++)
                file.WriteElementString("line"+i, this.lineType[i].ToString());
            file.WriteEndElement();
            file.WriteStartElement("lineValues");
            for (int i = 0; i < this.lineValue.Length; i++)
                file.WriteElementString("line"+i, this.lineValue[i].ToString());
            file.WriteEndElement();
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";*********************Module IO Module Configuration*********************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
            writer.WriteLine("    ;Configuration of SPI module");
            writer.WriteLine("      banksel	    SSPCON1");
            writer.WriteLine("      movlw	    b'00000000'");
            writer.WriteLine("      movwf	    SSPCON1");


            writer.WriteLine("      banksel	TRISH	 ");         
            if (lineType[0] == IoType.Input)
                writer.WriteLine("      bsf	    CE_TRIS	 ");
            else
            {
                writer.WriteLine("      bcf	    CE_TRIS	 ");
                writer.WriteLine("      banksel	    PORTH	 ");
                if (lineValue[0] == IoValue.On)
                    writer.WriteLine("      bsf	    CE_PIN	 ");
                else
                    writer.WriteLine("      bcf	    CE_PIN	 ");
            }



            writer.WriteLine("      banksel	    TRISF	 ");
            if (lineType[1] == IoType.Input)
                writer.WriteLine("      bsf	    CSN_TRIS	 ");
            else
            {
                writer.WriteLine("      bcf	    CSN_TRIS	 ");
                writer.WriteLine("      banksel	    PORTF	 ");
                if (lineValue[1] == IoValue.On)
                    writer.WriteLine("      bsf	    CSN_PIN	 ");
                else
                    writer.WriteLine("      bcf	    CSN_PIN	 ");
            }


            writer.WriteLine("      banksel	    TRISC	 ");
            if (lineType[2] == IoType.Input)
                writer.WriteLine("      bsf	    SCK_TRIS	 ");
            else
            {
                writer.WriteLine("      bcf	    SCK_TRIS	 ");
                writer.WriteLine("      banksel	    PORTC	 ");
                if (lineValue[2] == IoValue.On)
                    writer.WriteLine("      bsf	    SCK_PIN	 ");
                else
                    writer.WriteLine("      bcf	    SCK_PIN	 ");
            }


            writer.WriteLine("      banksel	    TRISC	 ");
            if (lineType[3] == IoType.Input)
                writer.WriteLine("      bsf	    SDO_TRIS		 ");
            else
            {
                writer.WriteLine("      bcf	    SDO_TRIS		 ");
                writer.WriteLine("      banksel	    PORTC	 ");
                if (lineValue[3] == IoValue.On)
                    writer.WriteLine("      bsf	    SDO_PIN	 ");
                else
                    writer.WriteLine("      bcf	    SDO_PIN	 ");
            }


            writer.WriteLine("      banksel	    TRISC	 ");
            if (lineType[4] == IoType.Input)
                writer.WriteLine("      bsf	    SDI_TRIS	 ");
            else
            {
                writer.WriteLine("      bcf	    SDI_TRIS	 ");
                writer.WriteLine("      banksel	    PORTC	 ");
                if (lineValue[4] == IoValue.On)
                    writer.WriteLine("      bsf	    SDI_PIN	 ");
                else
                    writer.WriteLine("      bcf	    SDI_PIN	 ");
            }


            writer.WriteLine("      banksel	    TRISB	 ");
            if (lineType[5] == IoType.Input)
                writer.WriteLine("      bsf	    IRQ_TRIS	 ");
            else
            {
                writer.WriteLine("      bcf	    IRQ_TRIS	 ");
                writer.WriteLine("      banksel	    PORTB	 ");
                if (lineValue[5] == IoValue.On)
                    writer.WriteLine("      bsf	    IRQ_PIN	 ");
                else
                    writer.WriteLine("      bcf	    IRQ_PIN	 ");
            }
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
