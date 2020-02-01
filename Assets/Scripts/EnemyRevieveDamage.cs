using UnityEngine;

public class EnemyRevieveDamage : MonoBehaviour
{

    private float _health;

    public float maxHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        _health = maxHealth;
    }

    public void dealDamage(float damage)
    {
        _health -= damage;
        CheckDeath();
    }

    private void CheckOverheal()
    { // Check to see if the player is already at max health (so they don't overheal)
        if (_health > maxHealth)
        {
            _health = maxHealth;
        }
    }

    private void CheckDeath()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
