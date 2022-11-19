using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapReset : MonoBehaviour
{
    public PlayerCheck _playerCheck;
    public List<BoxTrap> _bxTrapList;

    private void Update()
    {
        if (_playerCheck._dieCheck)
        {
            StartCoroutine("ResetTraps");
        }    
    }

    private void ResetTrap()
    {
        BoxTrapReset();
    }

    private void BoxTrapReset()
    {
        try
        {
            for (int i = 0; i < _bxTrapList.Count; i++)
            {
                _bxTrapList[i].OneCheck = false;
                _bxTrapList[i].transform.position = _bxTrapList[i]._originPos;
                _bxTrapList[i].gameObject.SetActive(true);
            }
        }
        catch (Exception ex)
        {
            print(ex.Message);
            return;
        }
    }

    IEnumerator ResetTraps() 
    {
        yield return new WaitForSecondsRealtime(1.2f);
        ResetTrap();
        yield return new WaitForSecondsRealtime(0.1f);

    }

}
