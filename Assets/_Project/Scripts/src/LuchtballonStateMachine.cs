using System.Collections.Generic;

namespace timeloop {
    public class LuchtballonStateMachine : State {
        private State currentState;
        private Dictionary<string, State> phases = new Dictionary<string, State>();


        public void AddPhase(string phaseName, State state) {
            phases[phaseName] = state;
        }

        public void ChangePhase(string phaseName) {
            if (currentState != null) {
                currentState.Exit();
            }

            currentState = phases[phaseName];
            currentState.Enter();
        }
        
        public override void Tick() {
            currentState.Tick();
        }
    }
}