using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.AssignAngle
{
    public class AssignAngleAction : Module
    {
        #region Attributes

        private Variable assignVariable = null;

        #endregion

        #region Properties

        public Variable AssignVariable { get { return this.assignVariable; } }

        #endregion

        public AssignAngleAction(string key)
        {
            this.key = key;
        }

        public AssignAngleAction(string key, Variable assignVariable)
        {
            this.key = key;
            this.assignVariable = assignVariable;
        }

        public AssignAngleAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
            return new AssignAngleAction(this.key, this.assignVariable);
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
            writer.WriteLine(";**********************Module Assign Angle******************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("  movlw   STATUS_A");
            writer.WriteLine("  movwf   MOT_STATUS_COM");
            writer.WriteLine("  call    MOT_FDBCK");
            writer.WriteLine("");
            writer.WriteLine("  movf    MOT_STATUS_DATA_0,W");
            writer.WriteLine("  movwf   " + this.AssignVariable.Name);
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            mowayModel.GetRegister(this.assignVariable.Name).Value = (byte)(mowayModel.Movement.Angle * 0.28M);   
        }
    }
}
