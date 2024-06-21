using System.Collections.Generic;

namespace timeloop {
    public class LuchtballonPhaseMachine : State {
        private State currentState;
        private Dictionary<string, State> states = new();
        private BossLuchtballon.BossData bossData;

        public LuchtballonPhaseMachine(BossLuchtballon.BossData bossData) : base(bossData) {
            this.bossData = bossData;
        }

        public void AddPhase(string stateName, State state) {
            states[stateName] = state;
        }

        public void ChangeState(string phaseName) {
            if (currentState != null) {
                currentState.Exit();
            }

            currentState = states[phaseName];
            currentState.Enter();
        }

        public override void Tick() {
            if (currentState != null) {
                currentState.Tick();
            }
        }
    }
}