using UnityEngine;

namespace timeloop {
    public class AbilityFireRing : Ability {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int ringCount;
        [SerializeField] private float ringInterval;
        [SerializeField] private float damageMultiplier = 1.2f;

        public override void OnUse(EntityDamager damager) {
            if (!canUse) return;

            for (int i = 0; i < ringCount; i++) {
                float angle = i * 360f / ringCount;
                Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.right;
                Vector3 position = damager.transform.position + direction * 0.5f;

                GameObject ring = Instantiate(prefab, position, Quaternion.identity);
                ring.transform.localScale = new Vector3(0.1f, 0.1f, 1);
                ring.transform.rotation = Quaternion.Euler(0, 0, angle);

                EntityFireExplosion explosion = ring.GetComponent<EntityFireExplosion>();
                explosion.Constructor(damager, damager.GetDamage() * damageMultiplier);
            }

            PostAbilityUse();
        }
    }
}