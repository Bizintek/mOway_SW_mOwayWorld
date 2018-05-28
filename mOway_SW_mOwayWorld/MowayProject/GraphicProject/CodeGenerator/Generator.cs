using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.CodeGenerator
{
    /// <summary>
    /// It includes the function common to any code generator that checks if a diagram is designed correctly
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public abstract class Generator
    {
        #region Static methods

        /// <summary>
        /// Check if a diagram has been designed correctly
        /// </summary>
        /// <param name="diagram">Diagram to check</param>
        /// <param name="errors">List of errors in the diagram</param>
        /// <returns>True if the diagram is correct, false otherwise</returns>
        public static bool CheckDiagram(Diagram diagram, List<DiagramError> errors)
        {
            bool endElement = false;
            // all the elements of the diagram are traversed
            foreach (Element element in diagram.Elements)
            {
                // if it is a start element, the following element is checked
                if (element is Start)
                {
                    if (!element.HasNext)
                        errors.Add(new DiagramError(ErrorType.Error, diagram, element, ErrorMessages.START_NEXT));
                    else if (element.Next.Next is Finish)
                        errors.Add(new DiagramError(ErrorType.Warning, diagram, element, ErrorMessages.FUCNTION_EMPTY));
                }
                // if it is a module, the next element is checked and if it has at least one previous
                else if (element is Module)
                {
                    if (!element.HasPrevious)
                        errors.Add(new DiagramError(ErrorType.Error, diagram, element, ErrorMessages.MODULE_PREVIOUS));
                    if (!element.HasNext)
                        errors.Add(new DiagramError(ErrorType.Error, diagram, element, ErrorMessages.MODULE_NEXT));
                }
                // if it is a conditional, the following two elements are checked and if at least it has a previous one
                else if (element is Conditional)
                {
                    if (!element.HasPrevious)
                        errors.Add(new DiagramError(ErrorType.Error, diagram, element, ErrorMessages.CONDITIONAL_PREVIOUS));
                    if (!((Conditional)element).HasNextTrue)
                        errors.Add(new DiagramError(ErrorType.Error, diagram, element, ErrorMessages.CONDITIONAL_NEXT_TRUE));
                    if (!((Conditional)element).HasNextFalse)
                        errors.Add(new DiagramError(ErrorType.Error, diagram, element, ErrorMessages.CONDITIONAL_NEXT_FALSE));
                }
                //if it is a final element, it is checked if it has at least one previous
                else if (element is Finish)
                {
                    endElement = true;
                    if (!element.HasPrevious)
                        errors.Add(new DiagramError(ErrorType.Error, diagram, element, ErrorMessages.FINISH_PREVIOUS));
                }
            }
            // if it is a function, it must have a final element, but it is a warning, not an error
            if ((diagram.IsFunction) && (!endElement))
                errors.Add(new DiagramError(ErrorType.Warning, diagram, null, ErrorMessages.FUNCTION_NO_RETURN));
            // True is returned if no errors were found
            if (errors.Count == 0)
                return true;
            else
                return false;
        }

        #endregion
    }
}
