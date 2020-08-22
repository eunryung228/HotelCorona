using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Left, Full 나누기
public class SkillTooltip : MonoBehaviour
{
    public Text textSkillName;
    public GridLayoutGroup upGrid;
    public GridLayoutGroup downGrid;


    void Start()
    {
        SetStatus(0);
    }

    void SetStatus(int index) // 툴팁 생성 시 호출
    {
        var skill = TBL_SKILL.GetEntity(index);
        textSkillName.text = skill.skillType.ToString();

        //skillIndex = index;
        //textSkillName.text=Skill
        // 스킬 이름 설정
        // UpGrid에 증가하는 스탯 이름 설정
        // UpGrid에 증가하는 스탯 값 가져와서 이미지 설정
        // DownGrid에 증가하는 스탯 이름 설정
        // DownGrid에 증가하는 스탯 값 가져와서 이미지 설정
    }

    void SetPosition()
    {
    }
}