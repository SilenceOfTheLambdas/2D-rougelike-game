using System;
using System.Collections;
using Pathfinding;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{   
    [Header("Imports")] [Space] 
    public AIPath aiSystem; // The AIPath System
    [FormerlySerializedAs("_projectile")] [SerializeField]private GameObject projectile; // The actual projectile object
    public Transform player; // The player
    
    [Header("Enemy Health Options")] [Space]
    // UI Stuff
    public GameObject healthBar;
    public Slider healthBarSlider;
    
    public GameManager.EnemyTypes enemyType;
    private float _maxHealth; // Health is dependant on what type the enemy is

    // Other Stuff
    public float minDmg; // Minimum damage the enemy can inflict
    public float maxDmg; // Maximum damage the enemy can inflict
    public float projectileForce; // The 'speed' in which the projectile moves
    public float cooldown; // The cooldown for how often the projectile coroutine is started
    
    
    private float _health; // The current health of the enemy

    private void Start()
    {   
        SetEnemyProperties();
        StartCoroutine(ShootPlayer());
    }

    public void DealDamage(float damage)
    {
        healthBar.SetActive(true);
        _health -= damage;
        healthBarSlider.value = _health;
        CheckDeath();
    }

    private void SetEnemyProperties()
    {
        // Setup the enemy stuff like; maxHealth, Damage etc.
        switch (enemyType)
        {
            case GameManager.EnemyTypes.Tier1:
                maxDmg = 25;
                minDmg = 15;
                _maxHealth = 50;
                projectileForce = 1;
                cooldown = 4;
                aiSystem.maxSpeed = 1.8f;
                break;
            case GameManager.EnemyTypes.Tier2:
                maxDmg = 50;
                minDmg = 25;
                _maxHealth = 75;
                projectileForce = 2;
                cooldown = 3;
                aiSystem.maxSpeed = 2f;
                break;
            case GameManager.EnemyTypes.Tier3:
                maxDmg = 75;
                minDmg = 50;
                _maxHealth = 100;
                projectileForce = 3;
                cooldown = 2;
                aiSystem.maxSpeed = 2.2f;
                break;
            case GameManager.EnemyTypes.Miniboss:
                maxDmg = 90;
                minDmg = 65;
                _maxHealth = 125;
                projectileForce = 3.3f;
                cooldown = 2;
                aiSystem.maxSpeed = 2.2f;
                break;
            case GameManager.EnemyTypes.Boss:
                // TODO: Each boss will have a certain level and unique feature
                maxDmg = 90;
                minDmg = 75;
                _maxHealth = 150;
                projectileForce = 3.5f;
                cooldown = 1.5f;
                aiSystem.maxSpeed = 2.5f;
                break;
        }
        _health = _maxHealth; // Set the current health equal to the max health
    }
    
    IEnumerator ShootPlayer()
    {
        // This code can wait; it is paused using the cooldown timer
        yield return new WaitForSeconds(cooldown);
        if (player != null)
        {
            var position = transform.position;
            // Spawn it in the game world
            var spell = Instantiate(projectile, position, Quaternion.identity);
            Vector2 myPos = position;
            Vector2 targetPos = player.position;
            var direction = (targetPos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<Enemy_Projectile>().SetDamage(Random.Range(minDmg, maxDmg));
            StartCoroutine(ShootPlayer());
        }
    }
    
    private void CheckDeath()
    {
        if (_health <= 0)
        {
            GameManager.Instance.OnKill(enemyType);
            Destroy(gameObject);
        }
    }
}
