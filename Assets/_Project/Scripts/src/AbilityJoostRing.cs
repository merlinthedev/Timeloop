using UnityEngine;

namespace timeloop {
    public class AbilityJoostRing : Ability {

        [SerializeField] private GameObject ringPrefab;
        
        public override void OnUse(EntityDamager damager) {
            if (!canUse) return; // is probably on cooldown

            EntityJoostRing ring = ringPrefab.GetComponent<EntityJoostRing>();
            ring.Initialize(damager as BossLuchtballon); // kind of hacky, but it works

        }
        
        
    }
}