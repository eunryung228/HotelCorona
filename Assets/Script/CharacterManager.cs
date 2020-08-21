using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : SingletonBehaviour<CharacterManager>
{
    [Header("캐릭터")]
    public List<Character> characters;
    [Header("룸")]
    public  List<Room>     rooms;

    public List<Character> LiveCharacters => characters.FindAll(character => character.CurrentState == CharacterState.Live);
    public List<Character> DeadCharacters => characters.FindAll(character => character.CurrentState == CharacterState.Death);

    protected override void Awake()
    {
        base.Awake();

        int count = characters.Count;
        for (int i = 0; i < count; ++i)
        {
            characters[i].room = rooms[i];
        }

        
        
        StartCoroutine(DieTest()); // 테스트용 코드
        StartCoroutine(AddTest());
    }

    // 테스트용 코드
    private IEnumerator DieTest()
    {
        while (true)
        {
            int count = LiveCharacters.Count;
            if (count > 0)
            {
                var character = LiveCharacters[Random.Range(0, count)];
                character.Kill();
            }
            
            yield return new WaitForSeconds(Random.Range(0f, 10f));
        }
       
    }
    
    // 테스트용 코드
    private IEnumerator AddTest()
    {
        while (true)
        {
            int count = DeadCharacters.Count;
            if (count > 0)
            {
                var character = DeadCharacters[Random.Range(0, count)];
                character.Refresh();
            }
            
            yield return new WaitForSeconds(Random.Range(0f, 10f));
        }
    }
}
