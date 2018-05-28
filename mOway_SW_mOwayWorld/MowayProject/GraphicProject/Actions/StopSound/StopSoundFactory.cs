using System;
using System.Xml;

using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.StopSound
{
    public class StopSoundFactory : iActionFactory
    {
        #region Attributes

        private string key;

        #endregion

        #region Properties

        public string Key { get { return this.key; } }
        public string Category { get { return StopSound.Category; } }

        #endregion

        public StopSoundFactory()
        {
            this.key = StopSound.Key;
        }

        public Tool GetToolAction()
        {
            return new StopSoundTool(this.key);
        }
        
        public Tool GetToolAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new StopSoundTool(this.key);
        }

        public GraphElement GetGraphAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new StopSoundGraphic(this.key);
        }

        public GraphElement GetGraphAction(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new StopSoundGraphic(this.key, elementData, variables);
        }
        
        public Element GetAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new StopSoundAction(key);
        }

        public ActionForm GetActionForm(Element element)
        {
            throw new ActionFormException(StopSound.ErrorMessage, StopSound.ErrorCaption);
        }

        public ActionPanel GetActionPanel(Element element)
        {
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new StopSoundPanel();
        }
    }
}