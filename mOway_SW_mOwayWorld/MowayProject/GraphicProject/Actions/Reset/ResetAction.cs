using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Reset
{
    public class ResetAction : Module
    {
        #region Attributes

        private bool resetTime = true;
        private bool resetDistance = true;

        #endregion

        #region Properties

        public bool ResetTime { get { return this.resetTime; } }
        public bool ResetDistance { get { return this.resetDistance; } }

        #endregion

        public ResetAction(string key)
        {
            this.key = key;
        }

        public ResetAction(string key, bool resetTime, bool resetDistance)
        {
            this.key = key;
            this.resetTime = resetTime;
            this.resetDistance = resetDistance;
        }

        public ResetAction(string key, XmlElement properties)
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
                    case "resetTime":
                        this.resetTime = System.Convert.ToBoolean(property.InnerText);
                        break;
                    case "resetDistance":
                        this.resetDistance = System.Convert.ToBoolean(property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(bool resetTime, bool resetDistance)
        {
            this.resetTime = resetTime;
            this.resetDistance = resetDistance;
        }

        public override Element Clone()
        {
            return new ResetAction(this.key, this.resetTime, this.resetDistance);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteElementString("resetTime", this.resetTime.ToString());
            file.WriteElementString("resetDistance", this.resetDistance.ToString());
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";************Module ResetMoveInformation********************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
            if (this.resetTime == true)
            {
                writer.WriteLine("  movlw   RST_T");
                writer.WriteLine("  movwf   MOT_RST_COM");
                writer.WriteLine("  call    MOT_RST");
            }
            if (this.resetDistance == true)
            {
                writer.WriteLine("  movlw   RST_KM");
                writer.WriteLine("  movwf   MOT_RST_COM");
                writer.WriteLine("  call    MOT_RST");

                //***DEBUG: In mowayGUI there were 3 options(reset time, total distance and distance)
                writer.WriteLine("  movlw   RST_D");
                writer.WriteLine("  movwf   MOT_RST_COM");
                writer.WriteLine("  call    MOT_RST");
            }
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            if (this.resetDistance == true)
            {
                mowayModel.Movement.ResetDistance();
                mowayModel.Movement.ResetAngle();
            }
        }
    }
}
