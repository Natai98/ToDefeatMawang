using System.Collections;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;

    private IEnumerator Start()
    {
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
            float speed = Mathf.Clamp(distance - 1.2f, 0f, 1.0f);
            //실제 움직임에 적용할 speed
            float rgspeed = speed * 0.1f;
            rb.MovePosition(transform.position + transform.forward * 2.0f * rgspeed);
            yield return new WaitForSeconds(0.02f);
        }
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

}
