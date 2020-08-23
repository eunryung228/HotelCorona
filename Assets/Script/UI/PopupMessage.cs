using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

using UnityEngine.UI;
public class PopupMessage : MonoBehaviour
{
    public Image m_Image;
    public Text m_Text;

    private RectTransform m_RectTransform;
    private Vector2 m_InitPosition;

    public bool Run = false;
    
    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_InitPosition = m_RectTransform.anchoredPosition;
    }
    public void Show(Sprite sprite, string text)
    {
        Run = true;
        m_Image.sprite = sprite;
        m_Text.text = text;

        m_Image.DOFade(1, 0f);
        m_Text.DOFade(1, 0f);
        m_RectTransform.anchoredPosition = m_InitPosition;
        m_RectTransform.DOAnchorPos(Vector2.zero, 0.4f).OnComplete(() =>
        {
            m_Text.DOFade(0, 1.6f).SetDelay(0.6f);
            m_Image.DOFade(0, 1.6f).SetDelay(0.6f).OnComplete(() =>
            {
                Run = false;
            });
        });
    }
}
