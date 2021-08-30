using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Launcher : MonoBehaviour {
    private InputAction inputMovement;
    private InputAction inputClick;
    [SerializeField] private Transform startPosition;

    [SerializeField] private Rigidbody2D rb;
    private Vector2 releasePosition;
    private bool trackPosition = false;
    [SerializeField] private float releaseTime = 0.15f;

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

    // This needs refactoring but testing for now
    private void Update() {
        if (trackPosition) {
            KeepBallOnMouse();
        }
    }

    private void KeepBallOnMouse() {
        rb.position = Camera.main.ScreenToWorldPoint(inputMovement.ReadValue<Vector2>());
    }

    private void OnInputClick(InputAction.CallbackContext ctx) {
        trackPosition = true;
        Debug.Log($"Mouse clicked at position: {inputMovement.ReadValue<Vector2>()}");
        rb.isKinematic = true;
    }

    private void OnInputRelease(InputAction.CallbackContext ctx) {
        trackPosition = false;
        releasePosition = inputMovement.ReadValue<Vector2>();
        Debug.Log($"Mouse click released at position: {releasePosition}");
        rb.position = releasePosition;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }

    private void OnInputHold(InputAction.CallbackContext ctx) {
        // This doesn't work the entire time mouse is being held down
        // rb.position = Camera.main.ScreenToWorldPoint(inputMovement.ReadValue<Vector2>());
        //  Debug.Log($"Mouse being held down: {inputMovement.ReadValue<Vector2>()}");
    }

    private IEnumerator Release() {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
    }
}