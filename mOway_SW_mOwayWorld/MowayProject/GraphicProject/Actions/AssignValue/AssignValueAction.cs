using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.AssignValue
{
    public class AssignValueAction : Module
    {
        #region Attributes

        private Variable assignVariable = null;
        private Variable variable = null;
        private int value = 0;

        #endregion

        #region Properties

        public Variable AssignVariable { get { return this.assignVariable; } }
        public Variable Variable { get { return this.variable; } }
        public int Value { get { return this.value; } }

        #endregion

        public AssignValueAction(string key)
        {
            this.key = key;
        }

        public AssignValueAction(string key, Variable assignVariable, Variable variable, int value)
        {
            this.key = key;
            this.assignVariable = assignVariable;
            this.variable = variable;
            this.value = value;
        }

        public AssignValueAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                    case "variable":
                        if (property.InnerText != "none")
                            this.variable = variables[property.InnerText];
                        break;
                    case "value":
                        this.value = System.Convert.ToInt32(property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(Variable assignVariable, Variable variable, int value)
        {
            this.assignVariable = assignVariable;
            this.variable = variable;
            this.value = value;
        }

        public override bool VariableUsed(Variable variable)
        {
            if ((this.assignVariable == variable) || (this.variable == variable))
                return true;
            else
                return false;
        }

        public override Element Clone()
        {
            return new AssignValueAction(this.key, this.assignVariable, this.variable, this.value);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            if (this.assignVariable == null)
                file.WriteElementString("assignVariable", "none");
            else
                file.WriteElementString("assignVariable", this.assignVariable.Name);
            if (this.variable == null)
                file.WriteElementString("variable", "none");
            else
                file.WriteElementString("variable", this.variable.Name);
            file.WriteElementString("value", this.value.ToString());
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";************Module Assigned********************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
            if (this.variable == null)
                writer.WriteLine("  movlw   ." + this.value);
            else
                writer.WriteLine("  movf    " + this.variable.Name + ",W");
            writer.WriteLine("  movwf   " + this.assignVariable.Name);
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            if (this.variable == null)
                mowayModel.GetRegister(this.assignVariable.Name).Value = (byte)this.value;
            else
                mowayModel.GetRegister(this.assignVariable.Name).Value = mowayModel.GetRegister(this.variable.Name).Value;          
        }
    }
}
