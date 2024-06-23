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

        private IBossBehaviour[] behaviours;
        private IBossBehaviour currentBehaviour;

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
            
            InitializeBossBehaviour();
        }


        protected override void Update() {
            base.Update();

            // tick the current phase
            currentBehaviour.Tick();
        }

        public override void TakeDamage(Entity source, float damage) {
            base.TakeDamage(source, damage);

            if (ShouldChangePhase()) {
                
            }
        }

        public override void GetPlayerPosition() {
            base.GetPlayerPosition();

            targetSelectionTimer = timeBetweenTargetSelectionAndMovement;
            currentState = BossLuchtballonState.TARGETING;
        }

        protected override void Die() {
            Destroy(bossBar);

            base.Die();
        }

        private void InitializeBossBehaviour() {
            behaviours = new IBossBehaviour[] {
                new LuchtballonPhaseOneBehaviour(this)
            };
            
            currentBehaviour = behaviours[0];
        }

        

        private bool ShouldChangePhase() {
            return health <= maxHealth / 3; // 33% health
        }

        public enum BossLuchtballonState {
            IDLE,
            WAITING,
            TARGETING,
            MOVING,
        }
    }
}