using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Line
{
    public enum LineState { Inactive, Black, White}

    public class LineAction : Conditional
    {
        #region Attributes

        private LineState leftSensor = LineState.Inactive;
        private LineState rightSensor = LineState.Inactive;
        private LogicOp operation = LogicOp.And;

        #endregion

        #region Properties

        public LineState LeftSensor { get { return this.leftSensor; } }
        public LineState RightSensor { get { return this.rightSensor; } }
        public LogicOp Operation { get { return this.operation; } }

        #endregion

        public LineAction(string key)
        {
            this.key = key;
        }

        public LineAction(string key, LineState leftSensor, LineState rightSensor, LogicOp operation)
        {
            this.key = key;
            this.leftSensor = leftSensor;
            this.rightSensor = rightSensor;
            this.operation = operation;
        }

        public LineAction(string key, XmlElement properties)
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
                    case "leftSensor":
                        this.leftSensor = (LineState)Enum.Parse(typeof(LineState), property.InnerText);
                        break;
                    case "rightSensor":
                        this.rightSensor = (LineState)Enum.Parse(typeof(LineState), property.InnerText);
                        break;
                    case "operation":
                        this.operation = (LogicOp)Enum.Parse(typeof(LogicOp), property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(LineState leftSensor, LineState rightSensor, LogicOp operation)
        {
            this.leftSensor = leftSensor;
            this.rightSensor = rightSensor;
            this.operation = operation;
        }

        public override Element Clone()
        {
            return new LineAction(this.key, this.leftSensor, this.rightSensor, this.operation);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteElementString("leftSensor", this.leftSensor.ToString());
            file.WriteElementString("rightSensor", this.rightSensor.ToString());
            file.WriteElementString("operation", this.operation.ToString());
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer, string labelFalse)
        {
            writer.WriteLine(";************Module DigOpto******************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
            writer.WriteLine("  call    SEN_LINE_DIG");
            if (leftSensor == LineState.Black && rightSensor == LineState.Black)
            {
                if (operation == LogicOp.And)
                {
                    writer.WriteLine("  btfss   SEN_LINE_L,0");
                    writer.WriteLine(labelFalse);
                    writer.WriteLine("  btfss   SEN_LINE_R,0");
                    writer.WriteLine(labelFalse);
                }
                else
                {
                    writer.WriteLine("  movf   SEN_LINE_R,W");
                    writer.WriteLine("  iorwf  SEN_LINE_L,F");
                    writer.WriteLine("  btfss  SEN_LINE_L,0");
                    writer.WriteLine(labelFalse);
                }
            }
            else if (leftSensor == LineState.Black && rightSensor == LineState.Inactive)
            {
                writer.WriteLine("  btfss   SEN_LINE_L,0");
                writer.WriteLine(labelFalse);
            }
            else if (leftSensor == LineState.Black && rightSensor == LineState.White)
            {
                if (operation == LogicOp.And)
                {
                    writer.WriteLine("  btfss   SEN_LINE_L,0");
                    writer.WriteLine(labelFalse);
                    writer.WriteLine("  btfsc   SEN_LINE_R,0");
                    writer.WriteLine(labelFalse);
                }
                else
                {
                    writer.WriteLine("  btfsc   SEN_LINE_L,0");
                    writer.WriteLine("  bsf     SEN_LINE_L,7");
                    writer.WriteLine("  btfss   SEN_LINE_R,0");
                    writer.WriteLine("  bsf     SEN_LINE_R,7");
                    writer.WriteLine("  movf    SEN_LINE_L,W");
                    writer.WriteLine("  iorwf   SEN_LINE_R,F");
                    writer.WriteLine("  btfss   SEN_LINE_R,7");
                    writer.WriteLine(labelFalse);
                }
            }
            else if (leftSensor == LineState.Inactive && rightSensor == LineState.Black)
            {
                writer.WriteLine("  btfss   SEN_LINE_R,0");
                writer.WriteLine(labelFalse);
            }
            else if (leftSensor == LineState.Inactive && rightSensor == LineState.White)
            {
                writer.WriteLine("  btfsc   SEN_LINE_R,0");
                writer.WriteLine(labelFalse);
            }
            else if (leftSensor == LineState.White && rightSensor == LineState.Black)
            {
                if (operation == LogicOp.And)
                {
                    writer.WriteLine("  btfsc   SEN_LINE_L,0");
                    writer.WriteLine(labelFalse);
                    writer.WriteLine("  btfss   SEN_LINE_R,0");
                    writer.WriteLine(labelFalse);
                }
                else
                {
                    writer.WriteLine("  btfss   SEN_LINE_L,0");
                    writer.WriteLine("  bsf     SEN_LINE_L,7");
                    writer.WriteLine("  btfsc   SEN_LINE_R,0");
                    writer.WriteLine("  bsf     SEN_LINE_R,7");
                    writer.WriteLine("  movf    SEN_LINE_L,W");
                    writer.WriteLine("  iorwf   SEN_LINE_R,F");
                    writer.WriteLine("  btfss   SEN_LINE_R,7");
                    writer.WriteLine(labelFalse);
                }
            }
            else if (leftSensor == LineState.White && rightSensor == LineState.Inactive)
            {
                writer.WriteLine("  btfsc   SEN_LINE_L,0");
                writer.WriteLine(labelFalse);
            }

            else if (leftSensor == LineState.White && rightSensor == LineState.White)
            {
                if (operation == LogicOp.And)
                {
                    writer.WriteLine("  btfsc   SEN_LINE_L,0");
                    writer.WriteLine(labelFalse);
                    writer.WriteLine("  btfsc   SEN_LINE_R,0");
                    writer.WriteLine(labelFalse);
                }
                else
                {
                    writer.WriteLine("  btfss   SEN_LINE_L,0");
                    writer.WriteLine("  bsf     SEN_LINE_L,7");
                    writer.WriteLine("  btfss   SEN_LINE_R,0");
                    writer.WriteLine("  bsf     SEN_LINE_R,7");
                    writer.WriteLine("  movf    SEN_LINE_L,W");
                    writer.WriteLine("  iorwf   SEN_LINE_R,F");
                    writer.WriteLine("  btfss   SEN_LINE_R,7");
                    writer.WriteLine(labelFalse);
                }
            }
            else
            {
                writer.WriteLine(";     Not allowed");
            }
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

        public override bool Simulate(MowayModel mowayModel)
        {
             bool leftCondition = false;
            bool rightCondition = false;

            // Check left sensor condition
            if((leftSensor == LineState.Black) && (mowayModel.LineSensors.LeftSensor >= MowayModel.MIN_LINE_BLACK) ||
                (leftSensor == LineState.White) && (mowayModel.LineSensors.LeftSensor <= MowayModel.MAX_LINE_WHITE))
                leftCondition = true;
            else
                leftCondition = false;
            
            // Check right sensor condition
            if((rightSensor == LineState.Black) && (mowayModel.LineSensors.RightSensor >= MowayModel.MIN_LINE_BLACK) ||
                (rightSensor == LineState.White) && (mowayModel.LineSensors.RightSensor <= MowayModel.MAX_LINE_WHITE))
                rightCondition = true;
            else
                rightCondition = false;

            // In case "detection inactive" is selected
            if((leftSensor == LineState.Inactive) && (rightSensor == LineState.Inactive))                        
                return true;            
            else if(leftSensor == LineState.Inactive)
                return rightCondition;
            else if(rightSensor == LineState.Inactive)
                return leftCondition;

            // Check logic operation (AND/OR) if both senors are active
            if(operation == LogicOp.And)                           
                return (leftCondition && rightCondition);
            else
                return (leftCondition || rightCondition);                                   
        }
    }
}
