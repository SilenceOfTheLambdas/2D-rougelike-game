using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float cameraSmoothing;
    [SerializeField]private Vector3 _offset;
    
    private void FixedUpdate()
    {
        if (player != null)
        {
            var newPosition = Vector3.Lerp(transform.position, player.transform.position + _offset, cameraSmoothing);
            transform.position = newPosition;
        }
    }
}
