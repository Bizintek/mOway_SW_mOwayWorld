using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;        // StreamReader, StreamWriter

using Moway.Template;
using Moway.Template.Controls;
using Moway.Server.Processes;

namespace Moway.Server
{
    public partial class ServerPanel : SharePanel
    {
        #region Constants
        const byte SIZE_OF_LINE = 43;
        const int SSID_LINE = 4302;
        const int SSID_POSITION = 24;
        const int IP_LINE = 4349;
        const int IP_POSITION = 30;
        const int FINAL_LINE = 4911;
        const int DEC_TO_CHAR = 48;
        const int DEC_TO_HEX = 55;
        #endregion

        #region Variales

        // Files to generate the HEX file
        string webFile1 = Application.StartupPath + "\\MowayWebServer.hex";
        string webFile2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MowayWorld\\MowayWebServer2.hex";

        // Buffers to save the characters to modify from the HEX file
        char[] bfrChksm = { '0', '0' };
        char[] bfrSSID = { '0', '0' };
        char[] bfrIP = { '0', '0' };

        decimal ssid1, ssid2, ssid3;

        #endregion

        #region Properties

        /// <summary>
        /// Title of the form
        /// </summary>
        public override string Tittle { get { return ServerMessages.TITTLE; } }
        /// <summary>
        /// Short title for the form
        /// </summary>
        public override string ShortTittle { get { return ServerMessages.SHORT_TITTLE; } }

        #endregion


        public ServerPanel()
        {
            InitializeComponent();
        }

        public override bool CloseBox()
        {
            return true;
        }

