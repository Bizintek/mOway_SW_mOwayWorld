using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.StartRf
{
    public class StartRfAction : Conditional
    {
        #region Attributes

        private int direction = 0;
        private int chanel = 0;

        #endregion

        #region Properties

        public int Direction { get { return this.direction; } }
        public int Chanel { get { return this.chanel; } }

        #endregion

        public StartRfAction(string key)
        {
            this.key = key;
        }
        public StartRfAction(string key, int direction, int chanel)
        {
            this.key = key;
            this.direction = direction;
            this.chanel = chanel;

        }

        public StartRfAction(string key, XmlElement properties)
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
                    case "direction":
                        this.direction = System.Convert.ToInt32(property.InnerText);
                        break;
                    case "chanel":
                        this.chanel = System.Convert.ToInt32(property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }



        public void UpdateSettings(int direction, int chanel)
        {
            this.direction = direction;
            this.chanel = chanel;
        }

        public override Element Clone()
        {
            return new StartRfAction(this.key, this.direction, this.chanel);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteElementString("direction", this.direction.ToString());
            file.WriteElementString("chanel", this.chanel.ToString());
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer, string labelFalse)
        {
            writer.WriteLine(";************Module RfActivation****************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");

            writer.WriteLine(";Configuration of SPI");
            writer.WriteLine("  call	    RF_CONFIG_SPI");
            writer.WriteLine("");
            writer.WriteLine(";Configuration of RF module (channel and dir)");
            writer.WriteLine("  movlw	    ." + this.direction + "		;Dir");
            writer.WriteLine("  movwf	    RF_DIR			");

            writer.WriteLine("  movlw	    ." + this.chanel + "		;Channel");
            writer.WriteLine("  movwf	    RF_CHN			");

            writer.WriteLine("  call	    RF_CONFIG");

            writer.WriteLine("	btfss	RF_STATUS,CONFIGOK");
            writer.WriteLine(labelFalse);

            writer.WriteLine("");
            writer.WriteLine(";Activate the module	");
            writer.WriteLine("  call	    RF_ON");
            
            writer.WriteLine("	btfss	RF_STATUS,ONOK");
            writer.WriteLine(labelFalse);
        }

        public override bool Simulate(MowayModel mowayModel)
        {
            mowayModel.Communication.Start((byte)this.direction, (byte)this.chanel);
            return true;
        }
    }
}
