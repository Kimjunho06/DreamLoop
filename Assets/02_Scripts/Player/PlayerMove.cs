using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float _jumpPower = 5f;
    public float _playerSpeed = 3f;

    public bool _isGround = false;
    public bool _isRunning = false;

    private Rigidbody2D _rigid;
    private PlayerCheck _playerCheck;
    private Animator _playerAnimator;


    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerCheck = GetComponent<PlayerCheck>();
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
        StateReset();
    }


    private void StateReset()
    {
        if (_playerCheck._downCheck) // OnGround
        {
            //about jump
            _isGround = true;
        }
        if (!_playerCheck._downCheck) // OnAir
        {
            _isGround = false;
        }
    }

    private void Jump()
    {
        if (_isGround && Input.GetKeyDown(KeyCode.Space)) // CanJump
        {
            _rigid.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }

        //Animation
        float CheckJumpValue = 0;

        if (_isGround)
        {
            CheckJumpValue = 0;
        }
        else
        {
            CheckJumpValue = _rigid.velocity.y;
        }
        print(CheckJumpValue);

    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        transform.position += new Vector3(h, 0) * Time.deltaTime * _playerSpeed;
        //Flip
        if (h > 0)
            transform.localScale = Vector3.one;
        if (h < 0)
            transform.localScale = new Vector3(-1, 1, 1);
            

        //Animation
        if (h == 0)
        {
            _isRunning = false;
        }
        else
        {
            _isRunning = true;
        }
        
        _playerAnimator.SetBool("Run", _isRunning);
    }
}
