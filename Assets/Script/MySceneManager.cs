using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public Image fadeImage;

    private string currScene = "TitleScene";
    private Color m_color;

    private float fadeTime = 1f;
    float imgStart;
    float imgEnd;
    float imgTime = 0f;


    public void ChangeScene(string scene)
    {
        StartCoroutine(ChangeSceneCoroutine(scene: scene));
    }

    IEnumerator ChangeSceneCoroutine(string scene)
    {
        yield return StartCoroutine(ImageFadeOut());
        SceneManager.UnloadSceneAsync(currScene);
        FindObjectOfType<GameManager>().StartDay();
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        StartCoroutine(ImageFadeIn());
    }

    public void PlayPassDay()
    {
        StartCoroutine(PassDayCoroutine());
    }

    IEnumerator PassDayCoroutine()
    {
        yield return StartCoroutine(ImageFadeOut());
        FindObjectOfType<TimeManager>().ResetTimeText();
        FindObjectOfType<DateManager>().PassDay();
        StartCoroutine(ImageFadeIn());
    }


    protected IEnumerator ImageFadeIn()
    {
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
    }


    protected IEnumerator ImageFadeOut()
    {
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
    }
}