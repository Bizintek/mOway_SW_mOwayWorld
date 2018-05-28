using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Obstacle
{
    public enum ObstacleState { Inactive, Detect, NoDetect }

    public class ObstacleAction : Conditional
    {
        #region Attributes

        private ObstacleState upperLeftSensor = ObstacleState.Inactive;
        private ObstacleState leftSensor = ObstacleState.Inactive;
        private ObstacleState upperRightSensor = ObstacleState.Inactive;
        private ObstacleState rightSensor = ObstacleState.Inactive;
        private LogicOp operation = LogicOp.And;

        #endregion

        #region Properties

        public ObstacleState UpperLeftSensor { get { return this.upperLeftSensor; } }
        public ObstacleState LeftSensor { get { return this.leftSensor; } }
        public ObstacleState UpperRightSensor { get { return this.upperRightSensor; } }
        public ObstacleState RightSensor { get { return this.rightSensor; } }
        public LogicOp Operation { get { return this.operation; } }

        #endregion

        public ObstacleAction(string key)
        {
            this.key = key;
        }

        public ObstacleAction(string key, ObstacleState upperLeftSensor, ObstacleState leftSensor, ObstacleState upperRightSensor, ObstacleState rightSensor, LogicOp operation)
        {
            this.key = key;
            this.upperLeftSensor = upperLeftSensor;
            this.leftSensor = leftSensor;
            this.upperRightSensor = upperRightSensor;
            this.rightSensor = rightSensor;
            this.operation = operation;
        }

        public ObstacleAction(string key, XmlElement properties)
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
                    case "upperLeftSensor":
                        this.upperLeftSensor = (ObstacleState)Enum.Parse(typeof(ObstacleState), property.InnerText);
                        break;
                    case "leftSensor":
                        this.leftSensor = (ObstacleState)Enum.Parse(typeof(ObstacleState), property.InnerText);
                        break;
                    case "upperRightSensor":
                        this.upperRightSensor = (ObstacleState)Enum.Parse(typeof(ObstacleState), property.InnerText);
                        break;
                    case "rightSensor":
                        this.rightSensor = (ObstacleState)Enum.Parse(typeof(ObstacleState), property.InnerText);
                        break;
                    case "operation":
                        this.operation = (LogicOp)Enum.Parse(typeof(LogicOp), property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public override Element Clone()
        {
            return new ObstacleAction(this.key, this.upperLeftSensor, this.leftSensor, this.upperRightSensor, this.rightSensor, this.operation);
        }

        public void UpdateSettings(ObstacleState upperLeftSensor, ObstacleState leftSensor, ObstacleState upperRightSensor, ObstacleState rightSensor, LogicOp operation)
        {
            this.upperLeftSensor = upperLeftSensor;
            this.leftSensor = leftSensor;
            this.upperRightSensor = upperRightSensor;
            this.rightSensor = rightSensor;
            this.operation = operation;
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteElementString("upperLeftSensor", this.upperLeftSensor.ToString());
            file.WriteElementString("leftSensor", this.leftSensor.ToString());
            file.WriteElementString("upperRightSensor", this.upperRightSensor.ToString());
            file.WriteElementString("rightSensor", this.rightSensor.ToString());
            file.WriteElementString("operation", this.operation.ToString());
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer, string labelFalse)
        {
            writer.WriteLine(";************Module DigInfra*****************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
            writer.WriteLine("  call    SEN_OBS_DIG");

            if (operation == LogicOp.And)
            {

                if (leftSensor == ObstacleState.Detect)
                {
                    writer.WriteLine("  btfss   SEN_OBS_SIDE_L,0");
                    writer.WriteLine(labelFalse);
                }
                else if (leftSensor == ObstacleState.NoDetect)
                {
                    writer.WriteLine("  btfsc   SEN_OBS_SIDE_L,0");
                    writer.WriteLine(labelFalse);
                }

                if (rightSensor == ObstacleState.Detect)
                {
                    writer.WriteLine("  btfss   SEN_OBS_SIDE_R,0");
                    writer.WriteLine(labelFalse);
                }
                else if (rightSensor == ObstacleState.NoDetect)
                {
                    writer.WriteLine("  btfsc   SEN_OBS_SIDE_R,0");
                    writer.WriteLine(labelFalse);
                }

                if (upperLeftSensor == ObstacleState.Detect)
                {
                    writer.WriteLine("  btfss   SEN_OBS_CENTER_L,0");
                    writer.WriteLine(labelFalse);
                }
                else if (upperLeftSensor == ObstacleState.NoDetect)
                {
                    writer.WriteLine("  btfsc   SEN_OBS_CENTER_L,0");
                    writer.WriteLine(labelFalse);
                }

                if (upperRightSensor == ObstacleState.Detect)
                {
                    writer.WriteLine("  btfss   SEN_OBS_CENTER_R,0");
                    writer.WriteLine(labelFalse);
                }
                else if (upperRightSensor == ObstacleState.NoDetect)
                {
                    writer.WriteLine("  btfsc   SEN_OBS_CENTER_R,0");
                    writer.WriteLine(labelFalse);
                }
            }
            else
            {
                writer.WriteLine("  clrf   AUX_00");
                if (leftSensor == ObstacleState.Detect)
                {                    
                    writer.WriteLine("  btfsc   SEN_OBS_SIDE_L,0");
                    writer.WriteLine("  bsf     AUX_00,0");
                }
                else if (leftSensor == ObstacleState.NoDetect)
                {                 
                    writer.WriteLine("  btfss   SEN_OBS_SIDE_L,0");
                    writer.WriteLine("  bsf     AUX_00,0");
                }

                if (rightSensor == ObstacleState.Detect)
                {                
                    writer.WriteLine("  btfsc   SEN_OBS_SIDE_R,0");
                    writer.WriteLine("  bsf     AUX_00,0");
                }
                else if (rightSensor == ObstacleState.NoDetect)
                {                 
                    writer.WriteLine("  btfss   SEN_OBS_SIDE_R,0");
                    writer.WriteLine("  bsf     AUX_00,0");
                }

                if (upperLeftSensor == ObstacleState.Detect)
                {                    
                    writer.WriteLine("  btfsc   SEN_OBS_CENTER_L,0");
                    writer.WriteLine("  bsf     AUX_00,0");
                }
                else if (upperLeftSensor == ObstacleState.NoDetect)
                {
                    writer.WriteLine("  btfss   SEN_OBS_CENTER_L,0");
                    writer.WriteLine("  bsf     AUX_00,0");
                }

                if (upperRightSensor == ObstacleState.Detect)
                {
                    writer.WriteLine("  btfsc   SEN_OBS_CENTER_R,0");
                    writer.WriteLine("  bsf     AUX_00,0");
                }
                else if (upperRightSensor == ObstacleState.NoDetect)
                {
                    writer.WriteLine("  btfss   SEN_OBS_CENTER_R,0");
                    writer.WriteLine("  bsf     AUX_00,0");
                }
                writer.WriteLine("  btfss   AUX_00,0");
                writer.WriteLine(labelFalse);
            }

            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

        public override bool Simulate(MowayModel mowayModel)
        {
            bool leftCondition = false;
            bool upperLeftCondition = false;
            bool rightCondition = false;
            bool upperRightCondition = false;

            // Check left side sensor condition
            if ((leftSensor == ObstacleState.Detect) && (mowayModel.ObstacleSensors.LeftSideSensor >= MowayModel.MIN_OBSTACLE) ||
                (leftSensor == ObstacleState.NoDetect) && (mowayModel.ObstacleSensors.LeftSideSensor < MowayModel.MIN_OBSTACLE))
                leftCondition = true;
            else
                leftCondition = false;

            // Check left center sensor condition
            if ((upperLeftSensor == ObstacleState.Detect) && (mowayModel.ObstacleSensors.LeftCentralSensor >= MowayModel.MIN_OBSTACLE) ||
                (upperLeftSensor == ObstacleState.NoDetect) && (mowayModel.ObstacleSensors.LeftCentralSensor < MowayModel.MIN_OBSTACLE))
                upperLeftCondition = true;
            else
                upperLeftCondition = false;

            // Check right center sensor condition
            if ((upperRightSensor == ObstacleState.Detect) && (mowayModel.ObstacleSensors.RightCentralSensor >= MowayModel.MIN_OBSTACLE) ||
                (upperRightSensor == ObstacleState.NoDetect) && (mowayModel.ObstacleSensors.RightCentralSensor < MowayModel.MIN_OBSTACLE))
                upperRightCondition = true;
            else
                upperRightCondition = false;

            // Check right side sensor condition
            if ((rightSensor == ObstacleState.Detect) && (mowayModel.ObstacleSensors.RightSideSensor >= MowayModel.MIN_OBSTACLE) ||
                (rightSensor == ObstacleState.NoDetect) && (mowayModel.ObstacleSensors.RightSideSensor < MowayModel.MIN_OBSTACLE))
                rightCondition = true;
            else
                rightCondition = false;

            // Check logic operation (AND/OR)
            if (operation == LogicOp.And)
            {
                if (leftSensor == ObstacleState.Inactive)
                    leftCondition = true;
                if (upperLeftSensor == ObstacleState.Inactive)
                    upperLeftCondition = true;
                if (upperRightSensor == ObstacleState.Inactive)
                    upperRightCondition = true;
                if (RightSensor == ObstacleState.Inactive)
                    rightCondition = true;
                return (leftCondition && upperLeftCondition && upperRightCondition && rightCondition);
            }
            else
            {
                if (leftSensor == ObstacleState.Inactive)
                    leftCondition = false;
                if (upperLeftSensor == ObstacleState.Inactive)
                    upperLeftCondition = false;
                if (upperRightSensor == ObstacleState.Inactive)
                    upperRightCondition = false;
                if (RightSensor == ObstacleState.Inactive)
                    rightCondition = false;
                return (leftCondition || upperLeftCondition || upperRightCondition || rightCondition);
            }
        }
    }
}
