using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;

using Moway.Simulator;
using Moway.Simulator.Registers;
using Moway.Project.GraphicProject.GraphLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;
using Moway.Project.GraphicProject.Actions.Call;

namespace Moway.Project.GraphicProject.Simulator
{
    /// <summary>
    /// Simulator for the Graphic project
    /// </summary>
    /// <LastRevision>27.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class GraphSimulator : ISimulator
    {
        #region Attributes

        /// <summary>
        /// Saves the state in which the simulator is located
        /// </summary>
        private SimState state = SimState.Inactive;
        /// <summary>
        /// Main function of the project
        /// </summary>
        private GraphDiagram mainFunction;
        /// <summary>
        /// All the functions of the project
        /// </summary>
        private SortedList<string, GraphDiagram> functions = new SortedList<string,GraphDiagram>();
        /// <summary>
        /// Project variable list
        /// </summary>
        private List<Variable> variables;
        /// <summary>
        /// Current function in which the simulator is located
        /// </summary>
        private GraphDiagram presentFunction;
        /// <summary>
        /// Temporary function for the correct simulation indicator update
        /// </summary>
        private GraphDiagram tempFunction;
        /// <summary>
        /// Current simulation action
        /// </summary>
        private GraphElement presentElement;
        /// <summary>
        /// Simulated model of the Moway about it is being simulated
        /// </summary>
        private MowayModel mowayModel;
        /// <summary>
        /// Indicates whether the simulator needs to be reset
        /// </summary>
        private bool requireReset;
        /// <summary>
        /// Indicates whether the simulator requires a validation of the functions
        /// </summary>
        private bool requireValidate;
        /// <summary>
        /// Saves call return items to functions
        /// </summary>
        private Stack<SimPointer> functionCallstack = new Stack<SimPointer>();
        /// <summary>
        /// Simulation Thread
        /// </summary>
        private Thread simulatorThread;
        /// <summary>
        /// Shared Variable to stop the simulation
        /// </summary>
        private bool stopSimulate;
        /// <summary>
        /// Graphic Simulation Trace Indicator
        /// </summary>
        private GraphTrace graphTrace = new GraphTrace();

        #endregion

        #region Properties

        /// <summary>
        /// Simulator status
        /// </summary>
        public SimState State { get { return this.state; } }
        /// <summary>
        /// Simulated model of the Moway about it is being simulated
        /// </summary>
        public MowayModel MowayModel { get { return this.mowayModel; } }
        /// <summary>
        /// Indicates that a simulator reset is required
        /// </summary>
        public bool RequireReset { get { return this.requireReset; } }
        /// <summary>
        /// Indicates that the project functions need to be validated
        /// </summary>
        public bool RequireValidate
        {
            get { return this.requireValidate; }
            set { this.requireValidate = value; }
        }

        #endregion

        #region Events

        /// <summary>
        /// Changing the Simulator status
        /// </summary>
        public event EventHandler StateChanged;
        public event EventHandler SimulationFinished;

        #endregion

        #region Singleton Pattern Implementation

        /// <summary>
        /// Simulator instance
        /// </summary>
        private static GraphSimulator instance = null;

        /// <summary>
        /// Returns a graphical instance Simulator
        /// </summary>
        /// <returns>Graphic simulator</returns>
        public static GraphSimulator GetSimulator()
        {
            if (instance == null)
                instance = new GraphSimulator();
            return instance;
        }

        /// <summary>
        /// Privater Builder 
        /// </summary>
        private GraphSimulator() 
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Activates the simulator by loading the necessary information from the project to simulate
        /// </summary>
        /// <param name="mainFunction"></param>
        /// <param name="functions"></param>
        /// <param name="variables"></param>
        public void ActivateSimulator(GraphDiagram mainFunction, List<GraphDiagram> functions, List<Variable> variables)
        {
            //The simulator state is changed
            this.state = SimState.Pause;
            if (this.StateChanged != null)
                this.StateChanged(this, new EventArgs());
            //The project information is saved to simulate
            this.mainFunction = mainFunction;
            //The functions are saved and the simulation layers are visible
            foreach (GraphDiagram function in functions)
            {
                function.SimulatorLayer.Visible = true;
                this.functions.Add(function.Name, function);
            }
            this.variables = variables;
            //A simulated Moway model is loaded
            this.mowayModel = new MowayModel();
            //Records are loaded to the MOway model
            List<Register> registers = new List<Register>();
            foreach (Variable variable in this.variables)
                registers.Add(new Register(variable.Name, variable.InitValue));
            this.mowayModel.LoadRegisters(registers);
            //The first element to simulate is indicated
            this.presentFunction = this.mainFunction;
            this.presentElement = this.presentFunction.StartElement;
            //Indicates that a function validation is required
            this.requireValidate = true;
            //The simulation indicator is displayed in the current function and its position is updated
            this.presentFunction.SimulatorLayer.Add(this.graphTrace);
            this.UpdateTrace(this.mainFunction, this.mainFunction.StartElement);
        }

        /// <summary>
        /// Disables the simulator by deleting the project information
        /// </summary>
        public void DeactivateSimulator()
        {
            //If the simulator is running, it stops
            if (this.state == SimState.Running)
            {
                this.stopSimulate = true;
                this.simulatorThread.Join();
                this.state = SimState.Pause;
                if (this.StateChanged != null)
                    this.StateChanged(this, new EventArgs());
            }
            //All simulation layers are hidden from all functions
            foreach (GraphDiagram function in this.functions.Values)
                function.SimulatorLayer.Visible = false;
            //The stroke indicator of the current function is removed
            this.presentFunction.SimulatorLayer.Remove(this.graphTrace);
            this.presentFunction.SimulatorLayer.UpdateSurface();
            //The Simulator status is updated
            this.state = SimState.Inactive;
            if (this.StateChanged != null)
                this.StateChanged(this, new EventArgs());
            //Project information is deleted to simulate
            this.mainFunction = null;
            this.functions.Clear();
            this.variables = null;
            //The simulated model of the Moway is eliminated
            this.mowayModel = null;
        }

        /// <summary>
        /// The simulator is indicated that the functions have been validated to allow the simulation
        /// </summary>
        public void FunctionsValidated()
        {
            this.requireValidate = false;
            this.ResetSimulator();
        }

        /// <summary>
        /// Add a new variable to the simulator
        /// </summary>
        /// <param name="variable">New variable</param>
        public void AddVariable(Variable variable)
        {
            if (this.variables.Contains(variable))
                throw new SimulatorException("Simulator already constain this variable");
            this.variables.Add(variable);
            this.mowayModel.AddRegister(new Register(variable.Name, variable.InitValue));
            this.requireReset = true;
        }

        /// <summary>
        /// Removes a variable from the simulator
        /// </summary>
        /// <param name="variable">Variable to remove</param>
        public void RemoveVariable(Variable variable)
        {
            if (!this.variables.Contains(variable))
                throw new SimulatorException("Simulator don't constain this variable");
            this.variables.Remove(variable);
            this.mowayModel.RemoveRegister(variable.Name);
            this.requireReset = true;
        }

        /// <summary>
        /// Updates the name of a variable
        /// </summary>
        /// <param name="prevName">Previous name of the variable</param>
        /// <param name="variable">Variable to update</param>
        public void UpdateVariable(string prevName, Variable variable)
        {
            if (variable.Name != prevName)
                this.mowayModel.RenameRegister(prevName, variable.Name);
            this.requireReset =true;
        }

        /// <summary>
        /// Add a new feature
        /// </summary>
        /// <param name="function">New Function</param>
        public void AddFunction(GraphDiagram function)
        {
            if (this.functions.ContainsValue(function))
                throw new SimulatorException("Simulator already constain this function");
            function.SimulatorLayer.Visible = true;
            this.functions.Add(function.Name, function);
            this.requireValidate = true;
        }

        /// <summary>
        /// Removes a function
        /// </summary>
        /// <param name="function">function to delete</param>
        public void RemoveFunction(GraphDiagram function)
        {
            if (!this.functions.ContainsValue(function))
                throw new SimulatorException("Simulator don't constain this function");
            this.functions.Remove(function.Name);
            this.requireValidate = true;
        }

        /// <summary>
        /// Updates the name of a function
        /// </summary>
        /// <param name="prevName">Previous name of the function</param>
        /// <param name="function">function to update</param>
        public void UpdateFunction(string prevName, GraphDiagram function)
        {
            this.functions.Remove(prevName);
            this.functions.Add(function.Name, function);
        }

        #endregion

        #region Public methods de la interfaz

        /// <summary>
        /// Launches simulation execution
        /// </summary>
        public void Run()
        {
            if (this.requireValidate)
                throw new SimulatorException("Functions are note validated");
            if (this.requireReset)
                this.ResetSimulator();
            //The Simulator status is updated
            this.state = SimState.Running;
            if (this.StateChanged != null)
                this.StateChanged(this, new EventArgs());
            //The arrow is hidden and the simulation layer is updated
            this.graphTrace.Visible = false;
            this.presentFunction.SimulatorLayer.UpdateSurface();
            //The thread is created and its execution is launched
            this.simulatorThread = new Thread(new ThreadStart(this.ExecuteRun));
            this.stopSimulate = false;
            this.simulatorThread.Start();
        }

        /// <summary>
        /// Launches simulation execution in animate mode
        /// </summary>
        public void Animate()
        {
            if (this.requireValidate)
                throw new SimulatorException("Functions are note validated");
            if (this.requireReset)
                this.ResetSimulator();
            //The Simulator status is updated
            this.state = SimState.Running;
            if (this.StateChanged != null)
                this.StateChanged(this, new EventArgs());
            //The thread is created and its execution is launched
            this.simulatorThread = new Thread(new ThreadStart(this.ExecuteAnimate));
            this.stopSimulate = false;
            this.simulatorThread.Start();
        }

        /// <summary>
        /// Stop the simulation
        /// </summary>
        public void Pause()
        {
            //The simulation process stops
            this.stopSimulate = true;
        }

        /// <summary>
        /// Reset the simulation
        /// </summary>
        public void Reset()
        {
            //If you are simulating, Stop the simulation
            if (this.state == SimState.Running)
                this.Pause();
            //The simulator is reset
            this.ResetSimulator();
        }

        /// <summary>
        /// Executes an action in the simulation, entering a subfunction if it were the case
        /// </summary>
        public void StepIn()
        {
            if (this.requireValidate)
                throw new SimulatorException("Functions are note validated");
            if (this.requireReset)
                this.ResetSimulator();
            //The Simulator status is updated
            this.state = SimState.Running;
            if (this.StateChanged != null)
                this.StateChanged(this, new EventArgs());
            //The thread is created and its execution is launched
            this.simulatorThread = new Thread(new ThreadStart(this.ExecuteStepIn));
            this.simulatorThread.Start();
        }

        /// <summary>
        /// Executes an action in the simulation, executing a complete subfunction if it were the case
        /// </summary>
        public void StepOver()
        {
            if (this.requireValidate)
                throw new SimulatorException("Functions are note validated");
            if (this.requireReset)
                this.ResetSimulator();
            //If the current item is not a CallGraphics, a StepIn is made
            if (!(this.presentElement is CallGraphic))
                this.StepIn();
            else
            {
                //The Simulator status is updated
                this.state = SimState.Running;
                if (this.StateChanged != null)
                    this.StateChanged(this, new EventArgs());
                //The thread is created and its execution is launched
                this.simulatorThread = new Thread(new ThreadStart(this.ExecuteStepOver));
                this.stopSimulate = false;
                this.simulatorThread.Start();
            }
        }

        #endregion

        #region Private methods para la simulación en un hilo paralelo

        /// <summary>
        /// function for the normal execution thread of the simulation
        /// </summary>
        private void ExecuteRun()
        {
            this.mowayModel.StartSimulation();
            //As long as the simulation does not stop
            while (true)
            {
                if (this.stopSimulate)
                {
                    this.graphTrace.Visible = true;
                    this.UpdateTrace(this.tempFunction, this.presentElement);
                    this.state = SimState.Pause;
                    if (this.StateChanged != null)
                        this.StateChanged(this, new EventArgs());
                    this.mowayModel.PauseSimulation();
                    break;
                }
                SimPointer next = this.SimulateAction(this.tempFunction, this.presentElement);
                if (next == null)   //The end of the simulation has been reached
                {
                    //The end of the simulation has been reached
                    this.graphTrace.Visible = true;
                    this.UpdateTrace(this.tempFunction, this.presentElement);
                    //The Simulator status is updated
                    this.state = SimState.Stop;
                    if (this.StateChanged != null)
                        this.StateChanged(this, new EventArgs());
                    this.mowayModel.PauseSimulation();
                    if (this.SimulationFinished != null)
                        this.SimulationFinished(this, new EventArgs());
                    break;
                }
                else
                {
                    this.tempFunction = next.Function;
                    this.presentElement = next.Element;
                }
                System.Threading.Thread.Sleep(10);                
            }
        }

        /// <summary>
        /// function for execution thread in animate simulation mode
        /// </summary>
        private void ExecuteAnimate()
        {
            this.mowayModel.StartSimulation();
            //As long as the simulation does not stop
            while (true)
            {
                if (this.stopSimulate)
                {
                    this.state = SimState.Pause;
                    if (this.StateChanged != null)
                        this.StateChanged(this, new EventArgs());
                    this.mowayModel.PauseSimulation();
                    break;
                }
                SimPointer next = this.SimulateAction(this.presentFunction, this.presentElement);
                if (next == null)   //The end of the simulation has been reached
                {
                    //The simulation indicator is displayed and updated
                    this.UpdateTrace(this.presentFunction, this.presentElement);
                    //The Simulator status is updated
                    this.state = SimState.Stop;
                    if (this.StateChanged != null)
                        this.StateChanged(this, new EventArgs());
                    this.mowayModel.PauseSimulation();
                    if (this.SimulationFinished != null)
                        this.SimulationFinished(this, new EventArgs());
                    break;
                }
                else
                    this.UpdateTrace(next.Function, next.Element);
                //The model is indicated that the simulation should be paused in the intermediate time between each of the actions to simulate
                this.mowayModel.PauseSimulation();
                System.Threading.Thread.Sleep(500);
                this.mowayModel.StartSimulation();
            }
        }

        /// <summary>
        /// function for execution thread in animate simulation mode
        /// </summary>
        private void ExecuteStepIn()
        {
            this.mowayModel.StartSimulation();
            SimPointer next = this.SimulateAction(this.presentFunction, this.presentElement);
            if (next == null)   //The end of the simulation has been reached
            {
                //The Simulator status is updated
                this.state = SimState.Stop;
                if (this.StateChanged != null)
                    this.StateChanged(this, new EventArgs());
                this.mowayModel.PauseSimulation();
                if (this.SimulationFinished != null)
                    this.SimulationFinished(this, new EventArgs());
            }
            else
            {
                //The simulation indicator is displayed and updated
                this.UpdateTrace(next.Function, next.Element);
                //The Simulator status is updated
                this.state = SimState.Pause;
                if (this.StateChanged != null)
                    this.StateChanged(this, new EventArgs());
                this.mowayModel.PauseSimulation();
            }
        }

        /// <summary>
        /// function for simulation execution thread StepOver
        /// </summary>
        private void ExecuteStepOver()
        {
            this.mowayModel.StartSimulation();
            int stackLevel = this.functionCallstack.Count;
            //As long as the simulation does not stop
            while (true)
            {
                if (this.stopSimulate)
                {
                    this.UpdateTrace(this.tempFunction, this.presentElement);
                    this.state = SimState.Pause;
                    if (this.StateChanged != null)
                        this.StateChanged(this, new EventArgs());
                    this.mowayModel.PauseSimulation();
                    break;
                }
                SimPointer next = this.SimulateAction(this.tempFunction, this.presentElement);
                if (next == null)   //The end of the simulation has been reached
                {
                    //The simulation indicator is displayed and updated
                    this.UpdateTrace(this.tempFunction, this.presentElement);
                    //The Simulator status is updated
                    this.state = SimState.Stop;
                    if (this.StateChanged != null)
                        this.StateChanged(this, new EventArgs());
                    this.mowayModel.PauseSimulation();
                    if (this.SimulationFinished != null)
                        this.SimulationFinished(this, new EventArgs());
                    break;
                }
                else
                {
                    //If there are the same items in the function return stack you have finished the StepOver
                    if (this.functionCallstack.Count == stackLevel)
                    {
                        //The simulation indicator is displayed and updated
                        this.UpdateTrace(this.presentFunction, next.Element);
                        //The Simulator status is updated
                        this.state = SimState.Pause;
                        if (this.StateChanged != null)
                            this.StateChanged(this, new EventArgs());
                        this.mowayModel.PauseSimulation();
                        break;
                    }
                    else
                    {
                        this.tempFunction = next.Function;
                        this.presentElement = next.Element;
                    }
                }
            }
            System.Threading.Thread.Sleep(10);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Completely reset the simulator
        /// </summary>
        private void ResetSimulator()
        {
            //indicated that a reset is not necessary
            this.requireReset = false;
            //The simulator indicator is updated with new references
            this.UpdateTrace(this.mainFunction, this.mainFunction.StartElement);
            this.tempFunction = presentFunction;
            //The function returns stack is cleaned
            this.functionCallstack.Clear();
            //Model records are reset
            foreach (Variable variable in this.variables)
                this.mowayModel.GetRegister(variable.Name).Value = variable.InitValue;
            //Model is reset
            this.mowayModel.ResetSimulation();
            //The simulated state is updated if it is different from Pause
            if (this.state != SimState.Pause)
            {
                this.state = SimState.Pause;
                if (this.StateChanged != null)
                    this.StateChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Simulates a function element and returns the next element to simulate
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private SimPointer SimulateAction(GraphDiagram function, GraphElement element)
        {
            GraphElement nextElement;
            //If it is a module
            if (this.presentElement is GraphModule)
            {
                if (this.presentElement is CallGraphic)
                {
                    //It gets the following item after you run the function
                    nextElement = this.presentElement.Next;
                    while (nextElement is GraphArrow)
                        nextElement = nextElement.Next;
                    //Saved in the function returns stack
                    this.functionCallstack.Push(new SimPointer(this.presentFunction, nextElement));
                    //The new function and the start element are returned
                    return new SimPointer(this.functions[((CallAction)this.presentElement.Element).Function.Name], this.functions[((CallAction)this.presentElement.Element).Function.Name].StartElement);
                }
                else
                {
                    this.presentElement.Simulate(this.mowayModel);
                    nextElement = this.presentElement.Next;
                }
            }
            else if (this.presentElement is GraphConditional)
            // It just remains to be a conditional
            {
                if (((GraphConditional)this.presentElement).Simulate(this.mowayModel))
                    nextElement = ((GraphConditional)this.presentElement).NextTrue;
                else
                    nextElement = ((GraphConditional)this.presentElement).NextFalse;
            }
            else if (this.presentElement is GraphStart)
                nextElement = this.presentElement.Next;
            else if (this.presentElement is GraphFinish)
            {
                if (this.functionCallstack.Count == 0)
                    return null;
                else
                    return this.functionCallstack.Pop();
            }
            else
                throw new SimulatorException("This element can't be simulated");
            //The following simulatable element is searched
            while (nextElement is GraphArrow)
                nextElement = nextElement.Next;
            return new SimPointer(function, nextElement);
        }

        /// <summary>
        /// Updates the stroke flag in the simulation graphical layer (updates the function and current element if they were different from the function parameters)
        /// </summary>
        /// <param name="function"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        private void UpdateTrace(GraphDiagram function, GraphElement element)
        {
            //The item to be noted is updated if it is not the same as the current
            if (this.presentElement != element)
                this.presentElement = element;
            //The stroke is placed on the current element
            if ((this.presentElement is GraphStart) || (this.presentElement is GraphFinish))
                this.graphTrace.Position = new Point(this.presentElement.Position.X - 12, this.presentElement.Position.Y + 3);
            else if (this.presentElement is GraphModule)
                this.graphTrace.Position = new Point(this.presentElement.Position.X - 14, this.presentElement.Position.Y + 9);
            else if (this.presentElement is GraphConditional)
                this.graphTrace.Position = new Point(this.presentElement.Position.X - 6, this.presentElement.Position.Y + 19);
            else
                throw new SimulatorException("Ningún otro elemento puede ser apuntado por la flecha");
            //Update the simulation layer of the current function
            if (this.presentFunction != function)
            {
                this.presentFunction.SimulatorLayer.Remove(this.graphTrace);
                this.presentFunction.SimulatorLayer.UpdateSurface();
                this.presentFunction = function;
                this.presentFunction.SimulatorLayer.Add(this.graphTrace);
            }
            this.presentFunction.SimulatorLayer.UpdateSurface();
        }

        #endregion
    }
}
