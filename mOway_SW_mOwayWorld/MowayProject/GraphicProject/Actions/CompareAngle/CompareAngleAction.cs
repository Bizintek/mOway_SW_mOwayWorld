using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.CompareAngle
{
    public class CompareAngleAction : Conditional
    {
        #region Attributes

        private ComparativeOp operation = ComparativeOp.Equal;
        private Variable compareVariable = null;
        private int compareValue = 0;

        #endregion

        #region Properties

        public ComparativeOp Operation { get { return this.operation; } }
        public Variable CompareVariable { get { return this.compareVariable; } }
        public int CompareValue { get { return this.compareValue; } }

        #endregion

        public CompareAngleAction(string key)
        {
            this.key = key;
        }

        public CompareAngleAction(string key, ComparativeOp operation, Variable compareVariable, int compareValue)
        {
            this.key = key;
            this.operation = operation;
            this.compareVariable = compareVariable;
            this.compareValue = compareValue;
        }

        public CompareAngleAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                    case "operation":
                        this.operation = (ComparativeOp)Enum.Parse(typeof(ComparativeOp), property.InnerText);
                        break;
                    case "compareVariable":
                        if (property.InnerText != "none")
                            this.compareVariable = variables[property.InnerText];
                        break;
                    case "compareValue":
                        this.compareValue = System.Convert.ToInt32(property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(ComparativeOp operation, Variable compareVariable, int compareValue)
        {
            this.operation = operation;
            this.compareVariable = compareVariable;
            this.compareValue = compareValue;
        }

        public override bool VariableUsed(Variable variable)
        {
            if (this.compareVariable == variable)
                return true;
            else
                return false;
        }

        public override Element Clone()
        {
            return new CompareAngleAction(this.key, this.operation, this.compareVariable, this.compareValue);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteElementString("operation", this.operation.ToString());
            if (compareVariable == null)
                file.WriteElementString("compareVariable", "none");
            else
                file.WriteElementString("compareVariable", this.compareVariable.Name);
            file.WriteElementString("compareValue", this.compareValue.ToString());
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer, string labelFalse)
        {

            byte compareValueByte;



            writer.WriteLine(";************Module Compare Angle**************************************");
            writer.WriteLine("");
            writer.WriteLine(";**********************************************************************");
            writer.WriteLine("");
            writer.WriteLine("  movlw   STATUS_A");
            writer.WriteLine("  movwf   MOT_STATUS_COM");
            writer.WriteLine("  call    MOT_FDBCK");
            writer.WriteLine("  movf    MOT_STATUS_DATA_0" + ",W");

            compareValueByte = (byte)((double)this.compareValue / 3.6);

            switch (this.operation)
            {
                case ComparativeOp.Bigger:
                    if (this.compareVariable == null)
                    {
                        writer.WriteLine("  addlw   ." + (255 - compareValueByte));
                        writer.WriteLine("  btfss   STATUS,C");
                        writer.WriteLine(labelFalse);
                    }
                    else
                    {
                        writer.WriteLine("  subwf   " + this.compareVariable.Name + ",W");
                        writer.WriteLine("  btfsc   STATUS,C");
                        writer.WriteLine(labelFalse);
                    }
                    break;
                case ComparativeOp.BiggerEqual:
                    if (this.compareVariable == null)
                    {
                        writer.WriteLine("  movwf   AUX_01");
                        writer.WriteLine("  clrf    AUX_00");
                        writer.WriteLine("  addlw   ." + (255 - compareValueByte));
                        writer.WriteLine("  btfss   STATUS,C");
                        writer.WriteLine("  incf    AUX_00,F");
                        writer.WriteLine("  movf    AUX_01,W");
                        writer.WriteLine("  sublw   ." + (compareValueByte));
                        writer.WriteLine("  btfss   STATUS,Z");
                        writer.WriteLine("  incf    AUX_00,F");
                        writer.WriteLine("  btfsc   AUX_00,1");
                        writer.WriteLine(labelFalse);
                    }
                    else
                    {
                        writer.WriteLine("  movwf   AUX_01");
                        writer.WriteLine("  clrf    AUX_00");
                        writer.WriteLine("  subwf   " + this.compareVariable.Name + ",W");
                        writer.WriteLine("  btfsc   STATUS,C");
                        writer.WriteLine("  incf    AUX_00,F");
                        writer.WriteLine("  movf    AUX_01,W");
                        writer.WriteLine("  subwf   " + this.compareVariable.Name + ",W");
                        writer.WriteLine("  btfss   STATUS,Z");
                        writer.WriteLine("  incf    AUX_00,F");
                        writer.WriteLine("  btfsc   AUX_00,1");
                        writer.WriteLine(labelFalse);
                    }
                    break;
                case ComparativeOp.Distinct:
                    if (this.compareVariable == null)
                    {
                        writer.WriteLine("  sublw   ." + (compareValueByte));
                        writer.WriteLine("  btfsc   STATUS,Z");
                        writer.WriteLine(labelFalse);
                    }
                    else
                    {
                        writer.WriteLine("  subwf   " + this.compareVariable.Name + ",W");
                        writer.WriteLine("  btfsc   STATUS,Z");
                        writer.WriteLine(labelFalse);
                    }

                    break;
                case ComparativeOp.Equal:
                    if (this.compareVariable == null)
                    {
                        writer.WriteLine("  sublw   ." + (compareValueByte));
                        writer.WriteLine("  btfss   STATUS,Z");
                        writer.WriteLine(labelFalse);
                    }
                    else
                    {
                        writer.WriteLine("  subwf   " + this.compareVariable.Name + ",W");
                        writer.WriteLine("  btfss   STATUS,Z");
                        writer.WriteLine(labelFalse);
                    }
                    break;
                case ComparativeOp.Smaller:
                    if (this.compareVariable == null)
                    {
                        writer.WriteLine("  addlw   ." + (255 - compareValueByte + 1));
                        writer.WriteLine("  btfsc   STATUS,C");
                        writer.WriteLine(labelFalse);
                    }
                    else
                    {
                        writer.WriteLine("  subwf   " + this.compareVariable.Name + ",W");
                        writer.WriteLine("  btfss   STATUS,C");
                        writer.WriteLine(labelFalse);
                    }
                    break;
                case ComparativeOp.SmallerEqual:
                    if (this.compareVariable == null)
                    {
                        writer.WriteLine("  movwf   AUX_01");
                        writer.WriteLine("  clrf    AUX_00");
                        writer.WriteLine("  addlw   ." + (255 - compareValueByte + 1));
                        writer.WriteLine("  btfsc   STATUS,C");
                        writer.WriteLine("  incf    AUX_00,F");
                        writer.WriteLine("  movf    AUX_01,W");
                        writer.WriteLine("  sublw   ." + (compareValueByte));
                        writer.WriteLine("  btfss   STATUS,Z");
                        writer.WriteLine("  incf    AUX_00,F");
                        writer.WriteLine("  btfsc   AUX_00,1");
                        writer.WriteLine(labelFalse);
                    }
                    else
                    {
                        writer.WriteLine("  movwf   AUX_01");
                        writer.WriteLine("  clrf    AUX_00");
                        writer.WriteLine("  subwf   " + this.compareVariable.Name + ",W");
                        writer.WriteLine("  btfss   STATUS,C");
                        writer.WriteLine("  incf    AUX_00,F");
                        writer.WriteLine("  movf    AUX_01,W");
                        writer.WriteLine("  subwf   " + this.compareVariable.Name + ",W");
                        writer.WriteLine("  btfss   STATUS,Z");
                        writer.WriteLine("  incf    AUX_00,F");
                        writer.WriteLine("  btfsc   AUX_00,1");
                        writer.WriteLine(labelFalse);
                    }
                    break;
                default:
                    writer.WriteLine("; Not allowed");
                    break;
            }
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
        }

        public override bool Simulate(MowayModel mowayModel)
        {
            int modelValueAux = 0;
            int compareValueAux = 0;

            modelValueAux = (int)mowayModel.Movement.Angle;

            // Save value to compare with
            if (this.compareVariable == null)
                compareValueAux = this.compareValue;
            else
                compareValueAux = (int)(mowayModel.GetRegister(this.compareVariable.Name).Value * 3.6M);

            switch (this.operation)
            {
                case ComparativeOp.Bigger:
                    if (modelValueAux > compareValueAux)
                        return true;
                    else
                        return false;

                case ComparativeOp.BiggerEqual:
                    if (modelValueAux >= compareValueAux)
                        return true;
                    else
                        return false;

                case ComparativeOp.Distinct:
                    if (modelValueAux != compareValueAux)
                        return true;
                    else
                        return false;

                case ComparativeOp.Equal:
                    if (modelValueAux == compareValueAux)
                        return true;
                    else
                        return false;

                case ComparativeOp.Smaller:
                    if (modelValueAux < compareValueAux)
                        return true;
                    else
                        return false;

                case ComparativeOp.SmallerEqual:
                    if (modelValueAux <= compareValueAux)
                        return true;
                    else
                        return false;

                default:
                    return false;
            }

        }
    }
}
