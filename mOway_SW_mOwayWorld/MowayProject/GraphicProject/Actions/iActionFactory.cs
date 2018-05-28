using System;
using System.Xml;
using System.Collections.Generic;

using Moway.Project.GraphicProject.GraphLayout.Elements;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions
{
    public interface iActionFactory
    {
        #region Properties

        string Key { get; }
        string Category { get; }

        #endregion

        #region Methods

        Tool GetToolAction();
        Tool GetToolAction(string key);
        GraphElement GetGraphAction(string key);
        GraphElement GetGraphAction(string key, XmlElement elementData, SortedList<string, Variable> variables);
        Element GetAction(string key);
        ActionForm GetActionForm(Element element);
        ActionPanel GetActionPanel(Element element);

        #endregion
    }
}
