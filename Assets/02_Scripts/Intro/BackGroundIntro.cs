using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackGroundIntro : MonoBehaviour
{
    public float _bckgrdSpeed;

    private void Update()
    {
        BackGroundMove();
        if (transform.position.x > 415)
        {
            _bckgrdSpeed *= -1;
        }
        if (transform.position.x < -5)
        {
            _bckgrdSpeed *= -1;
        }
    }

    private void BackGroundMove()
    {
        transform.position += new Vector3(1, 0, 0) * _bckgrdSpeed * Time.deltaTime;
    }
}
