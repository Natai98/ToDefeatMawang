using UnityEngine;
using UnityEngine.UI;

public class HitPlayer : MonoBehaviour, IDamage
{
    [SerializeField] private Slider Hpbar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hpbar.value = GameManager.Instance.hp / GameManager.Instance.maxHp;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Player가 공격받았습니다.");
        GameManager.Instance.hp -= damage;
        Hpbar.value = GameManager.Instance.hp / GameManager.Instance.maxHp;
        if(GameManager.Instance.hp <= 0f)
        {
            GameManager.Instance.hp = 20f;
        }
    }

    
}
