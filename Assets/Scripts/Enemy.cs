using UnityEngine;

public class Enemy : HealthPoint
{
    public SphereCollider detectionCollider;
    
    public float turnSpeed = 5f;

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
        }


    }

}
