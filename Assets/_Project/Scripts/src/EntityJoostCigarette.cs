using System;
using UnityEngine;

namespace timeloop {
    public class EntityJoostCigarette : Entity {
        private EntityDamager source;
        private float entityMovementSpeed = 0f;
        
        public void Initialize(EntityDamager source, float entityMovementSpeed) {
            this.source = source;
            this.entityMovementSpeed = entityMovementSpeed;
        }

        private void FixedUpdate() {
            transform.position += transform.right * (entityMovementSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (!other.gameObject.CompareTag("Player")) return;

            EntityLiving entity = other.GetComponent<EntityLiving>();
            
            entity.TakeDamage(source, source.GetDamage());
        }
    }
}