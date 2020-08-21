﻿using System.Collections;
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
    

    private void Awake()
    {
        DataInit(m_SkillIndex);
    }
    
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