using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private Text timeText;
    public Image timeImage;

    private float time = 0;

    private int hour = 8;
    private float sec = 0;
    private float checkTime = 8.57f;

    // 플레이 타임
    int playTime = 120;


    private void Start()
    {
        timeText = GetComponent<Text>();
    }

    public void ResetTime()
    {
        hour = 8;
        timeText.text = "08:00";
        timeImage.sprite = Resources.Load<Sprite>("UI/Timer/day") as Sprite;
    }

    void Update()
    {
        if (!GameManager.Instance.backPanel.activeSelf && !FindObjectOfType<MySceneManager>().fadeImage.gameObject.activeSelf)
        {
            time += Time.deltaTime;
            sec = Mathf.Ceil(time);

            if (sec >= 4.28)
            {
                hour += 1;
                sec = 0;
                timeText.text = hour.ToString("D2") + ":00";
                time = 0;

                if (hour == 15) // 원래 값 15
                    GameEvent.Trigger(GameEventType.Half);
                else if(hour == 18)
                    timeImage.sprite = Resources.Load<Sprite>("UI/Timer/night") as Sprite;
                //else if (hour == 10) // 원래 값 22
                  //  GameManager.Instance.CheckGameState();
                else if (hour == 22)
                    GameManager.Instance.CheckGameState();
            }
        }
    }
}