using UnityEngine;
using MonsterLove;
using MonsterLove.StateMachine;



[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public partial class Character : MonoBehaviour
{
    [Header("룸")] 
    public Room room;
    
    [Header("공복")]
    public  float currentFood;
    private float foodMulti;

    [Header("건강")]
    public  float currentHealth;
    private float healthMulti;

    [Header("정신력")]
    public  float currentMental;
    private float mentalMulti;

    [Header("외로움")]
    public  float currentLone;
    private float loneMulti;

    // 현재 스킬 쿨타임
    private float currentSkillCoolDown;
    
    [Header("확진일까지 남은 날")]
    public int remainConfirmDate;

    [Header("확진 확률")]
    public float confirmRate;
    
    [Header("탈출 확률")]
    public float escapeRate;
    
    [Header("날짜")]
    public int day;


    private enum CharacterType
    {
        Daughter,
        Grandma,
        Grandpa,
        Mama,
        Papa,
        Son,
        
        Count,
    }
    
    // FSM
    private enum FSMState
    {
        None,
        Start,
        Idle,
        Front,
        Back,
        Move,
        Die
    }

    private StateMachine<FSMState> m_FSM;

    private Animator       m_Animator;
    private SpriteRenderer m_SpriteRenderer;

    private CharacterType m_CharacterType;
    
    private void Awake()
    {
        m_Animator       = GetComponent<Animator>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        
        m_FSM = StateMachine<FSMState>.Initialize(this, FSMState.None);
        
        DataInit();
    }
    
    private void DataInit()
    {
        m_CharacterType = (CharacterType) Random.Range(0, (int)CharacterType.Count);

        currentFood   = CharacterData.maxFood;
        currentHealth = CharacterData.maxHealth;
        currentMental = CharacterData.maxMental;
        currentLone   = CharacterData.maxLone;
        
        foodMulti   = Random.Range(BalanceData.minFoodMulti,   BalanceData.maxFoodMulti  );
        healthMulti = Random.Range(BalanceData.minHealthMulti, BalanceData.maxHealthMulti);
        mentalMulti = Random.Range(BalanceData.minMentalMulti, BalanceData.maxMentalMulti);
        loneMulti   = Random.Range(BalanceData.minLoneMulti,   BalanceData.maxLoneMulti  );

        currentSkillCoolDown = 0f;

        remainConfirmDate    = Random.Range(BalanceData.minRemainConfirmDate, BalanceData.maxRemainConfirmDate);

        confirmRate          = Random.Range(BalanceData.minConfirmRate, BalanceData.maxConfirmRate);
        
        escapeRate           = 0f;

        day                  = 0;
        
        m_FSM.ChangeState(FSMState.None);
    }

    private void Start()
    {
        m_FSM.ChangeState(FSMState.Start);
    }

    private void Update()
    {
        // 하루 시작 <--> 하루 종료 상태 사이일때만 반영하도록 바꿔야함
        if (m_FSM.State == FSMState.None) return;
        
        
        float dt = Time.deltaTime;
        
        if (currentSkillCoolDown > 0)
        {
            currentSkillCoolDown -= dt;
        }

        currentFood   = Mathf.Max(0, currentFood   - foodMulti   * BalanceData.foodConsume    * dt);
        currentHealth = Mathf.Max(0, currentHealth - healthMulti * BalanceData.healthConsume  * dt);
        currentMental = Mathf.Max(0, currentMental - mentalMulti * BalanceData.mentalConsume  * dt);
        currentLone   = Mathf.Max(0, currentLone   - loneMulti   * BalanceData.loneConsume    * dt);

        if (currentFood   <= BalanceData.escapeRateThreshold * CharacterData.maxFood  ) escapeRate = Mathf.Min(100, escapeRate + BalanceData.escapeRateAdd * dt);
        if (currentHealth <= BalanceData.escapeRateThreshold * CharacterData.maxHealth) escapeRate = Mathf.Min(100, escapeRate + BalanceData.escapeRateAdd * dt);
        if (currentMental <= BalanceData.escapeRateThreshold * CharacterData.maxMental) escapeRate = Mathf.Min(100, escapeRate + BalanceData.escapeRateAdd * dt);
        if (currentLone   <= BalanceData.escapeRateThreshold * CharacterData.maxLone  ) escapeRate = Mathf.Min(100, escapeRate + BalanceData.escapeRateAdd * dt);
        
        if (currentFood   >= BalanceData.confirmRateThreshold * CharacterData.maxFood  ) confirmRate = Mathf.Max(0, confirmRate + BalanceData.confirmRateThreshold * dt);
        if (currentHealth >= BalanceData.confirmRateThreshold * CharacterData.maxHealth) confirmRate = Mathf.Max(0, confirmRate + BalanceData.confirmRateThreshold * dt);
        if (currentMental >= BalanceData.confirmRateThreshold * CharacterData.maxMental) confirmRate = Mathf.Max(0, confirmRate + BalanceData.confirmRateThreshold * dt);
        if (currentLone   >= BalanceData.confirmRateThreshold * CharacterData.maxLone  ) confirmRate = Mathf.Max(0, confirmRate + BalanceData.confirmRateThreshold * dt);
    }
    
    
    public bool TryUseSkill(TBL_SKILL skillData)
    {
        if (currentSkillCoolDown > 0)
        {
            return false;
        }

        currentFood   = Mathf.Min(currentFood   + skillData.foodAddAmount,   CharacterData.maxFood  );
        currentHealth = Mathf.Min(currentHealth + skillData.healthAddAmount, CharacterData.maxHealth);
        currentMental = Mathf.Min(currentMental + skillData.mentalAddAmount, CharacterData.maxMental);
        currentLone   = Mathf.Min(currentLone   + skillData.loneAddAmount,   CharacterData.maxLone  );

        currentSkillCoolDown = CharacterData.skillCoolDown;
        
        return true;
    }

    public void Die()
    {
        m_FSM.ChangeState(FSMState.Die, StateTransition.Overwrite);
    }
}

// FSM
public partial class Character : MonoBehaviour
{
    [Header("목적지")]
    public Vector3 DestinationPosition;
    public Vector3 CurrentPosition => transform.position;

    private float m_MoveSpeed = 1f;

    private void Start_Enter()
    {
        transform.position = room.GetRandomPosition();
        
        m_FSM.ChangeState(FSMState.Idle);
    }
    
    
    private void Idle_Enter()
    {
        DestinationPosition = room.GetRandomPosition();

        if (CurrentPosition.y < DestinationPosition.y)
        {
            m_FSM.ChangeState(FSMState.Back);
        }
        else
        {
            m_FSM.ChangeState(FSMState.Front);
        }
    }

    private void Front_Enter()
    {
        m_Animator.Play($"{m_CharacterType}_Front");
        m_SpriteRenderer.flipX = CurrentPosition.x < DestinationPosition.x;
        
        m_FSM.ChangeState(FSMState.Move);
    }

    private void Back_Enter()
    {
        m_Animator.Play($"{m_CharacterType}_Back");
        m_SpriteRenderer.flipX = CurrentPosition.x < DestinationPosition.x;
        
        m_FSM.ChangeState(FSMState.Move);
    }

    private void Move_Update()
    {
        if (Vector3.Distance(CurrentPosition, DestinationPosition) < m_MoveSpeed)
        {
            m_FSM.ChangeState(FSMState.Idle);
            return;
        }

        transform.position = Vector2.MoveTowards(CurrentPosition, DestinationPosition, m_MoveSpeed * Time.deltaTime);
    }

    private void Die_Enter()
    {
        m_SpriteRenderer.enabled = false;
    }
}
