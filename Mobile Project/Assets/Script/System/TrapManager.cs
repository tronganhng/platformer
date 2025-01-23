using System.Collections.Generic;
using UnityEngine;

public class TrapManager: MonoBehaviour
{
    public static TrapManager instance;
    GameObject[] cycleTraps;
    private void Awake() {
        if(instance == null) instance = this;
        else Destroy(this);
    }
    private void Start() {
        cycleTraps = GameObject.FindGameObjectsWithTag(Tag.ResetObj);
    }

    public void resetCycleTrap()
    {
        if(cycleTraps == null) return;
        foreach (GameObject obj in cycleTraps)
        {
            if(!obj.activeSelf)
                obj.SetActive(true);
        }   
    }
}