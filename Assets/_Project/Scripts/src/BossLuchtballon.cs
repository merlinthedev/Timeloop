using UnityEngine;

namespace timeloop {
    public class BossLuchtballon : Boss {
        [Header("BOSS LUCHTBALLON")] [SerializeField]
        private float movementSpeed = 12f;

        private float timeBetweenMovements = 1.5f;
        private float timeBetweenTargetSelectionAndMovement = 0.8f;

        private float movementTimer = 0f;
        private float targetSelectionTimer = 0f;

        private BossState currentState = BossState.IDLE; // make private, also the enum

        protected override void Update() {
            base.Update();

            HandleStates();
        }
        
        protected override void GetPlayerPosition() {
            base.GetPlayerPosition();

            targetSelectionTimer = timeBetweenTargetSelectionAndMovement;
            currentState = BossState.TARGETING;
        }

        private void Move() {
            // if the entity reaches the player position, stop moving
            if (Vector2.Distance(transform.position, playerPosition) >= 0.1f) {
                // move the entity
                transform.position =
                    Vector2.MoveTowards(transform.position, playerPosition, movementSpeed * Time.deltaTime);
            }
            else {
                movementTimer = timeBetweenMovements;
                currentState = BossState.WAITING;
            }
        }

        private void HandleStates() {
            switch (currentState) {
                case BossState.IDLE:
                    GetPlayerPosition();
                    break;
                case BossState.WAITING:
                    TickMovementTimer();
                    break;
                case BossState.TARGETING:
                    TickTargetSelectionTimer();
                    break;
                case BossState.MOVING:
                    Move();
                    break;
                default:
                    currentState = BossState.IDLE;
                    break;
            }
        }

        private void TickMovementTimer() {
            movementTimer -= Time.deltaTime;

            if (movementTimer <= 0f) {
                currentState = BossState.IDLE;
            }
        }

        private void TickTargetSelectionTimer() {
            targetSelectionTimer -= Time.deltaTime;

            if (targetSelectionTimer <= 0f) {
                currentState = BossState.MOVING;
            }
        }

        private enum BossState {
            IDLE,
            WAITING,
            TARGETING,
            MOVING,
        }
    }
}