using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
   
    [SerializeField]
    public LayerMask WhatIsGround;
    public float checkRadius = 1/10;
    public static IsGrounded isGrounded;
    public delegate void IsGrounded(bool colision);
  


    public void CheckGround()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, checkRadius, WhatIsGround);
        bool _isGrounded = colliders.Length > 0;

        if(_isGrounded)
        {
            isGrounded?.Invoke(true);
        }

    }
   

    public void Update()
    {
        CheckGround();
        
    }
}
