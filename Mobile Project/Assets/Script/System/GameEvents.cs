using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;
    public Action<bool> playerDeath;
    public Action<StateManager> pressJump;
    public Action endLevel;

    void Awake() 
    {
        if(instance == null) instance = this;
        else Destroy(gameObject);
    }
}
