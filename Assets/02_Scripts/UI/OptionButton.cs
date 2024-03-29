using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class OptionButton : MonoBehaviour
{
    public Image _panel;
    public Image _panelBackGround;

    public Button _optionOnBtn;
    public Button _optionOffBtn;

    public AudioSource _clickSound;

    public void OnClickSound() => _clickSound.Play();
    

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnPanelOpen()
    {
        Sequence seq = DOTween.Sequence();
        _optionOnBtn.gameObject.SetActive(false);
        seq.AppendCallback(PanelOnActive);
        seq.Append(_panel.DOFade(0.2f, 1f));
        seq.AppendCallback(PanelBackOnActive);
        seq.Append(_panelBackGround.transform.DOScale(1, 1f).SetEase(Ease.OutBounce));
        seq.AppendCallback(OptionCloseBtnOnActive);
    }

    public void OnPanelClose()
    {
        Sequence seq = DOTween.Sequence();
        _optionOffBtn.gameObject.SetActive(false);
        seq.Append(_panelBackGround.transform.DOScale(0, 1f).SetEase(Ease.OutBounce));
        seq.AppendCallback(PanelBackOffActive);
        seq.Append(_panel.DOFade(0, 1f));
        seq.AppendCallback(PanelOffActive);
        seq.AppendCallback(OptionOpenBtnOnActive);
    }

    private void PanelOnActive() => _panel.gameObject.SetActive(true);
    private void PanelOffActive() => _panel.gameObject.SetActive(false);
    private void PanelBackOnActive() => _panelBackGround.gameObject.SetActive(true);
    private void PanelBackOffActive() => _panelBackGround.gameObject.SetActive(false);

    private void OptionOpenBtnOnActive() => _optionOnBtn.gameObject.SetActive(true);
    private void OptionCloseBtnOnActive() => _optionOffBtn.gameObject.SetActive(true);
}
