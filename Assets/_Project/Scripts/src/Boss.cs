using UnityEngine;

namespace timeloop {
    public abstract class Boss : EntityDamager {
        private GameClass playerEntity;
        protected Vector2 playerPosition;


        protected override void Start() {
            base.Start();

            playerEntity = FindObjectOfType<GameClass>(); // bad, refactor
        }

        protected virtual void Update() {
        }


        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                playerEntity.TakeDamage(this, damage);
            }
        }

        protected virtual void GetPlayerPosition() {
            playerPosition = playerEntity.transform.position;
        }
    }
}