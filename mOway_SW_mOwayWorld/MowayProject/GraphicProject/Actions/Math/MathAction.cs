using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Math
{
    public class MathAction : Module
    {
        #region Attributes

        private Variable resultVariable = null;
        private ArithmeticOp operation = ArithmeticOp.Add;
        private Variable variable = null;
        private int value = 0;

        #endregion

        #region Properties

        public Variable ResultVariable { get { return this.resultVariable; } }
        public ArithmeticOp Operation { get { return this.operation; } }
        public Variable Variable { get { return this.variable; } }
        public int Value { get { return this.value; } }

        #endregion

        public MathAction(string key)
        {
            this.key = key;
        }

        public MathAction(string key, Variable resultVariable, ArithmeticOp operation, Variable variable, int value)
        {
            this.key = key;
            this.operation = operation;
            this.resultVariable = resultVariable;
            this.variable = variable;
            this.value = value;
        }

         public MathAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                    case "resultVariable":
                        if (property.InnerText != "none")
                            this.resultVariable = variables[property.InnerText];
                        break;
                    case "variable":
                        if (property.InnerText != "none")
                            this.variable = variables[property.InnerText];
                        break;
                    case "operation":
                        this.operation = (ArithmeticOp)Enum.Parse(typeof(ArithmeticOp), property.InnerText);
                        break;
                    case "value":
                        this.value = System.Convert.ToInt32(property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(Variable resultVariable, ArithmeticOp operation, Variable variable, int value)
        {
            this.resultVariable = resultVariable;
            this.operation = operation;
            this.variable = variable;
            this.value = value;
        }

        public override bool VariableUsed(Variable variable)
        {
            if ((this.resultVariable == variable) || (this.variable == variable))
                return true;
            else
                return false;
        }

        public override Element Clone()
        {
            return new MathAction(this.key, this.resultVariable, this.operation, this.variable, this.value);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            if (this.resultVariable == null)
                file.WriteElementString("resultVariable", "none");
            else
                file.WriteElementString("resultVariable", this.resultVariable.Name);
            file.WriteElementString("operation", this.operation.ToString());
            if (this.variable == null)
                file.WriteElementString("variable", "none");
            else
                file.WriteElementString("variable", this.variable.Name);
            file.WriteElementString("value", this.value.ToString());
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";************Module Maths***********************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        
            if (this.variable == null)
                writer.WriteLine("  movlw   ." + this.value);
            else
                writer.WriteLine("  movf    " + this.variable.Name + ",W");

            if (this.operation == ArithmeticOp.Add)
                writer.WriteLine("  addwf   " + this.resultVariable.Name + ",F");
            else if (this.operation == ArithmeticOp.Sub)
                writer.WriteLine("  subwf   " + this.resultVariable.Name + ",F");
            //}
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            byte mathValueAux = 0;

            // Save value to compare with
            if (this.variable == null)
                mathValueAux = (byte)this.value;
            else
                mathValueAux = mowayModel.GetRegister(this.variable.Name).Value;

            if (this.operation == ArithmeticOp.Add)
                mowayModel.GetRegister(this.resultVariable.Name).Value += mathValueAux;
            else if (this.operation == ArithmeticOp.Sub)
                mowayModel.GetRegister(this.resultVariable.Name).Value -= mathValueAux;
        }
    }
}
