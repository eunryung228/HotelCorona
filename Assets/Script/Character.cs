using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    //Netflix,
}

public class Character : MonoBehaviour
{
    [SerializeField] [Header("캐릭터 DB 인덱스")]
    private int m_CharacterIndex;
    
    private TBL_CHARACTER m_Data;
    public  TBL_CHARACTER data => m_Data;

    public CharacterState currentState;
    
    // 공복
    public  float currentFood;
    private float foodMulti;

    // 건강
    public  float currentHealth;
    private float healthMulti;

    // 정신력
    public  float currentMental;
    private float mentalMulti;

    // 외로움
    public  float currentLone;
    private float loneMulti;

    // 현재 스킬 쿨타임
    private float currentSkillCoolDown;
    
    // 확진일까지 남은 날
    public int remainConfirmDate;

    // 확진 확률
    public float confirmRate;
    
    // 탈출 확률
    public float escapeRate;
    
    
    // 생성된 날짜
    public int day;

    private void Awake()
    {
        DataInit(m_CharacterIndex);
    }
    
    private void DataInit(int characterIndex)
    {
        m_Data = TBL_CHARACTER.GetEntity(characterIndex);

        foodMulti   = Random.Range(BalanceData.minFoodMulti,   BalanceData.maxFoodMulti  );
        healthMulti = Random.Range(BalanceData.minHealthMulti, BalanceData.maxHealthMulti);
        mentalMulti = Random.Range(BalanceData.minMentalMulti, BalanceData.maxMentalMulti);
        loneMulti   = Random.Range(BalanceData.minLoneMulti,   BalanceData.maxLoneMulti  );

        currentSkillCoolDown = 0f;

        remainConfirmDate    = Random.Range(BalanceData.minRemainConfirmDate, BalanceData.maxRemainConfirmDate);

        confirmRate          = Random.Range(BalanceData.minConfirmRate, BalanceData.maxConfirmRate);
        
        escapeRate           = 0f;

        day                  = 0;
    }

    private void Update()
    {
        // 하루 시작 <--> 하루 종료 상태 사이일때만 반영하도록 바꿔야함
        
        float dt = Time.deltaTime;
        
        if (currentSkillCoolDown > 0)
        {
            currentSkillCoolDown -= dt;
        }

        currentFood   = Mathf.Max(0, currentFood   - foodMulti   * BalanceData.foodConsume    * dt);
        currentHealth = Mathf.Max(0, currentHealth - healthMulti * BalanceData.healthConsume  * dt);
        currentMental = Mathf.Max(0, currentMental - mentalMulti * BalanceData.mentalConsume  * dt);
        currentLone   = Mathf.Max(0, currentLone   - loneMulti   * BalanceData.loneConsume    * dt);

        if (currentFood   <= BalanceData.escapeRateThreshold * data.maxFood  ) escapeRate = Mathf.Min(100, escapeRate + BalanceData.escapeRateAdd * dt);
        if (currentHealth <= BalanceData.escapeRateThreshold * data.maxHealth) escapeRate = Mathf.Min(100, escapeRate + BalanceData.escapeRateAdd * dt);
        if (currentMental <= BalanceData.escapeRateThreshold * data.maxMental) escapeRate = Mathf.Min(100, escapeRate + BalanceData.escapeRateAdd * dt);
        if (currentLone   <= BalanceData.escapeRateThreshold * data.maxLone  ) escapeRate = Mathf.Min(100, escapeRate + BalanceData.escapeRateAdd * dt);
        
        if (currentFood   >= BalanceData.confirmRateThreshold * data.maxFood  ) confirmRate = Mathf.Max(0, confirmRate + BalanceData.confirmRateThreshold * dt);
        if (currentHealth >= BalanceData.confirmRateThreshold * data.maxHealth) confirmRate = Mathf.Max(0, confirmRate + BalanceData.confirmRateThreshold * dt);
        if (currentMental >= BalanceData.confirmRateThreshold * data.maxMental) confirmRate = Mathf.Max(0, confirmRate + BalanceData.confirmRateThreshold * dt);
        if (currentLone   >= BalanceData.confirmRateThreshold * data.maxLone  ) confirmRate = Mathf.Max(0, confirmRate + BalanceData.confirmRateThreshold * dt);
    }
    
    
    public bool TryUseSkill(TBL_SKILL skillData)
    {
        if (currentSkillCoolDown > 0)
        {
            return false;
        }

        currentFood   = Mathf.Min(currentFood   + skillData.foodAddAmount,   data.maxFood  );
        currentHealth = Mathf.Min(currentHealth + skillData.healthAddAmount, data.maxHealth);
        currentMental = Mathf.Min(currentMental + skillData.mentalAddAmount, data.maxMental);
        currentLone   = Mathf.Min(currentLone   + skillData.loneAddAmount,   data.maxLone  );

        currentSkillCoolDown = data.skillCoolDown;
        
        return true;
    }
}
