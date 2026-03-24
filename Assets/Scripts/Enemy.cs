using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : HealthPoint
{
    public SphereCollider detectionCollider;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject muzzle;
    public float turnSpeed = 5f;
    public float fireRate = 5f;
    private float reloadTime = 0f;

    private void Awake()
    {
        Init(20);
    }
    // Update is called once per frame
    void Update()
    {
       
        Detection();

    }
    
    void Detection ()
    {
        if (detectionCollider.bounds.Contains(tank.transform.position))
        {
            Vector3 direction = (tank.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
            if (Time.time >= reloadTime)
            {
                Shoot();
                reloadTime = Time.time + fireRate;
            }
        }


    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
    }

}
