using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform[] camPoints;
    public int roomIndex = 0;
    public float transTime = 0.5f;
    bool canMove = false;
    float velo;
    void Start()
    {
        transform.position = camPoints[0].position;
        for (int i = 0; i < camPoints.Length; i++)
        {
            camPoints[i].GetComponentInChildren<SwitchCam>().roomIndex = i;
        }
        GameEvents.instance.playerDeath += ResetCam;
    }

    void OnDisable() {
        GameEvents.instance.playerDeath -= ResetCam;
    }

    void FixedUpdate()
    {
        if(canMove) {
            if (Vector2.Distance(transform.position, camPoints[roomIndex].position) <= .1f)
                canMove = false;
            transform.position = Vector3.MoveTowards(transform.position, camPoints[roomIndex].position, velo * Time.fixedDeltaTime);
        }

    }

    public void SetMove(int roomIndex) {
        this.roomIndex = roomIndex;
        canMove = true;
        velo = (transform.position - camPoints[this.roomIndex].position).magnitude / transTime;
    }

    void ResetCam(bool i) {
        if(roomIndex == 0) return;
        StartCoroutine(ResetCamCoroutine());
    }

    IEnumerator ResetCamCoroutine() {
        yield return new WaitForSeconds(1.3f);
        roomIndex = 0;
        canMove = true;
        velo = (transform.position - camPoints[roomIndex].position).magnitude / transTime;
    }
}
