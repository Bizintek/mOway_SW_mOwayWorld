using System;
using System.Drawing;
using System.Windows.Forms;

using Moway.Template;
using Moway.Template.Controls;

using AForge.Video;
using AForge.Video.DirectShow;

namespace Moway.Camera
{
    public partial class CameraPanel : SharePanel
    {
        #region Camera Variables

        // Video devices
        FilterInfoCollection detectedDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);                
        VideoCaptureDevice videoSource = new VideoCaptureDevice();

        // Statistics for camera
        private const int statLength = 15;
        private int statIndex = 0;
        public int statReady = 0;
        private int[] statCount = new int[statLength];
        System.Drawing.Bitmap current = new System.Drawing.Bitmap(10, 10);
        private string device = null;
        private int capture_cont = 1;

        #endregion

        #region Attributes

        /// <summary>
        /// Object representing the camera
        /// </summary>
        private Camera camera = Camera.GetCamera();

        #endregion

        #region Properties

        /// <summary>
        /// Title for the form
        /// </summary>
        public override string Tittle { get { return CameraMessages.TITTLE; } }
        /// <summary>
        /// Short title for the form
        /// </summary>
        public override string ShortTittle { get { return CameraMessages.SHORT_TITTLE; } }

        #endregion

        public CameraPanel()
        {
            InitializeComponent();
        }

        #region Form Events

        /// <summary>
        /// Occurs in the form load.
        /// Update the camera list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CameraPanel_Load(object sender, EventArgs e)
        {           
            this.RefreshDevices();            
        }

        /// <summary>
        /// Update the camera list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BRefresh_Click(object sender, EventArgs e)
        {
            if (this.camera.CameraOn)
                this.camera.StopCamera();
            this.RefreshDevices();                      
        }


        /// <summary>
        /// Starts capturing the selected camera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BPlay_Click(object sender, EventArgs e)
        {                                   
            if (this.StartCameraPanel())
            {
                this.camera.PlayCamera("");
                this.bPlay.Enabled = false;
                this.bStop.Enabled = true;
                this.bRefresh.Enabled = false;
                this.cbDevice.Enabled = false;
                this.bCapture.Enabled = true;
                this.bBrowser.Enabled = true;
                this.tbName.Enabled = true;
                this.cbAutoincremental.Enabled = true;

                this.pbCamera.Visible = false;
                this.videoSourcePlayer1.Visible = true;
            }
            else
                MowayMessageBox.Show(CameraMessages.ERROR_PLAY_CAMERA, CameraMessages.CAMERA, MessageBoxButtons.OK, MessageBoxIcon.Error);

         
            return;           
        }


        /// <summary>
        /// Stops capturing the selected camera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BStop_Click(object sender, EventArgs e)
        {
            this.StopCameraPanel();
            this.camera.StopCamera();            
        }

        /// <summary>
        /// Saves the current image captured with the camera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCapture_Click(object sender, EventArgs e)
        {
            if (this.CaptureImage(this.tbLocation.Text, this.tbName.Text))
            {
                if (this.cbAutoincremental.Checked)
                {
                    this.capture_cont++;
                    tbName.Text = "Capture" + this.capture_cont.ToString() + ".jpg";
                }
            }
            else
                MowayMessageBox.Show(CameraMessages.ERROR_CAPTURE, CameraMessages.CAMERA, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        /// <summary>
        /// Captures an image and saves it to disk
        /// </summary>
        /// <param name="location"></param>
        /// <param name="name"></param>
        private bool CaptureImage(string location, string name)
        {
            if (videoSourcePlayer1.VideoSource != null)
            {
                current = videoSourcePlayer1.GetCurrentVideoFrame();

                string filePath = location;
                if (!System.IO.Directory.Exists(filePath))
                {
                    System.IO.DirectoryInfo OutputDir = System.IO.Directory.CreateDirectory(filePath);
                }
                string fileName = System.IO.Path.Combine(location, name);

                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }
                try
                {
                    current.Save(fileName);                    
                    return true;
                }
                catch
                {                    
                    return false;
                }
            }
            else
                return false;
        }

        /// <summary>
        /// Lets you select the destination folder gives the captured images
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BBrowser_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialog.ShowDialog())
                this.tbLocation.Text = folderBrowserDialog.SelectedPath;
        }

        #endregion

        #region Public methods

        public override bool CloseBox()
        {
            if (this.camera.CameraOn)
                if (!this.camera.StopCamera())
                    return false;
            this.StopCameraPanel();
            return true;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Update the list of detected cameras
        /// </summary>
        private void RefreshDevices()
        {            
            this.cbDevice.Items.Clear();
            detectedDevices = this.camera.GetDevices();

            //The cameras registered in the system are loaded into the CbCameras
            if (detectedDevices != null)
            {
                foreach (FilterInfo device in detectedDevices)                
                    this.cbDevice.Items.Add(device.Name);                                    
            }
            else
                MowayMessageBox.Show(CameraMessages.CAMERA_NOT_FOUND + "\r\n", CameraMessages.SHORT_TITTLE, MessageBoxButtons.OK, MessageBoxIcon.Error);           
                                
            
            if (this.cbDevice.Items.Count != 0)
            {                
                this.cbDevice.SelectedItem = this.cbDevice.Items[0];
                this.bPlay.Enabled = true;
            }
            else
                this.bPlay.Enabled = false;
        }


        #endregion

        #region Methods added


        /// <summary>
        /// Activates the camera viewer
        /// </summary>
        private bool StartCameraPanel()
        {
            try
            {
                // Select video device
                this.device = detectedDevices[this.cbDevice.SelectedIndex].MonikerString;

                // create video source            
                VideoCaptureDevice videoSource = new VideoCaptureDevice(this.device);

                // stop current video source
                videoSourcePlayer1.SignalToStop();
                videoSourcePlayer1.WaitForStop();

                // start new video source
                videoSourcePlayer1.VideoSource = videoSource;
                videoSourcePlayer1.Start();

                // reset statistics
                statIndex = statReady = 0;

                // start timer
                camTimer.Start();

                return true;
            }

            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Stops the camera viewer
        /// </summary>
        private void StopCameraPanel()
        {
            if (videoSourcePlayer1.VideoSource != null)
            {
                videoSourcePlayer1.SignalToStop();
                videoSourcePlayer1.WaitForStop();
            }

            this.bPlay.Enabled = true;
            this.bStop.Enabled = false;
            this.bRefresh.Enabled = true;
            this.cbDevice.Enabled = true;
            this.bCapture.Enabled = false;
            this.bBrowser.Enabled = false;
            this.tbName.Enabled = false;
            this.cbAutoincremental.Enabled = false;

            this.pbCamera.Visible = true;
            this.videoSourcePlayer1.Visible = false;       
        }

                
        #endregion
    }
}
