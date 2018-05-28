using System;

using SdlDotNet.Graphics;

namespace Moway.Project.GraphicProject.GraphLayout
{
    public delegate void SurfaceEventHandler(object sender, SurfaceEventArgs e);

    public class SurfaceEventArgs : EventArgs
    {
        #region Attributes

        private Surface surface;

        #endregion

        #region Properties

        public Surface Surface { get { return this.surface; } }

        #endregion

        public SurfaceEventArgs(Surface surface)
        {
            this.surface = surface;
        }
    }
}
