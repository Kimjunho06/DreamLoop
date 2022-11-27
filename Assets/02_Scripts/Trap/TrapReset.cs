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
    public List<FlashTile> _FlashTileSwitchList;

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
        FlashTileReset();
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
            print(ex.Message + "¹º°¡ Àß¸øµÊ");
        }
    }

    private void SpikeTrapReset()
    {
        try
        {
            for (int i = 0; i < _SpkTrapList.Count; i++)
            {
                _SpkTrapList[i].SpikeReset();
            }
        }
        catch (Exception ex)
        {
            print(ex.Message + "¹º°¡ Àß¸øµÊ");
        }
    }

    private void EnemyReset()
    {
        try
        {
            for (int i = 0; i < _EnemyList.Count; i++)
            {
                _EnemyList[i].transform.position = _EnemyList[i]._originPos;
            }
        }
        catch (Exception ex)
        {
            print(ex.Message + "¹º°¡ Àß¸øµÊ");
        }
    }
    
    private void MoveTileReset()
    {
        try
        {
            for (int i = 0; i < _MoveTileSwitchList.Count; i++)
            {
                _MoveTileSwitchList[i]._moveTileMap.transform.position = _MoveTileSwitchList[i]._originPos;
                _MoveTileSwitchList[i]._switchBxcol.enabled = true;
            }
        }
        catch (Exception ex)
        {
            print(ex.Message + "¹º°¡ Àß¸øµÊ");
        }
    }

    private void FlashTileReset()
    {
        try
        {
            for (int i = 0; i < _FlashTileSwitchList.Count; i++)
            {
                _FlashTileSwitchList[i]._isRayOn = false;
                _FlashTileSwitchList[i]._tileBxcol.isTrigger = false;
                _FlashTileSwitchList[i]._tileSpriteRender.sprite = _FlashTileSwitchList[i]._defaultSprite;
                _FlashTileSwitchList[i]._flashTile.gameObject.SetActive(false);
            }
        }
        catch (Exception ex)
        {
            print(ex.Message + "¹º°¡ Àß¸øµÊ");
        }
    }

    IEnumerator ResetTraps() 
    {
        yield return new WaitForSecondsRealtime(1f);
        ResetTrap();
        yield return new WaitForSecondsRealtime(0.1f);

    }

}
