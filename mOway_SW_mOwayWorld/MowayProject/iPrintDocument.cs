using System;
using System.Drawing.Printing;

namespace Moway.Project
{
    /// <summary>
    /// Interface of a print document
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public interface iPrintDocument
    {
        #region  Methods

        /// <summary>
        /// function that launches the printing of a document
        /// </summary>
        /// <param name="range"></param>
        void Print(PrintRange range);

        #endregion
    }
}
