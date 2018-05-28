using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.AssignSpeed
{
    public class AssignSpeedAction : Module
    {
        #region Attributes

        private Variable assignVariable = null;
        private Side wheel = Side.Right;

        #endregion

        #region Properties

        public Variable AssignVariable { get { return this.assignVariable; } }
        public Side Wheel { get { return this.wheel; } }

        #endregion

        public AssignSpeedAction(string key)
        {
            this.key = key;
        }

        public AssignSpeedAction(string key, Variable assignVariable, Side wheel)
        {
            this.key = key;
            this.assignVariable = assignVariable;
            this.wheel = wheel;
        }

        public AssignSpeedAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                    case "wheel":
                        this.wheel = (Side)Enum.Parse(typeof(Side), property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(Variable assignVariable, Side wheel)
        {
            this.assignVariable = assignVariable;
            this.wheel = wheel;
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
            return new AssignSpeedAction(this.key, this.assignVariable, this.wheel);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            if (this.assignVariable == null)
                file.WriteElementString("assignVariable", "none");
            else
                file.WriteElementString("assignVariable", this.assignVariable.Name);
            file.WriteElementString("wheel", this.wheel.ToString());
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";***********************Module Assign Speed*****************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            if (this.wheel == Side.Right)
                writer.WriteLine("  movlw   STATUS_V_R");
            else if (this.wheel == Side.Left)
                writer.WriteLine("  movlw   STATUS_V_L");
            writer.WriteLine("  movwf   MOT_STATUS_COM");
            writer.WriteLine("  call    MOT_FDBCK");
            writer.WriteLine("");
            writer.WriteLine("  movf    MOT_STATUS_DATA_0,W");
            writer.WriteLine("  movwf   " + this.assignVariable.Name);
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            if (this.wheel == Side.Left)
                mowayModel.GetRegister(this.assignVariable.Name).Value = (byte)mowayModel.Movement.LeftWheelSpeed;

            else if (this.wheel == Side.Right)
                mowayModel.GetRegister(this.assignVariable.Name).Value = (byte)mowayModel.Movement.RightWheelSpeed;
        }
    }
}
