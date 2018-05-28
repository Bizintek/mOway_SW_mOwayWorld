using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Rotate
{
    public enum RotateMode {Center, Wheel}
    public enum RotateWheel { RightForward, RightBackward, LeftForward, LeftBackward }

    public class RotateAction : Module
    {
        #region Attributes

        private Variable rotateVariable = null;
        private int rotateValue = 50;
        private RotateMode rotateMode = RotateMode.Center;
        private Side rotateSide = Side.Right;
        private Side rotateWheel = Side.Right;
        private Direction rotateDirection = Direction.Forward;
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
        private Variable angleVariable = null;
        /// <summary>
        /// Value for distance(only in the case of constant
        /// </summary>
        private decimal angleValue = 3.6M;
        /// <summary>
        /// Wait until the end of action condition is met
        /// </summary>
        private bool waitFinish = false;

        #endregion

        #region Properties

        public Variable RotateVariable { get { return this.rotateVariable; } }
        public int RotateValue { get { return this.rotateValue; } }
        public RotateMode RotateMode { get { return this.rotateMode; } }
        public Side RotateSide { get { return this.rotateSide; } }
        public Side RotateWheel { get { return this.rotateWheel; } }
        public Direction RotateDirection { get { return this.rotateDirection; } }
        public FlowchartControl FlowachartControl { get { return this.flowchartControl; } }
        public Variable TimeVariable { get { return this.timeVariable; } }
        public decimal TimeValue { get { return this.timeValue; } }
        public Variable AngleVariable { get { return this.angleVariable; } }
        public decimal AngleValue { get { return this.angleValue; } }
        public bool WaitFinish { get { return this.waitFinish; } }

        #endregion

        public RotateAction(string key)
        {
            this.key = key;
        }

        public RotateAction(string key, Variable rotateVariable, int rotateValue, RotateMode rotateMode, Side rotateSide, Side rotateWheel, Direction rotateDirection, FlowchartControl flowchartControl, Variable timeVariable, decimal timeValue, Variable angleVariable, decimal angleValue, bool waitFinish)
        {
            this.key = key;
            this.rotateVariable = rotateVariable;
            this.rotateValue = rotateValue;
            this.rotateMode = rotateMode;
            this.rotateWheel = rotateWheel;
            this.rotateSide = rotateSide;
            this.rotateDirection = rotateDirection;
            this.flowchartControl = flowchartControl;
            this.timeVariable = timeVariable;
            this.timeValue = timeValue;
            this.angleVariable = angleVariable;
            this.angleValue = angleValue;
            this.waitFinish = waitFinish;
        }

        public RotateAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                    case "rotateVariable":
                        if (property.InnerText != "none")
                            this.rotateVariable = variables[property.InnerText];
                        break;
                    case "rotateValue":
                        this.rotateValue = System.Convert.ToInt32(property.InnerText);
                        break;
                    case "rotateMode":
                        this.rotateMode = (RotateMode)Enum.Parse(typeof(RotateMode), property.InnerText);
                        break;
                    case "rotateSide":
                        this.rotateSide = (Side)Enum.Parse(typeof(Side), property.InnerText);
                        break;
                    case "rotateWheel":
                        this.rotateWheel = (Side)Enum.Parse(typeof(Side), property.InnerText);
                        break;
                    case "rotateDirection":
                        this.rotateDirection = (Direction)Enum.Parse(typeof(Direction), property.InnerText);
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
                    case "angleVariable":
                        if (property.InnerText != "none")
                            this.angleVariable = variables[property.InnerText];
                        break;
                    case "angleValue":
                        this.angleValue = System.Convert.ToDecimal(property.InnerText.Replace(',', '.'), new System.Globalization.CultureInfo("en-GB"));
                        break;
                    case "waitFinish":
                        this.waitFinish = System.Convert.ToBoolean(property.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(Variable rotateVariable, int rotateValue, RotateMode rotateMode, Side rotateSide, Side rotateWheel, Direction rotateDirection, FlowchartControl flowchartControl, Variable timeVariable, decimal timeValue, Variable angleVariable, decimal angleValue, bool waitFinish)
        {
            this.rotateVariable = rotateVariable;
            this.rotateValue = rotateValue;
            this.rotateMode = rotateMode;
            this.rotateWheel = rotateWheel;
            this.rotateSide = rotateSide;
            this.rotateDirection = rotateDirection;
            this.flowchartControl = flowchartControl;
            this.timeVariable = timeVariable;
            this.timeValue = timeValue;
            this.angleVariable = angleVariable;
            this.angleValue = angleValue;
            this.waitFinish = waitFinish;
        }

        public override bool VariableUsed(Variable variable)
        {
            if ((this.rotateVariable == variable) || (this.timeVariable == variable) || (this.angleVariable == variable))
                return true;
            else
                return false;
        }

        public override Element Clone()
        {
            return new RotateAction(this.key, this.rotateVariable, this.rotateValue, this.rotateMode, this.rotateSide, this.rotateWheel, this.rotateDirection, this.flowchartControl, this.timeVariable, this.timeValue, this.angleVariable, this.angleValue, this.waitFinish);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            if (this.rotateVariable == null)
                file.WriteElementString("rotateVariable", "none");
            else
                file.WriteElementString("rotateVariable", this.rotateVariable.Name);
            file.WriteElementString("rotateValue", this.rotateValue.ToString());
            file.WriteElementString("rotateMode", this.rotateMode.ToString());
            file.WriteElementString("rotateWheel", this.rotateWheel.ToString());
            file.WriteElementString("rotateSide", this.rotateSide.ToString());
            file.WriteElementString("rotateDirection", this.rotateDirection.ToString());
            file.WriteElementString("flowchartControl", this.flowchartControl.ToString());
            if (this.timeVariable == null)
                file.WriteElementString("timeVariable", "none");
            else
                file.WriteElementString("timeVariable", this.timeVariable.Name);
            file.WriteElementString("timeValue", this.timeValue.ToString());
            if (this.angleVariable == null)
                file.WriteElementString("angleVariable", "none");
            else
                file.WriteElementString("angleVariable", this.angleVariable.Name);
            file.WriteElementString("angleValue", this.angleValue.ToString());
            file.WriteElementString("waitFinish", this.waitFinish.ToString());
            file.WriteEndElement();
        }

        public void UpdateProperties(Variable rotateVariable, int rotateValue, RotateMode rotateMode, Side rotateSide, Side rotateWheel, Direction rotateDirection, FlowchartControl flowchartControl, Variable timeVariable, decimal timeValue, Variable angleVariable, decimal angleValue, bool waitFinish)
        {
            this.rotateVariable = rotateVariable;
            this.rotateValue = rotateValue;
            this.rotateMode = rotateMode;
            this.rotateWheel = rotateWheel;
            this.rotateSide = rotateSide;
            this.rotateDirection = rotateDirection;
            this.flowchartControl = flowchartControl;
            this.timeVariable = timeVariable;
            this.timeValue = timeValue;
            this.angleVariable = angleVariable;
            this.angleValue = angleValue;
            this.waitFinish = waitFinish;
        }

        public override void WriteCode(StreamWriter writer)
        {
            writer.WriteLine(";**************Module Turn**********************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
            //*****************************[ Speed ]***************************************
            if (rotateVariable == null)
                writer.WriteLine("  movlw   ." + rotateValue);
            else
                writer.WriteLine("  movf   " + rotateVariable.Name + ",W");
            writer.WriteLine("  movwf       MOT_VEL");
            //*****************************[Time or Distance]********************************
            if (flowchartControl == FlowchartControl.FinishTime)
            {
                writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                if (timeVariable == null)
                    writer.WriteLine("  movlw   ." + (byte)(timeValue * 10));
                else
                    writer.WriteLine("  movf   " + timeVariable.Name + ",W");
            }
            else if (flowchartControl == FlowchartControl.FinishAngle)
            {
                writer.WriteLine("  bcf     MOT_CON,COMTYPE");
                if (angleVariable == null)
                    writer.WriteLine("  movlw   ." + (byte)((angleValue * 10) / 36));
                else
                    writer.WriteLine("  movf   " + angleVariable.Name + ",W");
            }
            else if (flowchartControl == FlowchartControl.Continuously)
            {
                writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                writer.WriteLine("  movlw   .0");
            }
            writer.WriteLine("  movwf   MOT_T_DIST_ANG");
            //*****************************[Rotation mode]*************************************
            if (rotateMode == RotateMode.Center)
            {
                writer.WriteLine("  movlw   0x01");
                writer.WriteLine("  movwf   MOT_CENWHEEL");
                //***********************************[Side]***************************************
                if (rotateSide == Side.Right)
                    writer.WriteLine("  bsf     MOT_CON,RL");
                else
                    writer.WriteLine("  bcf     MOT_CON,RL");
            }
            else
            {
                writer.WriteLine("  movlw   0x00");
                writer.WriteLine("  movwf   MOT_CENWHEEL");
                //***********************************[Side]***************************************
                if (rotateWheel == Side.Right)
                    writer.WriteLine("  bsf     MOT_CON,RL");
                else
                    writer.WriteLine("  bcf     MOT_CON,RL");
            }

            //*********************************[Direction]*************************************
            if (rotateDirection == Direction.Forward)
                writer.WriteLine("  bsf     MOT_CON,FWDBACK");
            else
                writer.WriteLine("  bcf     MOT_CON,FWDBACK");

            //*********************************[Function]***************************************
            writer.WriteLine("  call    MOT_ROT");
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
            Moway.Simulator.Outputs.Direction simLeftWheelDirection = Moway.Simulator.Outputs.Direction.Forward;
            Moway.Simulator.Outputs.Direction simRightWheelDirection = Moway.Simulator.Outputs.Direction.Forward;
            byte simLeftWheelSpeed;
            byte simRightWheelSpeed;
            byte simRotateSpeed;
            decimal tempAngle;

            //***************** Save the value of the speed    *****************
            if (rotateVariable == null)
                simRotateSpeed = (byte)rotateValue;
            else
                simRotateSpeed = mowayModel.GetRegister(this.rotateVariable.Name).Value;

            //***************** Assign the value of the speed to each wheel   *****************
            if (rotateMode == RotateMode.Center)
            {
                // Rotation on the center of the robot
                if (rotateSide == Side.Right)
                {
                    simLeftWheelDirection = Moway.Simulator.Outputs.Direction.Forward;
                    simLeftWheelSpeed = simRotateSpeed;
                    simRightWheelDirection = Moway.Simulator.Outputs.Direction.Backward;
                    simRightWheelSpeed = simRotateSpeed;
                }
                else
                {
                    simLeftWheelDirection = Moway.Simulator.Outputs.Direction.Backward;
                    simLeftWheelSpeed = simRotateSpeed;
                    simRightWheelDirection = Moway.Simulator.Outputs.Direction.Forward;
                    simRightWheelSpeed = simRotateSpeed;
                }
            }
            else
            {
                // Rotation on a robot wheel
                if (rotateWheel == Side.Right)
                {
                    simLeftWheelSpeed = simRotateSpeed;
                    simRightWheelSpeed = 0;
                    if (rotateDirection == Direction.Forward)
                        simLeftWheelDirection = Moway.Simulator.Outputs.Direction.Forward;
                    else
                        simLeftWheelDirection = Moway.Simulator.Outputs.Direction.Backward;
                }
                else
                {
                    simLeftWheelSpeed = 0;
                    simRightWheelSpeed = simRotateSpeed;
                    if (rotateDirection == Direction.Forward)
                        simRightWheelDirection = Moway.Simulator.Outputs.Direction.Forward;
                    else
                        simRightWheelDirection = Moway.Simulator.Outputs.Direction.Backward;

                }
            }
                        
            mowayModel.Movement.UpdateMovement(simLeftWheelDirection, simLeftWheelSpeed, simRightWheelDirection, simRightWheelSpeed);

            //***************** Time or Angle  *****************
            if (flowchartControl == FlowchartControl.FinishTime)
            {               
                if (this.timeVariable == null)
                    System.Threading.Thread.Sleep((int)(this.timeValue * 1000));
                else
                    // Time variable: 0 - 255 hundredths of a second
                    System.Threading.Thread.Sleep((int)(mowayModel.GetRegister(this.timeVariable.Name).Value * 100));
                
                // mOway stops
                mowayModel.Movement.UpdateMovement(simLeftWheelDirection, 0, simRightWheelDirection, 0);
            }
            else if (flowchartControl == FlowchartControl.FinishAngle)
            {
                // Ensure that at least one of the wheels is in motion
                if (simLeftWheelSpeed == 0 && simRightWheelSpeed == 0)
                    return;
               
                else
                {
                    // Spinning on a wheel
                    if (angleVariable == null)
                        // Conversion: rotated angle -distance traveled
                        //***DEBUG
                        
                        tempAngle = mowayModel.Movement.Angle + angleValue;

                    else
                        //Variable: conversion from 0 - 360º to 0 - 100
                        //***DEBUG
                        
                    tempAngle = mowayModel.Movement.Angle + mowayModel.GetRegister(angleVariable.Name).Value;

                    
                    while (mowayModel.Movement.Angle < tempAngle);
                }

                // mOway stops
                mowayModel.Movement.UpdateMovement(simLeftWheelDirection, 0, simRightWheelDirection, 0);
            }
            else if (flowchartControl == FlowchartControl.Continuously)
            { }

            ////*****************   Wait until it ends    *****************

        }
    }
}
