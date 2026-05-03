using System.Collections;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    private bool attackReady = true;
    private GameObject player => GameObject.FindGameObjectWithTag("Player");
    private float distance = 100f;

    private IEnumerator Start()
    {
        yield return null;
        while(true)
        {
            if (!attackReady)
            {
                yield return new WaitForSeconds(5.0f);
                attackReady = true;
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

        if(distance < 1.2f && attackReady)
        {
            player.GetComponent<IDamage>()?.TakeDamage(1.0f);
            attackReady = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // if (attackReady)
            // {
            //     other.gameObject.GetComponent<IDamage>()?.TakeDamage(1.0f);
            //     attackReady = false;
            // }
        }
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }
}
