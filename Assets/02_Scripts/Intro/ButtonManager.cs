using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    public Image fadeImage;

    public Image _panel;
    public Image _panelBackGround;

    public Button _HowToOnBtn;
    public Button _HowToOffBtn;

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

    public void OnHowToOpen()
    {
        Sequence seq = DOTween.Sequence();
        _HowToOnBtn.interactable = false;
        seq.AppendCallback(PanelOnActive);
        seq.Append(_panel.DOFade(0.2f, 1f));
        seq.AppendCallback(PanelBackOnActive);
        seq.Append(_panelBackGround.transform.DOScale(1, 1f).SetEase(Ease.OutBounce));
        seq.AppendCallback(OptionCloseBtnOnActive);
    }
    public void OnHowToClose()
    {
        Sequence seq = DOTween.Sequence();
        _HowToOffBtn.gameObject.SetActive(false);
        seq.Append(_panelBackGround.transform.DOScale(0, 1f).SetEase(Ease.OutBounce));
        seq.AppendCallback(PanelBackOffActive);
        seq.Append(_panel.DOFade(0, 1f));
        seq.AppendCallback(PanelOffActive);
        seq.AppendCallback(OptionOpenBtnOnActive);
        seq.AppendCallback(HowToBtnAbleToInterac);
        
    }

    private void PanelOnActive() => _panel.gameObject.SetActive(true);
    private void PanelOffActive() => _panel.gameObject.SetActive(false);
    private void PanelBackOnActive() => _panelBackGround.gameObject.SetActive(true);
    private void PanelBackOffActive() => _panelBackGround.gameObject.SetActive(false);

    private void OptionOpenBtnOnActive() => _HowToOnBtn.gameObject.SetActive(true);
    private void OptionCloseBtnOnActive() => _HowToOffBtn.gameObject.SetActive(true);

    private void HowToBtnAbleToInterac() => _HowToOnBtn.interactable = true;
}
