using UnityEngine;
using UnityEngine.InputSystem;

namespace timeloop {
    public class Player : MonoBehaviour {
        private CustomInput input = null;
        private Rigidbody2D rb = null;
        private Animator animator;
        private Vector2 movementVector = Vector2.zero;
        [SerializeField] private float movementSpeed = 4f;

        // player components

        private void Awake() {
            input = new CustomInput();
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        private void OnEnable() {
            
            // TODO: Test
            
            input.Enable();
            input.Player.Movement.performed += OnMovementPerformed;
            input.Player.Movement.canceled += OnMovementCancelled;
        }

        private void OnDisable() {
            input.Disable();
            input.Player.Movement.performed -= OnMovementPerformed;
            input.Player.Movement.canceled -= OnMovementCancelled;
        }

        private void FixedUpdate() {
            rb.velocity = movementVector * movementSpeed;
            animator.SetBool("IsMoving", rb.velocity != Vector2.zero);

            if (rb.velocity.x > 0) {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (rb.velocity.x < 0) {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        private void OnMovementPerformed(InputAction.CallbackContext value) {
            movementVector = value.ReadValue<Vector2>();
        }

        private void OnMovementCancelled(InputAction.CallbackContext value) {
            movementVector = Vector2.zero;
        }
    }
}