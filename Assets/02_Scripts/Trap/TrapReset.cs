using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapReset : MonoBehaviour
{
    public PlayerCheck _playerCheck;
    public List<BoxTrap> _bxTrapList;
    public List<SpikeTrap> _SpkTrapList;

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
        SpikeTrapReset();
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

    private void SpikeTrapReset()
    {
        for (int i = 0; i < _SpkTrapList.Count; i++)
        {
            _SpkTrapList[i].SpikeReset();
        }
    }

    IEnumerator ResetTraps() 
    {
        yield return new WaitForSecondsRealtime(1f);
        ResetTrap();
        yield return new WaitForSecondsRealtime(0.1f);

    }

}
