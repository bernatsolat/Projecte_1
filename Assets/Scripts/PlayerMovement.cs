using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool mobing => _moving;


    [SerializeField]
    private float Speed = 1;
    private float JumpSpeed = 5;
    float timeToPike = 0.4f;
    float JumpHeight = 2.5f;
    private bool can;

    private bool _moving;
    PlayerInput _input;
    Rigidbody2D _rigidbody;

  

    void OnEnable()
    {
      
        GroundCollider.isGrounded += canJump;
    }
     
    
    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {

        Vector2 direction = new Vector2(_input.MovementHorizontal * Speed, _rigidbody.velocity.y) ;

        _rigidbody.velocity = direction;
        _moving = direction.magnitude > 0.01f;
    }

    private void Jump() 
    {
        if (can) 
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                SetGravity();
                _rigidbody.velocity = Vector2.up * JumpSpeed;
                can = false;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0f);
                SetGravity();
            }
        }   
    }
    

    private void canJump(bool canIJump)
    {
        can = canIJump;
    }
    void SetGravity()
    {

        if (JumpSpeed>0)
        {
            _rigidbody.gravityScale = ((-2 * JumpHeight / (timeToPike * timeToPike)) / Physics2D.gravity.y);
        }
        else
        {
            _rigidbody.gravityScale =  -1 * ((-2 * JumpHeight / (timeToPike * timeToPike)) / Physics2D.gravity.y);
        }
       

    }

   

}