        /// <summary>
        /// Launches to Default Web server with Moway server IP       
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLaunchWeb_Click(object sender, EventArgs e)
        {           
            try
            { 
                System.Diagnostics.Process.Start("http://169.254.3." + nudIp.Value.ToString());
            }
            catch
            {
                MowayMessageBox.Show(ServerMessages.BROWSER_ERROR, ServerMessages.TITTLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Update the name of the network MowayNet shown on the panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NudIp_ValueChanged(object sender, EventArgs e)
        {
            string strTempIp = "";

            if (nudIp.Value.ToString().Length == 1)
                strTempIp = "00" + nudIp.Value.ToString();

            else if (nudIp.Value.ToString().Length == 2)
                strTempIp = "0" + nudIp.Value.ToString();

            else
                strTempIp = nudIp.Value.ToString();

            this.labMowayNetNumber.Text = strTempIp;
        }


        /// <summary>
        /// Program the Moway with the generated HEX file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BProgram_Click(object sender, EventArgs e)
        {
            // Generate HEX File
            GenerateHex();                       
       
            // Programm Moway                                 
            ProgramProcessForm programProcessForm = new ProgramProcessForm(webFile2);
            programProcessForm.ShowDialog();                       
        }


        #region Auxiliary Functions

        /// <summary>
        /// Generates the HEX file with the IP selected from the original.        
        /// </summary>        
        private void GenerateHex()
        {
            string strTemp;
            char[] bfrTemp = new char[SIZE_OF_LINE];

            StreamReader reader = new StreamReader(webFile1);
            StreamWriter writer = new StreamWriter(webFile2);

            //*****************************************************************************************
            //  Modify the SSID of the network
            //*****************************************************************************************
            // Copy original HEX to the line where the SSID is defined
            for (int i = 1; i < SSID_LINE; i++)
            {
                strTemp = reader.ReadLine();
                writer.WriteLine(strTemp);
            }

            // Save the SSID line in a temporary buffer
            reader.ReadBlock(bfrTemp, 0, SIZE_OF_LINE);

            // Convert the value of selected SSID in hexadecimal and save it in the buffer to write
            ssid1 = decimal.Truncate(nudIp.Value / 100);
            ssid2 = decimal.Truncate(nudIp.Value / 10) - (10 * ssid1);
            ssid3 = nudIp.Value - (100 * ssid1) - (10 * ssid2);

            bfrTemp[SSID_POSITION - 4] = Convert.ToChar(Convert.ToInt32(ssid1) + DEC_TO_CHAR);
            bfrTemp[SSID_POSITION - 2] = Convert.ToChar(Convert.ToInt32(ssid2) + DEC_TO_CHAR);
            bfrTemp[SSID_POSITION] = Convert.ToChar(Convert.ToInt32(ssid3) + DEC_TO_CHAR);


            // Calculate checksum and save it in the buffer to write
            bfrChksm = GenerateChecksum(bfrTemp);
            bfrTemp[SIZE_OF_LINE - 2] = bfrChksm[0];
            bfrTemp[SIZE_OF_LINE - 1] = bfrChksm[1];

            // Write a line of the SSID modified
            writer.Write(bfrTemp);


            //*****************************************************************************************
            //  Changed IP web server
            //*****************************************************************************************
            // Continue copying the original HEX to the line where the IP is defined
            for (int i = SSID_LINE + 1; i < IP_LINE + 1; i++)
            {
                strTemp = reader.ReadLine();
                writer.WriteLine(strTemp);
            }

            // Save the IP line to a temporary buffer
            reader.ReadBlock(bfrTemp, 0, SIZE_OF_LINE);

            // Convert the selected IP value to hexadecimal and save it to the buffer to write
            bfrIP = Int2Hex(Convert.ToInt32(nudIp.Value));
            bfrTemp[IP_POSITION - 1] = bfrIP[0];
            bfrTemp[IP_POSITION] = bfrIP[1];

            // Calculate checksum and save it in the buffer to write
            bfrChksm = GenerateChecksum(bfrTemp);
            bfrTemp[SIZE_OF_LINE - 2] = bfrChksm[0];
            bfrTemp[SIZE_OF_LINE - 1] = bfrChksm[1];

            // Write a line of the modified IP
            writer.Write(bfrTemp);

            // Finish copying the original HEX file
            for (int i = IP_LINE + 2; i <= FINAL_LINE; i++)
            {
                strTemp = reader.ReadLine();
                writer.WriteLine(strTemp);
            }

            // Close files
            writer.Close();
            reader.Close();
        }

        /// <summary>
        /// Converts a decimal number to hexadecimal.         
        /// </summary>
        /// <param name="number"></param>        
        private char[] Int2Hex(int number)
        {
            char[] bfrRet = { '0', '0' };
            int tmpVal1;
            int tmpVal2;

            tmpVal1 = Convert.ToInt32(number / 16);
            tmpVal2 = number - tmpVal1 * 16; ;

            if (tmpVal1 == 16)
                tmpVal1 = 0;
            if (tmpVal1 > 9)
                bfrRet[0] = Convert.ToChar(tmpVal1 + DEC_TO_HEX);
            else
                bfrRet[0] = Convert.ToChar(tmpVal1 + DEC_TO_CHAR);

            if (tmpVal2 == 16)
                tmpVal2 = 0;
            if (tmpVal2 > 9)
                bfrRet[1] = Convert.ToChar(tmpVal2 + DEC_TO_HEX);
            else
                bfrRet[1] = Convert.ToChar(tmpVal2 + DEC_TO_CHAR);

            return bfrRet;
        }


        /// <summary>
        /// Converts a hexadecimal number to a decimal.
        /// </summary>
        /// <param name="number"></param>
        private int Hex2Dec(char number)
        {
            int ret = 0;          
        
            if (number >= '0' && number <= '9')            
                ret = number - DEC_TO_CHAR;
              
            else if (number >= 'A' && number <= 'F')            
                ret = number - DEC_TO_HEX;          
            
            return ret;
        }

        /// <summary>
        /// Generates the checksum of a HEX file line
        /// </summary>
        /// <param name="number"></param>
        private char[] GenerateChecksum(char[] line)
        {
            int intChksm1 = 0;
            int intChksm2 = 0;            
            int intTemp = 0;            
            char[] ret = { '0', '0' };

            //Sum of the elements between ': ' and the checksum
            for (int i = 1; i < SIZE_OF_LINE - 3; i++)
            {
                intChksm1 = Hex2Dec(line[i]);
                intChksm2 = Hex2Dec(line[++i]);
                intTemp = intTemp + ((intChksm1 * 16) + intChksm2);
            }

            // Calculation of the rest of the sum to 256
            intTemp %= 256;

            // Subtraction of the resulting remainder with 256
            intTemp = 256 - intTemp;

            // Converting to hexadecimal
            ret = Int2Hex(intTemp);
            
            return ret;
        }

        #endregion
    }
}
