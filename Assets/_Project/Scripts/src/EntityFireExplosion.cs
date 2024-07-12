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
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            EntityLiving living = other.gameObject.GetComponent<EntityLiving>();
            if (living == null) return;
            if (living.gameObject == owner.gameObject) return;

            living.TakeDamage(owner, damage);
        }
    }
}