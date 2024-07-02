using UnityEngine;

namespace timeloop {
    public abstract class Ability : MonoBehaviour {
        
        [Header("ABILITY")]
        [SerializeField] protected float abilityCooldown;
        private float abilityTimer = 0f;
        protected bool canUse => abilityTimer <= 0f; // can use ability if timer is 0 or lower 


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

        public float GetCooldown() {
            return abilityCooldown;
        }

        public bool CanUse() {
            return canUse;
        }
    }
}