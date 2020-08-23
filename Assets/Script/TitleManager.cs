using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void LoadUIScene()
    {
        SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void CheckData()
    {
        if (BalanceData.newQuarantine.Count != BalanceData.maxRoom.Count)
        {
            Debug.LogError("[X] 기확자님 확인해주세요.!");
            Debug.LogError("일일 확진자 수와 일일 최대 방 갯수 리스트 데이터의 갯수가 같지않습니다.");
            Debug.LogError($"일일 확진자 수 데이터: {BalanceData.newQuarantine.Count}개");
            Debug.LogError($"일일 최대 방 갯수 데이터: {BalanceData.maxRoom.Count}개");
        }
    }

    public GameObject backPanel;
    public GameObject tutorialPanel;
    public GameObject creditPanel;

    public void ClickGameStart()
    {
        MySceneManager.Instance.ChangeScene("TempMainScene");
    }

    public void ClickTutorialBtn()
    {
        backPanel.SetActive(true);
        tutorialPanel.SetActive(true);
    }

    public void ClickCreditButton()
    {
        backPanel.SetActive(true);
        creditPanel.SetActive(true);
    }

    public void ClickCloseBtn()
    {
        backPanel.SetActive(false);
        tutorialPanel.SetActive(false);
        creditPanel.SetActive(false);
    }

    public void ClickGameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}