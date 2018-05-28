using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.StopMovement
{
    public class StopMovementAction : Module
    {
        public StopMovementAction(string key)
        {
            this.key = key;
        }

        public StopMovementAction(string key, XmlElement properties)
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
        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";************Module Stop************************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
            writer.WriteLine(";   Call STOP ");
            writer.WriteLine("    call    MOT_STOP");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

        public override Element Clone()
        {
            return new StopMovementAction(this.key);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteEndElement();
        }

        public override void Simulate(MowayModel mowayModel)
        {
            mowayModel.Movement.UpdateMovement(Moway.Simulator.Outputs.Direction.Forward, 0, Moway.Simulator.Outputs.Direction.Forward, 0);
        }
    }
}
