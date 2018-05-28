using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

using Moway.Template;
using Moway.Template.Controls;
using Moway.Project.GraphicProject.Actions.Start;
using Moway.Project.GraphicProject.Controls;
using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.Forms;
using Moway.Project.GraphicProject.Actions;

namespace Moway.Project.GraphicProject
{
    /// <summary>
    /// Represents a variable in the graphic project
    /// </summary>
    internal class GraphProject : iProject
    {
        #region Attributes

        /// <summary>
        /// Project Name
        /// </summary>
        private string name = "temp";
        /// <summary>
        /// Path of the project
        /// </summary>
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MowayWorld";
        /// <summary>
        /// Indicates whether the project has already been saved to the disk
        /// </summary>
        private bool projectSaved = false;
        /// <summary>
        /// Project Builder
        /// </summary>     
        private string owner = Environment.UserName;
        /// <summary>
        /// Comments on the project
        /// </summary        
        private string comments = "";
        /// <summary>
        /// Language for code generation
        /// </summary>
        private Language language = Language.Assembler;
        /// <summary>
        /// Main function of the project
        /// </summary>
        private Diagram mainFunction = null;
        /// <summary>
        /// Project Auxiliary functions
        /// </summary>
        private SortedList<string, Diagram> subfunctions = new SortedList<string, Diagram>();
        /// <summary>
        /// Project Variables. A SortedList is used to do access to them easier
        /// </summary>
        private SortedList<string, Variable> variables = new SortedList<string, Variable>();

        #endregion

        #region Properties

        /// <summary>
        /// Project Name
        /// </summary>
        public string Name { get { return this.name; } }
        /// <summary>
        /// Full name of the project with extension
        /// </summary>
        public string ProjectFileName
        {
            get
            {
                if (!this.projectSaved)
                    return "";
                else
                    return this.name + ".mpj";
            }
        }
        /// <summary>
        /// Path of the project
        /// </summary>
        public string ProjectPath { get { return this.path; } }
        /// <summary>
        /// Project Builder
        /// </summary>
        public string Owner { get { return this.owner; } }
        /// <summary>
        /// Comments on the project
        /// </summary>
        public string Comments { get { return this.comments; } }
        /// <summary>
        /// Language for code generation
        /// </summary>
        public Language Language { get { return this.language; } }
        /// <summary>
        /// . asm File Path
        /// </summary>
        public string AsmFile
        {
            get
            {
                if (this.projectSaved)
                    return this.path + "\\" + this.name + "-files\\" + this.name + ".asm";
                else
                    return this.path + "\\" + this.name + ".asm";
            }
        }
        /// <summary>
        /// . hex File Path
        /// </summary>
        public string HexFile
        {
            get
            {
                if (this.projectSaved)
                    return this.path + "\\" + this.name + "-files\\" + this.name + ".hex";
                else
                    return this.path + "\\" + this.name + ".hex";
            }
        }
        /// <summary>
        /// Main function of the project
        /// </summary>
        public Diagram MainFunction { get { return this.mainFunction; } }
        /// <summary>
        /// Project Auxiliary functions
        /// </summary>
        public List<Diagram> Subfunctions
        {
            get
            {
                List<Diagram> functions = new List<Diagram>();
                functions.AddRange(this.subfunctions.Values);
                return functions;
            }
        }
        /// <summary>
        /// All the functions of the project (main function + subfunctions)
        /// </summary>
        public List<Diagram> Functions
        {
            get
            {
                List<Diagram> diagrams = new List<Diagram>();
                diagrams.Add(this.mainFunction);
                diagrams.AddRange(this.subfunctions.Values);
                return diagrams;
            }
        }
        /// <summary>
        /// Project Variables
        /// </summary>
        public List<Variable> Variables
        {
            get
            {
                List<Variable> variables = new List<Variable>();
                variables.AddRange(this.variables.Values);
                return variables;
            }
        }

        #endregion

        /// <summary>
        /// Builder of a graphic project in its temp mode
        /// </summary>
        public GraphProject()
        {
            this.mainFunction = new Diagram(GraphMessages.MAIN, "", new StartAction(), false);
        }

