using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.StopRf
{
    public class StopRfAction : Module
    {
        public StopRfAction(string key)
        {
            this.key = key;
        }
        public StopRfAction(string key, XmlElement properties)
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
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public override Element Clone()
        {
            return new StopRfAction(this.key);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteEndElement();
        }


        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";************Module StopRf**********************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
            writer.WriteLine("  call        RF_OFF");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            mowayModel.Communication.Stop();
        }
    }
}
