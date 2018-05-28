using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Noise
{
    public class NoiseAction : Conditional
    {
        public NoiseAction(string key)
        {
            this.key = key;
        }

        public NoiseAction(string key, XmlElement properties)
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

        public override void WriteCode(StreamWriter writer, string labelFalse)
        {
            writer.WriteLine(";************Module Sound************************************************");
            writer.WriteLine("");
            writer.WriteLine(";************************************************************************");
            writer.WriteLine("");
            writer.WriteLine("	call	SEN_MIC_DIG ");
            writer.WriteLine("	btfss	SEN_MIC,0 ");
            writer.WriteLine(labelFalse);
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

        public override Element Clone()
        {
            return new NoiseAction(this.key);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteEndElement();
        }

        public override bool Simulate(MowayModel mowayModel)
        {
            if (mowayModel.NoiseLevel >= MowayModel.MIN_NOISE)
                return true;
            else
                return false;
        }
    }
}
