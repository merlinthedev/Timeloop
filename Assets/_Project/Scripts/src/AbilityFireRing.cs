using UnityEngine;

namespace timeloop {
    public class AbilityFireRing : Ability {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int ringCount;
        [SerializeField] private float ringInterval;
        
        public override void OnUse(EntityDamager damager) {
            if (!canUse) return;
            
            
            
            PostAbilityUse();
        }
    }
}