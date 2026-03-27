using UnityEngine;

public abstract class HealthPoint : MonoBehaviour
{
    public int HpPoint { get; protected set; }

    [SerializeField] protected GameObject tank;
    [SerializeField] protected AudioSource hitSound;
    public void Init(int hp)
    {
        HpPoint = hp;

    }
    public void TakeDamage(int damage)
    {
        HpPoint -= damage;
        hitSound.Play();
        if (HpPoint <= 0)
        {
            
            HpPoint = 0;
            gameObject.SetActive(false);
        }
    }

}
