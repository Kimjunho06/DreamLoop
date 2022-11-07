using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float _playerSpeed = 3f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        transform.position += new Vector3(h, 0) * Time.deltaTime * _playerSpeed;
    }
}
