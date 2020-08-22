using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NewsType
{
    Daily,
    Level1,
    Level2A,
    Level2B
}

public static class NewsData
{
    public static List<string> GetNewsTexts(NewsType newsType)
    {
        List<string> texts = new List<string>();
        TBL_NEWS.ForEachEntity(newsData =>
        {
            if (newsData.newsType == newsType)
            {
                texts.Add(newsData.text);
            }
        });

        return texts;
    }

    public static string GetNewsText(int newsIndex)
    {
        return TBL_NEWS.GetEntity(newsIndex).text;
    }
    
    public static string GetRandomNewsText(NewsType newsType)
    {
        var news = GetNewsTexts(newsType);

        return news[Random.Range(0, news.Count)];
    }
}
