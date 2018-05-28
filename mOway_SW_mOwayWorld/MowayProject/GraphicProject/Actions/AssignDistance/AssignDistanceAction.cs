using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.AssignDistance
{
    public class AssignDistanceAction : Module
    {
        #region Attributes

        private Variable assignVariable = null;

        #endregion

        #region Properties

        public Variable AssignVariable { get { return this.assignVariable; } }

        #endregion

        public AssignDistanceAction(string key)
        {
            this.key = key;
        }

        public AssignDistanceAction(string key, Variable assignVariable)
        {
            this.key = key;
            this.assignVariable = assignVariable;
        }

        public AssignDistanceAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(Variable assignVariable)
        {
            this.assignVariable = assignVariable;
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
            return new AssignDistanceAction(this.key, this.assignVariable);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            if (this.assignVariable == null)
                file.WriteElementString("assignVariable", "none");
            else
                file.WriteElementString("assignVariable", this.assignVariable.Name);
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";**********************Module Assign Distance***************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("  movlw   STATUS_KM");
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
            byte tempDistance;
            decimal tempTimes;

            if (mowayModel.Movement.Distance > 255)
            {
                tempTimes = mowayModel.Movement.Distance / 255;
                tempDistance = (byte)(mowayModel.Movement.Distance - (255 * System.Math.Floor(tempTimes)));
            }
            else
                tempDistance = (byte)mowayModel.Movement.Distance;

            mowayModel.GetRegister(this.assignVariable.Name).Value = tempDistance; 
        }
    }
}
