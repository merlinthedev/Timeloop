using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    private float movementSpeed = 4f;


    private Vector2 movementInputVector = Vector2.zero;

    private void Update() {
        Vector3 movement = new Vector3(movementInputVector.x, 0, movementInputVector.y) * movementSpeed *
                           Time.deltaTime;
        transform.Translate(movement);
    }

    public void onWalkingAction(InputAction.CallbackContext context) {
        Debug.Log("movementInputVector: " + movementInputVector);
        movementInputVector = context.ReadValue<Vector2>();
    }
}