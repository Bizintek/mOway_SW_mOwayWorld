using System;

using SdlDotNet.Graphics;

namespace Moway.Project.GraphicProject.GraphLayout
{
    public delegate void LayerEventHandler(object sender, LayerEventArgs e);

    public class LayerEventArgs
    {
        Surface surface;

        public Surface Surface { get { return this.surface; } }
        public LayerEventArgs(Surface surface)
        {
            this.surface = surface;
        }
    }
}
