using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Turn
{
    public class TurnAction : Module
    {
        #region Attributes

        /// <summary>
        /// Variable for speed(if it is null, it is a constant value)
        /// </summary>
        private Variable speedVariable = null;
        /// <summary>
        /// Value for speed(only in the case of constant)
        /// </summary>
        private int speedValue = 50;
        /// <summary>
        /// Direction of movement
        /// </summary>
        private Direction direction = Direction.Forward;
        /// <summary>
        /// Variable for the radius(if it is null, it is a constant value)
        /// </summary>
        private Variable radiusVariable = null;
        /// <summary>
        /// Value for the radius(only in the case of constant)
        /// </summary>
        private decimal radiusValue = 1;
        /// <summary>
        /// Turn side
        /// </summary>
        private Side turnSide = Side.Right;
        /// <summary>
        /// Flow control for the action
        /// </summary>
        private FlowchartControl flowchartControl = FlowchartControl.Continuously;
        /// <summary>
        /// Variable for time(if it is null, it is a constant value)
        /// </summary>
        private Variable timeVariable = null;
        /// <summary>
        /// Value for time(only in the case of constant)
        /// </summary>
        private decimal timeValue = 0.1M;
        /// <summary>
        /// Variable for the distance(if it is null, it is a constant value)
        /// </summary>
        private Variable distanceVariable = null;
        /// <summary>
        /// Value for distance(only in the case of constant)
        /// </summary>
        private decimal distanceValue = 0.17M;
        /// <summary>
        /// Wait until the end of action condition is met
        /// </summary>
        private bool waitFinish = false;

        #endregion

        #region Properties

        public Variable SpeedVariable { get { return this.speedVariable; } }
        public int SpeedValue { get { return this.speedValue; } }
        public Direction Direction { get { return this.direction; } }
        public Variable RadiusVariable { get { return this.radiusVariable; } }
        public decimal RadiusValue { get { return this.radiusValue; } }
        public Side TurnSide { get { return this.turnSide; } }
        public FlowchartControl FlowachartControl { get { return this.flowchartControl; } }
        public Variable TimeVariable { get { return this.timeVariable; } }
        public decimal TimeValue { get { return this.timeValue; } }
        public Variable DistanceVariable { get { return this.distanceVariable; } }
        public decimal DistanceValue { get { return this.distanceValue; } }
        public bool WaitFinish { get { return this.waitFinish; } }

        #endregion

        public TurnAction(string key)
        {
            this.key = key;
        }

        public TurnAction(string key, Variable speedVariable, int speedValue, Direction direction, Variable radiusVariable, decimal radiusValue, Side turnSide, FlowchartControl flowchartControl, Variable timeVariable, decimal timeValue, Variable distanceVariable, decimal distanceValue, bool waitFinish)
        {
            this.key = key;
            this.speedVariable = speedVariable;
            this.speedValue = speedValue;
            this.direction = direction;
            this.radiusVariable = radiusVariable;
            this.radiusValue = radiusValue;
            this.turnSide = turnSide;
            this.flowchartControl = flowchartControl;
            this.timeVariable = timeVariable;
            this.timeValue = timeValue;
            this.distanceVariable = distanceVariable;
            this.distanceValue = distanceValue;
            this.waitFinish = waitFinish;
        }

        public TurnAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                    case "speedVariable":
                        if (property.InnerText != "none")
                        this.speedVariable = variables[property.InnerText];
                        break;
                    case "speedValue":
                        this.speedValue = System.Convert.ToInt32(property.InnerText);
                        break;
                    case "direction":
                        this.direction = (Direction)Enum.Parse(typeof(Direction), property.InnerText);
                        break;
                    case "radiusVariable":
                        if (property.InnerText != "none")
                            this.radiusVariable = variables[property.InnerText];
                        break;
                    case "radiusValue":
                        this.radiusValue = System.Convert.ToDecimal(property.InnerText.Replace(',', '.'), new System.Globalization.CultureInfo("en-GB"));
                        break;
                    case "turnSide":
                        this.turnSide = (Side)Enum.Parse(typeof(Side), property.InnerText);
                        break;
                    case "flowchartControl":
                        this.flowchartControl = (FlowchartControl)Enum.Parse(typeof(FlowchartControl), property.InnerText);
                        break;
                    case "timeVariable":
                        if (property.InnerText != "none")
                            this.timeVariable = variables[property.InnerText];
                        break;
                    case "timeValue":
                        this.timeValue = System.Convert.ToDecimal(property.InnerText.Replace(',', '.'), new System.Globalization.CultureInfo("en-GB"));
                        break;
                    case "distanceVariable":
                        if (property.InnerText != "none")
                            this.distanceVariable = variables[property.InnerText];
                        break;
                    case "distanceValue":
                        this.distanceValue = System.Convert.ToDecimal(property.InnerText.Replace(',', '.'), new System.Globalization.CultureInfo("en-GB"));
                        break;
                    case "waitFinish":
                        this.waitFinish = System.Convert.ToBoolean(property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        
        public void UpdateSettings(Variable speedVariable, int speedValue, Direction direction, Variable radiusVariable, decimal radiusValue, Side turnSide, FlowchartControl flowchartControl, Variable timeVariable, decimal timeValue, Variable distanceVariable, decimal distanceValue, bool waitFinish)
        {
            this.speedVariable = speedVariable;
            this.speedValue = speedValue;
            this.direction = direction;
            this.radiusVariable = radiusVariable;
            this.radiusValue = radiusValue;
            this.turnSide = turnSide;
            this.flowchartControl = flowchartControl;
            this.timeVariable = timeVariable;
            this.timeValue = timeValue;
            this.distanceVariable = distanceVariable;
            this.distanceValue = distanceValue;
            this.waitFinish = waitFinish;
        }

        public override bool VariableUsed(Variable variable)
        {
            if ((this.speedVariable == variable) || (this.radiusVariable == variable) || (this.timeVariable == variable) || (this.distanceVariable == variable))
                return true;
            else
                return false;
        }

        public override Element Clone()
        {
            return new TurnAction(this.key, this.speedVariable, this.speedValue, this.direction, this.radiusVariable, this.radiusValue, this.turnSide, this.flowchartControl, this.timeVariable, this.timeValue, this.distanceVariable, this.distanceValue, this.waitFinish);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            if (this.speedVariable == null)
                file.WriteElementString("speedVariable", "none");
            else
                file.WriteElementString("speedVariable", this.speedVariable.Name);
            file.WriteElementString("speedValue", this.speedValue.ToString());
            file.WriteElementString("direction", this.direction.ToString());
            if (this.radiusVariable == null)
                file.WriteElementString("radiusVariable", "none");
            else
                file.WriteElementString("radiusVariable", this.radiusVariable.Name);
            file.WriteElementString("radiusValue", this.radiusValue.ToString());
            file.WriteElementString("turnSide", this.turnSide.ToString());
            file.WriteElementString("flowchartControl", this.flowchartControl.ToString());
            if (this.timeVariable == null)
                file.WriteElementString("timeVariable", "none");
            else
                file.WriteElementString("timeVariable", this.timeVariable.ToString());
            file.WriteElementString("timeValue", this.timeValue.ToString());
            if (this.distanceVariable == null)
                file.WriteElementString("distanceVariable", "none");
            else
                file.WriteElementString("distanceVariable", this.distanceVariable.Name);
            file.WriteElementString("distanceValue", this.distanceValue.ToString());
            file.WriteElementString("waitFinish", this.waitFinish.ToString());
            file.WriteEndElement();
        }


        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";************Module Curve***********************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
            //*****************************[ Speed ]***************************************
            if (speedVariable == null)
                writer.WriteLine("  movlw   ." + speedValue);
            else
                writer.WriteLine("  movf   " + speedVariable.Name + ",W");
            writer.WriteLine("  movwf   MOT_VEL");
            //*****************************[Time or Distance]********************************
            if (flowchartControl == FlowchartControl.FinishTime)
            {
                writer.WriteLine("  bsf MOT_CON,COMTYPE");
                if (TimeVariable == null)
                    writer.WriteLine("  movlw   ." + (byte)(TimeValue * 10));
                else
                    writer.WriteLine("  movf   " + TimeVariable.Name + ",W");
            }
            else if (flowchartControl == FlowchartControl.FinishDistance)
            {
                writer.WriteLine("  bcf     MOT_CON,COMTYPE");
                if (DistanceVariable == null)
                    writer.WriteLine("  movlw   ." + (byte)(DistanceValue * 10));
                else
                    writer.WriteLine("  movf   " + DistanceVariable.Name + ",W");
            }
            else if (flowchartControl == FlowchartControl.Continuously)
            {
                writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                writer.WriteLine("  movlw   .0");
            }
            writer.WriteLine("  movwf   MOT_T_DIST_ANG");
            //***********************************[Radius]***************************************
            if (radiusVariable == null)
                writer.WriteLine("  movlw   ." + radiusValue);
            else
                writer.WriteLine("  movf   " + radiusVariable.Name + ",W");
            writer.WriteLine("  movwf       MOT_RAD");
            //***********************************[Side]***************************************
            if (turnSide == Side.Right)
                writer.WriteLine("  bsf     MOT_CON,RL");
            else
                writer.WriteLine("  bcf     MOT_CON,RL");
            //*********************************[Direction]*************************************
            if (direction == Direction.Forward)
                writer.WriteLine("  bsf     MOT_CON,FWDBACK");
            else
                writer.WriteLine("  bcf     MOT_CON,FWDBACK");
            //*********************************[Function]***************************************
            writer.WriteLine("  call    MOT_CUR");
            //*************************[Wait until it ends]******************************
            if (flowchartControl != FlowchartControl.Continuously)
            {
                writer.WriteLine("  call    MOT_CHECK_END");
            }
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

        public override void Simulate(MowayModel mowayModel)
        {
            byte simWheelSpeed;            
            byte simLeftWheelSpeed;
            byte simRightWheelSpeed;
            byte simCurvature;
            decimal tempDistance;
            Moway.Simulator.Outputs.Direction simWheelDirection;

            // Save speed in speed simulation variable
            if (speedVariable == null)
                simWheelSpeed = (byte)speedValue;
            else
                simWheelSpeed = mowayModel.GetRegister(speedVariable.Name).Value;

            // Save curvature in simulation variable
            if (radiusVariable == null)
                simCurvature = (byte)radiusValue;
            else
                simCurvature = mowayModel.GetRegister(radiusVariable.Name).Value;

            // Speed ​​and curvature can not add more than 100
            if (simWheelSpeed + simCurvature > 100)
                return;

            // The speed can not be less than the curvature
            else if (simWheelSpeed < simCurvature)
                return;

            // Assign speed to each wheel depending on the curvature
            if (turnSide == Side.Left)
            {
                simLeftWheelSpeed = (byte)(simWheelSpeed - simCurvature);
                simRightWheelSpeed = simWheelSpeed;
            }
            else
            {
                simLeftWheelSpeed = simWheelSpeed;
                simRightWheelSpeed = (byte)(simWheelSpeed - simCurvature);
            }

            // Save steering wheels in steering simulation variable
            if (direction == Direction.Forward)
                simWheelDirection = Moway.Simulator.Outputs.Direction.Forward;
            else
                simWheelDirection = Moway.Simulator.Outputs.Direction.Backward;

            // Assign variables to the simulation model
            mowayModel.Movement.UpdateMovement(simWheelDirection, simLeftWheelSpeed, simWheelDirection, simRightWheelSpeed);

            // If you choose to execute by time, pause the thread said time
            if (flowchartControl == FlowchartControl.FinishTime)
            {
                if (this.timeVariable == null)
                    System.Threading.Thread.Sleep((int)(this.timeValue * 1000));
                else
                    // Time variable: 0-255 hundredths of a second
                    System.Threading.Thread.Sleep((int)(mowayModel.GetRegister(this.timeVariable.Name).Value * 100));

                // mOway stops
                mowayModel.Movement.UpdateMovement(simWheelDirection, 0, simWheelDirection, 0);
            }
            // If you choose to run by distance, compare the distance traveled simulated
            else if (flowchartControl == FlowchartControl.FinishDistance)
            {
                if (simWheelSpeed == 0)
                    return;

                if (DistanceVariable == null)
                    tempDistance = mowayModel.Movement.Distance + distanceValue;
                else
                    tempDistance = mowayModel.Movement.Distance + mowayModel.GetRegister(distanceVariable.Name).Value / 10;

                while (mowayModel.Movement.Distance < tempDistance);

                // mOway stops
                mowayModel.Movement.UpdateMovement(simWheelDirection, 0, simWheelDirection, 0);
            }
            else if (flowchartControl == FlowchartControl.Continuously)
            { }

            //*************************[Wait until it ends]******************************
            if (this.waitFinish)
            { }
        }
    }
}
