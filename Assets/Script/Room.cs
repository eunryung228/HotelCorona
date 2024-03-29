﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Sprite m_Sprite;
    public Sprite m_OverSprite;
    
    [Header("방번호")]
    public int roomNumber;

    public List<Transform> m_UpTransforms;
    public List<Transform> m_DownTransforms;

    private SpriteRenderer m_SpriteRenderer;
    private int m_PosIndex;
    
    private void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public Vector3 GetRandomPosition()
    {
        if ((roomNumber % 6 >= 3))
        {
            m_PosIndex = Random.Range(0, m_DownTransforms.Count);
           
            return m_DownTransforms[m_PosIndex].position;
        }
        else
        {
            m_PosIndex = Random.Range(0, m_UpTransforms.Count);
           
            return m_UpTransforms[m_PosIndex].position;
        }
    }

    private void OnMouseOver()
    {
        if (GameManager.Instance.nowSkill == -1)
        {
            m_SpriteRenderer.sprite = m_Sprite;
            m_SpriteRenderer.sortingOrder = 1;
            return;
        }
        
        m_SpriteRenderer.sprite = m_OverSprite;
        m_SpriteRenderer.sortingOrder = 1000;
    }

    private void OnMouseExit()
    {
        m_SpriteRenderer.sprite = m_Sprite;
        m_SpriteRenderer.sortingOrder = 1;
    }

    private void OnMouseDown()
    {
        m_SpriteRenderer.sprite = m_Sprite;
        m_SpriteRenderer.sortingOrder = 1;
    }
}
