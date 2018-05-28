using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Lights
{
    public enum LightState { NoChange = 0, On, Off, Blink }

    public class LightsAction : Module
    {
        #region Attributes

        private LightState frontLight = LightState.NoChange;
        private LightState brakeLight = LightState.NoChange;
        private LightState topGreenLight = LightState.NoChange;
        private LightState topRedLight = LightState.NoChange;

        #endregion

        #region Properties

        public LightState FrontLight { get { return this.frontLight; } }
        public LightState BrakeLight { get { return this.brakeLight; } }
        public LightState TopGreenLight { get { return this.topGreenLight; } }
        public LightState TopRedLight { get { return this.topRedLight; } }

        #endregion

        public LightsAction(string key)
        {
            this.key = key;
        }

        public LightsAction(string key, LightState frontLight, LightState brakeLight, LightState topGreenLight, LightState topRedLight)
        {
            this.key = key;
            this.frontLight = frontLight;
            this.brakeLight = brakeLight;
            this.topGreenLight = topGreenLight;
            this.topRedLight = topRedLight;
        }

        public LightsAction(string key, XmlElement properties)
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
                    case "frontLight":
                        this.frontLight = (LightState)Enum.Parse(typeof(LightState), property.InnerText);
                        break;
                    case "brakeLight":
                        this.brakeLight = (LightState)Enum.Parse(typeof(LightState), property.InnerText);
                        break;
                    case "topGreenLight":
                        this.topGreenLight = (LightState)Enum.Parse(typeof(LightState), property.InnerText);
                        break;
                    case "topRedLight":
                        this.topRedLight = (LightState)Enum.Parse(typeof(LightState), property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(LightState frontLight, LightState brakeLight, LightState topGreenLight, LightState topRedLight)
        {
            this.frontLight = frontLight;
            this.brakeLight = brakeLight;
            this.topGreenLight = topGreenLight;
            this.topRedLight = topRedLight;
        }

        public override Element Clone()
        {
            return new LightsAction(this.key, this.frontLight, this.brakeLight, this.topGreenLight, this.topRedLight);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteElementString("frontLight", this.frontLight.ToString());
            file.WriteElementString("brakeLight", this.brakeLight.ToString());
            file.WriteElementString("topGreenLight", this.topGreenLight.ToString());
            file.WriteElementString("topRedLight", this.topRedLight.ToString());
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";************Module Leds************************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");


            switch (frontLight)
            {
                case LightState.NoChange:
                    break;
                case LightState.On:
                    writer.WriteLine("  call    LED_FRONT_ON");
                    break;
                case LightState.Off:
                    writer.WriteLine("  call    LED_FRONT_OFF");
                    break;
                case LightState.Blink:
                    writer.WriteLine("  call    LED_FRONT_ON_OFF");
                    break;
            }
            switch (brakeLight)
            {
                case LightState.NoChange:
                    break;
                case LightState.On:
                    writer.WriteLine("  call    LED_BRAKE_ON");
                    break;
                case LightState.Off:
                    writer.WriteLine("  call    LED_BRAKE_OFF");
                    break;
                case LightState.Blink:
                    writer.WriteLine("  call    LED_BRAKE_ON_OFF");
                    break;
            }
            switch (topGreenLight)
            {
                case LightState.NoChange:
                    break;
                case LightState.On:
                    writer.WriteLine("  call    LED_TOP_GREEN_ON");
                    break;
                case LightState.Off:
                    writer.WriteLine("  call    LED_TOP_GREEN_OFF");
                    break;
                case LightState.Blink:
                    writer.WriteLine("  call    LED_TOP_GREEN_ON_OFF");
                    break;
            }
            switch (topRedLight)
            {
                case LightState.NoChange:
                    break;
                case LightState.On:
                    writer.WriteLine("  call    LED_TOP_RED_ON");
                    break;
                case LightState.Off:
                    writer.WriteLine("  call    LED_TOP_RED_OFF");
                    break;
                case LightState.Blink:
                    writer.WriteLine("  call    LED_TOP_RED_ON_OFF");
                    break;
            }

            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

         public override void Simulate(MowayModel mowayModel)
        {
            mowayModel.Lights.UpdateLights(GetLightsState(this.frontLight), GetLightsState(this.brakeLight), GetLightsState(this.topGreenLight), GetLightsState(this.topRedLight));
            if (this.frontLight == LightState.Blink)
            {
                mowayModel.Lights.UpdateLights(DigitalState.On, DigitalState.NoChange, DigitalState.NoChange, DigitalState.NoChange);
                System.Threading.Thread.Sleep(250);
                mowayModel.Lights.UpdateLights(DigitalState.Off, DigitalState.NoChange, DigitalState.NoChange, DigitalState.NoChange);
                System.Threading.Thread.Sleep(250);
            }
            if (this.brakeLight == LightState.Blink)
            {
                mowayModel.Lights.UpdateLights(DigitalState.NoChange, DigitalState.On, DigitalState.NoChange, DigitalState.NoChange);
                System.Threading.Thread.Sleep(250);
                mowayModel.Lights.UpdateLights(DigitalState.NoChange, DigitalState.Off, DigitalState.NoChange, DigitalState.NoChange);
                System.Threading.Thread.Sleep(250);
            }
            if (this.topGreenLight == LightState.Blink)
            {
                mowayModel.Lights.UpdateLights(DigitalState.NoChange, DigitalState.NoChange, DigitalState.On, DigitalState.NoChange);
                System.Threading.Thread.Sleep(250);
                mowayModel.Lights.UpdateLights(DigitalState.NoChange, DigitalState.NoChange, DigitalState.Off, DigitalState.NoChange);
                System.Threading.Thread.Sleep(250);
            }
            if (this.topRedLight == LightState.Blink)
            {
                mowayModel.Lights.UpdateLights(DigitalState.NoChange, DigitalState.NoChange, DigitalState.NoChange,DigitalState.On);
                System.Threading.Thread.Sleep(250);
                mowayModel.Lights.UpdateLights(DigitalState.NoChange, DigitalState.NoChange, DigitalState.NoChange, DigitalState.Off);
                System.Threading.Thread.Sleep(250);
            }
        }

        private DigitalState GetLightsState(LightState ledState)
        {
            switch (ledState)
            {
                case LightState.On:
                    return DigitalState.On;
                case LightState.Off:
                    return DigitalState.Off;
                case LightState.NoChange:
                    return DigitalState.NoChange;
                default:
                    return DigitalState.NoChange;
            }
        }            
    }
}
