using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Actions
{
    public enum Side { Right = 0, Left }

    public enum Direction { Forward = 0, Backward }

    public enum FlowchartControl { Continuously, FinishTime, FinishDistance, FinishAngle }

    public enum LogicOp { And = 0, Or }

    public enum ComparativeOp { Equal = 0, Distinct, Bigger, BiggerEqual, Smaller, SmallerEqual}

    public enum ArithmeticOp { Add = 0, Sub }

    public enum AccelerometerAxis { X, Y, Z }

    public enum ObstacleSensor { Right = 0, UpperRight, Left, UpperLeft }

    public enum IoType { Input, Output };

    public enum IoValue { NoChange, On, Off, Toggle };

    public interface IAction
    {
    }
}
