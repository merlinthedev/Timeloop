using UnityEngine;

namespace timeloop {
    public abstract class GameClass : MonoBehaviour {
        [Header("Game Class")] [SerializeField]
        protected float dodgeCooldown = 4f;

        protected bool canDodge => dodgeTimer <= 0f;
        protected float dodgeTimer = 0f;

        [SerializeField] private float maxHealth = 20f;
        private float health;

        [SerializeField] private float movementSpeed = 4f;

        protected Rigidbody2D rb = null;
        private Animator animator;
        public Vector2 movementVector = Vector2.zero;

        public abstract void OnDodgePerformed();

        private void Awake() {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        protected virtual void Start() {
            health = maxHealth;
        }

        protected virtual void Update() {
            TickDodgeCooldown();
        }

        private void TickDodgeCooldown() {
            if (dodgeTimer > 0f) {
                dodgeTimer -= Time.deltaTime;
            }
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