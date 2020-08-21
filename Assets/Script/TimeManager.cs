using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private Text timeText;
    private float time = 0;

    private int min = 0;
    private float sec = 0;

    private void Start()
    {
        timeText = this.GetComponent<Text>();
    }

    void Update()
    {
        time += Time.deltaTime;
        sec = Mathf.Ceil(time);
        timeText.text = min.ToString("D2") + ":" + ((int)sec).ToString("D2");

        if (sec >= 60)
        {
            min += 1;
            sec = 0;

            if (min == 3)
            {

            }
        }
    }
}