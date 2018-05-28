using System;
using System.Collections.Generic;

using Moway.Simulator.Outputs;
using Moway.Simulator.Sensors;
using Moway.Simulator.Communications;
using Moway.Simulator.Expansion;
using Moway.Simulator.Registers;

namespace Moway.Simulator
{
    /// <summary>
    /// Possible states for digital actuators
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public enum DigitalState { On, Off, NoChange }

    /// <summary>
    /// Represents the Moway model to simulate
    /// </summary>
    public class MowayModel
    {
        #region Constants
        public const decimal MAX_LINE_WHITE = 20;
        public const decimal MIN_LINE_BLACK = 230;
        public const decimal MIN_OBSTACLE = 1;
        //***ADDED
        public const decimal MIN_NOISE = 1;
        public const decimal MIN_TAP = 1;
        #endregion

        #region Attributes

        /// <summary>
        /// Movement Module
        /// </summary>
        private Movement movement = new Movement();
        /// <summary>
        /// Light Module
        /// </summary>
        private Lights lights = new Lights();
        /// <summary>
        /// Sound module
        /// </summary>
        private Sound sound = new Sound();
        /// <summary>
        /// Battery Level
        /// </summary>
        private byte batteryLevel = 0;
        /// <summary>
        /// Line sensors
        /// </summary>
        private LineSensors lineSensors = new LineSensors();
        /// <summary>
        /// Obstacle Sensors
        /// </summary>
        private ObstacleSensors obstacleSensors = new ObstacleSensors();
        /// <summary>
        /// Temperature
        /// </summary>
        private decimal temperature = 0;
        /// <summary>
        /// Brihgtness
        /// </summary>
        private byte brightness = 0;
        /// <summary>
        /// Noise Level
        /// </summary>
        private byte noiseLevel = 0;
        /// <summary>
        /// Accelerometer
        /// </summary>
        private Accelerometer accelerometer = new Accelerometer();
        /// <summary>
        /// Communication of mOway
        /// </summary>
        private Communication communication = new Communication();
        /// <summary>
        /// Expansion module of mOway
        /// </summary>
        private IoExpansion ioExpansion = new IoExpansion();
        /// <summary>
        /// Registers defined in the model
        /// </summary>
        private SortedList<string, Register> registers = new SortedList<string, Register>();

        #endregion

        #region Properties

