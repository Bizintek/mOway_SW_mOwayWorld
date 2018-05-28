using System;
using System.Xml;

using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.StopCamera
{
    public class StopCameraFactory : iActionFactory
    {
        #region Attributes

        private string key;

        #endregion

        #region Properties

        public string Key { get { return this.key; } }
        public string Category { get { return StopCamera.Category; } }

        #endregion

        public StopCameraFactory()
        {
            this.key = StopCamera.Key;
        }

        public Tool GetToolAction()
        {
            return new StopCameraTool(this.key);
        }
        
        public Tool GetToolAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new StopCameraTool(this.key);
        }

        public GraphElement GetGraphAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new StopCameraGraphic(this.key);
        }

        public GraphElement GetGraphAction(string key, XmlElement elementData, System.Collections.Generic.SortedList<string, Variable> variables)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new StopCameraGraphic(this.key, elementData, variables);
        }

        public Element GetAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new StopCameraAction(key);
        }

        public ActionForm GetActionForm(Element element)
        {
            throw new ActionFormException(StopCamera.ErrorMessage, StopCamera.ErrorCaption);
        }

        public ActionPanel GetActionPanel(Element element)
        {
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new StopCameraPanel();
        }
    }
}