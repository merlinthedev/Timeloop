using solobranch.qLib;
using UnityEngine;
using UnityEngine.UI;

namespace timeloop {
    public abstract class Boss : EntityDamager {
        private GameClass playerEntity;
        protected Vector2 playerPosition;
        protected Image final;
        protected GameObject bossBar;


        protected override void Start() {
            base.Start();

            playerEntity = FindObjectOfType<GameClass>(); // bad, refactor
        }

        protected virtual void Update() {
        }


        protected virtual void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                playerEntity.TakeDamage(this, damage);
            }
        }

        public override void TakeDamage(Entity source, float damage) {
            base.TakeDamage(source, damage);

            RenderBossbar();

            Debug.Log("Boss took damage! : " + damage);
        }

        protected virtual void RenderBossbar() {
            float fillAmount = health / maxHealth;
            EventBus<UIUpdateBossBarEvent>.Raise(new UIUpdateBossBarEvent(this, fillAmount));
        }

        protected virtual void GetPlayerPosition() {
            playerPosition = playerEntity.transform.position;
        }

        public Image GetFillImage() {
            return final;
        }
    }
}