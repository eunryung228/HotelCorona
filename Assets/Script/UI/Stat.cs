using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyDefines;

public class Stat : MonoBehaviour
{
    Image statImage;
    public StatType stat;
    public Character character;

    public float maxValue = 0;
    public float currValue = 0;


    private void Start()
    {
        statImage = GetComponent<Image>();
    }


    public void SetInitialValue()
    {
        maxValue = CharacterData.maxFood;
        //maxValue = currValue = character.currentFood;
    }

    void SetStat()
    {
        Debug.Log(currValue);
        currValue = character.currentFood;
        statImage.fillAmount = currValue;
    }

    private void Update()
    {
        SetStat();
    }
}
