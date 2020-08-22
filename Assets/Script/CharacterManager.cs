using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : SingletonBehaviour<CharacterManager>
{
    [SerializeField] [Header("캐릭터 생성 위치")] private Transform m_CharacterParent;
    [SerializeField] [Header("캐릭터 프리팹")]    private Character  m_CharacterPrefab;
    
    
    [Header("캐릭터")]
    public  List<Character> characters;
    [SerializeField] [Header("룸")]
    private List<Room>     rooms;

    public List<Character> LiveCharacters => characters.FindAll(character => character.CurrentState == CharacterState.Live);
    public List<Character> DeadCharacters => characters.FindAll(character => character.CurrentState == CharacterState.Death);

    /************************************************************
     *        0번방         1번방        2번방
     *
     *        3번방         4번방        5번방
     ************************************************************/

    protected override void Awake()
    {
        base.Awake();

        MakeCharacterPool();
        
        
        // 0, 3, 4 번방 캐릭터 나타내기
        MakeCharacter(0);
        MakeCharacter(3);
        MakeCharacter(4);
    }

    private void MakeCharacterPool()
    {
        // 캐릭터 미리 24개 생성
        for (int i = 0; i < 24; ++i)
        {
            var character = Instantiate(m_CharacterPrefab, Vector3.zero, Quaternion.identity, m_CharacterParent);
            character.room = rooms[i % 6];
            characters.Add(character);
        }
    }

    public void MakeCharacter(int characterIndex)
    {
        var character = characters[characterIndex];
        if (character.CurrentState == CharacterState.Live) return;
        
        character.Refresh();
    }
}
