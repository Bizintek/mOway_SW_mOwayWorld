using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// Panel of that inherit to create shared panels
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class SharePanel : UserControl
    {
        #region Properties

        /// <summary>
        /// Title of the panel
        /// </summary>
        virtual public string Tittle { get { throw new Exception("This property can't be called"); } }
        /// <summary>
        /// Short title of the panel
        /// </summary>
        virtual public string ShortTittle { get { throw new Exception("This property can't be called"); } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public SharePanel()
        {
            InitializeComponent();
        }

        #region Public methods

        /// <summary>
        /// This method must always be called before closing, and in addition, it must be implemented obligatorily by the class that inherit from it.
        /// </summary>
        /// <returns></returns>
        public virtual bool CloseBox() { throw new Exception("This method can't be called"); }

        #endregion
    }
}
