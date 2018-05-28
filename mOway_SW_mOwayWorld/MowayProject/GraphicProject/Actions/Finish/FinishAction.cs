using System;
using System.Collections;
using System.Xml;

using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.Finish
{
    public class FinishAction : Moway.Project.GraphicProject.DiagramLayout.Elements.Finish
    {
        public FinishAction(string key)
        {
            this.key = key;
        }


        public FinishAction(string key, XmlElement properties)
        {
            this.key = key;
            if (properties.Name != "properties")
                throw new ActionException("Can't create the action");
            foreach (XmlElement property in properties.ChildNodes)
            {
                switch (property.Name)
                {
                    case "version":
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteEndElement();
        }

        public override Element Clone()
        {
            return new FinishAction(this.key);
        }
    }
}
