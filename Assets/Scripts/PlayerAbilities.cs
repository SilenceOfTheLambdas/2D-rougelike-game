using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerAbilities : MonoBehaviour
{
    public static PlayerAbilities Instance;

    public GameObject player; // Get the player
    public GameObject walls; // The walls

    [Header("Dash Ability")] 
    public bool dashEnabled = true;

    public float dashRange = 0.12f;

    private Vector2 _targetPos; // Target position for the dash ability
    
    private void Awake()
    {
        // If an instance already exists, destroy it and create a new one
        if (Instance == null)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (dashEnabled) DashAbilty();
    }

    private void DashAbilty()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        _targetPos = Vector2.zero;
        switch (player.GetComponent<PlayerController>().facingDirection)
        {
            case PlayerController.Facing.Down:
                _targetPos.y = -1;
                break;
            case PlayerController.Facing.Up:
                _targetPos.y = 1;
                break;
            case PlayerController.Facing.Right:
                _targetPos.x = 1;
                break;
            case PlayerController.Facing.Left:
                _targetPos.x = -1;
                break;
            default:
                _targetPos.y = -1;
                break;
        }
        if (!player.GetComponent<BoxCollider2D>().IsTouching(walls.GetComponent<TilemapCollider2D>())) 
            player.transform.Translate(_targetPos * dashRange);
    }
}
