using UnityEngine;

namespace timeloop {
    public class AbilityJoostRing : Ability {
        [SerializeField] private GameObject ringPrefab;

        public override void OnUse(EntityDamager damager) {
            if (!canUse) {
                Debug.Log("Cant use " + GetType().Name + " yet!");
                return; // is probably on cooldown
            }

            var ring = Instantiate(ringPrefab, damager.transform.position, Quaternion.identity);
            EntityJoostRing joostRing = ring.GetComponent<EntityJoostRing>();
            
            // EntityJoostRing ring = ringPrefab.GetComponent<EntityJoostRing>();
            joostRing.Initialize(damager as BossLuchtballon); // kind of hacky, but it works
            
            base.PostAbilityUse();
        }
    }
}