using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterData 
{
    private static TBL_CHARACTER m_Data = TBL_CHARACTER.GetEntity(0);

    public static float maxFood       => m_Data.maxFood;
    public static float maxHealth     => m_Data.maxHealth;
    public static float maxMental     => m_Data.maxMental;
    public static float maxLone       => m_Data.maxLone;
    public static float skillCoolDown => m_Data.skillCoolDown;
}
