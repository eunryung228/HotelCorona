using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Left, Full 나누기
public class SkillTooltip : MonoBehaviour
{
    public Text textSkillName;
    public Grid upGrid;
    public Grid downGrid;

    public Skill skill;


    void Start()
    {
    }

    void SetStatus(int index) // 툴팁 생성 시 호출
    {
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