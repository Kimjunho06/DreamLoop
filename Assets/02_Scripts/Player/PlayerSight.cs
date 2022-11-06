using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSight : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 500.0f;

    private float xRotate;
    private float yRotate;
    private float xRotateMove;
    private float yRotateMove;

    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
        yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
        yRotate = transform.eulerAngles.y + yRotateMove;
        //xRotate = transform.eulerAngles.x + xRotateMove; 
        xRotate = xRotate + xRotateMove;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f); // À§, ¾Æ·¡ 
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        
    }
}
