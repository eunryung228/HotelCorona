using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : SingletonBehaviour<CharacterManager>
{
    private List<Character> m_Characters;
    public List<Character> characters => m_Characters;
}
