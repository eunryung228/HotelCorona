using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateManager : MonoBehaviour
{
    public Text textDate;

    private int date = 1;
    private int winDate = 21; // temp


    public void PassDay()
    {
        date += 1;
        textDate.text = date.ToString("D2");
    }

    public void ResetDate()
    {
        date = 1;
        textDate.text = date.ToString("D2");
    }
}