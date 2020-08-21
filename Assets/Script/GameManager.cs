using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

    // 총 게임 데이터
    int confirmNum;
    int cureNum;
    int escapeNum;

    // 일일 게임 데이터
    int dailyConfirmNum;
    int dailyCureNum;
    int dailyEscapeNum;

    // 인카운터 용
    int totalConfirmNum;

    // 대기 중인 격리자 수
    int remainQuarStby;

    int currentRoom;
    int maxRoom;
}