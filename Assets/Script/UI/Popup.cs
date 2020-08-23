using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Popup : MonoBehaviour, GameEventListener<PopupEvent>
{
    public List<Sprite> m_Sprites;
    public List<PopupMessage> m_Messages;

    private void Awake()
    {
        
        this.AddGameEventListening<PopupEvent>();
    }
 
    /***
     *
     *   %s 층 자가 격리자가 탈출했습니다
        자가 격리자 중 %d 명의 확진자가 발생했습니다
        자가 격리자 중 %d 명이 격리 해제 되었습니다
     * 
     */
    public void OnGameEvent(PopupEvent e)
    {
        string message = string.Empty;
        ;
        switch (e.Type)
        {
            case PopupEventType.Confirm:
                message = $"{e.Count}명의 확진자가 발생했습니다.";
                Show(m_Sprites[2], message);

                break;
            
            case PopupEventType.Cure:
                message = $"{e.Count}명이 격리 해제 되었습니다.";
                Show(m_Sprites[1], message);
                break;
            
            //  0 ~  5: 1
            //  6 ~ 11: 2
            // 12 ~ 17: 3
            case PopupEventType.Escape:
                message = $"{e.Index / 6 + 1}층 격리자가 탈출했습니다.";
                Show(m_Sprites[0], message);

                break;
        }
        
        
    }


    private void Show(Sprite sprite, string message)
    {
        foreach (var showMessage in m_Messages)
        {
            if (!showMessage.Run)
            {
                showMessage.Show(sprite, message);
                return;
            }
        }
    }
}
