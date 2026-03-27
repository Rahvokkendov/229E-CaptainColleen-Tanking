using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    public HealthPoint playerHp;
    public Slider hpSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHp != null)
        {
            hpSlider.value = playerHp.HpPoint;
        }
    }
}
