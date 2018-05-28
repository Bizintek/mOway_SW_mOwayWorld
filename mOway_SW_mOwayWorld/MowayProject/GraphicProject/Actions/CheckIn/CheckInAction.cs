using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.CheckIn
{
    public class CheckInAction : Conditional
    {
        #region Attributes

        private int line = 0;
        private ComparativeOp operation = ComparativeOp.Equal;
        private IoValue lineValue = IoValue.On;

        #endregion

        #region Properties

        public int Line { get { return this.line; } }
        public ComparativeOp Operation { get { return this.operation; } }
        public IoValue LineValue { get { return this.lineValue; } }

        #endregion

        public CheckInAction(string key)
        {
            this.key = key;
        }

        public CheckInAction(string key, int line, ComparativeOp operation, IoValue lineValue)
        {
            this.key = key;
            this.line = line;
            this.operation = operation;
            this.lineValue = lineValue;
        }

        public CheckInAction(string key, XmlElement properties)
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
                    case "line":
                        this.line = System.Convert.ToInt32(property.InnerText);
                        break;
                    case "operation":
                        this.operation = (ComparativeOp)Enum.Parse(typeof(ComparativeOp), property.InnerText);
                        break;
                    case "lineValue":
                        this.lineValue = (IoValue)Enum.Parse(typeof(IoValue), property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(int line, ComparativeOp operation, IoValue lineValue)
        {
            this.line = line;
            this.operation = operation;
            this.lineValue = lineValue;
        }

        public override Element Clone()
        {
            return new CheckInAction(this.key, this.line, this.operation, this.lineValue);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteElementString("line", this.line.ToString());
            file.WriteElementString("operation", this.operation.ToString());
            file.WriteElementString("lineValue", this.lineValue.ToString());
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer, string labelFalse)
        {
            writer.WriteLine(";**************Module IoCheckIn*****************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");

            switch (line)
            {
                case 0:
                    writer.WriteLine("      banksel	    PORTH	 ");                   
                    if (this.operation == ComparativeOp.Equal)
                    {
                        if (this.lineValue == IoValue.On)
                            writer.WriteLine("      btfss       CE_PIN");
                        else if (this.lineValue == IoValue.Off)
                            writer.WriteLine("      btfsc       CE_PIN");
                    }
                    else if (this.operation == ComparativeOp.Distinct)
                    {
                        if (this.lineValue == IoValue.On)
                            writer.WriteLine("      btfsc       CE_PIN");
                        else if (this.lineValue == IoValue.Off)
                            writer.WriteLine("      btfss       CE_PIN");
                    }
                    writer.WriteLine(labelFalse);
                    break;
                case 1:
                    writer.WriteLine("      banksel	    PORTF	 ");                    
                    if (this.operation == ComparativeOp.Equal)
                    {
                        if (this.lineValue == IoValue.On)
                            writer.WriteLine("      btfss       CSN_PIN");
                        else if (this.lineValue == IoValue.Off)
                            writer.WriteLine("      btfsc       CSN_PIN");
                    }
                    else if (this.operation == ComparativeOp.Distinct)
                    {
                        if (this.lineValue == IoValue.On)
                            writer.WriteLine("      btfsc       CSN_PIN");
                        else if (this.lineValue == IoValue.Off)
                            writer.WriteLine("      btfss       CSN_PIN");
                    }
                    writer.WriteLine(labelFalse);
                    break;
                case 2:
                    writer.WriteLine("      banksel	    PORTC	 ");
                    if (this.operation == ComparativeOp.Equal)
                    {
                        if (this.lineValue == IoValue.On)
                            writer.WriteLine("      btfss       SCK_PIN");
                        else if (this.lineValue == IoValue.Off)
                            writer.WriteLine("      btfsc       SCK_PIN");
                    }
                    else if (this.operation == ComparativeOp.Distinct)
                    {
                        if (this.lineValue == IoValue.On)
                            writer.WriteLine("      btfsc       SCK_PIN");
                        else if (this.lineValue == IoValue.Off)
                            writer.WriteLine("      btfss       SCK_PIN");
                    }
                    writer.WriteLine(labelFalse);
                    break;
                case 3:
                    writer.WriteLine("      banksel	    PORTC	 ");
                    if (this.operation == ComparativeOp.Equal)
                    {
                        if (this.lineValue == IoValue.On)
                            writer.WriteLine("      btfss       SDO_PIN");
                        else if (this.lineValue == IoValue.Off)
                            writer.WriteLine("      btfsc       SDO_PIN");
                    }
                    else if (this.operation == ComparativeOp.Distinct)
                    {
                        if (this.lineValue == IoValue.On)
                            writer.WriteLine("      btfsc       SDO_PIN");
                        else if (this.lineValue == IoValue.Off)
                            writer.WriteLine("      btfss       SDO_PIN");
                    }
                    writer.WriteLine(labelFalse);
                    break;
                case 4:
                    writer.WriteLine("      banksel	    PORTC	 ");
                    if (this.operation == ComparativeOp.Equal)
                    {
                        if (this.lineValue == IoValue.On)
                            writer.WriteLine("      btfss       SDI_PIN");
                        else if (this.lineValue == IoValue.Off)
                            writer.WriteLine("      btfsc       SDI_PIN");
                    }
                    else if (this.operation == ComparativeOp.Distinct)
                    {
                        if (this.lineValue == IoValue.On)
                            writer.WriteLine("      btfsc       SDI_PIN");
                        else if (this.lineValue == IoValue.Off)
                            writer.WriteLine("      btfss       SDI_PIN");
                    }
                    writer.WriteLine(labelFalse);
                    break;
                default:
                    writer.WriteLine("      banksel	    PORTB	 ");
                    if (this.operation == ComparativeOp.Equal)
                    {
                        if (this.lineValue == IoValue.On)
                            writer.WriteLine("      btfss       IRQ_PIN");
                        else if (this.lineValue == IoValue.Off)
                            writer.WriteLine("      btfsc       IRQ_PIN");
                    }
                    else if (this.operation == ComparativeOp.Distinct)
                    {
                        if (this.lineValue == IoValue.On)
                            writer.WriteLine("      btfsc       IRQ_PIN");
                        else if (this.lineValue == IoValue.Off)
                            writer.WriteLine("      btfss       IRQ_PIN");
                    }                 
                    writer.WriteLine(labelFalse);
                    break;
            }
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

        public override bool Simulate(MowayModel mowayModel)
        {
            return true;
        }
    }
}
