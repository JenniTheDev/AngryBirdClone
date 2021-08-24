using UnityEngine;
using UnityEngine.InputSystem;

public class Launcher : MonoBehaviour {
    private InputAction inputMovement;
    private InputAction inputClick;
    [SerializeField] private Transform startPosition;

    [SerializeField] private Rigidbody2D rb;
    private Vector2 releasePosition;

    private void Start() {
        var input = new PlayerControls();
        inputMovement = input.Player.Drag;
        inputMovement.Enable();

        inputClick = input.Player.Fire;
        inputClick.Enable();
        // inputClick.started += record value of mouse until performed = power of launcher = velocity
        // startposition - release position
        // on click method, on input release

        inputClick.started += OnInputClick;
        inputClick.canceled += OnInputRelease;
        inputClick.performed += OnInputHold;
    }

    private void OnInputRelease(InputAction.CallbackContext ctx) {
        releasePosition = inputMovement.ReadValue<Vector2>();
        Debug.Log($"Mouse click released at position: {releasePosition}");
        rb.position = releasePosition;
        rb.isKinematic = false;
    }

    private void OnInputClick(InputAction.CallbackContext ctx) {
        Debug.Log($"Mouse clicked at position: {inputMovement.ReadValue<Vector2>()}");
        rb.isKinematic = true;
    }

    private void OnInputHold(InputAction.CallbackContext ctx) {
        rb.position = Camera.main.ScreenToWorldPoint(inputMovement.ReadValue<Vector2>());
    }
}