using System;
using System.Xml;

using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.CompareAccelerometer
{
    public class CompareAccelerometerFactory : iActionFactory
    {
        #region Attributes

        private string key;

        #endregion

        #region Properties

        public string Key { get { return this.key; } }
        public string Category { get { return CompareAccelerometer.Category; } }

        #endregion

        public CompareAccelerometerFactory()
        {
            this.key = CompareAccelerometer.Key;
        }

        public Tool GetToolAction()
        {
            return new CompareAccelerometerTool(this.key);
        }

        public Tool GetToolAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new CompareAccelerometerTool(this.key);
        }

        public GraphElement GetGraphAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new CompareAccelerometerGraphic(this.key);
        }

        public GraphElement GetGraphAction(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new CompareAccelerometerGraphic(this.key, elementData, variables);
        }

        public Element GetAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new CompareAccelerometerAction(key);
        }

        public ActionForm GetActionForm(Element element)
        {
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new CompareAccelerometerForm((CompareAccelerometerAction)element);
        }

        public ActionPanel GetActionPanel(Element element)
        {
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new CompareAccelerometerPanel((CompareAccelerometerAction)element);
        }
    }
}