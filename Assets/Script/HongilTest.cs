using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HongilTest : MonoBehaviour
{
    private void Awake()
    {
        // TBL_CHARACTER 데이터 하나 읽기 (3번째 위치 데이터)
        var data = TBL_CHARACTER.GetEntity(2);
        Debug.Log(data.maxFood);
        Debug.Log(data.maxHealth);
        Debug.Log(data.maxMental);
        
        // TBL_CHARACTER 모든 데이터 순회
        for (int i = 0; i < TBL_CHARACTER.CountEntities; ++i)
        {
            var temp = TBL_CHARACTER.GetEntity(i);
            Debug.Log(temp.maxHealth);
            Debug.Log(temp.maxFood);
        }
        
        
        
        
        
        
        
        
        
        
        // 밸런스 데이터는 예외로 데이터가 한개라서 정적클래스로 만듬
        Debug.Log(BalanceData.newQuarantine);
        Debug.Log(BalanceData.loneConsume);
    }
}
