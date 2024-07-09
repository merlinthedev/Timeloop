using UnityEngine;
using UnityEngine.UI;

namespace timeloop {
    public abstract class Ability : MonoBehaviour {
        [Header("ABILITY")] [SerializeField] protected float abilityCooldown;
        private float abilityTimer = 0f;
        [SerializeField] private Image abilityImage;
        protected bool canUse => abilityTimer <= 0f; // can use ability if timer is 0 or lower 


        protected void PostAbilityUse() {
            abilityTimer = abilityCooldown;
        }

        public abstract void OnUse(EntityDamager damager);

        public void Initialize() {
            abilityTimer = 0f;

            Hook();
        }

        private void Hook() {
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