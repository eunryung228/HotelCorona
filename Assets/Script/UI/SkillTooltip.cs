using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Left, Full 나누기
public class SkillTooltip : MonoBehaviour
{
    Vector2 defaultPos;

    public Text textSkillName;
    public SkillTooltipStat[] stats;


    private void Awake()
    {
        defaultPos = GetComponent<RectTransform>().position;
    }

    public void SetStatus(int index) // 툴팁 생성 시 호출
    {
        var skill = TBL_SKILL.GetEntity(index);
        textSkillName.text = skill.skillType.ToString();

        for (int i = 0; i < stats.Length; i++)
        {
            stats[i].SetSkillStat(index);
        }

        SetPosition(index);
    }

    public void ResetStatus()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i].SetReturn();
        }
    }

    void SetPosition(int index)
    {
        Vector2 pos = defaultPos + new Vector2(102.7f * (index - 1), 0);
        GetComponent<RectTransform>().position = pos;
    }
}