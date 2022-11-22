using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Change Value")]
    public int _randomState; // Case 0 : Idle , Case 1 : Left, Case 2 : Right
    public float _changeRandomDelay;
    public float _enemySpeed;
    [Header("Check Value")]
    public Vector2 _originPos;

    private int _enemyMoveDir;
    private int _enemyLook;

    Animator _enemyAnimator;
    PlayerCheck _playerCheck;

    private void Awake()
    {
        _enemyAnimator = GetComponent<Animator>();
        _playerCheck = FindObjectOfType<PlayerCheck>();
    }

    private void Start()
    {
        StartCoroutine(RandomMove());
        _originPos = transform.position;
    }

    private void Update()
    {
        Move();
        switch (_randomState)
        {                
            case 0: // Idle
                IdleState(); break; 
            case 1: // Left
                LeftState(); break;
            case 2: // Right
                RightState(); break;
        }        
    }

    private void Move()
    {
        transform.position += new Vector3(_enemyMoveDir, 0) * Time.deltaTime * _enemySpeed;
        _enemyAnimator.SetBool("Moving", _randomState != 0);
        
    }

    private void IdleState()
    {
        _enemyMoveDir = 0;
    }

    private void LeftState()
    {
        _enemyMoveDir = -1;
        _enemyLook = 1;
        transform.localScale = new Vector3(_enemyLook, 1, 1);
    }

    private void RightState()
    {
        _enemyMoveDir = 1;
        _enemyLook = -1;
        transform.localScale = new Vector3(_enemyLook, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyLimit") && _randomState == 1)
        {
            _randomState = 2;
            return;
        }
        if (collision.gameObject.CompareTag("EnemyLimit") && _randomState == 2)
        {
            _randomState = 1;
            return;
        }
        
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerCheck.Die();
        }
    }

    IEnumerator RandomMove()
    {
        while (true)
        {
            _randomState = Random.Range(0, 3);
            if (_randomState == 0)
            {
                _changeRandomDelay = Random.Range(1f, 1.2f);
            }
            else
            {
                _changeRandomDelay = Random.Range(2f, 4f);
            }
            yield return new WaitForSecondsRealtime(_changeRandomDelay);
            
        }
    }

   
}
