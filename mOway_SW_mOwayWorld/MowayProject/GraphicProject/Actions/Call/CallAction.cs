using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Call
{
    public class CallAction : Module
    {
        #region Attributes

        private Diagram function;

        #endregion

        #region Properties

        public Diagram Function { get { return this.function; } }

        #endregion

        public CallAction(string key)
        {
            this.key = key;
        }

        public CallAction(string key, Diagram function)
        {
            this.key = key;
            this.function = function;
        }

        public CallAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                    case "function":
                        this.function = GraphManager.GetFunction(property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(Diagram function)
        {
            this.function = function;
        }

        public override bool FunctionUsed(Diagram function)
        {
            if (this.function == function)
                return true;
            return false;
        }

        public override Element Clone()
        {
            return new CallAction(this.key, this.function);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteElementString("function", this.function.Name);
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";LLamada a subutina");
            writer.WriteLine("    call    " + this.function.Name);
            writer.WriteLine("");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            
        }
    }
}
