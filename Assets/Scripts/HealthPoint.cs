using UnityEngine;

public abstract class HealthPoint : MonoBehaviour
{
    public int HpPoint { get; protected set; }
    public int DamagePoint { get; protected set; }

    [SerializeField] protected GameObject tank;

    public void Init(int hp, int dmg)
    {
        HpPoint = hp;
        DamagePoint = dmg;
    }
    public void TakeDamage(int damage)
    {
        HpPoint -= damage;
        if (HpPoint <= 0)
        {
            HpPoint = 0;
            gameObject.SetActive(false);
        }
    }

}
