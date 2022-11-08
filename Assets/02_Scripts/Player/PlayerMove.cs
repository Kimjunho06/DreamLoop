using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float _jumpPower = 5f;
    public float _playerSpeed = 3f;

    private bool _isGround = false;

    private Rigidbody2D _rigid;
    private PlayerCheck _playerCheck;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerCheck = GetComponent<PlayerCheck>();
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
            _isGround = false;
        }
        if (!_playerCheck._downCheck) // OnAir
        {
            _isGround = true;
        }
    }

    private void Jump()
    {
        if (!_isGround && Input.GetKeyDown(KeyCode.Space)) // CanJump
        {
            _rigid.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        transform.position += new Vector3(h, 0) * Time.deltaTime * _playerSpeed;
    }
}
