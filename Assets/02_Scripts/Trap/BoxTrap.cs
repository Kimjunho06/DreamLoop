using System;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using System.Collections;

public class BoxTrap : MonoBehaviour
{
    [Header("Case")]
    public int _boxTrapRunType;
    
    [Header("Case 0 : HideBox")]
    public int _boxHideDistance;

    [Header("Case 1 : DashBox")]
    public int _boxDashSpeed;
    public int _boxDashDistance;
    public bool _isBackDash;

    [Header("Just Check")]
    public bool OneCheck = false;
    public bool BackDash = false;
    public Vector2 _originPos;

    private BoxCollider2D bxCol;
    private PlayerCheck _playerCheck;


    private void Awake()
    {
        bxCol = GetComponent<BoxCollider2D>();
        _playerCheck = FindObjectOfType<PlayerCheck>();
    }

    private void Start()
    {
        _originPos = transform.position;
    }

    private void Update()
    {
        try
        {
            switch (_boxTrapRunType)
            {
                case 0:
                    HideBoxTrap(); break;
                case 1:
                    DashingBoxTrap(); break;
            }
        }
        catch (Exception ex)
        {
            return;
        }

        //Test Code
        Debug.DrawRay(transform.position, Vector3.left * 4, Color.red);
        

    }

    private void HideBoxTrap() // Case 0
    {
        RaycastHit2D upBoxRay = Physics2D.BoxCast(transform.position, new Vector2(1, 2), 0, Vector2.up, _boxHideDistance, LayerMask.GetMask("Player"));
        try
        {
            if (upBoxRay.collider)
            {
                gameObject.SetActive(false);
            }
        }
        catch (Exception ex)
        {
            print(ex.Message);
        }
        
    }

    private void DashingBoxTrap() // Case 1
    {
        RaycastHit2D leftRay = Physics2D.Raycast(transform.position, Vector2.left, _boxDashDistance, LayerMask.GetMask("Player"));
        RaycastHit2D rightRay = Physics2D.Raycast(transform.position, Vector2.right, _boxDashDistance, LayerMask.GetMask("Player"));

        if (!OneCheck)
        {
            if (leftRay.collider)
            {
                StartCoroutine(LeftDash());
            }
        }
        if (BackDash)
        {
            if (rightRay.collider)
            {
                StartCoroutine(RightDash());
            }    
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _boxTrapRunType == 1) //case 1
        {
            _playerCheck.Die();
        }
    }

    IEnumerator LeftDash()
    {
        gameObject.transform.DOMove(new Vector3(transform.position.x - _boxDashSpeed, transform.position.y), 1f);
        bxCol.offset = new Vector2(-0.9613895f, 0.02913332f);
        bxCol.size = new Vector2(0.07722092f, 1.841849f);
        OneCheck = true;
        yield return new WaitForSeconds(2f);
        if (_isBackDash)
        {
            BackDash = true;
        }
    }

    IEnumerator RightDash()
    {
        gameObject.transform.DOMove(new Vector3(transform.position.x + _boxDashSpeed, transform.position.y), 1f);
        bxCol.offset = new Vector2(0.958489f, -0.04078674f);
        bxCol.size = new Vector2(0.051983f, 1.841849f);
        BackDash = false;
        yield return new WaitForSecondsRealtime(3f);   
    }
}
