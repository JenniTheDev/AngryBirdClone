using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour {
    private Pointer pointer = Pointer.current;
    private bool isPressed = false;
    [SerializeField] private Rigidbody2D rb;

    private void Update() {
        if (isPressed) {
            // rb.position =
        }
    }

    private void OnClick() {
        // this needs fixing for Press down and press up
        // this click counts for press down and let go
        if (pointer.IsPressed()) {
            isPressed = true;
            Debug.Log("pressed click");
            rb.isKinematic = true;
        } else {
            isPressed = false;
            Debug.Log("pressed click");
            rb.isKinematic = false;
        }
    }
}