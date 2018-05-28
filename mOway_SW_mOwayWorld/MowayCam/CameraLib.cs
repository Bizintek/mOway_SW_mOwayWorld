using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;

using AForge.Video;
using AForge.Video.DirectShow;


namespace Moway.Camera
{
    public partial class CameraLib
    {
        //// statistics for camera
        //private const int statLength = 15;
        //private int statIndex = 0;
        //private int statReady = 0;
        //private int[] statCount = new int[statLength];
        //System.Drawing.Bitmap current = new System.Drawing.Bitmap(10, 10);
        //private string device = null;
        //private ResourceManager messages;

       

        //// Video device
        //public string VideoDevice
        //{
        //    get { return device; }
        //}

        //// Open video source
        //private void OpenVideoSource(IVideoSource source)
        //{
            //// stop current video source
            //videoSourcePlayer1.SignalToStop();
            //videoSourcePlayer1.WaitForStop();

            //// start new video source
            //videoSourcePlayer1.VideoSource = source;
            //videoSourcePlayer1.Start();

            //// reset statistics
            //statIndex = statReady = 0;

            ////// start timer
            ////timer.Start();
        //}


        ///// <summary>
        ///// When Start button clicked, the user selects the video source.
        ///// The video sources are displayed on a list.
        ///// Once selected, the video capture starts.       
        ///// </summary>
        //private void botActivar_Click(object sender, EventArgs e)
        //{
        //    bool Videocap = false;
        //    byte i = 0;
        //    byte VideocapIndex = 0;
        //    FilterInfoCollection videoDevices;


        //    // enumerate video devices
        //    videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

        //    if (videoDevices.Count == 0)
        //    {
        //        MessageBox.Show("No se ha detectado ningún dispositivo de vídeo.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    else
        //    {
        //        // Detect all devices connected
        //        foreach (FilterInfo device in videoDevices)
        //        {
        //            // Case of other drivers are installed
        //            if (device.Name == "Moway Videocap" || device.Name == "USB2.0 ATV" || device.Name == "STK1160 Grabber")
        //            {
        //                Videocap = true;
        //                VideocapIndex = i;
        //            }
        //            i++;
        //        }
        //        if (Videocap == true)
        //        {
        //            device = videoDevices[VideocapIndex].MonikerString;

        //            // create video source
        //            VideoCaptureDevice videoSource = new VideoCaptureDevice(this.VideoDevice);

        //            // open it
        //            OpenVideoSource(videoSource);

        //            // Enable "Save" and "Stop" buttons
        //            CamOnControls();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Moway Videocap no detectada. Otros dispositivos de vídeo detectados:", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        //            // DEBUG: detect other cameras
        //            VideoCaptureDeviceForm form = new VideoCaptureDeviceForm();

        //            if (form.ShowDialog(this) == DialogResult.OK)
        //            {
        //                // create video source
        //                VideoCaptureDevice videoSource = new VideoCaptureDevice(form.VideoDevice);

        //                // open it
        //                OpenVideoSource(videoSource);

        //                // Enable "Save" and "Stop" buttons
        //                CamOnControls();
        //            }
        //        }
        //        return;
        //    }
        //}

        ///// <summary>
        ///// Enables camera control buttons
        ///// </summary>
        //private void CamOnControls()
        //{
        //    botActivar.Enabled = false;
        //    botParar.Enabled = true;
        //    botGuardar.Enabled = true;
        //}

        ///// <summary>
        ///// Enables camera start buttons
        ///// </summary>
        //private void CamOffControls()
        //{
        //    botActivar.Enabled = true;
        //    botParar.Enabled = false;
        //    botGuardar.Enabled = false;
        //}

        ///// <summary>
        ///// When Stop button is clicked, the video stops.
        ///// </summary>
        //private void botParar_Click(object sender, EventArgs e)
        //{
        //    CamOffControls();
        //    if (videoSourcePlayer1.VideoSource != null)
        //    {
        //        videoSourcePlayer1.SignalToStop();
        //        videoSourcePlayer1.WaitForStop();
        //    }
        //}

        ///// <summary>
        ///// When Save button is clicked, the current video frame is saved in a file.
        ///// Both path and name can be chosen on the MowayCam form.
        ///// If that path doesn't exists, it will be created.
        ///// If the file name exists, it will be overwriten.
        ///// 
        ///// </summary>
        //private void botGuardar_Click_1(object sender, EventArgs e)
        //{
        //    if (videoSourcePlayer1.VideoSource != null)
        //    {
        //        current = videoSourcePlayer1.GetCurrentVideoFrame();

        //        string filePath = textGuardarPath.Text;
        //        if (!System.IO.Directory.Exists(filePath))
        //        {
        //            System.IO.DirectoryInfo OutputDir = System.IO.Directory.CreateDirectory(filePath);
        //        }
        //        string fileName = System.IO.Path.Combine(filePath, textNombre.Text);

        //        if (System.IO.File.Exists(fileName))
        //        {
        //            System.IO.File.Delete(fileName);
        //        }
        //        try
        //        {
        //            current.Save(fileName);
        //            MessageBox.Show("Imagen guardada.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        catch
        //        {
        //            MessageBox.Show("ERROR. La imagen no ha sido guardada:\r\n- El dispositivo de vídeo no ha iniciado todavía.\r\n- La ruta es inválida.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        ///// <summary>
        ///// When MowayCam form is closed, the video stops.
        ///// </summary>
        //private void Main_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    if (videoSourcePlayer1.VideoSource != null)
        //    {
        //        videoSourcePlayer1.SignalToStop();
        //        videoSourcePlayer1.WaitForStop();
        //    }
        //    Application.ExitThread();
        //    Application.Exit();
        //}
    }
}
