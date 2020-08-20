using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BalanceData
{
    public static int newQuarantine   => TBL_DATA.GetEntity(0).newQuarantine;
    public static float minFoodMulti => TBL_DATA.GetEntity(0).minFoodMulti;
}
