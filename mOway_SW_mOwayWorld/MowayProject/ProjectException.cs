using System;

namespace Moway.Project 
{
    /// <summary>
    /// Exception specified for Project
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class ProjectException : Exception
    {
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="message"></param>
        public ProjectException(string message):base(message)
        {
        }
    }
}
