using System;
using System.Collections.Generic;

namespace FSM
{
    public enum ProcessState
    {
        Options,
        HUD,
        Pause,
        Death,
        Inventory,
        Skills
    }

    public enum Command
    {
        HUD_Inventory,
        HUD_Death,
        HUD_Pause,
        Pause_HUD,
        Pause_Options,
        Pause_Inventory,
        Death_HUD,
        Options_Pause,
        Inventory_HUD,
        Inventory_Skills,
        Inventory_Pause,
        Skills_HUD,
        Skills_Inventory
    }

    public class Process
    {
        class StateTransition
        {
            readonly ProcessState CurrentState;
            readonly Command Command;

            public StateTransition(ProcessState currentState, Command command)
            {
                CurrentState = currentState;
                Command = command;
            }

            public override int GetHashCode()
            {
                return 17 + 31 * CurrentState.GetHashCode() + 31 * Command.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                StateTransition other = obj as StateTransition;
                return other != null && this.CurrentState == other.CurrentState && this.Command == other.Command;
            }
        }

        Dictionary<StateTransition, ProcessState> transitions;
        public ProcessState CurrentState { get; private set; }

        public Process()
        {
            CurrentState = ProcessState.HUD;
            transitions = new Dictionary<StateTransition, ProcessState>
            {
                { new StateTransition(ProcessState.HUD, Command.HUD_Death), ProcessState.Death },
                { new StateTransition(ProcessState.HUD, Command.HUD_Pause), ProcessState.Pause },
                { new StateTransition(ProcessState.HUD, Command.HUD_Inventory), ProcessState.Inventory },

                { new StateTransition(ProcessState.Death, Command.Death_HUD), ProcessState.HUD },

                { new StateTransition(ProcessState.Pause, Command.Pause_HUD), ProcessState.HUD },
                { new StateTransition(ProcessState.Pause, Command.Pause_Options), ProcessState.Options },
                { new StateTransition(ProcessState.Pause, Command.Pause_Inventory), ProcessState.Inventory },

                { new StateTransition(ProcessState.Options, Command.Options_Pause), ProcessState.Pause },

                { new StateTransition(ProcessState.Inventory, Command.Inventory_HUD), ProcessState.HUD },
                { new StateTransition(ProcessState.Inventory, Command.Inventory_Skills), ProcessState.Skills },
                { new StateTransition(ProcessState.Inventory, Command.Inventory_Pause), ProcessState.Pause },

                { new StateTransition(ProcessState.Skills, Command.Skills_HUD), ProcessState.HUD },
                { new StateTransition(ProcessState.Skills, Command.Skills_Inventory), ProcessState.Inventory }
            };
        }

        public ProcessState GetNext(Command command)
        {
            StateTransition transition = new StateTransition(CurrentState, command);
            ProcessState nextState;
            if (!transitions.TryGetValue(transition, out nextState))
                throw new Exception("Invalid transition: " + CurrentState + " -> " + command);
            return nextState;
        }

        public ProcessState MoveNext(Command command)
        {
            CurrentState = GetNext(command);
            return CurrentState;
        }
    }


  /*  public class Program
    {
        static void Main(string[] args)
        {
            Process p = new Process();
            Console.WriteLine("Current State = " + p.CurrentState);
            Console.WriteLine("Command.Begin: Current State = " + p.MoveNext(Command.Begin));
            Console.WriteLine("Command.Pause: Current State = " + p.MoveNext(Command.Pause));
            Console.WriteLine("Command.End: Current State = " + p.MoveNext(Command.End));
            Console.WriteLine("Command.Exit: Current State = " + p.MoveNext(Command.Exit));
            Console.ReadLine();
        }
    }
    */
}
