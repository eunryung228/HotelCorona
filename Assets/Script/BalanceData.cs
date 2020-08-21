using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BalanceData
{
    private static TBL_DATA m_Data => TBL_DATA.GetEntity(0);
    
    // 일일 추가 격리자
    public static int   newQuarantine        => m_Data.newQuarantine;     
    
    // 공복 배율 범위
    public static float minFoodMulti         => m_Data.minFoodMulti;      
    public static float maxFoodMulti         => m_Data.maxFoodMulti;
    
    // 건강 배율 범위
    public static float minHealthMulti       => m_Data.minHealthMulti;
    public static float maxHealthMulti       => m_Data.maxHealthMulti;
    
    // 정신력 배율 범위
    public static float minMentalMulti       => m_Data.minMentalMulti;
    public static float maxMentalMulti       => m_Data.maxMentalMulti;
    
    // 외로움 배율 범위
    public static float minLoneMulti         => m_Data.minLoneMulti;
    public static float maxLoneMulti         => m_Data.maxHealthMulti;
    
    // 4대 스탯 소모
    public static float foodConsume          => m_Data.foodConsume;
    public static float healthConsume        => m_Data.healthConsume;
    public static float mentalConsume        => m_Data.mentalConsume;
    public static float loneConsume          => m_Data.loneConsume;
    
    // 확진일까지 남은 날
    public static int minRemainConfirmDate   => m_Data.minRemainConfirmDate;
    public static int maxRemainConfirmDate   => m_Data.minRemainConfirmDate;

    // 확진 확률
    public static float minConfirmRate       => m_Data.minConfirmRate;
    public static float maxConfirmRate       => m_Data.maxConfirmRate;
}
