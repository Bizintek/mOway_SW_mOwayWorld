using System;
using System.Xml;

using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.AssignAngle
{
    public class AssignAngleFactory : iActionFactory
    {
        #region Atributtes

        private string key;

        #endregion

        #region Properties

        public string Key { get { return this.key; } }
        public string Category { get { return AssignAngle.Category; } }

        #endregion

        public AssignAngleFactory()
        {
            this.key = AssignAngle.Key;
        }

        public Tool GetToolAction()
        {
            return new AssignAngleTool(this.key);
        }
        
        public Tool GetToolAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new AssignAngleTool(this.key);
        }

        public GraphElement GetGraphAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new AssignAngleGraphic(this.key);
        }

        public GraphElement GetGraphAction(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new AssignAngleGraphic(this.key, elementData, variables);
        }

        public Element GetAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new AssignAngleAction(key);
        }

        public ActionForm GetActionForm(Element element)
        {
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new AssignAngleForm((AssignAngleAction)element);
        }

        public ActionPanel GetActionPanel(Element element)
        {
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new AssignAnglePanel((AssignAngleAction)element);
        }
    }
}