using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    [SerializeField]
    GameObject foodPrefab = null;

    GameObject[] characters;
    List<Transform> roomList = new List<Transform>();
    List<GameObject> foodBarList = new List<GameObject>();

    Camera camera = null;


    private void Start()
    {
        camera = Camera.main;

        characters = GameObject.FindGameObjectsWithTag("Player");

        GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");
        for (int i = 0; i < rooms.Length; i++)
        {
            roomList.Add(rooms[i].transform);
            GameObject foodBar = Instantiate(foodPrefab, roomList[i].transform.position, Quaternion.identity, transform);
            foodBarList.Add(foodBar);
        }
        SetPosition();
    }

    void SetPosition()
    {
        for (int i = 0; i < foodBarList.Count; i++)
        {
            foodBarList[i].transform.position = camera.WorldToScreenPoint(roomList[i].position + new Vector3(0, 10f, 0));
            foodBarList[i].transform.GetChild(0).GetComponent<Stat>().character = characters[0].GetComponent<Character>();
            foodBarList[i].transform.GetChild(0).GetComponent<Stat>().SetInitialValue();
        }
    }


    // 캐릭터에서 스탯을 가져와 이미지 초기화. 모두 차있는 상태
    // 새로운 격리자가 들어올 때마다 호출
    public void SetInitialStat()
    {
    }
}