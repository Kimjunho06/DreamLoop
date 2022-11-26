using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Scrollbar _backGroundBgmScroll;
    public Scrollbar _interacSoundScroll;

    public AudioSource _backGroundBgm;
    public List<AudioSource> _interacSoundList;

    private void Start()
    {
        _backGroundBgmScroll.value = PlayerPrefs.GetFloat("BackBgmSave");
        _interacSoundScroll.value = PlayerPrefs.GetFloat("InteracSoundSave");        
    }

    private void Update()
    {
        ChangeBgm();
        ChangeInteracSound();
    }

    private void ChangeBgm()
    {
        _backGroundBgm.volume = _backGroundBgmScroll.value;
        
        PlayerPrefs.SetFloat("BackBgmSave", _backGroundBgmScroll.value);
    }

    private void ChangeInteracSound()
    {
        for (int i = 0; i < _interacSoundList.Count; i++)
        {
            _interacSoundList[i].volume = _interacSoundScroll.value;
        }
        
        PlayerPrefs.SetFloat("InteracSoundSave", _interacSoundScroll.value);

        
    }
}
