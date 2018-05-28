using System;
using System.Drawing;

namespace Moway.Template.Controls
{
    /// <summary>
    /// Interface for items that can be included in the toolbar
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public interface IToolBarItem
    {
        /// <summary>
        /// Control position
        /// </summary>
        Point Location { get; set; }
        /// <summary>
        /// Control Size
        /// </summary>
        Size Size { get; }
    }
}
