using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    [Header("Checking")]
    public bool _downCheck = false;

    [Header("Value Control")]
    public float _rayDistance = 1f;
    public LayerMask _checkLayer;

    private BoxCollider2D _bxCol;
    

    private void Awake()
    {
        _bxCol = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        DownRayCheck();
    }

    private void DownRayCheck()
    {
        RaycastHit2D Downhit = Physics2D.BoxCast(_bxCol.bounds.center, new Vector2(0.5f, 3), 0, Vector2.down, _rayDistance, _checkLayer);
        if (Downhit.collider)
        {
            _downCheck = true;
        }
        else
        {
            _downCheck = false;
        }
    }

}