        /// <summary>
        /// Movement Module
        /// </summary>
        public Movement Movement { get { return this.movement; } }
        /// <summary>
        /// Light Module
        /// </summary>
        public Lights Lights { get { return this.lights; } }
        /// <summary>
        /// Sound module
        /// </summary>
        public Sound Sound { get { return this.sound; } }
        /// <summary>
        /// Battery Level
        /// </summary>
        public byte BatteryLevel { get { return this.batteryLevel; } }
        /// <summary>
        /// Line sensors
        /// </summary>
        public LineSensors LineSensors { get { return this.lineSensors; } }
        /// <summary>
        /// Obstacle Sensors
        /// </summary>
        public ObstacleSensors ObstacleSensors { get { return this.obstacleSensors; } }
        /// <summary>
        /// Temperature
        /// </summary>
        public decimal Temperature { get { return this.temperature; } }
        /// <summary>
        /// Brihgtness
        /// </summary>
        public byte Brightness { get { return this.brightness; } }
        /// <summary>
        /// Noise Level
        /// </summary>
        public byte NoiseLevel { get { return this.noiseLevel; } }
        /// <summary>
        /// Accelerometer
        /// </summary>
        public Accelerometer Accelerometer { get { return this.accelerometer; } }
        /// <summary>
        /// Communication of mOway
        /// </summary>
        public Communication Communication { get { return this.communication; } }
        /// <summary>
        /// Expansion module of mOway
        /// </summary>
        public IoExpansion IoExpansion { get { return this.ioExpansion; } }
        /// <summary>
        /// Registers defined in the model
        /// </summary>
        public List<Register> Registers
        {
            get
            {
                List<Register> temp = new List<Register>();
                foreach (Register register in this.registers.Values)
                    temp.Add(register);
                return temp;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// New register added
        /// </summary>
        public event RegisterEventHandler RegisterAdded;
        /// <summary>
        /// Register Removed
        /// </summary>
        public event RegisterEventHandler RegisterRemoved;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public MowayModel() { }

        #region Public methods

        /// <summary>
        /// Model simulation Start
        /// </summary>
        public void StartSimulation()
        {
            this.movement.EnableDistanceControl();
        }

        /// <summary>
        /// Pause in Model simulation
        /// </summary>
        public void PauseSimulation()
        {
            this.movement.DisableDistanceControl();
        }

        /// <summary>
        /// Reset the Moway model
        /// </summary>
        public void ResetSimulation()
        {
            this.movement.Reset();
            this.lights.Reset();
            this.sound.Reset();
            this.communication.Reset();
            this.ioExpansion.Reset();
        }

        #endregion

        #region Public methods of updating sensors

        /// <summary>
        /// Update the simulated MOway Battery Level
        /// </summary>
        /// <param name="batteryLevel">Battery Level</param>
        public void UpdateBatteryLevel(byte batteryLevel)
        {
            this.batteryLevel = batteryLevel;
        }

        /// <summary>
        /// Updates the value of the outside temperature for the simulated MOway
        /// </summary>
        /// <param name="temperature">Temperature Value</param>
        public void UpdateTemperature(decimal temperature)
        {
            this.temperature = temperature;
        }

        /// <summary>
        /// Updates the value of the external Brihgtness for the simulated MOway
        /// </summary>
        /// <param name="brightness"></param>
        public void UpdateBrightness(byte brightness)
        {
                this.brightness = brightness;
        }

        /// <summary>
        /// Update the external Noise Level for the simulated MOway
        /// </summary>
        /// <param name="noiseLevel">Outside noise level</param>
        public void UpdateNoiseLevel(byte noiseLevel)
        {
            this.noiseLevel = noiseLevel;
        }

        #endregion

        #region Public methods of updating registers

        /// <summary>
        /// Loads a list of registers in the model
        /// </summary>
        /// <param name="registers">List of registers</param>
        public void LoadRegisters(List<Register> registers)
        {
            foreach (Register register in registers)
                this.registers.Add(register.Name, register);
        }

        /// <summary>
        /// Gets an identifier register by name
        /// </summary>
        /// <param name="name">Register Name</param>
        /// <returns>Register requested, NULL in case of non-existence</returns>
        public Register GetRegister(string name)
        {
            return this.registers[name];
        }

        /// <summary>
        /// Add a new register to the list of registers
        /// </summary>
        /// <param name="register">Register to add</param>
        public void AddRegister(Register register)
        {
            if (this.registers.Keys.Contains(register.Name))
                throw new SimulatorException("This register is already defined in mOway model");
            this.registers.Add(register.Name, register);
            if (this.RegisterAdded != null)
                this.RegisterAdded(this, new RegisterEventArgs(register));
        }

        /// <summary>
        /// Rename a register
        /// </summary>
        /// <param name="prevName">Register name</param>
        /// <param name="newName">New register name</param>
        public void RenameRegister(string prevName, string newName)
        {
            Register register = this.registers[prevName];
            this.registers.Remove(prevName);
            register.Name = newName;
            this.registers.Add(register.Name, register);
        }

        /// <summary>
        /// Delete a register identified by its name
        /// </summary>
        /// <param name="name">Register name</param>
        public void RemoveRegister(string name)
        {
            if (!this.registers.Keys.Contains(name))
                throw new SimulatorException("This register isn't defined in mOway model");
            Register register = this.registers[name];
            this.registers.Remove(name);
            if (this.RegisterRemoved != null)
                this.RegisterRemoved(this, new RegisterEventArgs(register));
        }

        #endregion
    }
}
