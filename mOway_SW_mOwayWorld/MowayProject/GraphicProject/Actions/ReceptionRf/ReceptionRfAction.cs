using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.ReceptionRf
{
    public class ReceptionRfAction : Conditional
    {
        #region Attributes

        private Variable direction = null;
        private Variable[] dataVariable = { null, null, null, null, null, null, null, null };

        #endregion

        #region Properties

        public Variable Direction { get { return this.direction; } }
        public Variable[] Data { get { return this.dataVariable; } }

        #endregion

        public ReceptionRfAction(string key)
        {
            this.key = key;
        }

        public ReceptionRfAction(string key, Variable direction, Variable[] dataVariable)
        {
            this.key = key;
            this.direction = direction;
            this.dataVariable = dataVariable;
        }

        public ReceptionRfAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                    case "direction":
                        if (property.InnerText != "none")
                            this.direction = variables[property.InnerText];
                        break;
                    case "dataVariables":
                        foreach (XmlElement dataVariable in property.ChildNodes)
                            if (dataVariable.InnerText != "none")
                                this.dataVariable[System.Convert.ToInt32(dataVariable.Name[4])-48] = variables[dataVariable.InnerText];
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(Variable direction, Variable[] dataVariable)
        {
            this.direction = direction;
            this.dataVariable = dataVariable;
        }

        public override bool VariableUsed(Variable variable)
        {
            if (this.direction == variable)
                return true;
            foreach (Variable dVariable in this.dataVariable)
                if (dVariable == variable)
                    return true;
            return false;
        }

        public override Element Clone()
        {
            return new ReceptionRfAction(this.key, this.direction, this.dataVariable);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            if (this.direction == null)
                file.WriteElementString("direction", "none");
            else
                file.WriteElementString("direction", this.direction.Name);
            file.WriteStartElement("dataVariables");
            for (int i = 0; i < this.dataVariable.Length; i++)
                if (this.dataVariable[i] == null)
                    file.WriteElementString("data" + i, "none");
                else
                    file.WriteElementString("data" + i, this.dataVariable[i].Name);
            file.WriteEndElement();
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer, string labelFalse)
        {
            writer.WriteLine(";************Module RfReceive********************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
            writer.WriteLine("  call		RF_RECEIVE	");
            writer.WriteLine("  btfss		RF_STATUS,RCVOK");
            writer.WriteLine(labelFalse);
          
            if (this.direction != null)
            {
                writer.WriteLine("  movf     RF_DIR_IN" + ",W");
                writer.WriteLine("  movwf    " + this.direction.Name);
            }

            for (int i = 0; i < 8; i++)
            {
                if (this.dataVariable[i] != null)
                {
                    writer.WriteLine("  movf     RF_DATA_IN_" + i + ",W");
                    writer.WriteLine("  movwf    " + this.dataVariable[i].Name);
                }
            }

            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
        }

        public override bool Simulate(MowayModel mowayModel)
        {
            Moway.Simulator.Communications.Message rxedMessage = null;

            if (mowayModel.Communication.MessageReceived())
            {
                rxedMessage = mowayModel.Communication.GetMessage();

                if (this.direction != null)
                    mowayModel.GetRegister(this.direction.Name).Value = rxedMessage.Direction;
                for (int simCont = 0; simCont < 8; simCont++)
                {
                    if (this.dataVariable[simCont] != null)
                        mowayModel.GetRegister(this.dataVariable[simCont].Name).Value = rxedMessage.Data[simCont];
                }
                return true;
            }
            else
                return false;
        }
    }
}
