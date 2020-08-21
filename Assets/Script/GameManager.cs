using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    private MySceneManager mgrScene;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

    public GameObject dayPanel;
    public GameObject newsPanel;
    public GameObject backPanel;
    public GameObject passDayPanel;
    public GameObject failDayPanel;


    // 총 게임 데이터
    int confirmNum = 0;
    int cureNum = 0;
    int escapeNum = 0;

    // 일일 게임 데이터
    int dailyConfirmNum = 0;
    int dailyCureNum = 0;
    int dailyEscapeNum = 0;

    // 인카운터 용
    int totalConfirmNum = 342;

    // 대기 중인 격리자 수
    int remainQuarStby;

    int currentRoom;
    int maxRoom;



    private void Start()
    {
        mgrScene = FindObjectOfType<MySceneManager>();
    }

    public void StartDay()
    {
        newsPanel.SetActive(true);
        dayPanel.SetActive(true);
    }


    public void CheckConfirmNum()
    {
        backPanel.SetActive(true);
        if (confirmNum >= totalConfirmNum)
        {
            failDayPanel.SetActive(true);
        }
        else
        {
            passDayPanel.SetActive(true);
        }
    }

    public void ClickPassDayBtn()
    {
        backPanel.SetActive(false);
        passDayPanel.SetActive(false);
        mgrScene.PlayPassDay();
    }
}