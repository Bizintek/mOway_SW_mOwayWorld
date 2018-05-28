using System;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;

using Moway.Project.GraphicProject.GraphLayout;

namespace Moway.Project.GraphicProject.Simulator
{
    /// <summary>
    /// Graphic marker for simulation visualization
    /// </summary>
    /// <LastRevision>27.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class GraphTrace : Sprite
    {
        /// <summary>
        /// Builder
        /// </summary>
        public GraphTrace()
        {
            //The surface is created
            this.Surface = new Surface(16, 16);
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Transparent = true;
            this.TransparentColor = GraphDiagram.TRASPARENT_COLOR;
            //The image of the arrow is included
            this.Surface.Blit(new Surface(SimulatorGraphics.Trace));
        }
    }
}
