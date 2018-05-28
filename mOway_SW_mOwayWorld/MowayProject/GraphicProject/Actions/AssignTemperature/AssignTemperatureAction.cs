using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.AssignTemperature
{
    public class AssignTemperatureAction : Module
    {
        #region Attributes

        private Variable assignVariable = null;

        #endregion

        #region Properties

        public Variable AssignVariable { get { return this.assignVariable; } }

        #endregion

        public AssignTemperatureAction(string key)
        {
            this.key = key;
        }

        public AssignTemperatureAction(string key, Variable assignVariable)
        {
            this.key = key;
            this.assignVariable = assignVariable;

        }

        public AssignTemperatureAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
            return new AssignTemperatureAction(this.key, this.assignVariable);
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
            writer.WriteLine(";*****************Module Assign Temperature*****************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("  call    SEN_TEMPERATURE");
            writer.WriteLine("  movf    SEN_TEMPERATURE_C,W");
            writer.WriteLine("  movwf   " + assignVariable.Name);
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            mowayModel.GetRegister(this.assignVariable.Name).Value = (byte)mowayModel.Temperature;            
        }
    }
}
