using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MadeByTxt : MonoBehaviour, IPointerDownHandler
{
    public TextMeshProUGUI _madebyTxt;

    public void OnPointerDown(PointerEventData eventData)
    {
        _madebyTxt.gameObject.SetActive(true);
    }
}
