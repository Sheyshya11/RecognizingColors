using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSwap : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] Image _image;
    [SerializeField] Sprite _default, _pressed;
    ListAudio listAudio;

    private void Start()
    {
        listAudio = FindObjectOfType<ListAudio>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        listAudio.ClickButton();
        _image.sprite = _pressed;
        
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        listAudio.UnClickButton();
        _image.sprite = _default;
        
    }
}
