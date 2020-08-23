using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooltime : MonoBehaviour
{
    Character m_character;
    public bool isOn { get; set; } = false;

    Image[] cooltimeImages;

    public float maxValue = 0;
    public float currValue = 0;

    public int currSkillIndex = -1;
    

    private void Awake()
    {
        cooltimeImages = GetComponentsInChildren<Image>();
    }


    public void SetInitialCooltime(int index)
    {
        var characters = CharacterManager.Instance.characters;
        m_character = characters[index];

        if (index >= (GameManager.Instance.currentPage - 1) * 6 && index < (GameManager.Instance.currentPage - 1) * 6 + 6) // 리셋 되어야함
        {
            if (m_character.currentSkillCoolDown > 0) // 실행 중
            {
                SetInitialValue();
                isOn = true;
            }
            else
            {
                isOn = false;
            }
            SetState();
        }
        else
        {
            isOn = false;
            SetState();
        }
    }


    public void SetState()
    {
        for (int i = 0; i < cooltimeImages.Length; i++)
        {
            cooltimeImages[i].enabled = isOn;
        }
    }

    public void SetInitialValue()
    {
        maxValue = CharacterData.skillCoolDown;
        currValue = m_character.currentSkillCoolDown;
    }

    public void SetSkillState(int index)
    {
        SetInitialValue();
        currSkillIndex = index;
        isOn = true;
        SetState();
        cooltimeImages[2].sprite = Resources.Load<Sprite>("UI/Skill/Cooltime/icon" + index);
    }

    public void SetStat()
    {
        currValue = m_character.currentSkillCoolDown;
        cooltimeImages[1].fillAmount = 1 - currValue / maxValue;

        if (currValue <= 0 || m_character.CurrentState == CharacterState.Death)
        {
            isOn = false;
            SetState();
        }
    }
}