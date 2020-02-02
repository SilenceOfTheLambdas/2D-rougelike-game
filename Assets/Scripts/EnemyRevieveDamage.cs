using UnityEngine;
using UnityEngine.UI;

public class EnemyRevieveDamage : MonoBehaviour
{

    public GameObject healthBar;
    public Slider healthBarSlider;
    private float _health;

    public float maxHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        _health = maxHealth;
    }

    public void dealDamage(float damage)
    {
        healthBar.SetActive(true);
        _health -= damage;
        healthBarSlider.value = _health;
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
