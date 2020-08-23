using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooltimeManager : MonoBehaviour, GameEventListener<GameEvent>
{
    static public CooltimeManager Instance;

    public Camera camera;

    public GameObject cooltimePrefab;

    List<Transform> characterList = new List<Transform>();
    List<GameObject> cooltimeList = new List<GameObject>();


    private void Awake()
    {
        Instance = this;
        this.AddGameEventListening<GameEvent>();
    }


    private void Start()
    {
        InitializeCooltime();
    }


    public void OnGameEvent(GameEvent e)
    {
        switch (e.Type)
        {
            case GameEventType.DailyStart:
            case GameEventType.PageChange:
                {
                    InitializeByPage();
                    break;
                }
        }

    }


    public void InitializeCooltime()
    {
        var characters = CharacterManager.Instance.characters;

        for (int i = 0; i < characters.Count; i++)
        {
            characterList.Add(characters[i].transform);
            GameObject cooltime = Instantiate(cooltimePrefab, characterList[i].transform.position, Quaternion.identity, transform);
            cooltimeList.Add(cooltime);
        }
    }


    public void InitializeByPage() // 다른 층으로 넘어갈 때마다 호출
    {
        for (int i = 0; i < cooltimeList.Count; i++)
        {
            cooltimeList[i].GetComponent<Cooltime>().SetInitialCooltime(i);
        }
    }

    public void UseSkill(int charNum, int skillIndex)
    {
        cooltimeList[charNum].GetComponent<Cooltime>().SetSkillState(skillIndex);
    }


    private void Update()
    {
        for (int i = 0; i < cooltimeList.Count; i++)
        {
            cooltimeList[i].transform.position = camera.WorldToScreenPoint(characterList[i].transform.position + new Vector3(0, 0.7f, 0));

            if (cooltimeList[i].GetComponent<Cooltime>().isOn)
                cooltimeList[i].GetComponent<Cooltime>().SetStat();
        }
    }
}