using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerTankControl : MonoBehaviour
{
    public float moveFoce = 10f;
    public float maxSpeed = 100f;
    public float rotateSpeed = 100f;

    private InputAction moveActions;
    //private InputAction turretActions;
    private Rigidbody rb;

    [SerializeField] GameObject turret;

    private void Awake()
    {
        moveActions = InputSystem.actions.FindAction("Move");
        //turretActions = InputSystem.actions.FindAction("Turret Turn");
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       TurretTurn();

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

    public void TurretTurn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Plane plane = new Plane(Vector3.up, transform.position);


        float distance;

        if (plane.Raycast(ray, out distance))
        {
            Vector3 mousePoint = ray.GetPoint(distance);
            Vector3 direction = mousePoint - transform.position;

            direction.y = 0;


            Quaternion targetRotation = Quaternion.LookRotation(direction);
            turret.transform.rotation = targetRotation;
        }
    }

}
