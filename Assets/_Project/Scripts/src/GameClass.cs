using solobranch.qLib;
using UnityEngine;

namespace timeloop {
    public abstract class GameClass : EntityDamager {
        [Header("GAME CLASS")] [SerializeField]
        protected float dodgeCooldown = 4f;

        protected bool canDodge => dodgeTimer <= 0f;
        protected float dodgeTimer = 0f;
        
        [SerializeField] private float movementSpeed = 4f;

        protected Rigidbody2D rb = null;
        private Animator animator;
        [HideInInspector] public Vector2 movementVector = Vector2.zero;
        
        // Abilities
        [SerializeField] protected Ability ability1;
        [SerializeField] protected Ability ability2;

        public abstract void OnDodgePerformed();
        public abstract void OnAbility1Performed();
        public abstract void OnAbility2Performed();

        private void Awake() {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            
            ability1?.Initialize();
            ability2?.Initialize();
        }
        
        protected virtual void Update() {
            TickCooldowns();
        }

        private void TickCooldowns() {
            TickDodgeCooldown();
            TickAbilityCooldowns();
        }

        private void TickAbilityCooldowns() {
            ability1?.Tick();
            ability2?.Tick();
        }

        private void TickDodgeCooldown() {
            if (dodgeTimer > 0f) {
                dodgeTimer -= Time.deltaTime;
            }
        }

        public override void TakeDamage(Entity source, float damage) {
            base.TakeDamage(source, damage);
            
            Debug.Log("Player took damage! : " + damage);
            
            // raise event for updating healthbar
            EventBus<UIUpdateHealthBarEvent>.Raise(new UIUpdateHealthBarEvent(health / maxHealth));
        }

        protected virtual void FixedUpdate() {
            rb.velocity = movementVector * movementSpeed;
            animator.SetBool("IsMoving", rb.velocity != Vector2.zero);

            if (rb.velocity.x > 0) {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (rb.velocity.x < 0) {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}