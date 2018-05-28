using System;
using System.Xml;

using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.CompareAngle
{
    public class CompareAngleFactory : iActionFactory
    {
        #region Attributes

        private string key;

        #endregion

        #region Properties

        public string Key { get { return this.key; } }
        public string Category { get { return CompareAngle.Category; } }

        #endregion

        public CompareAngleFactory()
        {
            this.key = CompareAngle.Key;
        }

        public Tool GetToolAction()
        {
            return new CompareAngleTool(this.key);
        }

        public Tool GetToolAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new CompareAngleTool(this.key);
        }

        public GraphElement GetGraphAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new CompareAngleGraphic(this.key);
        }

        public GraphElement GetGraphAction(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new CompareAngleGraphic(this.key, elementData, variables);
        }

        public Element GetAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new CompareAngleAction(key);
        }

        public ActionForm GetActionForm(Element element)
        {
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new CompareAngleForm((CompareAngleAction)element);
        }

        public ActionPanel GetActionPanel(Element element)
        {
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new CompareAnglePanel((CompareAngleAction)element);
        }
    }
}