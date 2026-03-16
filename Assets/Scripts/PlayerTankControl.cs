using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerTankControl : MonoBehaviour
{
    public float moveFoce = 10f;
    public float maxSpeed = 100f;
    public float rotateSpeed = 100f;

    private InputAction moveActions;
    private Rigidbody rb;

    [SerializeField] GameObject turret;

    private void Awake()
    {
       moveActions = InputSystem.actions.FindAction("Move");
       rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();


    }

    public void Move()
    {
        Vector2 moveInput = moveActions.ReadValue<Vector2>();

        rb.AddForce(transform.forward * moveInput.y * moveFoce, ForceMode.Acceleration);

        rb.AddTorque(transform.up * moveInput.x * rotateSpeed, ForceMode.Force);


        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}
