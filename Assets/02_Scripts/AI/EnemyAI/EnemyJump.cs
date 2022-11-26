using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    public Rigidbody2D _rigid;

    public PlayerMove _pmove;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && Input.GetKeyUp(KeyCode.Space))
        {
            _rigid.AddForce(Vector2.up * 8 * _pmove._jumpPowerPlus, ForceMode2D.Impulse);
            print("d");
        }
    }
}
