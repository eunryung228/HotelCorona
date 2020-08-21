using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    // ????????????????????????????
}

public class Character : MonoBehaviour
{
    private TBL_CHARACTER m_Data;
    public TBL_CHARACTER data => m_Data;

    public CharacterState currentState;
    
    // 공복
    public float currentFood;
    public float foodMulti;

    // 건강
    public float currentHealth;
    public float healthMulti;

    // 정신력
    public float currentMental;
    public float mentalMulti;

    // 외로움
    public float currentLone;
    public float loneMulti;

    // 현재 스킬 쿨타임
    public float currentSkillCoolDown;
    
    // 확진일까지 남은 날
    public int remainConfirmDate;

    // 확진 확률
    public float confirmRate;
    
    // 탁출 확률
    public float escapeRate;
    
    private void Init(int characterIndex)
    {
        m_Data = TBL_CHARACTER.GetEntity(characterIndex);

        foodMulti   = Random.Range(BalanceData.minFoodMulti,   BalanceData.maxFoodMulti);
        healthMulti = Random.Range(BalanceData.minHealthMulti, BalanceData.maxHealthMulti);
        mentalMulti = Random.Range(BalanceData.minMentalMulti, BalanceData.maxMentalMulti);
        loneMulti   = Random.Range(BalanceData.minLoneMulti,   BalanceData.maxLoneMulti);

        currentSkillCoolDown = 0f;

        remainConfirmDate = 10000000; // ?

        confirmRate = 100000000; // ?
        
        escapeRate = 0f;
    }
}
