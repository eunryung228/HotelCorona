using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    private GameManager mgrGame;

    [SerializeField]
    private bool isPass;

    Text textConfirm;
    Text textCure;
    Text textEscape;


    private void Awake()
    {
        mgrGame = FindObjectOfType<GameManager>();

        Text[] text = GetComponentsInChildren<Text>();
        textConfirm = text[0];
        textCure = text[1];
        textEscape = text[2];
    }


    public void SetResult()
    {
        if (isPass)
        {
            textConfirm.text = mgrGame.dailyConfirmNum + "명";
            textCure.text = mgrGame.dailyCureNum + "명";
            textEscape.text = mgrGame.dailyEscapeNum + "명";
        }
        else
        {
            textConfirm.text = mgrGame.confirmNum + "명";
            textCure.text = mgrGame.cureNum + "명";
            textEscape.text = mgrGame.escapeNum + "명";
        }
    }
}