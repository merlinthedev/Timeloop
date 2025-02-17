﻿using UnityEngine;

namespace timeloop {
    public class AbilityFireRing : Ability {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int ringCount;
        [SerializeField] private float ringInterval;
        [SerializeField] private float ringRadius = 10f;
        [SerializeField] private float damageMultiplier = 1.2f;

        public override void OnUse(EntityDamager damager) {
            if (!canUse) return;

            Vector3 startPosition = damager.transform.position;


            Utils.DelayedForLoop(ringCount, ringInterval, (i) => {
                float angle = i * 360f / ringCount;
                Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.right * ringRadius;
                Vector3 position = startPosition + direction * 0.5f;

                GameObject ring = Instantiate(prefab, position, Quaternion.identity);
                ring.transform.rotation = Quaternion.Euler(0, 0, angle);

                EntityFireExplosion explosion = ring.GetComponent<EntityFireExplosion>();
                explosion.Constructor(damager, damager.GetDamage() * damageMultiplier);
            }, damager);

            PostAbilityUse();
        }
    }
}