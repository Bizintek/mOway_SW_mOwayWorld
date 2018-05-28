using System;
using System.Collections.Generic;
using System.Text;

using AForge.Video.DirectShow;

namespace Moway.Camera
{
    public class Camera
    {
        #region Attributes

        /// <summary>
        /// Indicates the status of the camera
        /// </summary>
        private bool cameraOn = false;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether the camera is on or not
        /// </summary>
        public bool CameraOn { get { return this.cameraOn; } }

        #endregion

        #region Implementation of the Singleton pattern

        private static Camera instance = null;

        public static Camera GetCamera()
        {
            if (instance == null)
                instance = new Camera();
            return instance;
        }

        #endregion

        private Camera() { }

        #region Public methods

        /// <summary>
        /// Indicates whether the camera is on or not
        /// </summary>
        /// <returns>List of detected video devices</returns>
        public FilterInfoCollection GetDevices()
        {            
            FilterInfoCollection videoDevices;
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count == 0)                          
                return null;                
            else
                return videoDevices;            
        }

        /// <summary>
        /// Returns the default camera(to be able to initially visualize the mOway's directly)
        /// </summary>
        /// <returns></returns>
        public string GetDefaultDevice()
        {
            return "proof";
        }

        /// <summary>
        /// Launches a specific camera starts to visualize the images
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public bool PlayCamera(string camera)
        {
            this.cameraOn = true;
            return true;
        }

        /// <summary>
        /// Stop the camera you are currently viewing
        /// </summary>
        /// <returns></returns>
        public bool StopCamera()
        {            
            this.cameraOn = false;
            return true;
        }

        /// <summary>
        /// Save in a jpg the image that is being displayed at this moment
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Capture(string path, string name)
        {
            return true;
        }

        #endregion
    }
}
