using UnityEngine;
using UnityEngine.InputSystem;

namespace timeloop {
    public class Player : MonoBehaviour {
        private CustomInput input = null;
        private GameClass gameClass = null;

        private void Awake() {
            input = new CustomInput();
            gameClass = GetComponent<GameClass>();
        }

        private void OnEnable() {
            EnableInput();
        }

        private void OnDisable() {
            DisableInput();
        }


        private void OnMovementPerformed(InputAction.CallbackContext value) {
            gameClass.movementVector = value.ReadValue<Vector2>();
        }

        private void OnMovementCancelled(InputAction.CallbackContext value) {
            gameClass.movementVector = Vector2.zero;
        }

        private void OnDodgePerformed(InputAction.CallbackContext value) {
            gameClass.OnDodgePerformed();
        }

        private void EnableInput() {
            input.Enable();
            input.Player.Movement.performed += OnMovementPerformed;
            input.Player.Movement.canceled += OnMovementCancelled;
            input.Player.Dodge.performed += OnDodgePerformed;
        }

        private void DisableInput() {
            input.Disable();
            input.Player.Movement.performed -= OnMovementPerformed;
            input.Player.Movement.canceled -= OnMovementCancelled;
            input.Player.Dodge.performed -= OnDodgePerformed;
        }
    }
}