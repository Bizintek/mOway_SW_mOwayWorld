using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.CompareObstacle
{
    public class CompareObstacleAction : Conditional
    {
        #region Attributes

        private ObstacleSensor obstacleSensor = ObstacleSensor.Right;
        private ComparativeOp operation = ComparativeOp.Equal;
        private Variable compareVariable = null;
        private int compareValue = 0;

        #endregion

        #region Properties

        public ObstacleSensor ObstacleSensor { get { return this.obstacleSensor; } }
        public ComparativeOp Operation { get { return this.operation; } }
        public Variable CompareVariable { get { return this.compareVariable; } }
        public int CompareValue { get { return this.compareValue; } }

        #endregion

        public CompareObstacleAction(string key)
        {
            this.key = key;
        }

        public CompareObstacleAction(string key, ObstacleSensor obstacleSensor, ComparativeOp operation, Variable compareVariable, int compareValue)
        {
            this.key = key;
            this.obstacleSensor = ObstacleSensor;
            this.operation = operation;
            this.compareVariable = compareVariable;
            this.compareValue = compareValue;
        }

        public CompareObstacleAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                    case "obstacleSensor":
                        this.obstacleSensor = (ObstacleSensor)Enum.Parse(typeof(ObstacleSensor), property.InnerText);
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

        public void UpdateSettings(ObstacleSensor obstacleSensor, ComparativeOp operation, Variable compareVariable, int compareValue)
        {
            this.obstacleSensor = obstacleSensor;
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
            return new CompareObstacleAction(this.key, this.obstacleSensor, this.operation, this.compareVariable, this.compareValue);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteElementString("obstacleSensor", this.obstacleSensor.ToString());
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
            writer.WriteLine(";*********************Module Compare Obstacle***************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            switch (this.obstacleSensor)
            {
                case ObstacleSensor.Left:
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_CENTER_R");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_SIDE_R");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_CENTER_L");
                    writer.WriteLine("  bsf		SEN_CHECK_OBS,OBS_SIDE_L");
                    writer.WriteLine("  call 	SEN_OBS_ANALOG");
                    writer.WriteLine("  movf    SEN_OBS_SIDE_L,W");
                    break;
                case ObstacleSensor.Right:
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_CENTER_R");
                    writer.WriteLine("  bsf		SEN_CHECK_OBS,OBS_SIDE_R");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_CENTER_L");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_SIDE_L");
                    writer.WriteLine("  call 	SEN_OBS_ANALOG");
                    writer.WriteLine("  movf    SEN_OBS_SIDE_R,W");
                    break;
                case ObstacleSensor.UpperLeft:
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_CENTER_R");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_SIDE_R");
                    writer.WriteLine("  bsf		SEN_CHECK_OBS,OBS_CENTER_L");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_SIDE_L");
                    writer.WriteLine("  call 	SEN_OBS_ANALOG");
                    writer.WriteLine("  movf    SEN_OBS_CENTER_L,W");
                    break;
                case ObstacleSensor.UpperRight:
                    writer.WriteLine("  bsf		SEN_CHECK_OBS,OBS_CENTER_R");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_SIDE_R");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_CENTER_L");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_SIDE_L");
                    writer.WriteLine("  call 	SEN_OBS_ANALOG");
                    writer.WriteLine("  movf    SEN_OBS_CENTER_R,W");
                    break;
            }

            switch (this.operation)
            {
                case ComparativeOp.Bigger:
                    if (this.compareVariable == null)
                    {
                        writer.WriteLine("  addlw   ." + (255 - this.compareValue));
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
                        writer.WriteLine("  addlw   ." + (255 - this.compareValue));
                        writer.WriteLine("  btfss   STATUS,C");
                        writer.WriteLine("  incf    AUX_00,F");
                        writer.WriteLine("  movf    AUX_01,W");
                        writer.WriteLine("  sublw   ." + (this.compareValue));
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
                        writer.WriteLine("  sublw   ." + (this.compareValue));
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
                        writer.WriteLine("  sublw   ." + (this.compareValue));
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
                        writer.WriteLine("  addlw   ." + (255 - this.compareValue + 1));
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
                        writer.WriteLine("  addlw   ." + (255 - this.compareValue + 1));
                        writer.WriteLine("  btfsc   STATUS,C");
                        writer.WriteLine("  incf    AUX_00,F");
                        writer.WriteLine("  movf    AUX_01,W");
                        writer.WriteLine("  sublw   ." + (this.compareValue));
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

            // Save sensor model value
            if (this.obstacleSensor == ObstacleSensor.Left)
                modelValueAux = mowayModel.ObstacleSensors.LeftSideSensor;
            else if (this.obstacleSensor == ObstacleSensor.Right)
                modelValueAux = mowayModel.ObstacleSensors.RightSideSensor;
            else if (this.obstacleSensor == ObstacleSensor.UpperLeft)
                modelValueAux = mowayModel.ObstacleSensors.LeftCentralSensor;
            else if (this.obstacleSensor == ObstacleSensor.UpperRight)
                modelValueAux = mowayModel.ObstacleSensors.RightCentralSensor;

            // Save value to compare with
            if (this.compareVariable == null)
                compareValueAux = this.compareValue;
            else
                compareValueAux = mowayModel.GetRegister(this.compareVariable.Name).Value;


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
