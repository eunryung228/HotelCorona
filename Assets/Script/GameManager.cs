using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Ready,
    Play,
    End,
}

public partial class GameManager : MonoBehaviour, GameEventListener<GameEvent>
{
    static public GameManager Instance;

    public GameState CurrentState = GameState.Ready;

    private void Awake()
    {
        Instance = this;
        
        this.AddGameEventListening<GameEvent>();
    }


    public GameObject dayPanel;
    public GameObject newsPanel;
    public GameObject floorPanel;
    public GameObject skillPanel;
    public GameObject backPanel;
    public GameObject passDayPanel;
    public GameObject failDayPanel;
    public GameObject endingPanel;


    // 총 게임 데이터
    public int confirmNum = 0;
    public int cureNum = 0;
    public int escapeNum = 0;

    // 일일 게임 데이터
    public int dailyConfirmNum = 0;
    public int dailyCureNum = 0;
    public int dailyEscapeNum = 0;

    public int day = 0;

    // 대기 중인 격리자 수
    int remainQuarStby = 0;

    public int currentRoom = 0;

    public int nowSkill { get; set; } = -1;
    int roomNum = -1;

    Button[] skillList;


    // 현재 페이지 (default = 1);
    public int currentPage = 1;


    public void SetOffUIPanels()
    {
        backPanel.SetActive(false);
        newsPanel.SetActive(false);
        dayPanel.SetActive(false);
        floorPanel.SetActive(false);
        skillPanel.SetActive(false);
        passDayPanel.SetActive(false);
        failDayPanel.SetActive(false);
        endingPanel.SetActive(false);
    }

    public void SetOffPanelForRetry()
    {
        backPanel.SetActive(false);
        failDayPanel.SetActive(false);
        endingPanel.SetActive(false);
    }


    // StartGame이랑 StartDay랑 협의 보기 *^^*
    public void StartGame()
    {
        newsPanel.SetActive(true);
        dayPanel.SetActive(true);
        skillPanel.SetActive(true);
        floorPanel.SetActive(true);

        skillList = skillPanel.GetComponentsInChildren<Button>();
    }

    public void StartDay()
    {
        GameEvent.Trigger(GameEventType.DailyStart);
    }


    private void ResetTodayData()
    {
        dailyCureNum = 0;
        dailyConfirmNum = 0;
        dailyEscapeNum = 0;
    }

    public void ResetAllData()
    {
        cureNum = 0;
        confirmNum = 0;
        escapeNum = 0;
        ResetTodayData();
    }

    public void CheckGameState()
    {
        GameEvent.Trigger(GameEventType.DailyEnd);
        
        
        backPanel.SetActive(true);

        if (escapeNum >= BalanceData.failEscapeNum)
        {
            failDayPanel.SetActive(true);
            failDayPanel.transform.GetChild(0).GetComponent<ResultManager>().SetResult();
        }
        else if (day >= BalanceData.successDayNum) // 게임 엔딩 판정
        {
            endingPanel.SetActive(true);
            endingPanel.transform.GetChild(0).GetComponent<ResultManager>().SetResult();
        }
        else
        {
            passDayPanel.SetActive(true);
            passDayPanel.transform.GetChild(0).GetComponent<ResultManager>().SetResult();
        }
        ResetTodayData();
    }

    public void ClickPassDayBtn()
    {
        backPanel.SetActive(false);
        passDayPanel.SetActive(false);
        MySceneManager.Instance.PlayPassDay();
    }

    public void ClickBackToTitleBtn()
    {
        ResetAllData();
        MySceneManager.Instance.ChangeScene("TitleScene");
    }

    public void ClickRestartGameBtn()
    {
        ResetAllData();
        MySceneManager.Instance.Restart();
    }


    private void ClickTarget()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity);

            if (!backPanel.activeSelf && !MySceneManager.Instance.fadeImage.gameObject.activeSelf)
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

        if (CurrentState == GameState.Play)
        {
            EscapeCheck();
        }
    }
}

