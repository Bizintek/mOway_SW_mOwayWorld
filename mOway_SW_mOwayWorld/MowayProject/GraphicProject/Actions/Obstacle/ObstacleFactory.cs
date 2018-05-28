using System;
using System.Xml;
using System.Collections.Generic;

using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Obstacle
{
    public class ObstacleFactory : iActionFactory
    {
        #region Attributes

        private string key;

        #endregion

        #region Properties

        public string Key { get { return this.key; } }
        public string Category { get { return Obstacle.Category; } }

        #endregion

        public ObstacleFactory()
        {
            this.key = Obstacle.Key;
        }

        public Tool GetToolAction()
        {
            return new ObstacleTool(this.key);
        }

        public Tool GetToolAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new ObstacleTool(this.key);
        }

        public GraphElement GetGraphAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new ObstacleGraphic(this.key);
        }

        public GraphElement GetGraphAction(string key, XmlElement elementData, SortedList<string,Variable> variables)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new ObstacleGraphic(this.key, elementData);
        }

        public Element GetAction(string key)
        {
            if (this.key != key)
                throw new ActionException("Key is not correct");
            return new ObstacleAction(key);
        }

        public ActionForm GetActionForm(Element element)
        {
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new ObstacleForm((ObstacleAction)element);
        }

        public ActionPanel GetActionPanel(Element element)
        {
            if (this.key != element.Key)
                throw new ActionException("Key is not correct");
            return new ObstaclePanel((ObstacleAction)element);
        }

    }
}