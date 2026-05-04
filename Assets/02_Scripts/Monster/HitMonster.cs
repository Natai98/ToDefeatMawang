using UnityEngine;
using UnityEngine.UI;

public class HitMonster : MonoBehaviour, IDamage
{
    public float hp;

    [SerializeField] private Slider hpBar;
    [SerializeField] private MonsterSO monsterStat;

    private void Start()
    {
        hpBar.value = 1.0f;
        hp = monsterStat.HP;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        hpBar.value = hp / monsterStat.HP;
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
