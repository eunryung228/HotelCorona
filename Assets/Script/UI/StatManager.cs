using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public int roomNumber; // 방 번호

    [SerializeField]
    Character m_character; // 담당 캐릭터

    [SerializeField]
    private Stat food;
    [SerializeField]
    private Stat health;
    [SerializeField]
    private Stat mental;
    [SerializeField]
    private Stat lone;


    private void Start()
    {
        SetInitialStat();
    }

    public void SetInitialStat() // 다른 층으로 이동할 때마다 호출
    {
        var characters = CharacterManager.Instance.characters;
        m_character = characters[(GameManager.Instance.currentPage - 1) * 6 + roomNumber];
        
        if (m_character.CurrentState == CharacterState.Death)
        {
            food.SetEmpty();
            health.SetEmpty();
            mental.SetEmpty();
            lone.SetEmpty();
        }
        else
        {
            food.SetInitialValue(m_character.currentFood, CharacterData.maxFood);
            health.SetInitialValue(m_character.currentHealth, CharacterData.maxHealth);
            mental.SetInitialValue(m_character.currentMental, CharacterData.maxMental);
            lone.SetInitialValue(m_character.currentLone, CharacterData.maxLone);
        }
    }

    private void Update()
    {
        if (m_character.CurrentState != CharacterState.Death)
        {
            food.SetStat(m_character.currentFood);
            health.SetStat(m_character.currentHealth);
            mental.SetStat(m_character.currentMental);
            lone.SetStat(m_character.currentLone);
        }
    }
}