using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    // ????????????????????????????
}

public class Character : MonoBehaviour
{
    [SerializeField] [Header("캐릭터 DB 인덱스")]
    private int m_CharacterIndex;
    
    private TBL_CHARACTER m_Data;
    public  TBL_CHARACTER data => m_Data;

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
    
    // 탈출 확률
    public float escapeRate;

    private void Awake()
    {
        DataInit(m_CharacterIndex);
    }
    
    private void DataInit(int characterIndex)
    {
        m_Data = TBL_CHARACTER.GetEntity(characterIndex);

        foodMulti   = Random.Range(BalanceData.minFoodMulti,   BalanceData.maxFoodMulti);
        healthMulti = Random.Range(BalanceData.minHealthMulti, BalanceData.maxHealthMulti);
        mentalMulti = Random.Range(BalanceData.minMentalMulti, BalanceData.maxMentalMulti);
        loneMulti   = Random.Range(BalanceData.minLoneMulti,   BalanceData.maxLoneMulti);

        currentSkillCoolDown = 0f;

        remainConfirmDate = 10000000; // ? 기획자한테 물어봐야함

        confirmRate = 100000000;      // ? 기획자한테 물어봐야함
        
        escapeRate = 0f;
    }

    private void Update()
    {
        if (currentSkillCoolDown > 0)
        {
            currentSkillCoolDown -= Time.deltaTime;
        }
    }
    
    public bool TryUseSkill(TBL_SKILL skillData)
    {
        if (currentSkillCoolDown > 0)
        {
            return false;
        }

        // ? 최대값 있는지 기획자한테 물어봐야함
        currentFood   = Mathf.Min(currentFood   + skillData.foodAddAmount,   100f);
        currentHealth = Mathf.Min(currentHealth + skillData.healthAddAmount, 100f);
        currentMental = Mathf.Min(currentMental + skillData.mentalAddAmount, 100f);
        currentLone   = Mathf.Min(currentLone   + skillData.loneAddAmount,   100f);

        currentSkillCoolDown = data.skillCoolDown;
        
        return true;
    }
}
