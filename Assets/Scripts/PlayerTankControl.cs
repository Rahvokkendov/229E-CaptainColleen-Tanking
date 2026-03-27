using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using NUnit.Framework;
public class PlayerTankControl : MonoBehaviour
{
    public float moveFoce = 10f;
    public float maxSpeed = 100f;
    public float rotateSpeed = 100f;
    public float maxRotateSpeed = 5f;
    public float fireRate = 5f;
    private float reloadTime = 0f;
    public float recoilForce = 0f;
    
    private InputAction moveActions;
    private Rigidbody rb;

    [SerializeField] AudioSource firingSound;
    [SerializeField] AudioSource idleEngine;
    [SerializeField] AudioSource movingSound;
    [SerializeField] ParticleSystem fireEffect;
    [SerializeField] List<GameObject> wheels;
    [SerializeField] GameObject turret;
    [SerializeField] GameObject muzzle;
    [SerializeField] GameObject bulletPrefab;
    private void Awake()
    {
        moveActions = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
        
    }
    private void Update()
    {
       TurretTurn();

        if (Mouse.current.leftButton.wasPressedThisFrame && Time.time >= reloadTime)
        {
            Shoot();
            reloadTime = Time.time + fireRate;
        }
    }

    void FixedUpdate()
    {
        Move();

    }

    
    public void Move()
    {
        foreach (GameObject wheel in wheels)
        {
            wheel.transform.Rotate(Vector3.right * moveActions.ReadValue<Vector2>().y * moveFoce * Time.fixedDeltaTime);
        }

        Vector2 moveInput = moveActions.ReadValue<Vector2>();

        rb.AddForce(transform.forward * moveInput.y * moveFoce, ForceMode.Force);
        rb.AddTorque(transform.up * moveInput.x * rotateSpeed, ForceMode.Impulse);

        if (rb.angularVelocity.magnitude > maxRotateSpeed)
        {
            rb.angularVelocity = rb.angularVelocity.normalized * maxRotateSpeed;
        }

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

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);

        rb.AddForce(-turret.transform.forward * recoilForce, ForceMode.Impulse);
        rb.AddTorque(-turret.transform.forward * recoilForce, ForceMode.Impulse);
        Debug.Log("Shoot!");
        firingSound.Play();   
        fireEffect.Play();
    }


}
