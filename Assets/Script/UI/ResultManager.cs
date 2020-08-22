using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private bool isPass;

    Text textConfirm;
    Text textCure;
    Text textEscape;


    private void Awake()
    {
        Text[] text = GetComponentsInChildren<Text>();
        textConfirm = text[0];
        textCure = text[1];
        textEscape = text[2];
    }


    public void SetResult()
    {
        if (isPass)
        {
            textConfirm.text = GameManager.Instance.dailyConfirmNum + "명";
            textCure.text = GameManager.Instance.dailyCureNum + "명";
            textEscape.text = GameManager.Instance.dailyEscapeNum + "명";
        }
        else
        {
            textConfirm.text = GameManager.Instance.confirmNum + "명";
            textCure.text = GameManager.Instance.cureNum + "명";
            textEscape.text = GameManager.Instance.escapeNum + "명";
        }
    }
}