using System;
using System.Xml;

using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Noise
{
    public class NoiseFactory : iActionFactory
    {
        #region Attributes

        private string key;

        #endregion

        #region Properties

        public string Key { get { return this.key; } }
        public string Category { get { return Noise.Category; } }

        #endregion

        public NoiseFactory()
        {
            this.key = Noise.Key;
        }

        public Tool GetToolAction()
        {
            return new NoiseTool(this.key);
        }

        public Tool GetToolAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new NoiseTool(this.key);
        }

        public GraphElement GetGraphAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new NoiseGraphic(this.key);
        }

        public GraphElement GetGraphAction(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new NoiseGraphic(this.key, elementData, variables);
        }

        public Element GetAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new NoiseAction(key);
        }

        public ActionForm GetActionForm(Element element)
        {
            throw new ActionFormException(Noise.ErrorMessage, Noise.ErrorCaption);
        }

        public ActionPanel GetActionPanel(Element element)
        {
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new NoisePanel();
        }
    }
}