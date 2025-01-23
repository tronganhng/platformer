using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;
    GameObject player;
    public CinemachineVirtualCamera virtualCamera;
    public CinemachineImpulseSource impulseSource;
    public Transform checkPoint;
    public GameObject endLevelUI;
    void Awake()
    {
        if(instance == null) instance = this;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tag.Player);
        GameEvents.instance.playerDeath += PlayerDeath;
        GameEvents.instance.endLevel += EndLevel;
    }

    #region Handle PlayerDeath Event
    void PlayerDeath(bool addForce)
    {
        // Cam Shake
        if(impulseSource != null) impulseSource.GenerateImpulse();
        // Add Force
        player.GetComponent<StateManager>().ChangeState(new Idle());
        Vector2 direct = new Vector2(InputManager.instance.inputDirect, 1f);
        if(addForce)
            player.GetComponent<Rigidbody2D>().velocity = direct.normalized * UnityEngine.Random.Range(14f, 17f);
        
        // Reset
        SetPlayerComponent(false);
        StartCoroutine(SetPlayerToCheckPoint());
        virtualCamera.Follow = null;
    }

    IEnumerator SetPlayerToCheckPoint()
    {
        yield return new WaitForSeconds(2f);
        player.transform.position = checkPoint.position;
        player.transform.rotation = Quaternion.identity;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        SetPlayerComponent(true);
        virtualCamera.Follow = player.transform.GetChild(1);

        TrapManager.instance.resetCycleTrap();
    }

    void SetPlayerComponent(bool isActive)
    {
        player.GetComponent<Collider2D>().enabled = isActive;
        player.GetComponent<Animator>().enabled = isActive;
        player.GetComponent<StateManager>().enabled = isActive;
    }
    #endregion

    #region Handle EndLevel Event
    void EndLevel()
    {
        StartCoroutine(EndLevelDelay());
    }

    IEnumerator EndLevelDelay()
    {
        yield return new WaitForSeconds(2f);
        endLevelUI.SetActive(true);
        yield return new WaitForSeconds(.5f);
        Time.timeScale = 0f;
    }
    #endregion
}
