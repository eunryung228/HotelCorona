using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorPanel : MonoBehaviour, GameEventListener<GameEvent>
{
    public List<Sprite> m_ButtonSprites;
    
    public Button m_PrevButton;
    public List<Button> m_Buttons;
    public Button m_NextButton;

    private int m_LastPage;
    
    private void Awake()
    {
        this.AddGameEventListening<GameEvent>();
    }

    public void OnGameEvent(GameEvent e)
    {
        switch (e.Type)
        {
            case GameEventType.DailyStart:
            case GameEventType.PageChange:
            RefreshButtons();
            break;
        }
    }

    private void RefreshButtons()
    {
        int currentPage = GameManager.Instance.currentPage;
        m_LastPage = BalanceData.maxRoom[GameManager.Instance.day] / 6;
        
        m_PrevButton.enabled = (currentPage != 1);
        m_NextButton.enabled = (currentPage != m_LastPage);

        for (int i = 0; i < m_Buttons.Count; ++i)
        {
            m_Buttons[i].image.sprite = (currentPage == (i + 1)) ? m_ButtonSprites[i] : m_ButtonSprites[4 + i];
            m_Buttons[i].enabled = (i < m_LastPage);
        }
    }

    public void OnClickPrev()
    {
        GameManager.Instance.currentPage -= 1;
        GameEvent.Trigger(GameEventType.PageChange);
    }

    public void OnClickFloor(int floor)
    {
        GameManager.Instance.currentPage = floor;
        GameEvent.Trigger(GameEventType.PageChange);
    }
    
    public void OnClickNext()
    {
        GameManager.Instance.currentPage += 1;
        GameEvent.Trigger(GameEventType.PageChange);
    }
}
