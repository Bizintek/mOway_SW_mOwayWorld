using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.AssignObstacle
{
    public class AssignObstacleAction : Module
    {
        #region Attributes

        private Variable assignVariable = null;
        private ObstacleSensor obstacleSensor = ObstacleSensor.Right;

        #endregion

        #region Properties

        public Variable AssignVariable { get { return this.assignVariable; } }
        public ObstacleSensor ObstacleSensor { get { return this.obstacleSensor; } }

        #endregion

        public AssignObstacleAction(string key)
        {
            this.key = key;
        }

        public AssignObstacleAction(string key, Variable assignVariable, ObstacleSensor obstacleSensor)
        {
            this.key = key;
            this.assignVariable = assignVariable;
            this.obstacleSensor = obstacleSensor;
        }

        public AssignObstacleAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                    case "assignVariable":
                        if (property.InnerText != "none")
                            this.assignVariable = variables[property.InnerText];
                        break;
                    case "obstacleSensor":
                        this.obstacleSensor = (ObstacleSensor)Enum.Parse(typeof(ObstacleSensor), property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(Variable assignVariable, ObstacleSensor obstacleSensor)
        {
            this.assignVariable = assignVariable;
            this.obstacleSensor = obstacleSensor;
        }

        public override bool VariableUsed(Variable variable)
        {
            if (this.assignVariable == variable)
                return true;
            else
                return false;
        }

        public override Element Clone()
        {
            return new AssignObstacleAction(this.key, this.assignVariable, this.obstacleSensor);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            if (this.assignVariable == null)
                file.WriteElementString("assignVariable", "none");
            else
                file.WriteElementString("assignVariable", this.assignVariable.Name);
            file.WriteElementString("obstacleSensor", this.obstacleSensor.ToString());
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";*********************Module Assign Obstacle****************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            switch (this.obstacleSensor)
            {
                case ObstacleSensor.Left:
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_CENTER_R");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_SIDE_R");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_CENTER_L");
                    writer.WriteLine("  bsf		SEN_CHECK_OBS,OBS_SIDE_L");
                    writer.WriteLine("  call 	SEN_OBS_ANALOG");
                    writer.WriteLine("  movf    SEN_OBS_SIDE_L,W");
                    break;
                case ObstacleSensor.Right:
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_CENTER_R");
                    writer.WriteLine("  bsf		SEN_CHECK_OBS,OBS_SIDE_R");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_CENTER_L");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_SIDE_L");
                    writer.WriteLine("  call 	SEN_OBS_ANALOG");
                    writer.WriteLine("  movf    SEN_OBS_SIDE_R,W");
                    break;
                case ObstacleSensor.UpperLeft:
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_CENTER_R");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_SIDE_R");
                    writer.WriteLine("  bsf		SEN_CHECK_OBS,OBS_CENTER_L");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_SIDE_L");
                    writer.WriteLine("  call 	SEN_OBS_ANALOG");
                    writer.WriteLine("  movf    SEN_OBS_CENTER_L,W");
                    break;
                case ObstacleSensor.UpperRight:
                    writer.WriteLine("  bsf		SEN_CHECK_OBS,OBS_CENTER_R");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_SIDE_R");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_CENTER_L");
                    writer.WriteLine("  bcf		SEN_CHECK_OBS,OBS_SIDE_L");
                    writer.WriteLine("  call 	SEN_OBS_ANALOG");
                    writer.WriteLine("  movf    SEN_OBS_CENTER_R,W");
                    break;
            }
            writer.WriteLine("  movwf   " + this.assignVariable.Name);
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            switch (this.obstacleSensor)
            {
                case ObstacleSensor.Left:
                    mowayModel.GetRegister(this.assignVariable.Name).Value = mowayModel.ObstacleSensors.LeftSideSensor;
                    break;
                case ObstacleSensor.Right:
                    mowayModel.GetRegister(this.assignVariable.Name).Value = mowayModel.ObstacleSensors.RightSideSensor;
                    break;
                case ObstacleSensor.UpperLeft:
                    mowayModel.GetRegister(this.assignVariable.Name).Value = mowayModel.ObstacleSensors.LeftCentralSensor;
                    break;
                case ObstacleSensor.UpperRight:
                    mowayModel.GetRegister(this.assignVariable.Name).Value = mowayModel.ObstacleSensors.RightCentralSensor;
                    break;
            }
        }
    }
}
