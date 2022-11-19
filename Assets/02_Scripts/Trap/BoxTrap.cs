using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class BoxTrap : MonoBehaviour
{
    public int _boxTrapRunType;
    
    private bool OneCheck = false;

    private BoxCollider2D bxCol;

    private void Awake()
    {
        bxCol = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        switch (_boxTrapRunType)
        {
            case 0:
                HideBoxTrap(); break;
            case 1:
                DashingBoxTrap(); break;
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
            OneCheck = true;
        }
        print(OneCheck);

    }
}
