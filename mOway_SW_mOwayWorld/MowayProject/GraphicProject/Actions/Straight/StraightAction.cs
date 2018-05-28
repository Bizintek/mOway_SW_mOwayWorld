using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Straight
{
    public class StraightAction : Module
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
        private decimal distanceValue = 0.1M;
        /// <summary>
        /// Wait until the end of action condition is met
        /// </summary>
        private bool waitFinish = false;

        #endregion

        #region Properties

        public Variable SpeedVariable { get { return this.speedVariable; } }
        public int SpeedValue { get { return this.speedValue; } }
        public Direction Direction { get { return this.direction; } }
        public FlowchartControl FlowachartControl { get { return this.flowchartControl; } }
        public Variable TimeVariable { get { return this.timeVariable; } }
        public decimal TimeValue { get { return this.timeValue; } }
        public Variable DistanceVariable { get { return this.distanceVariable; } }
        public decimal DistanceValue { get { return this.distanceValue; } }
        public bool WaitFinish { get { return this.waitFinish; } }

        #endregion

        public StraightAction(string key)
        {
            this.key = key;
        }

        public StraightAction(string key,Variable speedVariable, int speedValue, Direction direction, FlowchartControl flowchartControl, Variable timeVariable, decimal timeValue, Variable distanceVariable, decimal distanceValue, bool waitFinish)
        {
            this.key = key;
            this.speedVariable = speedVariable;
            this.speedValue = speedValue;
            this.direction = direction;
            this.flowchartControl = flowchartControl;
            this.timeVariable = timeVariable;
            this.timeValue = timeValue;
            this.distanceVariable = distanceVariable;
            this.distanceValue = distanceValue;
            this.waitFinish = waitFinish;
        }

        public StraightAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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

        public void UpdateSettings(Variable speedVariable, int speedValue, Direction direction, FlowchartControl flowchartControl, Variable timeVariable, decimal timeValue, Variable distanceVariable, decimal distanceValue, bool waitFinish)
        {
            this.speedVariable = speedVariable;
            this.speedValue = speedValue;
            this.direction = direction;
            this.flowchartControl = flowchartControl;
            this.timeVariable = timeVariable;
            this.timeValue = timeValue;
            this.distanceVariable = distanceVariable;
            this.distanceValue = distanceValue;
            this.waitFinish = waitFinish;
        }

        public override bool VariableUsed(Variable variable)
        {
            if ((this.speedVariable == variable) || (this.timeVariable == variable) || (this.distanceVariable == variable))
                return true;
            else
                return false;
        }

        public override Element Clone()
        {
            return new StraightAction(this.key, this.speedVariable, this.speedValue, this.direction, this.flowchartControl, this.timeVariable, this.timeValue, this.distanceVariable, this.distanceValue, this.waitFinish);
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
            file.WriteElementString("flowchartControl", this.flowchartControl.ToString());
            if (this.timeVariable == null)
                file.WriteElementString("timeVariable", "none");
            else
                file.WriteElementString("timeVariable", this.timeVariable.Name);
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
            //*****************************[Module header]************************************
            writer.WriteLine(";************Module Move*************************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");

            //***********************************[Speed]***********************************
            if (speedVariable == null)
                writer.WriteLine("  movlw   ." + speedValue);
            else
                writer.WriteLine("  movf   " + speedVariable.Name + ",W");
            writer.WriteLine("  movwf   MOT_VEL");

            //*****************************[Time or Distance]********************************
            if (flowchartControl == FlowchartControl.FinishTime)
            {
                writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                if (timeVariable == null)
                    writer.WriteLine("  movlw   ." + (byte)(timeValue * 10));
                else
                    writer.WriteLine("  movf   " + timeVariable.Name + ",W");
            }
            else if (flowchartControl == FlowchartControl.FinishDistance)
            {
                writer.WriteLine("  bcf     MOT_CON,COMTYPE");
                if (distanceVariable == null)
                    writer.WriteLine("  movlw   ." + (byte)(distanceValue * 10));
                else
                    writer.WriteLine("  movf   " + distanceVariable.Name + ",W");
            }
            else if (flowchartControl == FlowchartControl.Continuously)
            {
                writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                writer.WriteLine("  movlw   .0");
            }
            writer.WriteLine("  movwf   MOT_T_DIST_ANG");
            //*********************************[Direction]*************************************
            if (direction == Direction.Forward)
                writer.WriteLine("  bsf     MOT_CON,FWDBACK");
            else
                writer.WriteLine("  bcf     MOT_CON,FWDBACK");
            //*********************************[Function]***************************************
            writer.WriteLine("  call    MOT_STR");
            //*************************[Wait until it ends]******************************
            if (this.waitFinish)
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
            decimal tempDistance; 
            Moway.Simulator.Outputs.Direction simWheelDirection;

            // Save speed in speed simulation variable
            if (speedVariable == null)
                simWheelSpeed = (byte)speedValue;                
            else
                simWheelSpeed = mowayModel.GetRegister(speedVariable.Name).Value;

            // Save speed in speed simulation variable
            if (simWheelSpeed > 100)
                return;

            // Save steering wheel in steering simulation variable
            if (direction == Direction.Forward)
                simWheelDirection = Moway.Simulator.Outputs.Direction.Forward;
            else
                simWheelDirection = Moway.Simulator.Outputs.Direction.Backward;

            // Assign variables to the simulation model
            mowayModel.Movement.UpdateMovement(simWheelDirection, simWheelSpeed, simWheelDirection, simWheelSpeed);

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
