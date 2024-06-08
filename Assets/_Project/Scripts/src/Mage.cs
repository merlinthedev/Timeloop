using solobranch.qLib;
using UnityEngine;

namespace timeloop {
    public class Mage : GameClass {
        [Header("MAGE")] [SerializeField] private float blinkDistance = 5f;

        protected override void Start() {
            base.Start();
        }

        protected override void Update() {
            base.Update();
        }

        public override void OnDodgePerformed() {
            if (!canDodge) return;
            Blink();
        }

        public override void OnAbility1Performed() {
            ability1?.OnUse();
        }

        public override void OnAbility2Performed() {
            ability2?.OnUse();
        }

        private void Blink() {
            Vector2 blinkPosition = rb.position + movementVector.normalized * blinkDistance;
            rb.MovePosition(blinkPosition);
            dodgeTimer = dodgeCooldown;

            EventBus<DodgeUsedEvent>.Raise(new DodgeUsedEvent(dodgeTimer));
        }
    }
}