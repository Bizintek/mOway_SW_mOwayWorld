using System;
using System.Xml;

using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.CompareBrightness
{
    public class CompareBrightnessFactory : iActionFactory
    {
        #region Attributes

        private string key;

        #endregion

        #region Properties

        public string Key { get { return this.key; } }
        public string Category { get { return CompareBrightness.Category; } }

        #endregion

        public CompareBrightnessFactory()
        {
            this.key = CompareBrightness.Key;
        }

        public Tool GetToolAction()
        {
            return new CompareBrightnessTool(this.key);
        }

        public Tool GetToolAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new CompareBrightnessTool(this.key);
        }

        public GraphElement GetGraphAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new CompareBrightnessGraphic(this.key);
        }

        public GraphElement GetGraphAction(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new CompareBrightnessGraphic(this.key, elementData, variables);
        }

        public Element GetAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new CompareBrightnessAction(key);
        }

        public ActionForm GetActionForm(Element element)
        {
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new CompareBrightnessForm((CompareBrightnessAction)element);
        }

        public ActionPanel GetActionPanel(Element element)
        {
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new CompareBrightnessPanel((CompareBrightnessAction)element);
        }
    }
}