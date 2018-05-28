using System;
using System.Xml;

using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Pause
{
    /// <summary>
    /// Factory for the "Pause" action
    /// </summary>
    public class PauseFactory : iActionFactory
    {
        #region Attributes

        /// <summary>
        /// Action key
        /// </summary>
        private string key;

        #endregion

        #region Properties

        /// <summary>
        /// Action key
        /// </summary>
        public string Key { get { return this.key; } }
        /// <summary>
        /// Categoría de la acción
        /// </summary>
        public string Category { get { return Pause.Category; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public PauseFactory()
        {
            //the Action key is set
            this.key = Pause.Key;
        }

        /// <summary>
        /// Returns the tool object of the "Pause" action
        /// </summary>
        /// <returns>Herramienta de la acción</returns>
        public Tool GetToolAction()
        {
            return new PauseTool(this.key);
        }

        /// <summary>
        /// Returns the tool object of the "Pause" action
        /// </summary>
        /// <param name="key">Action key</param>
        /// <returns>Action tool</returns>
        public Tool GetToolAction(string key)
        {
            //It checks if the requested key is correct
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new PauseTool(this.key);
        }

        /// <summary>
        /// Returns the graphic object of the "Pause" action
        /// </summary>
        /// <param name="key">Action key</param>
        /// <returns> Action graph</returns>
        public GraphElement GetGraphAction(string key)
        {
            //It checks if the requested key is correct
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new PauseGraphic(this.key);
        }

        public GraphElement GetGraphAction(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new PauseGraphic(this.key, elementData, variables);
        }

        /// <summary>
        /// Returns the logical object of the "Pause" action
        /// </summary>
        /// <param name="key">Action key</param>
        /// <returns>The action itself</returns>
        public Element GetAction(string key)
        {
            //It checks if the requested key is correct
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new PauseAction(key);
        }

        /// <summary>
        /// Returns the configuration form for the "Pause" action
        /// </summary>
        /// <param name="element">Action to configure</param>
        /// <returns> Configuration form</returns>
        public ActionForm GetActionForm(Element element)
        {
            //It checks if the requested key is correct
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new PauseForm((PauseAction)element);
        }

        public ActionPanel GetActionPanel(Element element)
        {
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new PausePanel((PauseAction)element);
        }
    }
}