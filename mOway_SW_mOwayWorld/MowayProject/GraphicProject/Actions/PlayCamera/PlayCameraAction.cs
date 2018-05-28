using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.PlayCamera
{
    public class PlayCameraAction : Module
    {
        #region Attributes

        private int channel = 1;

        #endregion

        #region Properties

        public int Channel { get { return this.channel; } }
        
        #endregion

        public PlayCameraAction(string key)
        {
            this.key = key;
        }

        public PlayCameraAction(string key, int channel)
        {
            this.key = key;
            this.channel = channel;
        }

        public PlayCameraAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                    case "channel":
                        this.channel = System.Convert.ToInt32(property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(int channel)
        {
            this.channel = channel;
        }

        public override Element Clone()
        {
            return new PlayCameraAction(this.key, this.channel);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteElementString("channel", this.channel.ToString());
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";************Module PlayCamera********************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");

            writer.WriteLine(";Camera configuration");
            writer.WriteLine("  call    CAM_CONFIG");
            writer.WriteLine(";Configuration of Camera module channel");
            writer.WriteLine("  movlw	    ." + this.channel.ToString() + "		;Channel");
            writer.WriteLine("  movwf	    CAM_CHANNEL			");

            writer.WriteLine("  call	    CAM_CHN_SEL");
            writer.WriteLine("");
            writer.WriteLine(";Activate the module	");
            writer.WriteLine("  call	    CAM_ON");

            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            
        }
    }
}
