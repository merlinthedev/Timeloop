using UnityEngine;

namespace timeloop {
    public class LuchtballonPhaseOneBehaviour : IBossBehaviour {
        private readonly BossLuchtballon boss;
        
        public LuchtballonPhaseOneBehaviour(BossLuchtballon boss) {
            this.boss = boss;
        }
        
        public void Enter() {
        }

        public void Tick() {
            HandleState();
        }

        public void Exit() {
        }
        
        private void HandleState() {
            switch (boss.currentState) {
                case BossLuchtballon.BossLuchtballonState.IDLE:
                    boss.GetPlayerPosition();
                    break;
                case BossLuchtballon.BossLuchtballonState.TARGETING:
                    TickTargetSelectionTimer();
                    break;
                case BossLuchtballon.BossLuchtballonState.WAITING:
                    TickMovementTimer();
                    break;
                case BossLuchtballon.BossLuchtballonState.MOVING:
                    Move();
                    break;
            }
        }

        private void Move() {
            // if the entity reaches the player position, stop moving
            if (Vector2.Distance(boss.transform.position, boss.playerPosition) >= 0.1f) {
                // move the entity
                boss.transform.position =
                    Vector2.MoveTowards(boss.transform.position, boss.playerPosition, movementSpeed * Time.deltaTime);
            }
            else {
                movementTimer = timeBetweenMovements;
                currentState = BossLuchtballon.BossLuchtballonState.WAITING;
            }
        }

        private void TickMovementTimer() {
            movementTimer -= Time.deltaTime;

            if (movementTimer <= 0f) {
                currentState = BossLuchtballon.BossLuchtballonState.IDLE;
            }
        }

        private void TickTargetSelectionTimer() {
            targetSelectionTimer -= Time.deltaTime;

            if (targetSelectionTimer <= 0f) {
                currentState = BossLuchtballon.BossLuchtballonState.MOVING;
            }
        }
    }
}