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

    public void ClickGameStart()
    {
        FindObjectOfType<MySceneManager>().ChangeScene("TempMainScene");
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