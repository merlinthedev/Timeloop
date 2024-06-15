﻿using UnityEngine;

namespace timeloop {
    public abstract class EntityLiving : Entity {
        [Header("ENTITY LIVING")]
        [SerializeField] protected float maxHealth;
        protected float health;

        protected virtual void Start() {
            health = maxHealth;
        }

        public virtual void TakeDamage(Entity source, float damage) {
            health -= damage;

            if (health <= 0) {
                Die();
            }
        }

        protected virtual void Die() {
            Destroy(gameObject);
        }

        public float GetHealth() {
            return health;
        }
    }
}