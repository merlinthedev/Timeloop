using UnityEngine;

namespace timeloop {
    public class Boss : EntityLiving {
        private GameClass playerEntity;

        private float timeBetweenMovements = 1.5f;
        private float timeBetweenTargetSelectionAndMovement = 0.8f;

        private float movementTimer = 0f;
        private float targetSelectionTimer = 0f;

        [SerializeField] private float movementSpeed = 8f;

        private Vector2 playerPosition;
        public BossState currentState = BossState.IDLE; // make private, also the enum

        protected override void Start() {
            base.Start();

            playerEntity = FindObjectOfType<GameClass>(); // bad, refactor
        }

        private void Update() {
            HandleStates();
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

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                playerEntity.TakeDamage(this, 1f);
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

        private void GetPlayerPosition() {
            playerPosition = playerEntity.transform.position;

            targetSelectionTimer = timeBetweenTargetSelectionAndMovement;
            currentState = BossState.TARGETING;
        }

        public enum BossState {
            IDLE,
            WAITING,
            TARGETING,
            MOVING,
        }
    }
}