using UnityEngine;
using UnityEngine.InputSystem;

public class Launcher : MonoBehaviour {
    private InputAction inputMovement;
    private InputAction inputClick;
    [SerializeField] private Transform startPosition;
    private Transform releasePosition;

    private void Start() {
        var input = new PlayerControls();
        inputMovement = input.Player.Drag;
        inputMovement.Enable();

        inputClick = input.Player.Fire;
        inputClick.Enable();
        // inputClick.started += record value of mouse until performed = power of launcher = velocity
        // start - end
        // on click method, on input release

        inputClick.started += OnInputClick;
        inputClick.canceled += OnInputRelease;
    }

    private void OnInputRelease(InputAction.CallbackContext ctx) {
        Debug.Log($"Mouse click released at position: {inputMovement.ReadValue<Vector2>()}");
    }

    private void OnInputClick(InputAction.CallbackContext ctx) {
        Debug.Log($"Mouse clicked at position: {inputMovement.ReadValue<Vector2>()}");
    }
}