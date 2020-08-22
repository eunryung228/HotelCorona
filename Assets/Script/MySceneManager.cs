using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MyDefines;


public class MySceneManager : MonoBehaviour
{
    static public MySceneManager Instance;
    public Image fadeImage;

    private void Awake()
    {
        Instance = this;
    }


    private string currScene = "TitleScene";
    private Color m_color;

    private SceneState sceneState = SceneState.NORMAL;

    private float fadeTime = 1f;
    float imgStart;
    float imgEnd;
    float imgTime = 0f;





    private void MakeScene(string scene)
    {
        SceneManager.UnloadSceneAsync(currScene);

        if (currScene == "TitleScene")
        {
            FindObjectOfType<GameManager>().StartGame();
            GameManager.Instance.StartDay();
            BGMManager.instance.Play(1);
        }
        else
        {
            FindObjectOfType<GameManager>().SetOffUIPanels();
            BGMManager.instance.Play(0);
        }
        currScene = scene;
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        sceneState = SceneState.NORMAL;
    }

    public void ChangeScene(string scene)
    {
        StartCoroutine(ChangeSceneCoroutine(scene: scene));
    }

    IEnumerator ChangeSceneCoroutine(string scene)
    {
        StartCoroutine(ImageFadeOut());
        yield return new WaitUntil(() => sceneState == SceneState.OUT);

        MakeScene(scene);
        yield return new WaitUntil(() => sceneState == SceneState.NORMAL);

        StartCoroutine(ImageFadeIn());
    }

    public void PlayPassDay()
    {
        StartCoroutine(PassDayCoroutine());
    }

    IEnumerator PassDayCoroutine()
    {
        yield return StartCoroutine(ImageFadeOut());
        FindObjectOfType<TimeManager>().ResetTime();
        FindObjectOfType<DateManager>().PassDay();
        GameManager.Instance.StartDay();
        StartCoroutine(ImageFadeIn());
    }

    public void Restart()
    {
        StartCoroutine(RestartCoroutine());
    }

    IEnumerator RestartCoroutine()
    {
        yield return StartCoroutine(ImageFadeOut());
        GameManager.Instance.ResetAllData();
        GameManager.Instance.SetOffPanelForRetry();
        FindObjectOfType<TimeManager>().ResetTime();
        FindObjectOfType<DateManager>().ResetDate();
        StartCoroutine(ImageFadeIn());
    }


    protected IEnumerator ImageFadeIn()
    {
        sceneState = SceneState.FI;
        m_color.a = 1f;
        m_color = fadeImage.color;
        imgStart = 1f; imgEnd = 0f; imgTime = 0f;

        while (m_color.a > 0f)
        {
            imgTime += Time.deltaTime / fadeTime;
            m_color.a = Mathf.Lerp(imgStart, imgEnd, imgTime);
            fadeImage.color = m_color;
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
        sceneState = SceneState.NORMAL;
    }


    protected IEnumerator ImageFadeOut()
    {
        sceneState = SceneState.FO;
        fadeImage.gameObject.SetActive(true);
        m_color.a = 0f;
        m_color = fadeImage.color;
        imgStart = 0f; imgEnd = 1f; imgTime = 0f;
        m_color.a = Mathf.Lerp(imgStart, imgEnd, imgTime);

        while (m_color.a < 1f)
        {
            imgTime += Time.deltaTime / fadeTime;
            m_color.a = Mathf.Lerp(imgStart, imgEnd, imgTime);
            fadeImage.color = m_color;
            yield return null;
        }
        sceneState = SceneState.OUT;
    }
}