using UnityEngine;

namespace timeloop {
    public class EntityJoostRing : Entity {
        [SerializeField] private float increaseSizeSpeed;
        [SerializeField] private float damageMultiplier;
        [SerializeField] private float maxRadius; // radius
        private Collider2D col;
        private BossLuchtballon boss;

        // attack
        private float attackCooldown = 0.6f;
        private float attackTimer = 0;
        private EntityLiving entity;
        private bool canAttack => attackTimer <= 0;

        public void Initialize(BossLuchtballon boss) {
            this.boss = boss;
        }

        private void Update() {
            TickCooldown();
        }

        private void FixedUpdate() {
            if (transform.localScale.x < maxRadius) {
                transform.localScale += new Vector3(increaseSizeSpeed, increaseSizeSpeed, 0);
            }
            else {
                Destroy(gameObject);
            }
        }

        private void TickCooldown() {
            if (attackTimer > 0) {
                attackTimer -= Time.deltaTime;
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            entity = other.GetComponent<EntityLiving>();


            Debug.Log("Collision: " + entity.gameObject.name); // debugging purposes
            Collision();
        }

        private void OnTriggerStay2D(Collider2D other) {
            Collision();
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (other.GetComponent<EntityLiving>() == entity) {
                entity = null;
            }
        }

        private void Collision() {
            if (entity != null && entity != boss && entity.IsAlive()) {
                if (canAttack) {
                    Debug.Log("attacking " + entity.gameObject.name + " with " + boss.GetDamage() * damageMultiplier +
                              " damage");
                    entity.TakeDamage(this, boss.GetDamage() * damageMultiplier);
                    attackTimer = attackCooldown;
                }
            }
        }
    }
}