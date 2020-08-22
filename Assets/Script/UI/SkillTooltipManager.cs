using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTooltipManager : MonoBehaviour
{
    public SkillTooltip fullTooltip;
    public GameObject leftTooltip;


    public void TooltipLayerOn(int skill)
    {
        fullTooltip.gameObject.SetActive(true);
        fullTooltip.SetStatus(skill);
    }

    public void TooltipLayerOff()
    {
        fullTooltip.ResetStatus();
        fullTooltip.gameObject.SetActive(false);
    }

    public void LeftTooltipLayerOn()
    {
        leftTooltip.gameObject.SetActive(true);
    }
    public void LeftTooltipLayerOff()
    {
        leftTooltip.gameObject.SetActive(false);
    }
}
