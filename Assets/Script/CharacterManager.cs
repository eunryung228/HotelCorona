using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : SingletonBehaviour<CharacterManager>, GameEventListener<GameEvent>
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

        this.AddGameEventListening<GameEvent>();
        
        
        // 캐틱터 앞에서부터 3개 생성
        
        //TryMakeCharacter();
        //TryMakeCharacter();
        //TryMakeCharacter();
    }

    public void OnGameEvent(GameEvent e)
    {
        switch (e.Type)
        {
            case GameEventType.PageChange: OnPageChange(); return;
        }
    }

    private void OnPageChange()
    {
        // 1페이지 : 캐릭터  0 ~ 5번 노출
        // 2페이지 : 캐릭터  6 ~ 11번 노출
        // 3페이지:  캐릭터 12 ~ 17번 노출;
        // 설명: 1페이지일때는 0 ~ 5번 캐릭터중 살아잇는 애만 노출, 나머지는 숨김
        foreach (var character in characters) character.Hide();

        int startIndex = (GameManager.Instance.currentPage - 1) * 6;      
        int endIndex = startIndex + 6;         

        for (int i = startIndex; i < endIndex; ++i)
        {
            characters[i].Show();
        }
    }
    
    private void MakeCharacterPool()
    {
        // 캐릭터 미리 maxRoom 만큼 생성
        int count = 0;
        for (int i = 0; i < BalanceData.maxRoom.Count; ++i)
        {
            // 방 최대 개수 구하기
            if (BalanceData.maxRoom[i] > count) count = BalanceData.maxRoom[i];
        }
        
        for (int i = 0; i < count; ++i)
        {
            var character = Instantiate(m_CharacterPrefab, Vector3.zero, Quaternion.identity, m_CharacterParent);
            character.room = rooms[i % 6];
            characters.Add(character);
        }
    }

    public Character GetCharacterByRoomNumber(int roomNumber)
    {
        // 2페이지일때 0번 룸 -> 6번 캐릭터 반환
        // 3페이지일때 1번 룸 -> 13번 캐릭터 반환
        int characterIndex = (GameManager.Instance.currentPage - 1) * 6 + roomNumber;

        return characters[characterIndex];
    }

    public bool TryMakeCharacter()
    {
        int roomCount = BalanceData.maxRoom[GameManager.Instance.day];

        for (int i = 0; i < roomCount; ++i)
        {
            if (characters[i].CurrentState == CharacterState.Death)
            {
                characters[i].Refresh();
                return true;
            }
        }
        
        return false;
    }
    
}
