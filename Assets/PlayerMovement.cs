using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputSystem_Actions controls;   // input actions class
    Vector2 moveInput;         // input store karega
    public float speed = 5f;   // player speed

    void Awake()
    {
        controls = new InputSystem_Actions();
    }

    void Start()
    {
        // jab key press hogi
        controls.Player.Move.performed += OnMove;

        // jab key chhodi jayegi
        controls.Player.Move.canceled += StopMove;

        controls.Enable();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void StopMove(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}