public partial class GameManager : MonoBehaviour, GameEventListener<GameEvent>
{
    public void OnGameEvent(GameEvent e)
    {
        switch (e.Type)
        {
            // 하루가 시작하면 아래 함수들이 호출된다.
            // 하루 시작을 알리는 이벤트: GameEvent.Trigger(GameEventType.DailyStart);
            case GameEventType.DailyStart:
                CurrentState = GameState.Play;
                AddCharactersDay(); // 격리자 날짜 추가
               // EscapeCheck();      // 탈출 판정
                CureCheck();        // 완치 판정
                MakeCharacters(BalanceData.newQuarantine[day]);   // 격리자 추가
                InitSkillCoolTime(); // 스킬 쿨타임 초기화
                day++;
                break;
            
            case GameEventType.Half:
                ConfirmCheck();     // 확진 판정
                MakeCharacters();   // 격리자 추가
                break;
            
            case GameEventType.DailyEnd:
                CurrentState = GameState.End;
                break;
        }
        
    }

    private void InitSkillCoolTime() // 스킬 쿨다운 초기화
    {
        var characters = CharacterManager.Instance.LiveCharacters;

        foreach (var character in characters)
        {
            character.currentSkillCoolDown = 0f;
        }
    }
    
    private void AddCharactersDay() // 격리자 날짜 추가
    {
        var characters = CharacterManager.Instance.LiveCharacters;

        foreach (var character in characters)
        {
            character.remainConfirmDate -= 1; //격리자 남은 판정일 감소
            character.day += 1; //격리자 생활일 카운트 증가
        }
    }
    
    private void EscapeCheck() // 탈출 판정
    {
        var characters = CharacterManager.Instance.LiveCharacters;
        int count = 0;

        foreach (var character in characters)
        {
            if (character.escapeRate >= 100)
            {
                Debug.Log($"[LOG] { CharacterManager.Instance.characters.IndexOf(character)}번 캐릭터가 탈출했습니다.");
                
                character.Kill();
                count++;
            }
        }

        escapeNum += count;
        dailyEscapeNum += count;
        
        if (count > 0)
        {
            GameEvent.Trigger(GameEventType.PageChange);
        }
    }

    private void ConfirmCheck() // 확진 판정
    {
        var characters = CharacterManager.Instance.LiveCharacters;
        int count = 0;

        foreach (var character in characters)
        {
            if (character.remainConfirmDate == 0 && character.confirmRate >= Random.Range(0.0f,100.0f))
            {
                Debug.Log($"[LOG] { CharacterManager.Instance.characters.IndexOf(character)}번 캐릭터가 확진 판정을 받았습니다.");
                
                
                character.Kill();
                
                count++;
            }
        }

        if (count > 0)
        {
            AudioManager.Instance.Play("Ambulance");
            GameEvent.Trigger(GameEventType.PageChange);
        }
        
        confirmNum += count;
        dailyConfirmNum = count;
    }

    private void CureCheck()  // 완치 판정
    {
        var characters = CharacterManager.Instance.LiveCharacters;
        int count = 0;

        foreach (var character in characters)
        {
            if (character.day >= BalanceData.cure)
            {
                Debug.Log($"[LOG] { CharacterManager.Instance.characters.IndexOf(character)}번 캐릭터가 완치됐습니다.");

 
                character.Kill();
                count++;
            }
        }
        
        cureNum += count;
        dailyCureNum = count;
    }

    private void MakeCharacters(int todayCount = 0) // 격리자 추가
    {
        remainQuarStby += todayCount;

        int willMakeCount = remainQuarStby;
        for (int i = 0; i < willMakeCount; ++i)
        {
            if (CharacterManager.Instance.TryMakeCharacter())
            {
                remainQuarStby--;
            }
        }
        
        GameEvent.Trigger(GameEventType.PageChange);

        currentRoom = CharacterManager.Instance.LiveCharacters.Count;
    }
}