using System;
using System.Windows.Forms;

namespace Moway.Simulator.Outputs
{
    /// <summary>
    /// Address of the movements
    /// </summary>
    public enum Direction { Forward, Backward }

    /// <summary>
    /// It represents the moves module of the simulated MOway
    /// </summary>
    /// <LastRevision>25.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class Movement
    {
        #region Constants

        /// <summary>
        /// Timer interval for distance control
        /// </summary>
        private const int TIMER_DISTANCE_INTERVAL = 100;        //100 milliseconds

        #endregion

        #region Attributes

        /// <summary>
        /// Left wheel direction
        /// </summary>
        private Direction leftWheelDirection = Direction.Forward;
        /// <summary>
        /// Wheel speed Left
        /// </summary>
        private byte leftWheelSpeed = 0;
        /// <summary>
        /// Right Wheel direction
        /// </summary>
        private Direction rightWheelDirection = Direction.Forward;
        /// <summary>
        /// Wheel speed Right
        /// </summary>
        private byte rightWheelSpeed = 0;
        /// <summary>
        /// Distance traveled
        /// </summary>
        private decimal distance = 0;
        /// <summary>
        /// Angle Travel
        /// </summary>
        private decimal angle = 0;
        /// <summary>
        /// Thread for distance control and angle travel
        /// </summary>
        private System.Threading.Thread controlThread;
        private bool controlThreadStop = false;

        #endregion

        #region Properties

        /// <summary>
        /// Left wheel direction
        /// </summary>
        public Direction LeftWheelDirection { get { return this.leftWheelDirection; } }
        /// <summary>
        /// Wheel speed Left
        /// </summary>
        public byte LeftWheelSpeed { get { return this.leftWheelSpeed; } }
        /// <summary>
        /// Right Wheel direction
        /// </summary>
        public Direction RightWheelDirection { get { return this.rightWheelDirection; } }
        /// <summary>
        /// Wheel speed Right
        /// </summary>
        public byte RightWheelSpeed { get { return this.rightWheelSpeed; } }
        /// <summary>
        ///Distance traveled
        /// </summary>
        public decimal Distance { get { return this.distance; } }
        /// <summary>
        /// Angle Travel
        /// </summary>
        public decimal Angle { get { return this.angle; } }

        #endregion

        #region Events

        /// <summary>
        /// Event of change in the movement of the MOway
        /// </summary>
        public event EventHandler MovementChanged;
        /// <summary>
        /// Event of Change in the value of the distance traveled
        /// </summary>
        public event EventHandler DistanceChanged;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        internal Movement() { }

        #region Public methods

        /// <summary>
        /// Update the MOway movement
        /// </summary>
        /// <param name="leftWheelDirection">Left wheel direction</param>
        /// <param name="leftWheelSpeed">Wheel speed Left</param>
        /// <param name="rightWheelDirection">Right Wheel direction</param>
        /// <param name="rightWheelSpeed">Wheel speed Right</param>
        public void UpdateMovement(Direction leftWheelDirection, byte leftWheelSpeed, Direction rightWheelDirection, byte rightWheelSpeed)
        {
            if ((this.leftWheelDirection != leftWheelDirection) || (this.leftWheelSpeed != leftWheelSpeed) || (this.rightWheelDirection != rightWheelDirection) || (this.rightWheelSpeed != rightWheelSpeed))
            {
                this.leftWheelDirection = leftWheelDirection;
                this.leftWheelSpeed = leftWheelSpeed;
                this.rightWheelDirection = rightWheelDirection;
                this.rightWheelSpeed = rightWheelSpeed;
                if (this.MovementChanged != null)
                    this.MovementChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Updates the value of the distance
        /// </summary>
        /// <param name="distance">Distance traveled</param>
        public void UpdateDistance(decimal distance)
        {
            if (this.distance != distance)
            {
                this.distance = distance;
                if (this.DistanceChanged != null)
                    this.DistanceChanged(this, new EventArgs());
            }
        }

        //***ADDED
        /// <summary>
        /// Reset the value of the distance traveled
        /// </summary>        
        public void ResetDistance()
        {
            if (this.distance != 0)
            {
                this.distance = 0;
                if (this.DistanceChanged != null)
                    this.DistanceChanged(this, new EventArgs());
            }
        }

        //***ADDED
        /// <summary>
        /// Reset the value of the travel angle
        /// </summary>        
        public void ResetAngle()
        {
            if (this.angle != 0)            
                this.angle = 0;                            
        }

        #endregion

        #region Internal methods

        /// <summary>
        /// Enables MOway distance control
        /// </summary>
        internal void EnableDistanceControl()
        {
            this.controlThread = new System.Threading.Thread(new System.Threading.ThreadStart(this.ControlManager));
            this.controlThreadStop = false;
            this.controlThread.Start();
        }

        /// <summary>
        /// Disables MOway distance control
        /// </summary>
        internal void DisableDistanceControl()
        {
            lock (this.controlThread)
            {
                this.controlThreadStop = true;
            }
        }

        /// <summary>
        /// Reset the MOway motion module
        /// </summary>
        internal void Reset()
        {
            if ((this.leftWheelSpeed != 0) || (this.rightWheelSpeed != 0))
            {
                this.leftWheelSpeed = 0;
                this.rightWheelSpeed = 0;
                if (this.MovementChanged != null)
                    this.MovementChanged(this, new EventArgs());
            }
            if (this.distance != 0)
            {
                this.distance = 0;
                if (this.DistanceChanged != null)
                    this.DistanceChanged(this, new EventArgs());
            }
            if (this.angle != 0)            
                this.angle = 0;                            
        }

        #endregion

        #region Private methods para el control de la distancia

        /// <summary>
        /// Manages the distance traveled by the MOway
        /// </summary>
        private void ControlManager()
        {
            //***ADDED
            int tempLeftWheelSpeed;
            int tempRightWheelSpeed;
            decimal tempSpeed = 0;
            decimal tempAngle = 0;

            while (true)
            {
                System.Threading.Thread.Sleep(TIMER_DISTANCE_INTERVAL);
                lock (this.controlThread)
                {
                    if (this.controlThreadStop)
                        break;

                    // Average wheel speeds
                    tempLeftWheelSpeed = this.leftWheelSpeed;
                    tempRightWheelSpeed = this.rightWheelSpeed;

                    if (this.leftWheelDirection == Direction.Backward)
                        tempLeftWheelSpeed = 0 - tempLeftWheelSpeed;

                    if (this.rightWheelDirection == Direction.Backward)
                        tempRightWheelSpeed = 0 - tempRightWheelSpeed;

                    tempSpeed = (tempLeftWheelSpeed + tempRightWheelSpeed) / 2;
                    tempSpeed = Math.Abs(tempSpeed);

                    // Adjust the speed value. The speed of mOway is not linear.

                    if (tempLeftWheelSpeed == 0 && tempRightWheelSpeed == 0)
                    {
                        tempSpeed = 0;
                        tempAngle = 0;
                    }


                    //**************** Conversion for the Rotate block
                    // Rotation over the center
                    else if (tempLeftWheelSpeed == -tempRightWheelSpeed)
                    {
                        // The robot does not advance
                        tempSpeed = 0;

                        if (Math.Abs(tempLeftWheelSpeed) > 90 && Math.Abs(tempLeftWheelSpeed) <= 100)
                            tempAngle = 26.7M;
                        else if (Math.Abs(tempLeftWheelSpeed) > 80 && Math.Abs(tempLeftWheelSpeed) <= 90)
                            tempAngle = 25.3M;
                        else if (Math.Abs(tempLeftWheelSpeed) > 70 && Math.Abs(tempLeftWheelSpeed) <= 80)
                            tempAngle = 23.8M;
                        else if (Math.Abs(tempLeftWheelSpeed) > 60 && Math.Abs(tempLeftWheelSpeed) <= 70)
                            tempAngle = 22.7M;
                        else if (Math.Abs(tempLeftWheelSpeed) > 50 && Math.Abs(tempLeftWheelSpeed) <= 60)
                            tempAngle = 21.4M;
                        else if (Math.Abs(tempLeftWheelSpeed) > 40 && Math.Abs(tempLeftWheelSpeed) <= 50)
                            tempAngle = 20.1M;
                        else if (Math.Abs(tempLeftWheelSpeed) > 30 && Math.Abs(tempLeftWheelSpeed) <= 40)
                            tempAngle = 19.0M;
                        else if (Math.Abs(tempLeftWheelSpeed) > 20 && Math.Abs(tempLeftWheelSpeed) <= 30)
                            tempAngle = 17.9M;
                        else if (Math.Abs(tempLeftWheelSpeed) > 10 && Math.Abs(tempLeftWheelSpeed) <= 20)
                            tempAngle = 17.3M;
                        else if (Math.Abs(tempLeftWheelSpeed) > 0 && Math.Abs(tempLeftWheelSpeed) <= 10)
                            tempAngle = 16.8M;
                    }

                    // Rotation on a wheel
                    else if (tempLeftWheelSpeed == 0 || tempRightWheelSpeed == 0)
                    {
                        // Forward Assignment
                        if (tempSpeed > 90 && tempSpeed <= 100)
                            tempSpeed = 8.5M;
                        else if (tempSpeed > 80 && tempSpeed <= 90)
                            tempSpeed = 8;
                        else if (tempSpeed > 70 && tempSpeed <= 80)
                            tempSpeed = 7.5M;
                        else if (tempSpeed > 60 && tempSpeed <= 70)
                            tempSpeed = 7;
                        else if (tempSpeed > 50 && tempSpeed <= 60)
                            tempSpeed = 6.5M;
                        else if (tempSpeed > 30 && tempSpeed <= 50)
                            tempSpeed = 6;
                        else if (tempSpeed > 20 && tempSpeed <= 30)
                            tempSpeed = 5.5M;
                        else if (tempSpeed > 0 && tempSpeed <= 20)
                            tempSpeed = 5;

                        // Rotation assignment
                        if (tempSpeed > 90 && tempSpeed <= 100)
                            tempAngle = 14.1M;
                        else if (tempSpeed > 80 && tempSpeed <= 90)
                            tempAngle = 13.0M;
                        else if (tempSpeed > 70 && tempSpeed <= 80)
                            tempAngle = 12.3M;
                        else if (tempSpeed > 60 && tempSpeed <= 70)
                            tempAngle = 11.6M;
                        else if (tempSpeed > 50 && tempSpeed <= 60)
                            tempAngle = 10.9M;
                        else if (tempSpeed > 40 && tempSpeed <= 50)
                            tempAngle = 10.3M;
                        else if (tempSpeed > 30 && tempSpeed <= 40)
                            tempAngle = 9.8M;
                        else if (tempSpeed > 20 && tempSpeed <= 30)
                            tempAngle = 9.4M;
                        else if (tempSpeed > 10 && tempSpeed <= 20)
                            tempAngle = 8.8M;
                        else if (tempSpeed > 0 && tempSpeed <= 10)
                            tempAngle = 8.4M;
                    }

                    // Conversion of Wheels speed ("Straight" and "Turn" blocks)
                    else if ((this.leftWheelDirection == this.rightWheelDirection) /* && (this.leftWheelSpeed == this.rightWheelSpeed)*/)
                    {
                        if (tempSpeed > 90 && tempSpeed <= 100)
                            tempSpeed = 17;
                        else if (tempSpeed > 80 && tempSpeed <= 90)
                            tempSpeed = 16;
                        else if (tempSpeed > 70 && tempSpeed <= 80)
                            tempSpeed = 15;
                        else if (tempSpeed > 60 && tempSpeed <= 70)
                            tempSpeed = 14;
                        else if (tempSpeed > 50 && tempSpeed <= 60)
                            tempSpeed = 13;
                        else if (tempSpeed > 30 && tempSpeed <= 50)
                            tempSpeed = 12;
                        else if (tempSpeed > 20 && tempSpeed <= 30)
                            tempSpeed = 11;
                        else if (tempSpeed > 0 && tempSpeed <= 20)
                            tempSpeed = 10;
                    }                  


                   
                    //***DEBUG
                    //lock (this.distance)
                    //{
                    this.distance += tempSpeed * 0.1M;
                    this.angle += tempAngle;
                    //}

                    if (this.DistanceChanged != null)
                        this.DistanceChanged(this, new EventArgs());
                }
            }
        }

        #endregion
    }
}
