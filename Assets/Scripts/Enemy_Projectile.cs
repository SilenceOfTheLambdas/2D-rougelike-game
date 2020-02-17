using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy_Projectile : MonoBehaviour
{
    private float _playerDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null) return;
            DamagePlayer();
            Destroy(gameObject);
            
    }

    public void SetDamage(float damage)
    {
        _playerDamage = damage;
    }

    private void DamagePlayer()
    {
        PlayerController.TakeDamage(_playerDamage);
    }
}
