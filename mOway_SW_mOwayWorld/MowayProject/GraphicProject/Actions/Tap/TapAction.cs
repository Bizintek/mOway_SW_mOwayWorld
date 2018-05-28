using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Tap
{
    public class TapAction : Conditional
    {
        public TapAction(string key)
        {
            this.key = key;
        }
        
        public TapAction(string key, XmlElement properties)
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
            return new TapAction(this.key);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteEndElement();
        }


        public override void WriteCode(StreamWriter writer, string labelFalse)
        {
            writer.WriteLine(";************Module AccelerometerEvent**********************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
            writer.WriteLine(" call       SEN_ACCE_CHECK_TAP");
            writer.WriteLine(" btfss      SEN_ACCE_TAP,TAP");
            writer.WriteLine(labelFalse);
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

        public override bool Simulate(MowayModel mowayModel)
        {
            if ((mowayModel.Accelerometer.XAxisValue <= -(MowayModel.MIN_TAP)) || (mowayModel.Accelerometer.XAxisValue >= MowayModel.MIN_TAP) ||
                (mowayModel.Accelerometer.YAxisValue <= -(MowayModel.MIN_TAP)) || (mowayModel.Accelerometer.YAxisValue >= MowayModel.MIN_TAP) ||
                (mowayModel.Accelerometer.ZAxisValue <= -(MowayModel.MIN_TAP)) || (mowayModel.Accelerometer.ZAxisValue >= MowayModel.MIN_TAP))
            {
                return true;
            }
            else
                return false;
        }        
    }
}
