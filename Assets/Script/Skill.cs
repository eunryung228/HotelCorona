using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum SkillType
{
    맥도날드, 넷플릭스, 페이스북,
    맘스터치, 유튜브, 손소독제
}

public class Skill : MonoBehaviour
{
    [SerializeField] [Header("스킬 DB 인덱스")]
    private int m_SkillIndex;

    private TBL_SKILL m_Data;
    public  TBL_SKILL data => m_Data;
    

    private void Awake()
    {
        DataInit(m_SkillIndex);
    }
    
    private void DataInit(int skillIndex)
    {
        m_Data = TBL_SKILL.GetEntity(skillIndex);
    }


    public string GetSkillName()
    {
        return m_Data.skillType.ToString();
    }
    public List<string> GetUpStatList()
    {
        return m_Data.upStat;
    }

    public void ClickSkillButton()
    {
        GameManager.Instance.nowSkill = m_SkillIndex;
    }
    
    // 스킬 사용
    public void Use(int roomNumber)
    {
        Character character = CharacterManager.Instance.GetCharacterByRoomNumber(roomNumber);
        if (!character)
        {
            Debug.LogError($"[X] CharacterManager.Instance.GetCharacterByRoomNumber{roomNumber} (currentPage ={GameManager.Instance.currentPage}) is Null Reference");
            return;
        }

        if (character.CurrentState == CharacterState.Death)
        {
            // 캐릭터가 없는 상태
            Debug.Log(m_Data.skillType + " 사용 실패");
            return;
        }

        if (character.TryUseSkill(m_Data))
        {
            // 스킬 사용이 잘 되었다는 메시지
            Debug.Log(m_Data.skillType + " 사용"); // temp
            AudioManager.Instance.Play(m_Data.skillType.ToString());
        }
        else
        {
            // 캐릭터 스킬 쿨다운이 아직 남아있어서 스킬 사용이 실패했다는 메시지
            Debug.Log((SkillType)m_SkillIndex + " 사용 실패"); // temp
        }
    }
}
