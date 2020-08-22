using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum SkillType
{
    McDonald, Netflix, Facebook,
    MomsTouch, YouTube, Sanitizer
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

    public void ClickSkillButton()
    {
        FindObjectOfType<GameManager>().nowSkill = m_SkillIndex;
    }
    
    // 스킬 사용
    public void Use(int roomNumber)
    {
        Character character = CharacterManager.Instance.GetCharacterByRoomNumber(roomNumber);
        if (!character)
        {
            Debug.LogError($"[X] CharacterManager.Instance.GetCharacterByRoomNumber{roomNumber} (currentPage ={GameManager.instance.currentPage}) is Null Reference");
            return;
        }

        if (character.CurrentState == CharacterState.Death)
        {
            // 캐릭터가 없는 상태
            Debug.Log((SkillType)m_SkillIndex + " 사용 실패");
            return;
        }

        if (character.TryUseSkill(m_Data))
        {
            // 스킬 사용이 잘 되었다는 메시지
            Debug.Log((SkillType)m_SkillIndex + " 사용"); // temp
            AudioManager.Instance.Play(((SkillType)m_SkillIndex).ToString());
        }
        else
        {
            // 캐릭터 스킬 쿨다운이 아직 남아있어서 스킬 사용이 실패했다는 메시지
            Debug.Log((SkillType)m_SkillIndex + " 사용 실패"); // temp
        }
    }
}
