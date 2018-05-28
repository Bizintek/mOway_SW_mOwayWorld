using System;

using Moway.Template;

namespace Moway.Project
{
    /// <summary>
    /// Delegate for a box events
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void BoxEventHandler(object sender, BoxEventArgs e);

    /// <summary>
    /// Arguments for the previous delegate
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class BoxEventArgs
    {
        #region Attributes

        /// <summary>
        /// Box
        /// </summary>
        private MowayBox box;

        #endregion

        #region Properties

        /// <summary>
        /// Box
        /// </summary>
        public MowayBox Box { get { return this.box; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="box">Box</param>
        public BoxEventArgs(MowayBox box)
        {
            this.box = box;
        }
    }
}
