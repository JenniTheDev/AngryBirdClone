using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("Ball is out of bounds");
        // Make this a SO Event to reset ball
    }
}