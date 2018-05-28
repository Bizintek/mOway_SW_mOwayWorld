using System;
using System.IO;
using System.Windows.Forms;

using lib_prog_mow2;

namespace Moway.Controller
{
    public class Controller
    {
        #region Constants

        private const int BATTERY_INTERVAL = 500;
        private const int MOWAYGUI_PROCESS_INDICATOR_SUCCESS = 101;
        private const int MOWAYGUI_PROCESS_INDICATOR_ERROR_VER = 106;
        private const int MOWAYGUI_PROCESS_INDICATOR_ERROR_PRO = 105;
        private const int MOWAYGUI_PROCESS_INDICATOR_NO_MEMORY = 201;

        private const long HEX_MAX_SIZE_201 = 182763;
        private const long HEX_MAX_SIZE_202 = 365526;

        #endregion

        #region Attributes

        private bool mowayConnected = false;
        private bool mowayPrograming = false;
        /// <summary>
        /// Firmware version of the connected robot
        /// </summary>
        private string firmware;
        private int battery;

        private Timer timer = new Timer();
        private BziprogManager2 bziprog;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether the Moway is connected or not
        /// </summary>
        public bool MowayAttached { get { return this.mowayConnected; } }
        /// <summary>
        /// Firmware version of the connected robot
        /// </summary>
        public string Firmware
        {
            get
            {
                if (!this.mowayConnected)
                    throw new ControllerException("Moway disconnected");
                else
                    return this.firmware;
            }
        }
        /// <summary>
        /// Battery level of the robot
        /// </summary>
        public int Battery
        {
            get
            {
                if (!this.mowayConnected)
                    throw new ControllerException("Moway disconnected");
                else
                    return this.battery;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// It is launched when it is detected that the Moway has been connectedy
        /// </summary>
        public event ControllerEventHandler MowayConnected;
        /// <summary>
        /// It is launched when it is detected that the Moway is disconnected
        /// </summary>
        public event EventHandler MowayDisconnected;
        /// <summary>
        /// It is launched every time the battery level changes 5% or simply when it reaches 100% or when it drops below 10%
        /// </summary>
        public event BatteryEventHandler BatteryChanged;
        /// <summary>
        /// It launches at the end of the programming of the moway
        /// </summary>
        public event EventHandler ProgrammingCompleted;
        /// <summary>
        /// It is launched in case there is an error in the Moway programming
        /// </summary>
        public event EventHandler ProgrammingCanceled;
        /// <summary>
        /// It is released every 5%, for example, of the programming that is taken from the Moway
        /// </summary>
        public event ProgressEventHandler ProgrammingProgress;

        #endregion

        #region Implementation of the Singleton pattern

        private static Controller instance = null;

        public static Controller GetController()
        {
            if (instance == null)
                instance = new Controller();
            return instance;
        }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        private Controller()
        {
            bziprog = new BziprogManager2();
            this.bziprog.Progress += new NewProgram2ProgressEventHandler(bziprog_Progress);

        //**ADDED: Check the memory of Moway
            this.NoMemoryProg();

            //the timer is set            
            this.timer.Interval = BATTERY_INTERVAL;

            this.timer.Tick += new EventHandler(Timer_Tick);       
            this.timer.Enabled = true;
        }

        #region Events

        void bziprog_Progress(int progress)
        {            
            if (progress == MOWAYGUI_PROCESS_INDICATOR_SUCCESS)
            {
                this.mowayPrograming = false; 
                if (this.ProgrammingCompleted != null)
                    this.ProgrammingCompleted(this, new EventArgs());                              
            }
            else if (progress == MOWAYGUI_PROCESS_INDICATOR_NO_MEMORY)
            {
                this.mowayPrograming = false;
                this.NoMemoryProg();
            }
            else if (progress > MOWAYGUI_PROCESS_INDICATOR_SUCCESS)
            {
                this.mowayPrograming = false;
                if (this.ProgrammingCanceled != null)
                    this.ProgrammingCanceled(this, new EventArgs());
            }
            else
                if (this.ProgrammingProgress != null)
                    this.ProgrammingProgress(this, new ProgressEventArgs(progress));
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            if (!this.mowayPrograming)
                if (this.bziprog.deviceAttached == true && !this.ProgIsRunning())
                {
                    this.bziprog.UpdateBatFirm();
                    if (!this.mowayConnected)
                    {
                        this.mowayConnected = true;
                        this.firmware = this.FormatFirmware(this.bziprog.get_mOwFirm());
                        this.battery = this.bziprog.get_mOwBat();
                        if (this.MowayConnected != null)
                            this.MowayConnected(this, new ControllerEventArgs(this.firmware, this.battery));
                    }
                    if (this.bziprog.get_mOwBat() != this.battery)
                    {
                        this.battery = this.bziprog.get_mOwBat();
                        if (this.BatteryChanged != null)
                            this.BatteryChanged(this, new BatteryEventArgs(this.battery));
                    }
                }
                else if ((this.bziprog.deviceAttached == false) && (this.mowayConnected))
                {
                    this.mowayConnected = false;
                    this.firmware = "";
                    this.battery = 0;
                    if (this.MowayDisconnected != null)
                        this.MowayDisconnected(this, new EventArgs());
                }
        }

        #endregion

        #region Public functions

        /// <summary>
        /// Download a program in the connected robot
        /// </summary>
        /// <param name="hexPath">Path of the.HEX file with the program code</param>
        public void ProgramMoway(string hexPath)
        {
            if (!File.Exists(hexPath))
                throw new ControllerException("File not found");
            if (!this.bziprog.deviceAttached)
                throw new ControllerException("Moway disconnected");
            if (this.ProgIsRunning())
                throw new ControllerException("Moway busy");
            this.bziprog.Prog(hexPath);
            this.mowayPrograming = true;
        }

        /// <summary>
        /// ????
        /// </summary>
        /// <returns></returns>
        public bool ProgIsRunning()
        {
            if (this.bziprog.bootloaderState != 0xFF)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Check if the PIC has enough memory for the.hex file
        /// Returns "0" if the memory is sufficient, "1" if version 2.0.1 is not enough and "2" if version 2.0.2 is not enough.
        /// </summary>
        public int CheckPicMemory(string hex_name)
        {
            if (!this.mowayConnected)
                throw new ControllerException("Moway disconnected");
            FileInfo hexFile = new FileInfo(hex_name);

            if (this.firmware == "2.0.1")
            {
                // Check estimated memory of HEX file for PIC 18f86
                if (hexFile.Length >= HEX_MAX_SIZE_201)
                    return 1;
            }
            else if (this.firmware == "2.0.2")
                // Check estimated memory of HEX file for PIC 18f87
                if (hexFile.Length >= HEX_MAX_SIZE_202)
                    return 2;
            return 0;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Check if the memory of the Moway microcontroller has been started correctly.
        /// </summary>
        private void NoMemoryProg()
        {
            if (!this.bziprog.CheckMemoAlloc())
            {
                MessageBox.Show(ControllerMessages.MOWAY_COMMUNICATION_ERROR, ControllerMessages.COMMUNICATION_ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(5);
            }
        }

        private string FormatFirmware(int firmware)
        {
            string temp = firmware.ToString();
            string text = "" + temp[0];
            for (int i = 1; i < temp.Length; i++)
                text += "." + temp[i];
            return text;
        }

        #endregion
    }
}
