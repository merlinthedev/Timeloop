using System.Collections.Generic;
using solobranch.qLib;
using UnityEngine;
using UnityEngine.UI;

namespace timeloop {
    public abstract class Boss : EntityDamager {
        [Header("BOSS")] [SerializeField] private float attackCooldown = 1.2f;
        private float attackTimer = 0f;
        private GameClass playerEntity { get; set; }
        public Vector2 playerPosition { get; protected set; }
        protected Image final;
        protected GameObject bossBar;

        [SerializeField] protected List<Ability> bossAbilities = new();

        protected override void Start() {
            base.Start();

            playerEntity = FindObjectOfType<GameClass>(); // bad, refactor
        }

        protected virtual void Update() {
            if (attackTimer > 0) {
                attackTimer -= Time.deltaTime;
            }

            TickBossAbilities();
        }

        private void TickBossAbilities() {
            for (int i = 0; i < bossAbilities.Count; i++) {
                bossAbilities[i].Tick();
            }
        }

        protected virtual void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                playerEntity.TakeDamage(this, damage);
            }
        }

        protected virtual void OnTriggerStay2D(Collider2D other) {
            if (attackTimer > 0) return;

            if (other.CompareTag("Player")) {
                EntityLiving entityLiving = other.GetComponent<EntityLiving>();
                entityLiving.TakeDamage(this, damage);

                attackTimer = attackCooldown;
            }
        }

        public override void TakeDamage(Entity source, float damage) {
            base.TakeDamage(source, damage);

            RenderBossbar();

            // Debug.Log("Boss took damage! : " + damage);
        }

        protected virtual void RenderBossbar() {
            float fillAmount = health / maxHealth;
            EventBus<UIUpdateBossBarEvent>.Raise(new UIUpdateBossBarEvent(this, fillAmount));
        }

        public virtual Vector3 GetPlayerPosition() {
            playerPosition = playerEntity.transform.position;

            return playerPosition;
        }

        public Image GetFillImage() {
            return final;
        }

        public bool CanCastAnyAbility() {
            for (int i = 0; i < bossAbilities.Count; i++) {
                if (bossAbilities[i].CanUse()) {
                    return true;
                }
            }
            return false;
        }

        
        public List<Ability> GetBossAbilities() {
            return bossAbilities;
        }
    }
}