using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    Image statImage;
    public Character character;

    public float maxValue = 0;
    public float currValue = 0;


    private void Start()
    {
        statImage = GetComponent<Image>();
    }


    public void SetInitialValue()
    {
        maxValue = currValue = character.currentFood;
    }

    void SetStat()
    {
        currValue = character.currentFood;
        statImage.fillAmount = currValue / maxValue;
    }

    private void Update()
    {
        SetStat();
    }
}
