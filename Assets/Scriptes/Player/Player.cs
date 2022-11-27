using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Movement _movement;

    private int _money;

    public void RaiseCoin(int reward)
    {
        _money += reward;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _movement.PlayAnimationHit();

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
