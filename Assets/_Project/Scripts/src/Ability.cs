using UnityEngine;
using UnityEngine.UI;

namespace timeloop {
    public abstract class Ability : MonoBehaviour {
        [Header("ABILITY")] [SerializeField] protected float abilityCooldown;
        private float abilityTimer = 0f;
        protected bool canUse => abilityTimer <= 0f; // can use ability if timer is 0 or lower 

        private EntityDamager damager;

        protected void PostAbilityUse() {
            abilityTimer = abilityCooldown;
        }

        public abstract void OnUse(EntityDamager damager);

        public void Initialize(EntityDamager damager) {
            this.damager = damager;
            abilityTimer = 0f;

            if (this.damager is GameClass) {
                Hook();
            }
        }

        private void Hook() {
            ManagerCanvas.GetInstance().Hook(this);
        }

        public float Tick() {
            TickAbilityCooldown();

            return abilityTimer / abilityCooldown;
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