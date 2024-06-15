using UnityEngine;

namespace timeloop {
    public class LuchtballonMoveState : State {
        private float targetTimer;
        private float timeBetweenTargetAndAttack;
        
        public LuchtballonMoveState(BossLuchtballon.BossData bossData, float timeBetweenTargetAndAttack) : base(bossData) {
            this.timeBetweenTargetAndAttack = timeBetweenTargetAndAttack;
        }
        
        public override void Enter() {
            // 
        }
        
        public override void Tick() {
            TickTargetTimer();
        }
        
        public override void Exit() {
        }

        private void TickTargetTimer() {
            targetTimer -= Time.deltaTime;
            
        }

        private void Move() {
            
        }

    }
}