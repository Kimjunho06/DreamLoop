using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashTile : MonoBehaviour
{
    public bool _isRayOn = false; // 레이 생성
    public float _flashRayDistance = 0.6f;
    public Vector2 _castSize;

    public GameObject _flashTile; // 레이쏘고 머리박을 위치의 함정
    public SpriteRenderer _tileSpriteRender; // _flashTile의 이미지
    public BoxCollider2D _tileBxcol; // istrigger 상태 바꿔주는 것

    public Sprite _defaultSprite; // 투명
    public Sprite _changeSprite; // 바꿀 _flashTile 이미지

    private void Start()
    {
        _tileSpriteRender.sprite = _defaultSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(RayOnDelay());
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
            RaycastHit2D DownBoxRay = Physics2D.BoxCast(_flashTile.transform.position, _castSize, 0, Vector2.down, _flashRayDistance, LayerMask.GetMask("Player"));
            _flashTile.gameObject.SetActive(true);
            if (DownBoxRay.collider)
            {
                _tileSpriteRender.sprite = _changeSprite;
                _tileBxcol.isTrigger = false;
            }
        }
    } 

    IEnumerator RayOnDelay()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        _isRayOn = true;
    }
}
