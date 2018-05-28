using System;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

using Moway.Project.GraphicProject.GraphLayout.Elements;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.Actions
{
    public abstract class ActionFactory
    {
        #region Attributes

        private static Hashtable factories = null;

        #endregion

        private static void LoadFactories()
        {
            factories = new Hashtable();

            iActionFactory factory;
            factory = new Free.FreeFactory();
            factories.Add(factory.Key, factory);
            factory = new Straight.StraightMoveFactory();
            factories.Add(factory.Key, factory);

            factory = new Rotate.RotateFactory();
            factories.Add(factory.Key, factory);
            factory = new StopMovement.StopMovementFactory();
            factories.Add(factory.Key, factory);
            factory = new PlaySound.PlaySoundFactory();
            factories.Add(factory.Key, factory);
            factory = new StopSound.StopSoundFactory();
            factories.Add(factory.Key, factory);
            factory = new Lights.LightsFactory();
            factories.Add(factory.Key, factory);

            factory = new Obstacle.ObstacleFactory();
            factories.Add(factory.Key, factory);
            factory = new Line.LineFactory();
            factories.Add(factory.Key, factory);
            factory = new Noise.NoiseFactory();
            factories.Add(factory.Key, factory);
            factory = new Tap.TapFactory();
            factories.Add(factory.Key, factory);

            factory = new Pause.PauseFactory();
            factories.Add(factory.Key, factory);
            factory = new Call.CallFactory();
            factories.Add(factory.Key, factory);
            factory = new Finish.FinishFactory();
            factories.Add(factory.Key, factory);

            factory = new Math.MathFactory();
            factories.Add(factory.Key, factory);
            factory = new Reset.ResetFactory();
            factories.Add(factory.Key, factory);

            factory = new AssignValue.AssignValueFactory();
            factories.Add(factory.Key, factory);
            factory = new AssignTime.AssignTimeFactory();
            factories.Add(factory.Key, factory);
            factory = new AssignSpeed.AssignSpeedFactory();
            factories.Add(factory.Key, factory);
            factory = new AssignDistance.AssignDistanceFactory();
            factories.Add(factory.Key, factory);
            factory = new AssignAngle.AssignAngleFactory();
            factories.Add(factory.Key, factory);
            factory = new AssignBrightness.AssignBrightnessFactory();
            factories.Add(factory.Key, factory);
            factory = new AssignLine.AssignLineFactory();
            factories.Add(factory.Key, factory);
            factory = new AssignObstacle.AssignObstacleFactory();
            factories.Add(factory.Key, factory);
            factory = new AssignAccelerometer.AssignAccelerometerFactory();
            factories.Add(factory.Key, factory);
            factory = new AssignNoise.AssignNoiseFactory();
            factories.Add(factory.Key, factory);
            factory = new AssignTemperature.AssignTemperatureFactory();
            factories.Add(factory.Key, factory);
            factory = new AssignBattery.AssignBatteryFactory();
            factories.Add(factory.Key, factory);

            factory = new CompareVariable.CompareVariableFactory();
            factories.Add(factory.Key, factory);
            factory = new CompareTime.CompareTimeFactory();
            factories.Add(factory.Key, factory);
            factory = new CompareSpeed.CompareSpeedFactory();
            factories.Add(factory.Key, factory);
            factory = new CompareDistance.CompareDistanceFactory();
            factories.Add(factory.Key, factory);
            factory = new CompareAngle.CompareAngleFactory();
            factories.Add(factory.Key, factory);
            factory = new CompareBrightness.CompareBrightnessFactory();
            factories.Add(factory.Key, factory);
            factory = new CompareLine.CompareLineFactory();
            factories.Add(factory.Key, factory);
            factory = new CompareObstacle.CompareObstacleFactory();
            factories.Add(factory.Key, factory);
            factory = new CompareAccelerometer.CompareAccelerometerFactory();
            factories.Add(factory.Key, factory);
            factory = new CompareNoise.CompareNoiseFactory();
            factories.Add(factory.Key, factory);
            factory = new CompareTemperature.CompareTemperatureFactory();
            factories.Add(factory.Key, factory);
            factory = new CompareBattery.CompareBatteryFactory();
            factories.Add(factory.Key, factory);

            factory = new StartRf.StartRfFactory();
            factories.Add(factory.Key, factory);
            factory = new StopRf.StopRfFactory();
            factories.Add(factory.Key, factory);
            factory = new TransmissionRf.TransmissionRfFactory();
            factories.Add(factory.Key, factory);
            factory = new ReceptionRf.ReceptionRfFactory();
            factories.Add(factory.Key, factory);
            factory = new ConfigIo.ConfigIoFactory();
            factories.Add(factory.Key, factory);
            factory = new CheckIn.CheckInFactory();
            factories.Add(factory.Key, factory);
            factory = new SetOut.SetOutFactory();
            factories.Add(factory.Key, factory);
            factory = new PlayCamera.PlayCameraFactory();
            factories.Add(factory.Key, factory);
            factory = new StopCamera.StopCameraFactory();
            factories.Add(factory.Key, factory);
        }

        public static List<Tool> GetToolsAction(string category)
        {
            if (factories == null)
                LoadFactories();
            List<Tool> tools = new List<Tool>();
            foreach (iActionFactory factory in factories.Values)
                if (factory.Category == category)
                    tools.Add(factory.GetToolAction());
            tools.Sort();
            return tools;
        }

        public static Tool GetToolAction(string key)
        {
            if (factories == null)
                LoadFactories();
            iActionFactory actionFactory = (iActionFactory)factories[key];
            if (actionFactory == null)
                throw new ActionException("Key not defined");
            return actionFactory.GetToolAction(key);
        }

        public static GraphElement GetGraphAction(string key)
        {
            if (factories == null)
                LoadFactories();
            iActionFactory actionFactory = (iActionFactory)factories[key];
            if (actionFactory == null)
                throw new ActionException("Key not defined");
            return actionFactory.GetGraphAction(key);
        }

        public static GraphElement GetGraphAction(string key, XmlElement elementData, SortedList<string, Variable> variables)
        {
            if (factories == null)
                LoadFactories();
            iActionFactory actionFactory = (iActionFactory)factories[key];
            if (actionFactory == null)
                throw new ActionException("Key not defined");
            return actionFactory.GetGraphAction(key, elementData, variables);
        }

        public static Element GetAction(string key)
        {
            if (factories == null)
                LoadFactories();
            iActionFactory actionFactory = (iActionFactory)factories[key];
            if (actionFactory == null)
                throw new ActionException("Key not defined");
            return actionFactory.GetAction(key);
        }

        public static ActionForm GetActionForm(Element element)
        {
            if (factories == null)
                LoadFactories();
            iActionFactory actionFactory = (iActionFactory)factories[element.Key];
            if (actionFactory == null)
                throw new ActionException("Key not defined");
            return actionFactory.GetActionForm(element);
        }

        public static ActionPanel GetActionPanel(Element element)
        {
            if (factories == null)
                LoadFactories();
            iActionFactory actionFactory = (iActionFactory)factories[element.Key];
            if (actionFactory == null)
                throw new ActionException("Key not defined");
            return actionFactory.GetActionPanel(element);
        }

    }
}
