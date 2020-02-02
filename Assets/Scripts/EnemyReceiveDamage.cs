using UnityEngine;
using UnityEngine.UI;

public class EnemyReceiveDamage : MonoBehaviour
{

    [Header("Enemy Options")] [Space]
    public GameObject healthBar;
    public Slider healthBarSlider;
    private float _health;
    public GameManager.EnemyTypes enemyType;

    public float maxHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        _health = maxHealth;
    }

    public void DealDamage(float damage)
    {
        healthBar.SetActive(true);
        _health -= damage;
        healthBarSlider.value = _health;
        CheckDeath();
    }

    private void CheckOverheal()
    { // Check to see if the player is already at max health (so they don't over-heal)
        if (_health > maxHealth)
        {
            _health = maxHealth;
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
