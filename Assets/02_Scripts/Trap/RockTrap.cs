using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RockTrap : MonoBehaviour
{
    public float _rockDistance = 2f;
    public float _rockDelay = 0.3f;
    public Vector2 _originPos;

    private void Update()
    {
        RockTrapOn();
    }

    private void Start()
    {
        _originPos = transform.position;    
    }

    private void RockTrapOn()
    {
        RaycastHit2D leftRay = Physics2D.BoxCast(transform.position, new Vector2(2, 1), 0, Vector2.left, _rockDistance, LayerMask.GetMask("Player"));
    
        if (leftRay.collider)
        {
            StartCoroutine("RockTrapOnDelay");
        }
    }

    IEnumerator RockTrapOnDelay()
    {
        transform.DOMove(new Vector3(transform.position.x - 1f, transform.position.y), _rockDelay);
        yield return new WaitForSecondsRealtime(0.2f);
        transform.DOMove(new Vector3(transform.position.x + 1f, transform.position.y), _rockDelay);

    }
}
