using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateManager : MonoBehaviour
{
    public Text textDate;


    public void PassDay()
    {
        textDate.text = GameManager.Instance.day.ToString("D2");
    }

    public void ResetDate()
    {
        GameManager.Instance.day = 0; // 다른 곳에 위치
        textDate.text = GameManager.Instance.day.ToString("D2");
    }
}