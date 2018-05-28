using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.AssignLine
{
    public class AssignLineAction : Module
    {
        #region Attributes

        private Variable assignVariable = null;
        private Side lineSensor = Side.Right;

        #endregion

        #region Properties

        public Variable AssignVariable { get { return this.assignVariable; } }
        public Side LineSensor { get { return this.lineSensor; } }

        #endregion

        public AssignLineAction(string key)
        {
            this.key = key;
        }

        public AssignLineAction(string key, Variable assignVariable, Side lineSensor)
        {
            this.key = key;
            this.assignVariable = assignVariable;
            this.lineSensor = lineSensor;
        }

        public AssignLineAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                    case "lineSensor":
                        this.lineSensor = (Side)Enum.Parse(typeof(Side), property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(Variable assignVariable, Side lineSensor)
        {
            this.assignVariable = assignVariable;
            this.lineSensor = lineSensor;
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
            return new AssignLineAction(this.key, this.assignVariable, this.lineSensor);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            if (this.assignVariable == null)
                file.WriteElementString("assignVariable", "none");
            else
                file.WriteElementString("assignVariable", this.assignVariable.Name);
            file.WriteElementString("lineSensor", this.lineSensor.ToString());
            file.WriteEndElement();
        }


        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";************************Module Assign Line*****************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("  call    SEN_LINE_ANALOG");
            if (this.lineSensor == Side.Right)
                writer.WriteLine("  movf    SEN_LINE_R,W");
            else if (this.lineSensor == Side.Left)
                writer.WriteLine("  movf    SEN_LINE_L,W");
            writer.WriteLine("  movwf   " + this.assignVariable.Name);
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            if (this.lineSensor == Side.Right)
                mowayModel.GetRegister(this.assignVariable.Name).Value = (byte)mowayModel.LineSensors.RightSensor;
            else if (this.lineSensor == Side.Left)
                mowayModel.GetRegister(this.assignVariable.Name).Value = (byte)mowayModel.LineSensors.LeftSensor;
        }
    }
}
