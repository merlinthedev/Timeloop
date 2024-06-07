using UnityEngine;

namespace timeloop {
    public class AbilityFireBolt : Ability {
        [SerializeField] private GameObject fireBoltPrefab;
        [SerializeField] private float fireBoltSpeed = 20f;
        
        public override void OnUse() {
            
        }
    }
}