using UnityEngine;

namespace timeloop {
    public abstract class Ability : MonoBehaviour {
        [SerializeField] protected float abilityCooldown;
        protected float abilityTimer = 0f;
        protected bool canUse => abilityTimer <= 0f;

        public abstract void OnUse();

        protected virtual void Update() {
            TickAbilityCooldown();
        }

        private void TickAbilityCooldown() {
            if (abilityTimer > 0f) {
                abilityTimer -= Time.deltaTime;
            }
        }
    }
}