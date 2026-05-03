using UnityEngine;
using UnityEngine.UI;

public class HitMonster : MonoBehaviour, IDamage
{
    float hp = 10f;

    [SerializeField] private Slider hpBar;

    private void Start()
    {
        hpBar.value = hp / 10f;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        hpBar.value = hp / 10f;
        if(hp <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
