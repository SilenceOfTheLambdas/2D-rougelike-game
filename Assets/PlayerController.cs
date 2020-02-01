using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;
    private Vector2 direction;
    private Animator _animator;

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
        transform.Translate(direction * (speed * Time.deltaTime));
        SetAnimatorMovement(direction);
    }

    private void TakeInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }

    private void SetAnimatorMovement(Vector2 direction)
    {
        _animator.SetFloat("xDir", direction.x);
        _animator.SetFloat("yDir", direction.y);
        print(_animator.GetFloat("xDir"));
    }
}
