using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour

{
    public static PlayerManager Instance { get; private set; }

    public Vector2 lastPosition;


    public Vector2 GetPosition()
    {
        return lastPosition;
    }

    public void SetPosition(Vector2 position)
    {
        lastPosition = position;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }
}
