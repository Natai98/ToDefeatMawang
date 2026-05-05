using System.Collections;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    [SerializeField] private MonsterSO monsterStat;
    public bool canMove = true;
    private Animator anim;
    private GameObject player;
    private Rigidbody rb;

    private IEnumerator Start()
    {
        anim = transform.GetChild(1).GetComponent<Animator>();
        yield return null;
        player = GameManager.Instance.player;
        rb = GetComponent<Rigidbody>();

        while (true)
        {
            Vector3 dir = player.transform.position - transform.position;
            float distance = Vector3.Distance(player.transform.position, transform.position);
            dir.y = 0f;
            dir.Normalize();
            transform.forward = dir;

            //Animation에 적용할 speed
            float speed = Mathf.Clamp(distance - monsterStat.AttackRange + 0.1f, 0f, 1.0f);
            anim.SetFloat("Move", speed);
            //실제 움직임에 적용할 speed
            float rgspeed = speed * 0.1f;
            if (canMove)
            {
                rb.MovePosition(transform.position + transform.forward * monsterStat.Speed * rgspeed);
            }
            yield return new WaitForSeconds(0.02f);
        }
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

}
