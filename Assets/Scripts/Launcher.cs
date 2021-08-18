using UnityEngine;
using UnityEngine.InputSystem;

public class Launcher : MonoBehaviour {
    private InputAction inputMovement;
    private InputAction inputClick;

    private void Start() {
        var input = new PlayerControls();
        inputMovement = input.Player.Drag;
        inputMovement.Enable();

        inputClick = input.Player.Fire;
        inputClick.Enable();
        inputClick.performed += OnInputClick;
    }

    private void OnInputClick(InputAction.CallbackContext ctx) {
        Debug.Log($"Mouse clicked at position: {inputMovement.ReadValue<Vector2>()}");
        Debug.Log($"fire");
    }
}