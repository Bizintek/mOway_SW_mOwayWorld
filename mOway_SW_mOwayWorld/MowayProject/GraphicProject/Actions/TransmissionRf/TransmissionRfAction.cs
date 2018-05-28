using System;
using System.IO;
using System.Xml;

using Moway.Simulator;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions.TransmissionRf
{
    public class TransmissionRfAction : Conditional
    {
        #region Attributes

        private int direction = 0;
        private Variable[] dataVariable = { null, null, null, null, null, null, null, null };
        private int[] dataValue = { 0, 0, 0, 0, 0, 0, 0, 0 };

        #endregion

        #region Properties

        public int Direction { get { return this.direction; } }
        public Variable[] DataVariable { get { return this.dataVariable; } }
        public int[] DataValue { get { return this.dataValue; } }

        #endregion

        public TransmissionRfAction(string key)
        {
            this.key = key;
        }

        public TransmissionRfAction(string key, int direction, Variable[] dataVariable, int[] dataValue)
        {
            this.key = key;
            this.direction = direction;
            this.dataVariable = dataVariable;
            this.dataValue = dataValue;
        }

        public TransmissionRfAction(string key, XmlElement properties, System.Collections.Generic.SortedList<string, Variable> variables)
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
                        this.direction = System.Convert.ToInt32(property.InnerText);
                        break;
                    case "dataVariables":
                        foreach (XmlElement dataVariable in property.ChildNodes)
                            if (dataVariable.InnerText != "none")
                                this.dataVariable[System.Convert.ToInt32(dataVariable.Name[4])-48] = variables[dataVariable.InnerText];
                        break;
                    case "dataValues":
                        foreach (XmlElement dataValue in property.ChildNodes)
                            this.dataValue[System.Convert.ToInt32(dataValue.Name[4])-48] = System.Convert.ToInt32(dataValue.InnerText);
                        break;
                    default:
                        throw new ProjectException("Error el crear la acción");
                }
            }
        }

        public void UpdateSettings(int direction, Variable[] dataVariable, int[] dataValue)
        {
            this.direction = direction;
            this.dataVariable = dataVariable;
            this.dataValue = dataValue;
        }

        public override bool VariableUsed(Variable variable)
        {
            foreach (Variable dVariable in this.dataVariable)
                if (dVariable == variable)
                    return true;
            return false;
        }

        public override Element Clone()
        {
            return new TransmissionRfAction(this.key, this.direction, this.dataVariable, this.dataValue);
        }

        public override void SaveInFile(XmlWriter file)
        {
            file.WriteStartElement("properties");
            file.WriteElementString("version", "0.1");
            file.WriteElementString("direction", this.direction.ToString());
            file.WriteStartElement("dataVariables");
            for (int i = 0; i < this.dataVariable.Length; i++)
                if (this.dataVariable[i] == null)
                    file.WriteElementString("data" + i, "none");
                else
                    file.WriteElementString("data" + i.ToString(), this.dataVariable[i].Name);
            file.WriteEndElement();
            file.WriteStartElement("dataValues");
            for (int i = 0; i < this.dataValue.Length; i++)
                file.WriteElementString("data" + i, this.dataValue[i].ToString());
            file.WriteEndElement();
            file.WriteEndElement();
        }

        public override void WriteCode(StreamWriter writer, string labelFalse)
        {
            writer.WriteLine(";************Module RfTransmit********************************************");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
            writer.WriteLine("");
            writer.WriteLine("  movlw       ." + this.direction + "		;Dir of receptor");
            writer.WriteLine("  movwf	    RF_DIR_OUT");
            writer.WriteLine("			;Data to send		");
            writer.WriteLine("");
            for (int i = 0; i < 8; i++)
            {

                if (this.dataVariable[i] == null /*"constant"*/)
                {
                    writer.WriteLine("  movlw     ." + this.dataValue[i]);
                    writer.WriteLine("  movwf	    RF_DATA_OUT_" + i);
                }
                else
                {
                    writer.WriteLine("  movf     " + this.dataVariable[i].Name + ",W");
                    writer.WriteLine("  movwf	    RF_DATA_OUT_" + i);
                }
            }
            writer.WriteLine("");
            writer.WriteLine("  call	    RF_SEND		;Send");
            writer.WriteLine("  btfss	    RF_STATUS,SNDOK");
            writer.WriteLine(labelFalse);
            writer.WriteLine("  btfss	    RF_STATUS,ACK	");
            writer.WriteLine(labelFalse);

            writer.WriteLine("");
            writer.WriteLine("");
            writer.WriteLine(";***********************************************************************");
        }

        public override bool Simulate(MowayModel mowayModel)
        {
            byte[] dataSimAux = { 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int simCont = 0; simCont < 8; simCont++)
            {
                if (dataVariable[simCont] == null)
                    dataSimAux[simCont] = (byte)this.dataValue[simCont];
                else
                    dataSimAux[simCont] = (byte)mowayModel.GetRegister(this.dataVariable[simCont].Name).Value;
            }

            mowayModel.Communication.SendMessage((byte)this.direction, dataSimAux);
            return true;
        }
    }
}
