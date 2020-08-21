using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : SingletonBehaviour<CharacterManager>
{
    [Header("캐릭터")]
    public List<Character> characters;
    [Header("룸")]
    public  List<Room>     rooms;

    protected override void Awake()
    {
        base.Awake();

        int count = characters.Count;
        for (int i = 0; i < count; ++i)
        {
            characters[i].room = rooms[i];
        }

        StartCoroutine(DieTest());
    }

    private IEnumerator DieTest()
    {
        yield return new WaitForSeconds(3f);
        characters[2].Die();
    }
}
