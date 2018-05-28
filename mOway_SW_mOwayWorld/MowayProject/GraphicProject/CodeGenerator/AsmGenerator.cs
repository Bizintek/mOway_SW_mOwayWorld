using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.CodeGenerator
{
    /// <summary>
    /// Code generator for assembly language
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class AsmGenerator
    {
        #region Attributes

        /// <summary>
        /// Label counter(for automatic label generation)
        /// </summary>
        private static int labelCounter;

        #endregion

        #region Public methods estáticos

        /// <summary>
        /// Generates the code for a function, with its subfunctions and variables
        /// </summary>
        /// <param name="mainDiagram">Main function for code generation</param>
        /// <param name="functions">Subfunctions</param>
        /// <param name="variables">Variables</param>
        /// <param name="asmPath">Path of the resulting asm file</param>
        public static void GenerateCode(Diagram mainDiagram, List<Diagram> functions, List<Variable> variables, string asmPath)
        {
            StreamWriter writer = new StreamWriter(asmPath, false);
            AsmGenerator.RestoreLabelCounter();
            AsmGenerator.WriteHead(writer);
            if (variables.Count > 0)
                AsmGenerator.WriteVariables(writer, variables);
            AsmGenerator.WriteVectors(writer);
            AsmGenerator.WriteConfiguration(writer);
            //the program variables are initialized
            if (variables.Count > 0)
                AsmGenerator.WriteInitVariables(writer, variables);
            // the main function is encoded
                        AsmGenerator.GenerateDiagramCode(writer, mainDiagram);
            //the functions are encoded
            foreach (Diagram diagram in functions)
                AsmGenerator.GenerateDiagramCode(writer, diagram);
            AsmGenerator.WriteEndDirective(writer);
            writer.Close();
        }

        #endregion


        #region Static private methods

        /// <summary>
        /// Restart the label generation counter
        /// </summary>
        private static void RestoreLabelCounter()
        {
            labelCounter = 0;
        }

        /// <summary>
        /// Generates a new label
        /// </summary>
        /// <returns>Name of the label</returns>
        private static string GenerateLabel()
        {
            string label = "label" + AsmGenerator.labelCounter;
            labelCounter++;
            return label;
        }

        /// <summary>
        /// Returns the next element by jumping Arrow type
        /// </summary>
        /// <param name="element">Element of departure</param>
        /// <returns>Next element</returns>
        private static Element GetNextElement(Element element)
        {
            Element elementNext = element.Next;
            while (elementNext is Arrow)
                elementNext = elementNext.Next;
            return elementNext;
        }

        /// <summary>
        /// Returns the next element for a conditional, skipping the elements of type Arrow
        /// </summary>
        /// <param name="element">Element of departure</param>
        /// <param name="trueFalse">Indicates the next path of the conditional to follow</param>
        /// <returns>Next element</returns>
        private static Element GetNextElement(Conditional element, bool trueFalse)
        {
            Element elementNext = element.NextTrue;
            if (!trueFalse)
                elementNext = element.NextFalse;
            while (elementNext is Arrow)
                elementNext = elementNext.Next;
            return elementNext;
        }

        /// <summary>
        /// Generate the code for a diagram
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="diagram">Diagram for the generation</param>
        /// <param name="subrutine">Indicates whether it is a subroutine or not.True for subroutine</param>
        private static void GenerateDiagramCode(StreamWriter writer, Diagram diagram)
        {
            Queue<Element> falseBranch = new Queue<Element>();
            Hashtable labelElements = new Hashtable();
            List<Element> elementsCodified = new List<Element>();
            bool endElement = false, forceLoopEnd = false;
            Element presentElement = AsmGenerator.GetNextElement(diagram.Start);
            string label;

            if (diagram.IsFunction)
                AsmGenerator.WriteLabel(writer, diagram.Name);

            while (presentElement != null)
            {
                if (elementsCodified.Contains(presentElement))
                {
                    AsmGenerator.WriteUnconditionalJump(writer, (string)labelElements[presentElement]);
                    if (falseBranch.Count != 0)
                    {
                        presentElement = falseBranch.Dequeue();
                        continue;
                    }
                    else
                        break;
                }
                if (presentElement is Finish)
                {
                    if (diagram.IsFunction)
                        AsmGenerator.WriteSubrutineEnd(writer);
                    else
                        if (!endElement)
                        {
                            AsmGenerator.WriteEndLoop(writer);
                            endElement = true;
                        }
                        else
                            AsmGenerator.WriteUnconditionalJump(writer, "loopEnd");
                    if (falseBranch.Count != 0)
                    {
                        presentElement = falseBranch.Dequeue();
                        continue;
                    }
                    else
                        break;
                }
                else
                {
                    if (labelElements.ContainsKey(presentElement))
                        AsmGenerator.WriteLabel(writer, (string)labelElements[presentElement]);
                    else if (presentElement.MoreThan1Prev)
                    {
                        label = AsmGenerator.GenerateLabel();
                        labelElements.Add(presentElement, label);
                        AsmGenerator.WriteLabel(writer, label);
                    }
                    if (presentElement is Module)
                    {
                        ((Module)presentElement).WriteCode(writer);
                        elementsCodified.Add(presentElement);
                        presentElement = AsmGenerator.GetNextElement(presentElement);
                    }
                    else if (presentElement is Conditional)
                    {
                        Element elementNextFalse = AsmGenerator.GetNextElement((Conditional)presentElement, false);
                        if (labelElements.ContainsKey(elementNextFalse))
                        {
                            label = (string)labelElements[elementNextFalse];
                            ((Conditional)presentElement).WriteCode(writer, AsmGenerator.GetUnconditionalJump(label));
                            elementsCodified.Add(presentElement);
                            presentElement = AsmGenerator.GetNextElement((Conditional)presentElement, true);
                        }
                        else if (elementNextFalse is Finish)
                            if (diagram.IsFunction)
                            {
                                ((Conditional)presentElement).WriteCode(writer, AsmGenerator.GetSubrutineEnd());
                                elementsCodified.Add(presentElement);
                                presentElement = AsmGenerator.GetNextElement((Conditional)presentElement, true);
                            }
                            else
                            {
                                ((Conditional)presentElement).WriteCode(writer, AsmGenerator.GetUnconditionalJump("loopEnd"));
                                elementsCodified.Add(presentElement);
                                presentElement = AsmGenerator.GetNextElement((Conditional)presentElement, true);
                                forceLoopEnd = true;
                            }
                        else
                        {
                            label = AsmGenerator.GenerateLabel();
                            labelElements.Add(elementNextFalse, label);
                            falseBranch.Enqueue(elementNextFalse);
                            ((Conditional)presentElement).WriteCode(writer, AsmGenerator.GetUnconditionalJump(label));
                            elementsCodified.Add(presentElement);
                            presentElement = AsmGenerator.GetNextElement((Conditional)presentElement, true);
                        }
                    }
                }
            }
            if ((forceLoopEnd) && (!endElement))
                AsmGenerator.WriteEndLoop(writer);
        }

        /// <summary>
        /// Write the program header code
        /// </summary>
        /// <param name="writer"></param>
        private static void WriteHead(StreamWriter writer)
        {
            writer.WriteLine(";***************************************************************************");
            writer.WriteLine(";*                              mowayWorld                                 *");
            writer.WriteLine(";***************************************************************************");
            writer.WriteLine(";*Description:                                                             *");
            writer.WriteLine(";*Automatically generated code                                             *");
            writer.WriteLine(";***************************************************************************");
            writer.WriteLine(";***************************************************************************");
            writer.WriteLine("	list p=18F86j50");
            writer.WriteLine("   ;*	Include mOways microcontroller");

            writer.WriteLine("   #include \"inc\\P18F86j50.INC\"");
            writer.WriteLine("");
        }

        /// <summary>
        /// Write the code corresponding to the declaration of variables
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="variables"></param>
        private static void WriteVariables(StreamWriter writer, List<Variable> variables)
        {
            writer.WriteLine(";****************************************");
            writer.WriteLine(";*   Variables                          *");
            writer.WriteLine(";****************************************");
            for (int i = 0; i < variables.Count; i++)
            {
                string line = variables[i].Name;
                for (int j = line.Length; j < 0x0F; j = j + 0x01)
                    line += " ";
                line += "EQU    0x" + String.Format("{0:X2} ", (0x7E - i)); ;
                writer.WriteLine(line);
            }
            writer.WriteLine("");
        }

        /// <summary>
        /// Write the code with the start vector
        /// </summary>
        /// <param name="writer"></param>
        private static void WriteVectors(StreamWriter writer)
        {
            writer.WriteLine(";*	Reset Vector");
            writer.WriteLine("  org		0x1000");
            writer.WriteLine("  goto	INIT");
            writer.WriteLine(";*	Program memory	*");
            writer.WriteLine("  org		0x102A");
            writer.WriteLine(";************************");
            writer.WriteLine(";***************************[MOWAY LIBRARIES]*********************************************");
            writer.WriteLine("  #include \"inc\\lib_sen_moway_GUI.inc\"");
            writer.WriteLine("  #include \"inc\\lib_rf2gh4_GUI.inc\"");
            writer.WriteLine("  #include \"inc\\lib_mot_moway_GUI.inc\"");
            writer.WriteLine("  #include \"inc\\lib_cam_moway_GUI.inc\"");
            writer.WriteLine(";*************************************");
            writer.WriteLine("");
            writer.WriteLine("INIT:");
            writer.WriteLine("");
            writer.WriteLine(";#####################################");
        }

        /// <summary>
        /// Write calls for pre-program settings
        /// </summary>
        /// <param name="writer"></param>
        private static void WriteConfiguration(StreamWriter writer)
        {
            writer.WriteLine("  ;*************************[MOWAY CONFIGURATION]***********************");
            writer.WriteLine("  ;Sensor configuration");
            writer.WriteLine("  call    SEN_CONFIG");
            writer.WriteLine("  ;Motor configuration");
            writer.WriteLine("  call    MOT_CONFIG");                
            writer.WriteLine("");
        }



        /// <summary>
        /// Write the code corresponding to the initiation of variables
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="variables"></param>
        private static void WriteInitVariables(StreamWriter writer, List<Variable> variables)
        {
            writer.WriteLine(";****************************************");
            writer.WriteLine(";*   Variables initialization           *");
            writer.WriteLine(";****************************************");
            for (int i = 0; i < variables.Count; i++)
            {
                writer.WriteLine("  movlw   ." + variables[i].InitValue);
                writer.WriteLine("  movwf    " + variables[i].Name);
            }
            writer.WriteLine("");
        }

        /// <summary>
        /// Write an unconditional jump instruction
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="label">Name of the label</param>
        private static void WriteUnconditionalJump(StreamWriter writer, string label)
        {
            writer.WriteLine("");
            writer.WriteLine("  goto    " + label);
            writer.WriteLine("");
        }

        /// <summary>
        /// Returns the line for an unconditional jump
        /// </summary>
        /// <param name="label">Name of the label</param>
        /// <returns></returns>
        private static string GetUnconditionalJump(string label)
        {
            return "  goto    " + label;
        }

        /// <summary>
        /// Write a laber
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="label">Name of the label</param>
        private static void WriteLabel(StreamWriter writer, string label)
        {
            writer.WriteLine("");
            writer.WriteLine(label + ":");
        }

        /// <summary>
        /// Write the end loop for the main routine
        /// </summary>
        /// <param name="writer"></param>
        private static void WriteEndLoop(StreamWriter writer)
        {
            writer.WriteLine("loopEnd:");
            writer.WriteLine("  goto    loopEnd");
        }

        /// <summary>
        /// Write the end for the subroutines
        /// </summary>
        /// <param name="writer"></param>
        private static void WriteSubrutineEnd(StreamWriter writer)
        {
            writer.WriteLine("  return");
        }

        /// <summary>
        /// Returns the ending line for the subroutines
        /// </summary>
        /// <returns></returns>
        private static string GetSubrutineEnd()
        {
            return "  return";
        }

        /// <summary>
        /// Write the end of program directive
        /// </summary>
        /// <param name="writer"></param>
        private static void WriteEndDirective(StreamWriter writer)
        {
            writer.WriteLine("");
            writer.WriteLine("END");
        }

        #endregion
    }
}