        /// <summary>
        /// Builder of a graphic project. Saves the project at the location indicated.
        /// </summary>
        /// <param name="name">Project Name</param>
        /// <param name="path">Path of the project</param>
        public GraphProject(string name, string path)
        {
            this.name = name;
            this.path = path;
            this.projectSaved = true;
            this.mainFunction = new Diagram(GraphMessages.MAIN, "", new StartAction(), false);
            this.SaveProjectInDisk();
        }

        /// <summary>
        /// Builder of a graphic project. It is understood that the project is being loaded with a saved
        /// </summary>
        /// <param name="name">Project Name</param>
        /// <param name="path">Path of the project</param>
        /// <param name="properties">Project Properties</param>
        /// <param name="mainFunction">Main Function</param>
        /// <param name="functions">Auxiliary Functions</param>
        /// <param name="variables">Project Variables</param>
        public GraphProject(string name, string path, XmlElement properties, Diagram mainFunction, List<Diagram> functions, SortedList<string, Variable> variables)
        {
            this.name = name;
            this.path = path;
            this.projectSaved = true;
            foreach (XmlElement property in properties.ChildNodes)
            {
                switch (property.Name)
                {
                    case "owner":
                        this.owner = property.InnerText;
                        break;
                    case "comments":
                        this.comments = property.InnerText;
                        break;
                    case "language":
                        if (property.InnerText == Language.Assembler.ToString())
                            this.language = Language.Assembler;
                        else
                            this.language = Language.C;
                        break;
                    default:
                        throw new ProjectException("Properties file format error");
                }
            }
            this.mainFunction = mainFunction;
            foreach (Diagram function in functions)
                this.subfunctions.Add(function.Name, function);
            this.variables = variables;
        }

        #region Public methods

        /// <summary>
        /// Saves the project
        /// </summary>
        public void SaveProject()
        {
            if (!this.projectSaved)
                throw new ProjectException("Project has not been saved previously");
            this.SaveProjectInDisk();
        }

        /// <summary>
        /// Saves the project on a specific path
        /// </summary>
        /// <param name="projectFile"></param>
        public void SaveProject(string projectFile)
        {
            this.name = Path.GetFileNameWithoutExtension(projectFile);
            this.path = Path.GetDirectoryName(projectFile);
            this.projectSaved = true;
            this.SaveProjectInDisk();
        }

        /// <summary>
        /// Update Project Properties
        /// </summary>
        /// <param name="owner">Project Builder</param>
        /// <param name="comments">Comments on the project</param>
        /// <param name="language">Language for code generation</param>
        public void UpdateSettings(string owner, string comments, Language language)
        {
            this.owner = owner;
            this.comments = comments;
            this.language = language;
        }

        /// <summary>
        /// Add a new function to the project
        /// </summary>
        /// <param name="function">Function to include</param>
        public void AddFunction(Diagram function)
        {
            if (subfunctions.ContainsKey(function.Name))
                throw new ProjectException("This function already exist");
            this.subfunctions.Add(function.Name, function);
        }

        /// <summary>
        /// Updates the name of a function
        /// </summary>
        /// <param name="function">Function to update</param>
        /// <param name="name">New name for function</param>
        public void UpdateFunction(Diagram function, string name, string description)
        {
            if (this.mainFunction == function)
                this.mainFunction.UpdateDiagram(name, description);
            else
            {
                if (!this.subfunctions.ContainsKey(function.Name))
                    throw new ProjectException("This function don't exist");
                this.subfunctions.Remove(function.Name);
                function.UpdateDiagram(name, description);
                this.subfunctions.Add(function.Name, function);
            }
        }

        /// <summary>
        /// Delete a function
        /// </summary>
        /// <param name="name">Function Name to delete</param>
        /// <returns>True if it has been successfully deleted, False otherwise</returns>
        public bool RemoveFunction(string name)
        {
            Diagram function = this.subfunctions[name];
            foreach (Diagram diagram in this.Functions)
                if ((diagram != function) && (diagram.FunctionInUse(function)))
                    return false;
            this.subfunctions.Remove(name);
            return true;
        }

