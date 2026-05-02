using UnityEngine;

public interface IMove
{
    void Move();
}

public interface IDamage
{
    void TakeDamage(float damage);
}

public interface IGet
{
    void Get();
}
