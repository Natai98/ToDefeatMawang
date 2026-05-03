using UnityEngine;
using UnityEngine.UI;

public class HitPlayer : MonoBehaviour, IDamage
{
    [SerializeField] private Slider Hpbar;
    private float hp = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hpbar.value = hp / 20f;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Player가 공격받았습니다.");
        hp -= damage;
        Hpbar.value = hp / 20f;
        if(hp <= 0f)
        {
            hp = 20f;
        }
    }

    
}