        /// <summary>
        /// Checks whether the function is being used by another function
        /// </summary>
        /// <param name="function">Function to check</param>
        /// <returns>True if it is being used, False otherwise</returns>
        public bool FunctionInUsed(Diagram function)
        {
            foreach (Diagram diagram in this.Functions)
                if ((diagram != function) && (diagram.FunctionInUse(function)))
                    return true;
            return false;
        }

        /// <summary>
        /// Checks if a function exists with a particular name
        /// </summary>
        /// <param name="name">Function Name</param>
        /// <returns>True if it exists, False otherwise</returns>
        public bool ConstainFunction(string name)
        {
            return this.subfunctions.ContainsKey(name);
        }

        /// <summary>
        /// Add a variable to the project
        /// </summary>
        /// <param name="variable">Variable to include</param>
        public void AddVariable(Variable variable)
        {
            if (this.variables.ContainsKey(variable.Name))
                throw new ProjectException("This variable already exits");
            this.variables.Add(variable.Name, variable);
        }

        /// <summary>
        /// Returns a variable identified by its name
        /// </summary>
        /// <param name="name">Variable name</param>
        /// <returns>Idetificated Variable, NULL in case of not existing</returns>
        public Variable GetVariable(string name)
        {
            if (this.variables.ContainsKey(name))
                return this.variables.Values[this.variables.IndexOfKey(name)];
            else
                return null;
        }

        /// <summary>
        /// Updates the values of a variable
        /// </summary>
        /// <param name="variable">Variable to update</param>
        /// <param name="name">Variable Name</param>
        /// <param name="initValue">Initial value of the variable</param>
        public void UpdateVariable(Variable variable, string name, byte initValue)
        {
            if (!this.variables.ContainsKey(variable.Name))
                throw new ProjectException("This variable don't exist");
            this.variables.Remove(variable.Name);
            variable.Update(name, initValue);
            this.variables.Add(name, variable);
        }

        /// <summary>
        /// Checks if a function exists with a particular name
        /// </summary>
        /// <param name="name">Variable Name</param>
        /// <returns>True if it exists, False otherwise/returns>
        public bool ConstainVariable(string name)
        {
            return this.variables.ContainsKey(name);
        }

        /// <summary>
        /// Delete a variable
        /// </summary>
        /// <param name="variableName">Variable Name</param>
        /// <returns>True if it has been successfully deleted, False otherwise</returns>
        public bool RemoveVariable(string variableName)
        {
            Variable variable = this.variables[variableName];
            foreach (Diagram diagram in this.Functions)
                if (diagram.VariableInUse(variable))
                    return false;
            this.variables.Remove(variableName);
            return true;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Saves the project to a file on disk
        /// </summary>
        private void SaveProjectInDisk()
        {
            XmlWriter projectFile = new XmlTextWriter(this.path + "\\" + this.name + ".mpj", new System.Text.ASCIIEncoding());
            projectFile.WriteStartDocument();
            //The project properties are saved
            projectFile.WriteStartElement("mowayProject");
            projectFile.WriteElementString("type", "graphic");
            projectFile.WriteStartElement("properties");
            projectFile.WriteElementString("owner", this.owner);
            projectFile.WriteElementString("comments", this.comments);
            projectFile.WriteElementString("language", this.language.ToString());
            projectFile.WriteEndElement();

            projectFile.WriteStartElement("variables");
            foreach (Variable variable in this.Variables)
            {
                projectFile.WriteStartElement("variable");
                projectFile.WriteElementString("name", variable.Name);
                projectFile.WriteElementString("initValue", variable.InitValue.ToString());
                projectFile.WriteEndElement();
            }
            projectFile.WriteEndElement();

            projectFile.WriteStartElement("functions");
            projectFile.WriteElementString("main", this.mainFunction.Name);
            foreach (Diagram function in this.subfunctions.Values)
                projectFile.WriteElementString("function", function.Name);
            projectFile.WriteEndElement();

            projectFile.WriteEndElement();
            projectFile.WriteEndDocument();
            projectFile.Close();
        }

        #endregion
   }
}
