using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;
    private Vector2 _direction;
    private Animator _animator;
    private static readonly int XDir = Animator.StringToHash("xDir");
    private static readonly int YDir = Animator.StringToHash("yDir");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        TakeInput();
        Move();
    }

    private void Move()
    {
        transform.Translate(_direction * (speed * Time.deltaTime));

        if (_direction.x != 0 || _direction.y != 0)
        {
            SetAnimatorMovement(_direction);
        }
        else
        {
            _animator.SetLayerWeight(1,0);
        }
    }

    private void TakeInput()
    {
        _direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _direction += Vector2.right;
        }
    }

    private void SetAnimatorMovement(Vector2 d)
    {
        _animator.SetLayerWeight(1, 1); // Set the layer animation to 1, so it plays
        _animator.SetFloat(XDir, d.x);
        _animator.SetFloat(YDir, d.y);
    }

    public static void TakeDamage(float amount)
    {
        // Decrease the player's HP by a certain amount
        GameManager.Instance.playerHp -= amount;
        GameManager.Instance.setPlayerUI();
        if (GameManager.Instance.playerHp <= 0) GameManager.GameOver();
    }
}
