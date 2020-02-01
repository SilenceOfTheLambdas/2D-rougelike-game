using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyProjectile : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy")
        {
            // TODO:
            // if (collision.GetComponent<>() == null) return;
            // collision.GetComponent<EnemyRevieveDamage>().dealDamage(damage);
            // Destroy(gameObject);
        }
    }
}
