using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    private Vector2 _direction;
    private Animator _animator;
    public AIPath aiPath;
    private static readonly int XDir = Animator.StringToHash("xDir");
    private static readonly int YDir = Animator.StringToHash("yDir");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        if (aiPath.desiredVelocity.x > 0f)
        {
            // Enemy is moving right
            SetAnimatorMovement(new Vector2(1, 0));
        }

        if (aiPath.desiredVelocity.x < 0f)
        {
            // Enemy is moving to the left
            SetAnimatorMovement(new Vector2(-1, 0));
        }

        if (aiPath.desiredVelocity.y > 0f)
        {
            // Player is moving upwards
            SetAnimatorMovement(new Vector2(0, 1));
        }

        if (aiPath.desiredVelocity.y < 0f)
        {
            // Enemy is moving down
            SetAnimatorMovement(new Vector2(0, -1));
        }
    }
    
    private void SetAnimatorMovement(Vector2 direction)
    {
        _animator.SetFloat(XDir, direction.x);
        _animator.SetFloat(YDir, direction.y);
    }
}
