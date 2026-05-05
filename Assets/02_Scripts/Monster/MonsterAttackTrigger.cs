using UnityEngine;

public class MonsterAttackTrigger : MonoBehaviour
{
    private MonsterAttack monster;

    private void Start()
    {
        monster = transform.parent.GetComponent<MonsterAttack>();
    }

    private void AttackTrigger()
    {
        monster.Attack();
    }
}
