using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyDefines;

public class SkillTooltipStat : MonoBehaviour
{
    [SerializeField]
    private int gridNum;
    [SerializeField]
    private bool up;

    public Text statText;
    public GridLayoutGroup StatGrid;

    private int checkNum;
    private float statNum;
    private Image[] statImages;


    private void Awake()
    {
        statImages = StatGrid.GetComponentsInChildren<Image>();
    }

    public void SetSkillStat(int index)
    {
        var skill = TBL_SKILL.GetEntity(index);

        if (up)
        {
            if (gridNum < skill.upStat.Count)
            {
                statText.text = ((StatType)skill.upStat[gridNum]).ToString();
                checkNum = skill.upStat[gridNum];
                SetStatNum(index);
            }
            else
                SetEmpty();
        }
        else
        {
            if (skill.downStat[0] == -1)
                SetEmpty();
            else if (gridNum < skill.downStat.Count)
            {
                statText.text = ((StatType)skill.downStat[gridNum]).ToString();
                checkNum = skill.downStat[gridNum];
                SetStatNum(index);
            }
            else
                SetEmpty();
        }
    }


    void SetEmpty()
    {
        statText.text = "";
        statImages[0].enabled = false;
        statImages[1].enabled = false;
    }

    public void SetReturn()
    {
        statImages[0].enabled = true;
        statImages[1].enabled = true;
    }

    void SetStatNum(int index)
    {
        var skill = TBL_SKILL.GetEntity(index);

        switch (checkNum)
        {
            case 0:
                statNum = skill.foodAddAmount;
                break;
            case 1:
                statNum = skill.healthAddAmount;
                break;
            case 2:
                statNum = skill.mentalAddAmount;
                break;
            case 3:
                statNum = skill.loneAddAmount;
                break;
            default:
                break;
        }

        SetImage(checkNum);
    }

    void SetImage(int stat)
    {
        int full = (int)Mathf.Abs(statNum) / 100;
        float rem = Mathf.Abs(statNum) % 100;

        if (full == 2)
        {
            for (int i = 0; i < full; i++)
            {
                statImages[i].sprite = Resources.Load<Sprite>("UI/Skill/Tooltip/circle" + stat) as Sprite;
            }
        }
        else if (full == 1)
        {
            statImages[0].sprite = Resources.Load<Sprite>("UI/Skill/Tooltip/circle" + stat) as Sprite;

            if (rem == 0)
                statImages[1].enabled = false;
            else
                statImages[1].sprite = Resources.Load<Sprite>("UI/Skill/Tooltip/half" + stat) as Sprite;
        }
        else // full==0
        {
            statImages[1].enabled = false;

            if (rem == 0)
                statImages[0].enabled = false;
            else
                statImages[0].sprite = Resources.Load<Sprite>("UI/Skill/Tooltip/half" + stat) as Sprite;
        }
    }
}