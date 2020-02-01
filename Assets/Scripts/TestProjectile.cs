using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProjectile : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyRevieveDamage>() == null) return;
        collision.GetComponent<EnemyRevieveDamage>().dealDamage(damage);
        Destroy(gameObject);
    }
}
