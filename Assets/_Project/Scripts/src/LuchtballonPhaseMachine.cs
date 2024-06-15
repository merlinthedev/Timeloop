using System.Collections.Generic;

namespace timeloop {
    public class LuchtballonPhaseMachine : State {
        private State currentPhase;
        private Dictionary<string, State> phases = new();
        private BossLuchtballon.BossData bossData;

        public LuchtballonPhaseMachine(BossLuchtballon.BossData bossData) : base(bossData) {
            this.bossData = bossData;
        }

        public void AddPhase(string phaseName, State phaseState) {
            phases[phaseName] = phaseState;
        }

        public void ChangeState(string phaseName) {
            if (currentPhase != null) {
                currentPhase.Exit();
            }

            currentPhase = phases[phaseName];
            currentPhase.Enter();
        }

        public override void Tick() {
            if (currentPhase != null) {
                currentPhase.Tick();
            }
        }
    }
}