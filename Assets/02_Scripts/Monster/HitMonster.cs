using UnityEngine;

public class HitMonster : MonoBehaviour, IDamage
{
    float hp = 1;

    public void TakeDamage(float damage)
    {
        hp -= damage;
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
