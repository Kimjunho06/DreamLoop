using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.VisualScripting;
using System.Net.NetworkInformation;

public class BoxTrap : MonoBehaviour
{
    public int _boxTrapRunType;
    
    public bool OneCheck = false;
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
        RaycastHit2D upBoxRay = Physics2D.BoxCast(transform.position, new Vector2(1, 2), 0, Vector2.up, 1, LayerMask.GetMask("Player"));
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
        RaycastHit2D leftRay = Physics2D.Raycast(transform.position, Vector2.left, 4, LayerMask.GetMask("Player"));
        if (leftRay.collider && OneCheck == false)
        {
            gameObject.transform.DOMove(new Vector3(transform.position.x - 5, transform.position.y), 2f);
            bxCol.offset = new Vector2(-0.9613895f, 0.02913332f);
            bxCol.size = new Vector2(0.07722092f, 1.841849f);
            OneCheck = true;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _boxTrapRunType == 1) //case 1
        {
            _playerCheck.Die();
        }
    }

    
}
