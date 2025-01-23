using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtorialUI : MonoBehaviour
{
    public GameObject turtorialElement;
    public float stopGameDelay = 0.5f;
    GameObject player;
    bool detect;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tag.Player);
    }

    void Update()
    {
        if(player == null) return;
        if(Mathf.Abs(player.transform.position.x - transform.position.x) < .5f && !detect)
        {
            detect = true;
            GameObject UI = Instantiate(turtorialElement);
            if(UI.GetComponentInChildren<ChangeTimeScale>() != null)
                UI.GetComponentInChildren<ChangeTimeScale>().StopGame(stopGameDelay);
        }
    }
}
