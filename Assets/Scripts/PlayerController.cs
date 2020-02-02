using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;
    private Vector2 _direction;
    private Animator _animator;
    private static readonly int XDir = Animator.StringToHash("xDir");
    private static readonly int YDir = Animator.StringToHash("yDir");
    private static readonly int facingDown = Animator.StringToHash("FacingDown");
    private static readonly int facingUp = Animator.StringToHash("FacingUp");
    private static readonly int facingLeft = Animator.StringToHash("FacingLeft");
    private static readonly int facingRight = Animator.StringToHash("FacingRight");

    /*Player Enum showing which direction the player is facing*/
    public enum Facing
    {
        Up,
        Down,
        Left,
        Right
    }

    [SerializeField]public Facing facingDirection = Facing.Down; // The default direction the player is facing
    
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
            SetAnimatorMovement(facingDirection);
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
            facingDirection = Facing.Up;
            SetAnimatorMovement(Facing.Up);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _direction += Vector2.left;
            facingDirection = Facing.Left;
            SetAnimatorMovement(Facing.Left);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _direction += Vector2.down;
            facingDirection = Facing.Down;
            SetAnimatorMovement(Facing.Down);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _direction += Vector2.right;
            facingDirection = Facing.Right;
            SetAnimatorMovement(Facing.Right);
        }
    }

    private void SetAnimatorMovement(Facing direction)
    {
        _animator.SetLayerWeight(1, 1); // Set the layer animation to 1, so it plays
        _animator.SetBool(facingLeft, direction == Facing.Left);
        _animator.SetBool(facingRight, direction == Facing.Right);
        _animator.SetBool(facingDown, direction == Facing.Down);
        _animator.SetBool(facingUp, direction == Facing.Up);
    }

    public static void TakeDamage(float amount)
    {
        // Decrease the player's HP by a certain amount
        GameManager.Instance.playerHp -= amount;
        GameManager.Instance.SetPlayerUi();
        if (GameManager.Instance.playerHp <= 0) GameManager.GameOver();
    }
}
