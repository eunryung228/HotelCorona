using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject floorPanel;
    public GameObject skillPanel;
    public GameObject backPanel;
    public GameObject passDayPanel;
    public GameObject failDayPanel;


    // 총 게임 데이터
    public int confirmNum = 0;
    public int cureNum = 0;
    public int escapeNum = 0;

    // 일일 게임 데이터
    public int dailyConfirmNum = 0;
    public int dailyCureNum = 0;
    public int dailyEscapeNum = 0;

    // 인카운터 용
    int totalConfirmNum = 5;

    // 대기 중인 격리자 수
    int remainQuarStby;

    int currentRoom;
    int maxRoom;

    public int nowSkill { get; set; } = -1;
    int roomNum = -1;

    Button[] skillList;



    private void Start()
    {
        mgrScene = FindObjectOfType<MySceneManager>();
    }


    // temp
    public void UpUp()
    {
        dailyConfirmNum += 1;
    }
    //

    public void SetOffUIPanels()
    {
        backPanel.SetActive(false);
        newsPanel.SetActive(false);
        dayPanel.SetActive(false);
        floorPanel.SetActive(false);
        skillPanel.SetActive(false);
        passDayPanel.SetActive(false);
        failDayPanel.SetActive(false);
    }

    public void SetOffFailPanel()
    {
        backPanel.SetActive(false);
        failDayPanel.SetActive(false);
    }

    public void StartGame()
    {
        newsPanel.SetActive(true);
        dayPanel.SetActive(true);
        skillPanel.SetActive(true);
        floorPanel.SetActive(true);

        skillList = skillPanel.GetComponentsInChildren<Button>();
    }


    private void UpdateData()
    {
        confirmNum += dailyConfirmNum;
        cureNum += dailyCureNum;
        escapeNum += dailyEscapeNum;
        ResetTodayData();
    }

    private void ResetTodayData()
    {
        dailyCureNum = 0;
        escapeNum = 0;
        dailyEscapeNum = 0;
    }

    public void ResetAllData()
    {
        confirmNum = 0;
        dailyConfirmNum = 0;
        cureNum = 0;
        ResetTodayData();
    }

    public void CheckConfirmNum()
    {
        UpdateData();
        backPanel.SetActive(true);
        if (confirmNum >= totalConfirmNum)
        {
            failDayPanel.SetActive(true);
            failDayPanel.transform.GetChild(0).GetComponent<ResultManager>().SetResult();
        }
        else
        {
            passDayPanel.SetActive(true);
            passDayPanel.transform.GetChild(0).GetComponent<ResultManager>().SetResult();
        }
    }

    public void ClickPassDayBtn()
    {
        backPanel.SetActive(false);
        passDayPanel.SetActive(false);
        mgrScene.PlayPassDay();
    }

    public void ClickBackToTitleBtn()
    {
        ResetAllData();
        mgrScene.ChangeScene("TitleScene");
    }

    public void ClickRestartGameBtn()
    {
        ResetAllData();
        mgrScene.Restart();
    }


    private void ClickTarget()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity);

            if (!backPanel.activeSelf && !mgrScene.fadeImage.gameObject.activeSelf)
            {
                if (hit.collider != null)
                {
                    if (nowSkill != -1)
                    {
                        roomNum = hit.collider.gameObject.GetComponent<Room>().roomNumber;
                        skillList[nowSkill].GetComponent<Skill>().Use(roomNum);
                        roomNum = nowSkill = -1;
                    }
                }
            }
            else
            {
                roomNum = nowSkill = -1;
            }
        }
    }

    private void Update()
    {
        ClickTarget();
    }
}