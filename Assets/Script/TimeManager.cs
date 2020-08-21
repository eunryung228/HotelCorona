using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private GameManager mgrGame;

    private Text timeText;
    private float time = 0;

    private int min = 0;
    private float sec = 0;

    int playTime = 2; // 일단은 정수로


    private void Start()
    {
        mgrGame = FindObjectOfType<GameManager>();
        timeText = this.GetComponent<Text>();
    }

    public void ResetTimeText()
    {
        timeText.text = "00:00";
    }

    void Update()
    {
        if (!mgrGame.backPanel.activeSelf && !FindObjectOfType<MySceneManager>().fadeImage.gameObject.activeSelf)
        {
            Debug.Log(sec);
            time += Time.deltaTime;
            sec = Mathf.Ceil(time);
            timeText.text = min.ToString("D2") + ":" + ((int)sec).ToString("D2");

            // temp
            if (sec >= 3)
            {
                time = 0;
                min = 0;
                sec = 0;
                FindObjectOfType<GameManager>().CheckConfirmNum();
            }

            if (sec >= 60)
            {
                min += 1;
                sec = 0;

                if (min == playTime)
                {
                    FindObjectOfType<GameManager>().CheckConfirmNum();
                }
            }
        }
    }
}