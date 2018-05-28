using System;

namespace Moway.Project
{
    /// <summary>
    /// Interface of a project
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public interface iProject
    {
        #region Properties

        /// <summary>
        /// Project Name
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Path of the project
        /// </summary>
        string ProjectPath { get; }
        /// <summary>
        /// Project owner
        /// </summary>
        string Owner { get; }
        /// <summary>
        /// Comments about the project
        /// </summary>
        string Comments { get; }

        #endregion
    }
}
