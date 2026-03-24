using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody rb;
    public float shootForce = 50f;
    public int damagePoint = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        HealthPoint hp = collision.gameObject.GetComponent<HealthPoint>();
        if (hp != null)
        {

            hp.TakeDamage(damagePoint); 
        }
        Destroy(gameObject);
    }

    
}
