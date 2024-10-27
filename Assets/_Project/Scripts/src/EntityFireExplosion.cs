using System;
using solobranch.qLib;
using UnityEngine;

namespace timeloop {
    public class EntityFireExplosion : Entity {
        [SerializeField] private float lifetime = 1f;
        private bool shouldTick = false;
        private Collider2D collider2d;
        private float damage;

        private EntityDamager owner;

        private void Start() {
            collider2d = GetComponent<Collider2D>();
            collider2d.isTrigger = true;
        }

        public void Constructor(EntityDamager owner, float damage) {
            this.owner = owner;
            this.damage = damage;

            shouldTick = true;
        }

        private void Update() {
            if (!shouldTick) return;
            lifetime -= Time.deltaTime;
            if (lifetime <= 0) {
                Explode();
                Destroy(gameObject);
            }
        }

        private void Explode() {
            // check all current colliders in the explosion radius
            Collider2D[] colliders =
                Physics2D.OverlapCircleAll(transform.position, (collider2d as CircleCollider2D).radius);
            foreach (Collider2D col in colliders) {
                EntityLiving entity = col.GetComponent<EntityLiving>();
                if (entity != null && entity != owner && entity.IsAlive()) {
                    entity.TakeDamage(owner, damage);
                }
            }
        }
    }
}