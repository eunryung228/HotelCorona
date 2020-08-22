using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyDefines;

public class Stat : MonoBehaviour
{
    Image statImage;

    public float maxValue = 0;
    public float currValue = 0;


    private void Start()
    {
        statImage = GetComponent<Image>();
    }

    public void SetInitialValue(float cv, float mv)
    {
        currValue = cv;
        maxValue = mv;
    }

    public void SetEmpty()
    {
        Debug.Log(statImage);
        statImage.fillAmount = 0;
    }

    public void SetStat(float cv)
    {
        currValue = cv;
        statImage.fillAmount = currValue / maxValue;
    }
}