using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    public Image fadeImage;

    private void Start()
    {
        OnFadeOut();
    }

    public void OnFadeIn() => fadeImage.DOFade(1, 1f); 
    public void OnFadeOut() => fadeImage.DOFade(0, 1f);
}
