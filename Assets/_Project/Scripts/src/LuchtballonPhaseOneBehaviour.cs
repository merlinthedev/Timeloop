using UnityEngine;

namespace timeloop {
    public class LuchtballonPhaseOneBehaviour : IBossBehaviour {
        private readonly BossLuchtballon boss;

        private BossLuchtballonState currentState = BossLuchtballonState.IDLE;

        private float timeBetweenMovements = 1.5f;
        private float timeBetweenTargetSelectionAndMovement = 0.8f;

        private float movementTimer = 0f;
        private float targetSelectionTimer = 0f;

        private float smallestScale = 0.4f;
        private float finalScale = 0.6f;
        private float scaleFactor = 0.04f;

        private bool increasing = false;


        public LuchtballonPhaseOneBehaviour(BossLuchtballon boss) {
            this.boss = boss;
        }

        public void Enter() {
        }

        public void Tick() {
            HandleState();
        }

        public void Exit() {
            // do exit logic here, maybe cool particles or smth
            ExitCurrentState();
        }

        private void ExitCurrentState() {
            boss.SetInvulnerable(true);
            boss.SetMovementSpeed(0f);
            currentState = BossLuchtballonState.EXITING;
            Debug.Log("Exising phase one");
        }

        private void HandleState() {
            switch (currentState) {
                case BossLuchtballonState.IDLE:
                    GetPlayerPosition();
                    break;
                case BossLuchtballonState.TARGETING:
                    TickTargetSelectionTimer();
                    break;
                case BossLuchtballonState.WAITING:
                    TickMovementTimer();
                    break;
                case BossLuchtballonState.MOVING:
                    Move();
                    break;
                case BossLuchtballonState.EXITING:
                    HandleScaleLerping();
                    break;
            }
        }

        private void HandleScaleLerping() {
            Debug.Log("Lerping scale");
            if (increasing) {
                boss.transform.localScale = Vector3.Lerp(boss.transform.localScale,
                    new Vector3(finalScale, finalScale, 1),
                    Time.deltaTime * 2f);
            }
            else {
                boss.transform.localScale = Vector3.Lerp(boss.transform.localScale,
                    new Vector3(smallestScale, smallestScale, smallestScale),
                    Time.deltaTime * 0.8f);
                
                if(boss.transform.localScale.x <= smallestScale + scaleFactor) {
                    increasing = true;
                }
            }

            if (boss.transform.localScale.x >= finalScale - scaleFactor) {
                boss.NextPhase();
            }
        }

        private void Move() {
            // if the entity reaches the player position, stop moving
            if (Vector2.Distance(boss.transform.position, boss.playerPosition) >= 0.1f) {
                // move the entity
                boss.transform.position =
                    Vector2.MoveTowards(boss.transform.position, boss.playerPosition,
                        boss.GetMovementSpeed() * Time.deltaTime);
            }
            else {
                movementTimer = timeBetweenMovements;
                currentState = BossLuchtballonState.WAITING;
            }
        }

        private void TickMovementTimer() {
            movementTimer -= Time.deltaTime;

            if (movementTimer <= 0f) {
                currentState = BossLuchtballonState.IDLE;
            }
        }

        private void TickTargetSelectionTimer() {
            targetSelectionTimer -= Time.deltaTime;

            if (targetSelectionTimer <= 0f) {
                currentState = BossLuchtballonState.MOVING;
            }
        }

        private void GetPlayerPosition() {
            boss.GetPlayerPosition();

            targetSelectionTimer = timeBetweenTargetSelectionAndMovement;
            currentState = BossLuchtballonState.TARGETING;
        }

        enum BossLuchtballonState {
            IDLE,
            WAITING,
            TARGETING,
            MOVING,
            EXITING
        }
    }
}