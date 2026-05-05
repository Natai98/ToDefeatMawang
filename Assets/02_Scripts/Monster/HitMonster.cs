using UnityEngine;
using UnityEngine.UI;

public class HitMonster : MonoBehaviour, IDamage
{
    public float hp;

    [SerializeField] private Slider hpBar;
    [SerializeField] private MonsterSO monsterStat;

    private Animator anim;

    private void Start()
    {
        hpBar.value = 1.0f;
        hp = monsterStat.HP;

        anim = transform.GetChild(1).GetComponent<Animator>();
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
        anim.SetTrigger("Die");
        Destroy(this.gameObject, 2.0f);
    }
}
