﻿using solobranch.qLib;
using UnityEngine;

namespace timeloop {
    public class AbilityFireBolt : Ability {
        [SerializeField] private GameObject fireBoltPrefab;
        [SerializeField] private float fireBoltSpeed = 20f;

        public override void OnUse(EntityDamager damager) {
            if (!canUse) {
                Debug.Log("Can't use firebolt yet.", this);
                Debug.Log("CanUse: " + canUse + ", abilityTimer: " + abilityTimer, this);
                return;
            }

            EntityFireBolt entityFireBolt = Instantiate(fireBoltPrefab, damager.transform.position, Quaternion.identity)
                .GetComponent<EntityFireBolt>();
            entityFireBolt.Constructor(fireBoltSpeed, damager.GetDamage(),
                MathUtilities.__((Vector2)damager.transform.position));
            
            Debug.Log("used firebolt.");

            PostAbilityUse();
        }
    }
}