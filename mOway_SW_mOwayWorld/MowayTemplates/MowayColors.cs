using System;
using System.Drawing;

namespace Moway.Template
{
    /// <summary>
    /// Color definition for the MOway World application
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public abstract class MowayColors
    {
        #region Properties

        public static Color Border { get { return Color.FromArgb(153, 153, 153); } }
        public static Color DisableBorder { get { return Color.FromArgb(207, 207, 207); } }
        public static Color Text { get { return SystemColors.ControlText; } }
        public static Color DisableText { get { return SystemColors.GrayText; } }
        public static Color BackControl { get { return Color.White; } }
        public static Color DisableBackControl { get { return Color.White; } }
        public static Color Selection { get { return Color.FromArgb(222, 222, 222); } }

        #endregion
    }
}
