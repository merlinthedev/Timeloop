using System.Collections.Generic;
using UnityEngine.Rendering;

namespace timeloop {
    public class LuchtballonStateMachine : State {
        private State currentState;
        private Dictionary<string, State> phases = new();
        private BossLuchtballon.BossData bossData;

        public LuchtballonStateMachine(BossLuchtballon.BossData bossData) : base(bossData) {
            this.bossData = bossData;
        }

        public void AddPhase(string phaseName, State phaseState) {
            phases[phaseName] = phaseState;
        }

        public void ChangeState(string phaseName) {
            if (currentState != null) {
                currentState.Exit();
            }

            currentState = phases[phaseName];
            currentState.Enter();
        }

        private string GetNextPhase() {
            // get the next phase in the dictionary, you can assume that the phases are added in chronological order
            int indexOfCurrentPhase = new List<string>(phases.Keys).IndexOf(currentState.GetType().Name);
            return new List<string>(phases.Keys)[indexOfCurrentPhase + 1];
        }

        public override void Tick() {
            if (_a()) {
                ChangeState(GetNextPhase());
            }

            if (currentState != null) {
                currentState.Tick();
            }
        }

        private bool _a() {
            return bossData.boss.GetHealth() / bossData.maxHealth < bossData.phaseOneHealthCutOff;
        }
    }
}