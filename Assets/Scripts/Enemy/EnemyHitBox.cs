using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{

    [SerializeField] EnemyHealth health;

    public void TakeDamage(int damageAmount)
    {
        health.TakeDamage(damageAmount);

    }
}
