using UnityEngine;
using UnityEngine.UI;

namespace timeloop {
    public class BossLuchtballon : Boss {
        [Header("BOSS LUCHTBALLON")] [SerializeField]
        private float movementSpeed = 12f;

        [SerializeField] private GameObject bossBarPrefab;

        private float timeBetweenMovements = 1.5f;
        private float timeBetweenTargetSelectionAndMovement = 0.8f;

        private float movementTimer = 0f;
        private float targetSelectionTimer = 0f;

        [field: SerializeField]
        public BossLuchtballonState currentState { get; private set; } =
            BossLuchtballonState.IDLE; // make private, also the enum

        private LuchtballonStateMachine bossStateMachine;
        private BossData bossData;

        protected override void Start() {
            base.Start();

            RenderBossbar();

            bossBar = Instantiate(bossBarPrefab, CanvasSingleton.instance.transform);

            Image[] images = bossBar.GetComponentsInChildren<Image>();
            for (int i = 0; i < images.Length; i++) {
                if (images[i].fillMethod == Image.FillMethod.Horizontal) {
                    images[i].fillAmount = 1f;
                    final = images[i];
                }
            }

            StartStateMachine();
        }

        private void StartStateMachine() {
            bossData = new BossData(this, playerEntity, maxHealth);
            bossStateMachine = new LuchtballonStateMachine(bossData);
            
            LuchtballonPhaseMachine phaseOne = new LuchtballonPhaseMachine(bossData);

            LuchtballonMoveState phaseOneMoveState =
                new LuchtballonMoveState(bossData, timeBetweenTargetSelectionAndMovement);
            
            phaseOne.AddPhase("MOVE_STATE", phaseOneMoveState);
            
            bossStateMachine.AddPhase("PHASE_ONE", phaseOne);




        }

        protected override void Update() {
            base.Update();

            // tick the current phase
            bossStateMachine.Tick();
        }

        protected override void GetPlayerPosition() {
            base.GetPlayerPosition();

            targetSelectionTimer = timeBetweenTargetSelectionAndMovement;
            currentState = BossLuchtballonState.TARGETING;
        }

        public void ResetState() {
            currentState = BossLuchtballonState.IDLE;
        }

        protected override void RenderBossbar() {
            base.RenderBossbar();
        }

        protected override void Die() {
            Destroy(bossBar);

            base.Die();
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

        public enum BossLuchtballonState {
            IDLE,
            WAITING,
            TARGETING,
            MOVING,
        }

        public class BossData {
            public readonly BossLuchtballon boss;
            public readonly GameClass playerEntity;
            public readonly float maxHealth;
            public readonly float phaseOneHealthCutOff = 0.4f; // TODO: maybe make customizable later?

            public BossData(BossLuchtballon boss, GameClass playerEntity, float maxHealth) {
                this.boss = boss;
                this.playerEntity = playerEntity;
                this.maxHealth = maxHealth;
            }
        }
    }
}