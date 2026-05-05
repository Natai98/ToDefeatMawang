using System.Collections;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField] private MonsterSO monsterStat;
    private Animator anim;
    private bool attackReady = true;
    private GameObject player;
    private float distance = 100f;

    private IEnumerator Start()
    {
        anim = transform.GetChild(1).GetComponent<Animator>();
        yield return null;
        player = GameManager.Instance.player;
        while(true)
        {
            if (distance <= monsterStat.AttackRange)
            {
                GetComponent<MonsterMove>().canMove = false;
                anim.SetTrigger("Attack");
                yield return new WaitForSeconds(5.0f);
            }

            yield return null;
        }
    }

    private void Update()
    {
        if(player != null)
        {
            distance = Vector3.Distance(player.transform.position, transform.position);
        }
    }

    public void Attack()
    {
        if(distance <= monsterStat.AttackRange)
        {
            player.GetComponent<IDamage>()?.TakeDamage(monsterStat.ATK);
        }
        Invoke("MoveAgain", 0.3f);
    }

    private void MoveAgain()
    {
        GetComponent<MonsterMove>().canMove = true;
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }
}
