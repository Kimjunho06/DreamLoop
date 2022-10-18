using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public float _playerSpeed = 5f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.position += new Vector3(h, 0 ,v) * Time.deltaTime * _playerSpeed;
    }
}
