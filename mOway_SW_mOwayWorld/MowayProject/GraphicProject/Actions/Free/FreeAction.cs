using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Free
{
    public class FreeAction : Module
    {
        #region Attributes

        private Variable leftSpeedVariable = null;
        private int leftSpeedValue = 50;
        private Direction leftDirection = Direction.Forward;
        private Variable rightSpeedVariable = null;
        private int rightSpeedValue = 50;
        private Direction rightDirection= Direction.Forward;
        private FlowchartControl flowchartControl = FlowchartControl.Continuously;
        private Variable timeVariable = null;
        private decimal timeValue = 0.1M;
        private Variable distanceVariable = null;
        private decimal distanceValue = 0.17M;
        private bool waitFinish = false;

        #endregion

        #region Properties

        public Variable LeftSpeedVariable { get { return this.leftSpeedVariable; } }
        public int LeftSpeedValue { get { return this.leftSpeedValue; } }
        public Direction LeftDirection { get { return this.leftDirection; } }
        public Variable RightSpeedVariable { get { return this.rightSpeedVariable; } }
        public int RightSpeedValue { get { return this.rightSpeedValue; } }
        public Direction RightDirection { get { return this.rightDirection; } }
        public FlowchartControl FlowchartControl { get { return this.flowchartControl; } }
        public Variable TimeVariable { get { return this.timeVariable; } }
        public decimal TimeValue { get { return this.timeValue; } }
        public Variable DistanceVariable { get { return this.distanceVariable; } }
        public decimal DistanceValue { get { return this.distanceValue; } }
        public bool WaitFinish { get { return this.waitFinish; } }

        #endregion

        public FreeAction(string key)
        {
            this.key = key;

        }

         public FreeAction(string key, Variable leftSpeedVariable, int leftSpeedValue, Direction leftDirection, Variable rightSpeedVariable, int rightSpeedValue, Direction rightDirection, FlowchartControl flowchartControl, Variable timeVariable, decimal timeValue, Variable distanceVariable, decimal distanceValue, bool waitFinish)
        {
            this.key = key;
            this.leftSpeedVariable = leftSpeedVariable;
            this.leftSpeedValue = leftSpeedValue;
            this.leftDirection = leftDirection;
            this.rightSpeedVariable = rightSpeedVariable;
            this.rightSpeedValue = rightSpeedValue;
            this.rightDirection = rightDirection;
            this.flowchartControl = flowchartControl;
            this.timeVariable = timeVariable;
            this.timeValue = timeValue;
            this.distanceVariable = distanceVariable;
            this.distanceValue = distanceValue;
            this.waitFinish = waitFinish;
        }

         public FreeAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                    case "leftSpeedVariable":
                        if (property.InnerText != "none")
                            this.leftSpeedVariable = variables[property.InnerText];
                        break;
                    case "leftSpeedValue":
                        this.leftSpeedValue = System.Convert.ToInt32(property.InnerText);
                        break;
                    case "leftDirection":
                        this.leftDirection = (Direction)Enum.Parse(typeof(Direction), property.InnerText);
                        break;
                    case "rightSpeedVariable":
                        if (property.InnerText != "none")
                            this.rightSpeedVariable = variables[property.InnerText];
                        break;
                    case "rightSpeedValue":
                        this.rightSpeedValue = System.Convert.ToInt32(property.InnerText);
                        break;
                    case "rightDirection":
                        this.rightDirection = (Direction)Enum.Parse(typeof(Direction), property.InnerText);
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

        public void UpdateSettings(Variable leftSpeedVariable, int leftSpeedValue, Direction leftDirection, Variable rightSpeedVariable, int rightSpeedValue, Direction rightDirection, FlowchartControl flowchartControl, Variable timeVariable, decimal timeValue, Variable distanceVariable, decimal distanceValue, bool waitFinish)
        {
            this.leftSpeedVariable = leftSpeedVariable;
            this.leftSpeedValue = leftSpeedValue;
            this.leftDirection = leftDirection;
            this.rightSpeedVariable = rightSpeedVariable;
            this.rightSpeedValue = rightSpeedValue;
            this.rightDirection = rightDirection;
            this.flowchartControl = flowchartControl;
            this.timeVariable = timeVariable;
            this.timeValue = timeValue;
            this.distanceVariable = distanceVariable;
            this.distanceValue = distanceValue;
            this.waitFinish = waitFinish;
        }

        public override bool VariableUsed(Variable variable)
        {
            if ((this.leftSpeedVariable == variable) || (this.rightSpeedVariable == variable) || (this.timeVariable == variable) || (this.distanceVariable == variable))
                return true;
            else
                return false;
        }

        public override Element Clone()
        {
            return new FreeAction(this.key, this.leftSpeedVariable, this.leftSpeedValue, this.leftDirection, this.rightSpeedVariable, this.rightSpeedValue, this.rightDirection, this.flowchartControl, this.timeVariable, this.timeValue, this.distanceVariable, this.distanceValue, this.waitFinish);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            if (this.leftSpeedVariable == null)
                file.WriteElementString("leftSpeedVariable", "none");
            else
                file.WriteElementString("leftSpeedVariable", this.leftSpeedVariable.Name);
            file.WriteElementString("leftSpeedValue", this.leftSpeedValue.ToString());
            file.WriteElementString("leftDirection", this.leftDirection.ToString());
            if (this.rightSpeedVariable == null)
                file.WriteElementString("rightSpeedVariable", "none");
            else
                file.WriteElementString("rightSpeedVariable", this.rightSpeedVariable.Name);
            file.WriteElementString("rightSpeedValue", this.rightSpeedValue.ToString());
            file.WriteElementString("rightDirection", this.rightDirection.ToString());
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
            writer.WriteLine(";************Module FreeAction*******************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");

            if (leftSpeedVariable == rightSpeedVariable && leftSpeedValue == rightSpeedValue && leftDirection == rightDirection)
            {
                //***********************************[Speed]***********************************
                if (this.leftSpeedVariable == null)
                    writer.WriteLine("  movlw   ." + leftSpeedValue);
                else
                    writer.WriteLine("  movf   " + this.leftSpeedVariable.Name + ",W");
                writer.WriteLine("  movwf   MOT_VEL");

                //*****************************[Time or Distance]********************************
                if (flowchartControl == FlowchartControl.FinishTime)
                {
                    writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                    if (timeVariable == null)
                        writer.WriteLine("  movlw   ." + (byte)(this.timeValue * 10));
                    else
                        writer.WriteLine("  movf   " + this.timeVariable.Name + ",W");
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
                //*********************************[Diretion]*************************************
                if (leftDirection == Direction.Forward)
                    writer.WriteLine("  bsf     MOT_CON,FWDBACK");
                else
                    writer.WriteLine("  bcf     MOT_CON,FWDBACK");
                //*********************************[Function]***************************************
                writer.WriteLine("  call    MOT_STR");
            }
            else
            {
                if (leftSpeedVariable == null && rightSpeedValue == 0)
                {
                    writer.WriteLine(";*************************[Right motor]********************************");
                    //*****************************[ Speed ]***************************************
                    if (rightSpeedVariable == null)
                        writer.WriteLine("  movlw   ." + rightSpeedValue);
                    else
                        writer.WriteLine("  movf   " + rightSpeedVariable.Name + ",W");
                    writer.WriteLine("  movwf   MOT_VEL");
                    //*****************************[Time or Distance]********************************
                    if (this.flowchartControl == FlowchartControl.FinishTime)
                    {
                        writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                        if (timeVariable == null)
                            writer.WriteLine("  movlw   ." + (byte)(timeValue * 10));
                        else
                            writer.WriteLine("  movf   " + timeVariable.Name + ",W");
                    }
                    else if (this.flowchartControl == FlowchartControl.FinishDistance)
                    {
                        writer.WriteLine("  bcf     MOT_CON,COMTYPE");
                        if (distanceVariable == null)                           
                            writer.WriteLine("  movlw   ." + (byte)(distanceValue * 10));
                        else
                            writer.WriteLine("  movf   " + distanceVariable.Name + ",W");
                    }
                    else
                    {
                        writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                        writer.WriteLine("  movlw   .0");
                    }
                    writer.WriteLine("  movwf   MOT_T_DIST_ANG");
                    //*********************************[Direction]*************************************
                    if (rightDirection == Direction.Forward)
                        writer.WriteLine("  bsf     MOT_CON,FWDBACK");
                    else
                        writer.WriteLine("  bcf     MOT_CON,FWDBACK");
                    //*********************************[Function]***************************************
                    writer.WriteLine("  bsf     MOT_CON,RL");
                    writer.WriteLine("  call    MOT_CHA_VEL");

                    writer.WriteLine(";*************************[Left motor]******************************");
                    //*****************************[ Speed ]***************************************
                    if (leftSpeedVariable == null)
                        writer.WriteLine("  movlw   ." + leftSpeedValue);
                    else
                        writer.WriteLine("  movf   " + leftSpeedVariable.Name + ",W");
                    writer.WriteLine("  movwf   MOT_VEL");
                    //*****************************[Time or Distance]********************************
                    if (this.flowchartControl == FlowchartControl.FinishTime)
                    {
                        writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                        if (timeVariable == null)
                            writer.WriteLine("  movlw   ." + (byte)(timeValue * 10));
                        else
                            writer.WriteLine("  movf   " + timeVariable.Name + ",W");
                    }
                    else if (this.flowchartControl == FlowchartControl.FinishDistance)
                    {
                        writer.WriteLine("  bcf     MOT_CON,COMTYPE");
                        if (distanceVariable == null)
                            writer.WriteLine("  movlw   ." + (byte)(distanceValue * 10));
                        else
                            writer.WriteLine("  movf   " + distanceVariable.Name + ",W");
                    }
                    else
                    {
                        writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                        writer.WriteLine("  movlw   .0");
                    }
                    writer.WriteLine("  movwf   MOT_T_DIST_ANG");
                    //*********************************[Direction]*************************************
                    if (leftDirection == Direction.Forward)
                        writer.WriteLine("  bsf     MOT_CON,FWDBACK");
                    else
                        writer.WriteLine("  bcf     MOT_CON,FWDBACK");
                    //*********************************[Function]***************************************
                    writer.WriteLine("  bcf     MOT_CON,RL");
                    writer.WriteLine("  call    MOT_CHA_VEL");


                }
                else
                {



                    writer.WriteLine(";*************************[Left motor]******************************");
                    //*****************************[ Speed ]***************************************
                    if (leftSpeedVariable == null)
                        writer.WriteLine("  movlw   ." + leftSpeedValue);
                    else
                        writer.WriteLine("  movf   " + leftSpeedVariable.Name + ",W");
                    writer.WriteLine("  movwf   MOT_VEL");
                    //*****************************[Time or Distance]********************************
                    if (this.flowchartControl == FlowchartControl.FinishTime)
                    {
                        writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                        if (timeVariable == null)
                            writer.WriteLine("  movlw   ." + (byte)(timeValue * 10));
                        else
                            writer.WriteLine("  movf   " + timeVariable.Name + ",W");
                    }
                    else if (this.flowchartControl == FlowchartControl.FinishDistance)
                    {
                        writer.WriteLine("  bcf     MOT_CON,COMTYPE");
                        if (distanceVariable == null)
                            writer.WriteLine("  movlw   ." + (byte)(distanceValue * 10));
                        else
                            writer.WriteLine("  movf   " + distanceVariable.Name + ",W");
                    }
                    else
                    {
                        writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                        writer.WriteLine("  movlw   .0");
                    }
                    writer.WriteLine("  movwf   MOT_T_DIST_ANG");
                    //*********************************[Direction]*************************************
                    if (leftDirection == Direction.Forward)
                        writer.WriteLine("  bsf     MOT_CON,FWDBACK");
                    else
                        writer.WriteLine("  bcf     MOT_CON,FWDBACK");
                    //*********************************[Function]***************************************
                    writer.WriteLine("  bcf     MOT_CON,RL");
                    writer.WriteLine("  call    MOT_CHA_VEL");

                    writer.WriteLine(";*************************[Right motor]********************************");
                    //*****************************[ Speed ]***************************************
                    if (rightSpeedVariable == null)
                        writer.WriteLine("  movlw   ." + rightSpeedValue);
                    else
                        writer.WriteLine("  movf   " + rightSpeedVariable.Name + ",W");
                    writer.WriteLine("  movwf   MOT_VEL");
                    //*****************************[Time or Distance]********************************
                    if (this.flowchartControl == FlowchartControl.FinishTime)
                    {
                        writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                        if (timeVariable == null)
                            writer.WriteLine("  movlw   ." + (byte)(timeValue * 10));
                        else
                            writer.WriteLine("  movf   " + timeVariable.Name + ",W");
                    }
                    else if (this.flowchartControl == FlowchartControl.FinishDistance)
                    {
                        writer.WriteLine("  bcf     MOT_CON,COMTYPE");
                        if (distanceVariable == null)
                            writer.WriteLine("  movlw   ." + (byte)(distanceValue * 10));
                        else
                            writer.WriteLine("  movf   " + distanceVariable.Name + ",W");
                    }
                    else
                    {
                        writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                        writer.WriteLine("  movlw   .0");
                    }
                    writer.WriteLine("  movwf   MOT_T_DIST_ANG");
                    //*********************************[Direction]*************************************
                    if (rightDirection == Direction.Forward)
                        writer.WriteLine("  bsf     MOT_CON,FWDBACK");
                    else
                        writer.WriteLine("  bcf     MOT_CON,FWDBACK");
                    //*********************************[Function]***************************************
                    writer.WriteLine("  bsf     MOT_CON,RL");
                    writer.WriteLine("  call    MOT_CHA_VEL");
                }
            }
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
            byte simLeftWheelSpeed;
            byte simRightWheelSpeed;
            decimal tempDistance;
            Moway.Simulator.Outputs.Direction simLeftWheelDirection;
            Moway.Simulator.Outputs.Direction simRightWheelDirection;

            // Save speed in speed simulation variable
            if (leftSpeedVariable == null)
                simLeftWheelSpeed = (byte)leftSpeedValue;
            else
                simLeftWheelSpeed = mowayModel.GetRegister(leftSpeedVariable.Name).Value;

            if (rightSpeedVariable == null)
                simRightWheelSpeed = (byte)rightSpeedValue;
            else
                simRightWheelSpeed = mowayModel.GetRegister(rightSpeedVariable.Name).Value;

            // Save steering wheel in steering simulation variable
            if (leftDirection == Direction.Forward)
                simLeftWheelDirection = Moway.Simulator.Outputs.Direction.Forward;
            else
                simLeftWheelDirection = Moway.Simulator.Outputs.Direction.Backward;

            if (rightDirection == Direction.Forward)
                simRightWheelDirection = Moway.Simulator.Outputs.Direction.Forward;
            else
                simRightWheelDirection = Moway.Simulator.Outputs.Direction.Backward;

            // Assign variables to the simulation model
            mowayModel.Movement.UpdateMovement(simLeftWheelDirection, simLeftWheelSpeed, simRightWheelDirection, simRightWheelSpeed);

            // If you choose to execute by time, pause the thread said time
            if (flowchartControl == FlowchartControl.FinishTime)
            {
                if (this.timeVariable == null)
                    System.Threading.Thread.Sleep((int)(this.timeValue * 1000));
                else
                    System.Threading.Thread.Sleep((int)(mowayModel.GetRegister(this.timeVariable.Name).Value * 100));

                // mOway stops
                mowayModel.Movement.UpdateMovement(simLeftWheelDirection, 0, simRightWheelDirection, 0);
            }
            // If you choose to run by distance, compare the distance traveled simulated
            else if (flowchartControl == FlowchartControl.FinishDistance)
            {
                if (simLeftWheelSpeed == 0 && simRightWheelSpeed == 0)
                    return;

                if (DistanceVariable == null)
                    tempDistance = mowayModel.Movement.Distance + distanceValue;
                else
                    tempDistance = mowayModel.Movement.Distance + mowayModel.GetRegister(distanceVariable.Name).Value / 10;

                while (mowayModel.Movement.Distance < tempDistance);

                // mOway stops
                mowayModel.Movement.UpdateMovement(simLeftWheelDirection, 0, simRightWheelDirection, 0);
            }
            else if (flowchartControl == FlowchartControl.Continuously)
            { }

            //*************************[Wait until it ends]******************************
            if (this.waitFinish)
            { }
        }
    }
}
