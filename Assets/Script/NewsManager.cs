﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsManager : MonoBehaviour
{
    public GameObject textFrame;
    private Text newsText;

    public Animation newsAnim;

    int nowNewsNum = 0;


    void Start()
    {
        newsText = GetComponent<Text>();
        newsText.text = "";
        NewsOn();
    }

    public void NewsOn()
    {
        newsText.text = "오늘의 뉴스입니다."; // 임시
        // SetNormalNews();
        StartCoroutine(NewsCoroutine());
    }


    private void SetNormalNews()
    {
        Debug.Log("normal");
        // 데이터 랜덤 선택, 그러나 이전의 것은 선택할 수 없도록

        // news number 저장

        // 코루틴 시작
        StartCoroutine(NewsCoroutine());
    }

    // 게임매니저에서 호출할 수 있도록 public
    public void SetGlobalNews()
    {
        
    }


    IEnumerator NewsCoroutine()
    {
        newsAnim.Play();

        yield return new WaitForSeconds(10f);

        newsAnim.Stop();
        SetNormalNews();
        yield return null;
    }

    private void Update()
    {
        
    }
}