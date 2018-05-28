using System;
using System.IO;
using System.Collections.Generic;

using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Free
{
    public class FreeAction : Module
    {
        #region Atributos

        private Variable leftVariable = null;
        private int leftSpeedValue = 50;
        private Direction leftDirection = Direction.Forward;
        private Variable rightVariable = null;
        private int rightSpeedValue = 50;
        private Direction rightDirection= Direction.Forward;
        private FlowchartControl flowchartControl = FlowchartControl.Continuously;
        private Variable timeVariable = null;
        private decimal timeValue = 0.1M;
        private Variable distanceVariable = null;
        private decimal distanceValue = 0.17M;
        private bool waitFinish = false;

        #endregion

        #region Propiedades

        public Variable LeftSpeedVariable { get { return this.leftVariable; } }
        public int LeftSpeedValue { get { return this.leftSpeedValue; } }
        public Direction LeftDirection { get { return this.leftDirection; } }
        public Variable RightSpeedVariable { get { return this.rightVariable; } }
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

        public void UpdateProperties(Variable leftSpeedVariable, int leftSpeedValue, Direction leftDirection, Variable rightSpeedVariable, int rightSpeedValue, Direction rightDirection, FlowchartControl flowchartControl, Variable timeVariable, decimal timeValue, Variable distanceVariable, decimal distanceValue, bool waitFinish)
        {
            this.leftVariable = leftSpeedVariable;
            this.leftSpeedValue = leftSpeedValue;
            this.leftDirection = leftDirection;
            this.rightVariable = rightSpeedVariable;
            this.rightSpeedValue = rightSpeedValue;
            this.rightDirection = rightDirection;
            this.flowchartControl = flowchartControl;
            this.timeVariable = timeVariable;
            this.timeValue = timeValue;
            this.distanceVariable = distanceVariable;
            this.distanceValue = distanceValue;
            this.waitFinish = waitFinish;
        }

        public override void WriteCode(StreamWriter writer)
        {

            //*****************************[Cabecera módulo]************************************
            writer.WriteLine(";************Module FreeAction*******************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");

            if (leftVariable == rightVariable && leftSpeedValue == rightSpeedValue && leftDirection == rightDirection)
            {
                //***********************************[Velocidad]***********************************
                if (leftSpeedValue != null)
                    writer.WriteLine("  movlw   ." + leftSpeedValue);
                else
                    writer.WriteLine("  movf   " + leftSpeedVariable + ",W");
                writer.WriteLine("  movwf   MOT_VEL");

                //*****************************[Tiempo o distancia]********************************
                if (flowchartControl == FlowchartControl.Time)
                {
                    writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                    if (timeVariable == null)
                        writer.WriteLine("  movlw   ." + timeValue);
                    else
                        writer.WriteLine("  movf   " + timeVariable + ",W");
                }
                else if (flowchartControl == FlowchartControl.Distance)
                {
                    writer.WriteLine("  bcf     MOT_CON,COMTYPE");
                    if (distanceVariable == null)
                        writer.WriteLine("  movlw   ." + distanceValue);
                    else
                        writer.WriteLine("  movf   " + distanceVariable + ",W");
                }
                else if (flowchartControl == FlowchartControl.Continously)
                {
                    writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                    writer.WriteLine("  movlw   .0");
                }
                writer.WriteLine("  movwf   MOT_T_DIST_ANG");
                //*********************************[Dirección]*************************************
                if (leftDirection == Direction.Forward)
                    writer.WriteLine("  bsf     MOT_CON,FWDBACK");
                else
                    writer.WriteLine("  bcf     MOT_CON,FWDBACK");
                //*********************************[Función]***************************************
                writer.WriteLine("  call    MOT_STR");
            }
            else
            {
                if (leftVariable == null && rightSpeedValue == 0)
                {
                    writer.WriteLine(";*************************[Motor izquierdo]******************************");
                    //*****************************[ Velocidad ]***************************************
                    if (leftVariable == "constant")
                        writer.WriteLine("  movlw   ." + leftSpeedValue);
                    else
                        writer.WriteLine("  movf   " + leftVariable + ",W");
                    writer.WriteLine("  movwf   MOT_VEL");
                    //*****************************[Tiempo o distancia]********************************
                    if (timeEnabled == true)
                    {
                        writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                        if (timeVariable == "constant")
                            writer.WriteLine("  movlw   ." + timeValue);
                        else
                            writer.WriteLine("  movf   " + timeVariable + ",W");
                    }
                    else if (distanceEnabled == true)
                    {
                        writer.WriteLine("  bcf     MOT_CON,COMTYPE");
                        if (distanceVariable == "constant")
                            writer.WriteLine("  movlw   ." + distanceValue);
                        else
                            writer.WriteLine("  movf   " + distanceVariable + ",W");
                    }
                    else
                    {
                        writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                        writer.WriteLine("  movlw   .0");
                    }
                    writer.WriteLine("  movwf   MOT_T_DIST_ANG");
                    //*********************************[Dirección]*************************************
                    if (leftDirection == MoveDirection.Front)
                        writer.WriteLine("  bsf     MOT_CON,FWDBACK");
                    else
                        writer.WriteLine("  bcf     MOT_CON,FWDBACK");
                    //*********************************[Función]***************************************
                    writer.WriteLine("  bcf     MOT_CON,RL");
                    writer.WriteLine("  call    MOT_CHA_VEL");






                    writer.WriteLine(";*************************[Motor derecho]********************************");
                    //*****************************[ Velocidad ]***************************************
                    if (rightVariable == "constant")
                        writer.WriteLine("  movlw   ." + rightSpeedValue);
                    else
                        writer.WriteLine("  movf   " + rightVariable + ",W");
                    writer.WriteLine("  movwf   MOT_VEL");
                    //*****************************[Tiempo o distancia]********************************
                    if (timeEnabled == true)
                    {
                        writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                        if (timeVariable == "constant")
                            writer.WriteLine("  movlw   ." + timeValue);
                        else
                            writer.WriteLine("  movf   " + timeVariable + ",W");
                    }
                    else if (distanceEnabled == true)
                    {
                        writer.WriteLine("  bcf     MOT_CON,COMTYPE");
                        if (distanceVariable == "constant")
                            writer.WriteLine("  movlw   ." + distanceValue);
                        else
                            writer.WriteLine("  movf   " + distanceVariable + ",W");
                    }
                    else
                    {
                        writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                        writer.WriteLine("  movlw   .0");
                    }
                    writer.WriteLine("  movwf   MOT_T_DIST_ANG");
                    //*********************************[Dirección]*************************************
                    if (rightDirection == MoveDirection.Front)
                        writer.WriteLine("  bsf     MOT_CON,FWDBACK");
                    else
                        writer.WriteLine("  bcf     MOT_CON,FWDBACK");
                    //*********************************[Función]***************************************
                    writer.WriteLine("  bsf     MOT_CON,RL");
                    writer.WriteLine("  call    MOT_CHA_VEL");



                }
                else
                {

                    writer.WriteLine(";*************************[Motor derecho]********************************");
                    //*****************************[ Velocidad ]***************************************
                    if (rightVariable == "constant")
                        writer.WriteLine("  movlw   ." + rightSpeedValue);
                    else
                        writer.WriteLine("  movf   " + rightVariable + ",W");
                    writer.WriteLine("  movwf   MOT_VEL");
                    //*****************************[Tiempo o distancia]********************************
                    if (timeEnabled == true)
                    {
                        writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                        if (timeVariable == "constant")
                            writer.WriteLine("  movlw   ." + timeValue);
                        else
                            writer.WriteLine("  movf   " + timeVariable + ",W");
                    }
                    else if (distanceEnabled == true)
                    {
                        writer.WriteLine("  bcf     MOT_CON,COMTYPE");
                        if (distanceVariable == "constant")
                            writer.WriteLine("  movlw   ." + distanceValue);
                        else
                            writer.WriteLine("  movf   " + distanceVariable + ",W");
                    }
                    else
                    {
                        writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                        writer.WriteLine("  movlw   .0");
                    }
                    writer.WriteLine("  movwf   MOT_T_DIST_ANG");
                    //*********************************[Dirección]*************************************
                    if (rightDirection == MoveDirection.Front)
                        writer.WriteLine("  bsf     MOT_CON,FWDBACK");
                    else
                        writer.WriteLine("  bcf     MOT_CON,FWDBACK");
                    //*********************************[Función]***************************************
                    writer.WriteLine("  bsf     MOT_CON,RL");
                    writer.WriteLine("  call    MOT_CHA_VEL");

                    writer.WriteLine(";*************************[Motor izquierdo]******************************");
                    //*****************************[ Velocidad ]***************************************
                    if (leftVariable == "constant")
                        writer.WriteLine("  movlw   ." + leftSpeedValue);
                    else
                        writer.WriteLine("  movf   " + leftVariable + ",W");
                    writer.WriteLine("  movwf   MOT_VEL");
                    //*****************************[Tiempo o distancia]********************************
                    if (timeEnabled == true)
                    {
                        writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                        if (timeVariable == "constant")
                            writer.WriteLine("  movlw   ." + timeValue);
                        else
                            writer.WriteLine("  movf   " + timeVariable + ",W");
                    }
                    else if (distanceEnabled == true)
                    {
                        writer.WriteLine("  bcf     MOT_CON,COMTYPE");
                        if (distanceVariable == "constant")
                            writer.WriteLine("  movlw   ." + distanceValue);
                        else
                            writer.WriteLine("  movf   " + distanceVariable + ",W");
                    }
                    else
                    {
                        writer.WriteLine("  bsf     MOT_CON,COMTYPE");
                        writer.WriteLine("  movlw   .0");
                    }
                    writer.WriteLine("  movwf   MOT_T_DIST_ANG");
                    //*********************************[Dirección]*************************************
                    if (leftDirection == MoveDirection.Front)
                        writer.WriteLine("  bsf     MOT_CON,FWDBACK");
                    else
                        writer.WriteLine("  bcf     MOT_CON,FWDBACK");
                    //*********************************[Función]***************************************
                    writer.WriteLine("  bcf     MOT_CON,RL");
                    writer.WriteLine("  call    MOT_CHA_VEL");
                }
            }
            //*************************[Espera hasta que termina]******************************
            if (flowchartControl != FlowchartControl.Continously)
            {
                writer.WriteLine("  call    MOT_CHECK_END");
            }
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }
    }
}
