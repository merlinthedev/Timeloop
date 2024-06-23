using solobranch.qLib;
using UnityEngine;

namespace timeloop {
    public class AbilityFireBolt : Ability {
        [SerializeField] private GameObject fireBoltPrefab;
        [SerializeField] private float fireBoltSpeed = 20f;

        public override void OnUse(EntityDamager damager) {
            if (!canUse) {
                return;
            }

            EntityFireBolt entityFireBolt = Instantiate(fireBoltPrefab, damager.transform.position, Quaternion.identity)
                .GetComponent<EntityFireBolt>();
            entityFireBolt.Constructor(fireBoltSpeed, damager.GetDamage(),
                MathUtilities.GetDirectionFromMouseToOrigin((Vector2)damager.transform.position));
            

            PostAbilityUse();
        }
    }
}