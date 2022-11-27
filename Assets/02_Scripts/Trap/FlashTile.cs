using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashTile : MonoBehaviour
{
    public bool _isRayOn = false; // ���� ����
    public float _flashRayDistance = 0.6f;

    public GameObject _flashTile; // ���̽�� �Ӹ����� ��ġ�� ����
    public SpriteRenderer _tileSpriteRender; // _flashTile�� �̹���
    public BoxCollider2D _tileBxcol; // istrigger ���� �ٲ��ִ� ��

    public Sprite _defaultSprite; // ����
    public Sprite _changeSprite; // �ٲ� _flashTile �̹���

    private void Start()
    {
        _tileSpriteRender.sprite = _defaultSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isRayOn = true;
        }
    }

    private void Update()
    {
        FlashTileOn();
    }

    private void FlashTileOn()
    {
        if (_isRayOn)
        {
            RaycastHit2D DownRay = Physics2D.Raycast(_flashTile.transform.position, Vector2.down, _flashRayDistance, LayerMask.GetMask("Player"));
            _flashTile.gameObject.SetActive(true);
            if (DownRay.collider)
            {
                _tileSpriteRender.sprite = _changeSprite;
                _tileBxcol.isTrigger = false;
            }
        }
    } 
}
