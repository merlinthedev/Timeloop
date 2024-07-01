using UnityEngine;

namespace timeloop {
    public abstract class Ability : MonoBehaviour {
        [SerializeField] protected float abilityCooldown;
        [SerializeField] protected float abilityTimer = 0f;
        protected bool canUse => abilityTimer <= 0f;


        protected void PostAbilityUse() {
            abilityTimer = abilityCooldown;
        }

        public abstract void OnUse(EntityDamager damager);
        
        public void Initialize() {
            abilityTimer = 0f;
        }
        
        public void Tick() {
            TickAbilityCooldown();
        }

        private void TickAbilityCooldown() {
            if (abilityTimer > 0f) {
                abilityTimer -= Time.deltaTime;
            }
        }
    }
}