﻿using solobranch.qLib;
using UnityEngine;

namespace timeloop {
    public class EntityFireBolt : Entity {
        private float entitySpeed;
        private Vector2 normalizedDirection = Vector2.zero;
        private float damage = 10f;

        public void Constructor(float entitySpeed, float damage, Vector2 normalizedDirection) {
            this.entitySpeed = entitySpeed;
            this.damage = damage;
            this.normalizedDirection = normalizedDirection;
        }


        private void Update() {
            transform.position += (Vector3)normalizedDirection * entitySpeed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (GameObjectUtilities.HasComponentInHierarchy<EntityLiving>(other.gameObject) &&
                !other.gameObject.CompareTag("Player")) {
                EntityLiving entityLiving = GameObjectUtilities.FindTopLevelParent(other.gameObject.transform)
                    .GetComponentInChildren<EntityLiving>();

                entityLiving.TakeDamage(this, damage);
            }
        }
    }
}