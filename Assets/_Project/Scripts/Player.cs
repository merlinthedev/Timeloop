using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    private CustomInput input = null;
    private Rigidbody2D rb = null;
    private Vector2 movementVector = Vector2.zero;
    [SerializeField] private float movementSpeed = 4f;

    private void Awake() {
        input = new CustomInput();
        rb = GetComponent<Rigidbody2D>();
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

    private void OnMovementPerformed(InputAction.CallbackContext value) {
        movementVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value) {
        movementVector = Vector2.zero;
    }
}