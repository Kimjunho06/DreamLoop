using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTile : MonoBehaviour
{
    [Header("Change Value")]
    public GameObject _moveTileMap;
    public float _moveTileDir; // + : Right, - : Left
    public float _moveDur = 1f;

    [Header("Move Option")]
    public bool OneCheck;

    [Header("Check Value")]
    public Vector2 _originPos;

    private BoxCollider2D _SwitchBxcol;
    public BoxCollider2D _switchBxcol => _SwitchBxcol;

    private void Awake()
    {
        _SwitchBxcol = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        _originPos = _moveTileMap.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MoveTrap();
        }
    }

    private void MoveTrap()
    {
        _moveTileMap.transform.DOMove(new Vector3(_moveTileMap.transform.position.x + _moveTileDir, _moveTileMap.transform.position.y), _moveDur);
            
        if (OneCheck)
        {
            _SwitchBxcol.enabled = false;
        }
    }
}
