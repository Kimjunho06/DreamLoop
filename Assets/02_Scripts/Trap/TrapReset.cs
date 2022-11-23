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
    public List<EnemyAI> _EnemyList;
    public List<MoveTile> _MoveTileSwitchList;

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
        EnemyReset();
        PlayerStateReset();
        MoveTileReset();
    }

    private void PlayerStateReset()
    {
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

    private void EnemyReset()
    {
        for (int i = 0; i < _EnemyList.Count; i++)
        {
            _EnemyList[i].transform.position = _EnemyList[i]._originPos;
        }
    }
    
    private void MoveTileReset()
    {
        for (int i = 0; i < _MoveTileSwitchList.Count; i++)
        {
            _MoveTileSwitchList[i]._moveTileMap.transform.position = _MoveTileSwitchList[i]._originPos;
            _MoveTileSwitchList[i]._switchBxcol.enabled = true;
        }
    }

    IEnumerator ResetTraps() 
    {
        yield return new WaitForSecondsRealtime(1f);
        ResetTrap();
        yield return new WaitForSecondsRealtime(0.1f);

    }

}
