using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.AssignAccelerometer
{
    public class AssignAccelerometerAction : Module
    {
        #region Attributes

        private Variable assignVariable = null;
        private AccelerometerAxis axis = AccelerometerAxis.X;

        #endregion

        #region Properties

        public Variable AssignVariable { get { return this.assignVariable; } }
        public AccelerometerAxis Axis { get { return this.axis; } }

        #endregion

        public AssignAccelerometerAction(string key)
        {
            this.key = key;
        }

        public AssignAccelerometerAction(string key, Variable assignVariable, AccelerometerAxis axis)
        {
            this.key = key;
            this.assignVariable = assignVariable;
            this.axis = axis;
        }

        public AssignAccelerometerAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                    case "assignVariable":
                        if (property.InnerText != "none")
                            this.assignVariable = variables[property.InnerText];
                        break;
                    case "axis":
                        this.axis = (AccelerometerAxis)Enum.Parse(typeof(AccelerometerAxis), property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }

        }

        public void UpdateSettings(Variable assignVariable, AccelerometerAxis axis)
        {
            this.assignVariable = assignVariable;
            this.axis = axis;
        }

        public override bool VariableUsed(Variable variable)
        {
            if (this.assignVariable == variable)
                return true;
            else
                return false;
        }

        public override Element Clone()
        {
            return new AssignAccelerometerAction(this.key, this.assignVariable, this.axis);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            if (this.assignVariable == null)
                file.WriteElementString("assignVariable", "none");
            else
                file.WriteElementString("assignVariable", this.assignVariable.Name);
            file.WriteElementString("axis", this.axis.ToString());
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";**************Module Assign Accelerometer******************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("  call    SEN_ACCE_XYZ_READ");
            if (this.axis == AccelerometerAxis.X)
            {
                writer.WriteLine("  movf    SEN_ACCE_X,W");
            }
            else if (this.axis == AccelerometerAxis.Y)
            {
                writer.WriteLine("  movf    SEN_ACCE_Y,W");
            }
            else if (this.axis == AccelerometerAxis.Z)
            {
                writer.WriteLine("  movf    SEN_ACCE_Z,W");
            }
            else
            {
                writer.WriteLine("  movf    SEN_ACCE_X,W");
            }
            writer.WriteLine("  movwf   " + this.assignVariable.Name);
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            if (this.axis == AccelerometerAxis.X)
            {
                if (mowayModel.Accelerometer.XAxisValue == -2)
                    mowayModel.GetRegister(this.assignVariable.Name).Value = 0;
                else
                    mowayModel.GetRegister(this.assignVariable.Name).Value = (byte)((mowayModel.Accelerometer.XAxisValue * 64) + 127);
            }
            else if (this.axis == AccelerometerAxis.Y)
            {
                if (mowayModel.Accelerometer.YAxisValue == -2)
                    mowayModel.GetRegister(this.assignVariable.Name).Value = 0;
                else
                    mowayModel.GetRegister(this.assignVariable.Name).Value = (byte)((mowayModel.Accelerometer.YAxisValue * 64) + 127);
            }
            else
            {
                if (mowayModel.Accelerometer.ZAxisValue == -2)
                    mowayModel.GetRegister(this.assignVariable.Name).Value = 0;
                else
                    mowayModel.GetRegister(this.assignVariable.Name).Value = (byte)((mowayModel.Accelerometer.ZAxisValue * 64) + 127);
            }
        }
    }
}
