using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    public Image fadeImage;

    public void OnStart()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(fadeImage.DOFade(1, 1f));
        seq.AppendCallback(OnMainScene);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnMainScene()
    {
        SceneManager.LoadScene("Main");

    }

}
