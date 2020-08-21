using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    [SerializeField] [Header("스킬 DB 인덱스")]
    private int m_SkillIndex;

    private TBL_SKILL m_Data;
    public  TBL_SKILL data => m_Data;
    
    // 남은 스킬 사용 갯수
    public int remainUseAmount; // ??????????????????????? 디폴트 값 기획자한테 물어봐야함
    
    
    private void DataInit(int skillIndex)
    {
        m_Data = TBL_SKILL.GetEntity(skillIndex);
    }
    
    // 스킬 사용
    public void Use(int characterIndex)
    {
        Character character = CharacterManager.Instance.characters[characterIndex];
        if (!character)
        {
            Debug.LogError($"[X] CharacterManager.Instance.characters[{characterIndex}] is Null Reference");
            return;
        }

        // 스킬 남은 사용 갯수가 0일때 
        if (remainUseAmount == 0)
        {
            // 뭔가 처리해주삼
            return;
        }

        if (character.TryUseSkill(m_Data))
        {
            // 스킬 사용이 잘 되었다는 메시지
        }
        else
        {
            // 캐릭터 스킬 쿨다운이 아직 남아있어서 스킬 사용이 실패했다는 메시지
        }
    }
}
