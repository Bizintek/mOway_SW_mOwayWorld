using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.StopSound
{
    public class StopSoundAction : Module
    {
        public StopSoundAction(string key)
        {
            this.key = key;
        }

        public StopSoundAction(string key, XmlElement properties)
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
            return new StopSoundAction(this.key);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";************Module Stop Speaker****************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
            writer.WriteLine("  movlw	SPEAKER_OFF");
            writer.WriteLine("  movwf	SEN_SPEAKER_ON_OFF");
            writer.WriteLine("  call	SEN_SPEAKER");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            mowayModel.Sound.UpdateSound(DigitalState.Off, 0);
        }
    }
}
