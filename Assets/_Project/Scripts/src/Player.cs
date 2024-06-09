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

        private void OnAbiltiy1Performed(InputAction.CallbackContext value) {
            gameClass.OnAbility1Performed();
        }

        private void OnAbiltiy2Performed(InputAction.CallbackContext value) {
            gameClass.OnAbility2Performed();
        }

        private void EnableInput() {
            input.Enable();
            input.Player.Movement.performed += OnMovementPerformed;
            input.Player.Movement.canceled += OnMovementCancelled;
            input.Player.Dodge.performed += OnDodgePerformed;
            input.Player.LeftMouseAbility.performed += OnAbiltiy1Performed;
            input.Player.RightMouseAbility.performed += OnAbiltiy2Performed;
        }

        private void DisableInput() {
            input.Disable();
            input.Player.Movement.performed -= OnMovementPerformed;
            input.Player.Movement.canceled -= OnMovementCancelled;
            input.Player.Dodge.performed -= OnDodgePerformed;
            input.Player.LeftMouseAbility.performed -= OnAbiltiy1Performed;
            input.Player.RightMouseAbility.performed -= OnAbiltiy2Performed;
        }
    }
}