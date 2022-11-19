using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerCheck : MonoBehaviour
{

    [Header("Checking")]
    public bool _downCheck = false;


    [Header("Value Control")]
    public float _rayDistance = 1f;
    public LayerMask _checkLayer;

    [Header("Select Object")]
    public GameObject _savePointObject = null;
    public Image _fadeImage;

    private BoxCollider2D _bxCol;
    public BoxCollider2D _BxCol
    {
        get { return _bxCol; }
        set { _bxCol = value; }
    }
    

    private void Awake()
    {
        _bxCol = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        DownRayCheck();

        if (Input.GetKeyDown(KeyCode.T))
        {
            Die();
        }
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

    public void Die()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(_fadeImage.DOFade(1, 2f));
        seq.AppendCallback(SaveMove);
        seq.Append(_fadeImage.DOFade(0, 2f));
    }

    void SaveMove() => transform.position = _savePointObject.transform.position;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SavePoint"))
        {
            _savePointObject = collision.gameObject;
        }
    }

}
