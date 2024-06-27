using UnityEngine;

namespace timeloop {
    public class EntityDamager : EntityLiving {
        [Header("ENTITY DAMAGER")][SerializeField]protected float damage;

        public float GetDamage() {
            return damage;
        }
    }
}