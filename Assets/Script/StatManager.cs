using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public Image[] varImags;


    // 캐릭터에서 스탯을 가져와 이미지 초기화. 모두 차있는 상태
    // 새로운 격리자가 들어올 때마다 호출
    public void SetInitialStat()
    {
    }


    // 각각의 것 임시
    Image varImage;

    float maxValue = 24;
    float currValue = 24;
    float ratio = 0.01f;


    private void Start()
    {
        varImage = GetComponent<Image>();
    }


    private void Update() // 각각의 스탯에 대해 적용
    {
        currValue -= maxValue * ratio/60;
        varImage.fillAmount = currValue / maxValue;
    }
}