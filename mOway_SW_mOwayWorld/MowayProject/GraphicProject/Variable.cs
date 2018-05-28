using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject
{
    /// <summary>
    /// Represents a variable in the graphic project
    /// </summary>
    /// <LastRevision>17.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class Variable
    {
        #region Attributes

        /// <summary>
        /// Variable Name
        /// </summary>
        private string name;
        /// <summary>
        /// Initial value for the variable
        /// </summary>
        private byte initValue;

        #endregion

        #region Properties

        /// <summary>
        /// Variable Name
        /// </summary>
        public string Name { get { return this.name; } }
        /// <summary>
        /// Initial value for the variable
        /// </summary>
        public byte InitValue { get { return this.initValue; } }

        #endregion 

        /// <summary>
        /// Variable class Builder
        /// </summary>
        /// <param name="name">Variable Name</param>
        /// <param name="initValue">Initial value for the variable</param>
        public Variable(string name, byte initValue)
        {
            if (!Variable.Validate(name))
                throw new VariableException("Variable name is not valid");
            this.name = name;
            this.initValue = initValue;
        }

        #region Public methods

        /// <summary>
        /// Updates the attributes of an object
        /// </summary>
        /// <param name="name">Variable Name</param>
        /// <param name="initValue">Initial value for the variable</param>
        public void Update(string name, byte initValue)
        {
            if (!Variable.Validate(name))
                throw new VariableException("Variable name is not valid");
            this.name = name;
            this.initValue = initValue;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the name of a variable
        /// </summary>
        /// <param name="name">Variable Name</param>
        /// <returns>True if it is a valid name</returns>
        public static bool Validate(string name)
        {
            return Regex.IsMatch(name, @"^([a-zA-Z]{1}[a-zA-Z\d_]{4,13})$");
        }

        /// <summary>
        /// Checks if a given name is a keyword
        /// </summary>
        /// <param name="name">Variable Name</param>
        /// <returns>True If there is a keyword with the same name</returns>
        public static bool IsKeyword(string name)
        {
            try
            {
                StreamReader reader = new StreamReader(Application.StartupPath + "\\Keywords.txt");
                while (!reader.EndOfStream)
                {
                    string keyword = reader.ReadLine();
                    if (name.ToUpper() == keyword)
                    {
                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
                return false;
            }
            catch
            {
                throw new VariableException("Can't open keyword file");
            }
        }

        #endregion
    }
}
