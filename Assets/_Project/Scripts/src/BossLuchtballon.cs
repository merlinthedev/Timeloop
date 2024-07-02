using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace timeloop {
    public class BossLuchtballon : Boss {
        [Header("BOSS LUCHTBALLON")] [SerializeField]
        private float movementSpeed = 12f;

        [SerializeField] private GameObject bossBarPrefab;

        private List<IBossBehaviour> behaviours;
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
                // change phase with behaviour
                currentBehaviour.Exit();
            }
        }
        
        public void NextPhase() {
            // set the currentBehaviour to the next in the list, do not hard code the index
            if (behaviours.IndexOf(currentBehaviour) + 1 >= behaviours.Count) {
                Debug.LogError("No more behaviours to switch to");
                Environment.Exit(0); // not the best way to handle this, but it's a quick fix
                return;
            }

            currentBehaviour = behaviours[behaviours.IndexOf(currentBehaviour) + 1];

            currentBehaviour.Enter();
        }

        protected override void Die() {
            Destroy(bossBar);

            base.Die();
        }

        private void InitializeBossBehaviour() {
            behaviours = new List<IBossBehaviour> {
                new LuchtballonPhaseOneBehaviour(this),
                new LuchtballonPhaseTwoBehaviour(this),
            };

            currentBehaviour = behaviours[0];
        }


        private bool ShouldChangePhase() {
            return health <= maxHealth / 2; // 50% health
        }

        #region Getters & Setters

        public float GetMovementSpeed() {
            return movementSpeed;
        }

        public void SetMovementSpeed(float movementSpeed) {
            this.movementSpeed = movementSpeed;
        }
        

        #endregion
    }
}