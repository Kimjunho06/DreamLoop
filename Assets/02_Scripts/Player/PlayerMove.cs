using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float _jumpPower = 5f;
    public float _jumpPowerPlus = 0.1f;
    public float _playerMaxSpeed = 3f;

    public bool _isGround = false;
    public bool _isRunning = false;
    public bool _isJumping = false;
    public bool _isDucking = false;

    public Image _jumpGage;

    private float _playerCurrentSpeed = 0f;

    private Rigidbody2D _rigid;
    private PlayerCheck _playerCheck;
    private Animator _playerAnimator;


    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _playerCheck = GetComponent<PlayerCheck>();
        _playerAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        _playerCurrentSpeed = _playerMaxSpeed;
    }

    private void Update()
    {
        _jumpPowerPlus = Mathf.Clamp(_jumpPowerPlus, 0.5f, 1.1f);
        Move();
        Jump();
        StateReset();
        Ducking();

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
            _jumpPowerPlus = 0f;
        }

        //Animation
        _playerAnimator.SetBool("Ground", _isGround);
    }

    private void Jump()
    {
        /*if (_isGround && Input.GetKeyDown(KeyCode.Space)) // CanJump
        {
            _rigid.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }

        if (_isGround && Input.GetKeyUp(KeyCode.Space))
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _rigid.velocity.y /2);
        }*/

        if (_isGround && Input.GetKey(KeyCode.Space))
        {
            _jumpPowerPlus += Time.deltaTime;
        }
        if (_isGround && Input.GetKeyUp(KeyCode.Space))
        {
            _rigid.AddForce(Vector2.up * _jumpPower * _jumpPowerPlus, ForceMode2D.Impulse);
            _jumpPowerPlus = 0.1f;
        }
        _jumpGage.fillAmount = (_jumpPowerPlus - 0.5f) * 1.6f;

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

        
        if (CheckJumpValue > 0)
        {
            _isJumping = true;
        }
        else if (CheckJumpValue <= 0)
        {
            _isJumping = false;
        }
        
        _playerAnimator.SetBool("Jump", _isJumping);
        

    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        transform.position += new Vector3(h, 0) * Time.deltaTime * _playerCurrentSpeed;
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

        //_isRunning = !(h == 0);
        
        _playerAnimator.SetBool("Run", _isRunning);
    }

    private void Ducking()
    {
        if (_isGround)
        {
            _isDucking = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        }
        
        if (_isDucking)
        {
            _playerCheck._BxCol.size = Vector2.one;   
            _playerCheck._BxCol.offset = new Vector2(0, -0.5f);
            _playerCurrentSpeed = 0;
        }
        else
        {
            _playerCheck._BxCol.offset = new Vector2(-0.06001854f, -0.1288932f);
            _playerCheck._BxCol.size = new Vector2(1.238384f, 1.742214f);
            _playerCurrentSpeed = _playerMaxSpeed;
        }

        //Animation
        _playerAnimator.SetBool("Duck", _isDucking);
    }

}
