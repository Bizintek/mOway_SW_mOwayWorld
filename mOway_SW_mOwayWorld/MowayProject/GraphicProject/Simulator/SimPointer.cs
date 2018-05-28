using System;

using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Simulator
{
    /// <summary>
    /// Return pointer for function calls inside the simulator
    /// </summary>
    /// <LastRevision>27.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class SimPointer
    {
        #region Attributes

        /// <summary>
        /// Return pointer function
        /// </summary>
        private GraphDiagram function;
        /// <summary>
        /// Return pointer element
        /// </summary>
        private GraphElement element;

        #endregion

        #region Properties

        /// <summary>
        /// Return pointer function
        /// </summary>
        public GraphDiagram Function { get { return this.function; } }
        /// <summary>
        /// Return pointer element
        /// </summary>
        public GraphElement Element { get { return this.element; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="function">Return pointer function</param>
        /// <param name="element">Return pointer elementS</param>
        public SimPointer(GraphDiagram function, GraphElement element)
        {
            this.function = function;
            this.element = element;
        }
    }
}
