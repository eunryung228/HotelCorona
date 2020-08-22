using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NewsManager : MonoBehaviour
{
    public GameObject textFrame;
    private Text newsText;

    public Animation newsAnim;

    private int newsCount = 0;

    
    void Start()
    {
        newsText = GetComponent<Text>();
        newsText.text = "";
        NewsOn();
    }

    public void NewsOn()
    {
        StartCoroutine(NewsCoroutine());
    }
    
    
    IEnumerator NewsCoroutine()
    {
        var wait20 = new WaitForSeconds(20f);
        var wait10 = new WaitForSeconds(10f);

        while (true)
        {
            newsCount++;
            
            newsAnim.Play();
            if (newsCount % 3 == 0)
            {
                SetNewsLevelText();
                yield return wait10;
                newsAnim.Stop();
            }
            else
            {
                SetNewsDailyText();
                yield return wait10;
                newsAnim.Stop();
            }
        }
    }

    private void SetNewsDailyText()
    {
        newsText.text = NewsData.GetRandomNewsText(NewsType.Daily);
    }
    
    private void SetNewsLevelText()
    {
        string news = String.Empty;
        
        if (GameManager.Instance.day < 6)
        {
            news = NewsData.GetRandomNewsText(NewsType.Level1);
        }
        else
        {
            if (GameManager.Instance.escapeNum <= 6)
            {
                news = NewsData.GetRandomNewsText(NewsType.Level2A);
            }
            else
            {
                news = NewsData.GetRandomNewsText(NewsType.Level2B);
            }
        }

        newsText.text = news;
    }
    
}