using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyHealth : Health
{
    [SerializeField] private int _scoreValue;

    [SerializeField] private int _damageOnTouch;

    private void OnCollisionEnter2D(Collision2D col)
    {
        Health health = col.gameObject.GetComponent<Health>();

        if (health)
        {
            if (health.teamSide == TeamSide.Player)
            {
                health.TakeDamage(_damageOnTouch);
                AutoDestroy();
            }
        }
    }

    protected override void Die()
    {
        ScoreManager.SharedInstance.UpdateScore(_scoreValue);
        base.Die();
    }

    private void AutoDestroy()
    {
        base.Die();
    }
}
