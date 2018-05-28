using System;
using System.Xml;
using System.Collections.Generic;

using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Lights
{
    public class LightsFactory : iActionFactory
    {
        #region Attributes

        private string key;

        #endregion

        #region Properties

        public string Key { get { return this.key; } }
        public string Category { get { return Lights.Category; } }

        #endregion

        public LightsFactory()
        {
            this.key = Lights.Key;
        }

        public Tool GetToolAction()
        {
            return new LightsTool(this.key);
        }
        
        public Tool GetToolAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new LightsTool(this.key);
        }

        public GraphElement GetGraphAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new LightsGraphic(this.key);
        }

        public GraphElement GetGraphAction(string key, XmlElement elementData, SortedList<string,Variable> variables)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new LightsGraphic(this.key, elementData);
        }

        public Element GetAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new LightsAction(key);
        }

        public ActionForm GetActionForm(Element element)
        {
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new LightsForm((LightsAction)element);
        }

        public ActionPanel GetActionPanel(Element element)
        {
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new LightsPanel((LightsAction)element);
        }
    }
}