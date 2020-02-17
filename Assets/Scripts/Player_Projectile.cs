using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Projectile : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyController>() == null) return;
            collision.GetComponent<EnemyController>().DealDamage(damage);
            Destroy(gameObject);
    }
}
