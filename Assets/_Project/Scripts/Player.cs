using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;

namespace timeloop {
    public class Player : MonoBehaviour {
        private CustomInput input = null;
        private Rigidbody2D rb = null;
        private Vector2 movementVector = Vector2.zero;
        [SerializeField] private float movementSpeed = 4f;

        // player components
        private PlayerAnimationController playerAnimationController = null;

        private void Awake() {
            input = new CustomInput();
            rb = GetComponent<Rigidbody2D>();

            // player components
            playerAnimationController = new PlayerAnimationController(this);
        }

        private void OnEnable() {
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
        }

        private void Update() {
            UpdateAnimator(movementVector);
        }

        private int previousDir = 0;

        private void UpdateAnimator(Vector2 velocity) {
            int dir = 0;
            if (velocity.x > 0) {
                dir = 1;
            }
            else if (velocity.x < 0) {
                dir = 3;
            }
            else {
                if (velocity.y > 0) {
                    dir = 2;
                }
                else if (velocity.y < 0) {
                    dir = 0;
                }
                else {
                    dir = previousDir;
                }
            }


            playerAnimationController.SetDirection(dir);

            playerAnimationController.UpdateMove(buttonsPressed);
            previousDir = dir;
        }

        private bool buttonsPressed = false;

        private void OnMovementPerformed(InputAction.CallbackContext value) {
            movementVector = value.ReadValue<Vector2>();
            buttonsPressed = true;
        }

        private void OnMovementCancelled(InputAction.CallbackContext value) {
            movementVector = Vector2.zero;
            buttonsPressed = false;
        }
    }
}