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

        protected virtual void Update() {
            Debug.Log("abilityTimer: " + abilityTimer);
            
            TickAbilityCooldown();
        }

        private void TickAbilityCooldown() {
            Debug.Log("Checking tick cooldown.");
            if (abilityTimer > 0f) {
                abilityTimer -= Time.deltaTime;
                Debug.Log("Ticked cooldown.", this);
            }
        }
    }
}