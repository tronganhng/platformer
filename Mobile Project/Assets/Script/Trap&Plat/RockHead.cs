using System.Collections;
using UnityEngine;
using Cinemachine;
using System;

public class RockHead : MovingPlat
{
    public LayerMask groundLayer;
    public float moveRate = 1.5f;
    public float blinkRate = 0.4f;
    public CinemachineImpulseSource impulseSource;
    bool canMove = true;
    float velo;
    Vector2 moveDir;

    void Start() {
        velo = speed;
    }

    void FixedUpdate()
    {
        if(canMove) 
        {
            if(velo <= 20)
                velo += Time.deltaTime * 8;
            moveDir = (points[index].position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, points[index].position, velo * Time.deltaTime);
        }
        if(Vector2.Distance(transform.position, points[index].position) < .1f && canMove)
        {
            canMove = false;
            velo = speed;
            StartCoroutine(DelayIndex());
        }
    }

    IEnumerator DelayIndex()
    {
        setHitAnim();
        if(impulseSource != null) impulseSource.GenerateImpulse();
        yield return new WaitForSeconds(moveRate);
        GetComponent<Animator>().SetTrigger("blink");
        yield return new WaitForSeconds(blinkRate);
        index++;
        if(index >= points.Length)
        {
            index = 0;
        }
        canMove = true;
    }

    void setHitAnim() {
        GetComponent<Animator>().SetTrigger("hit");
        GetComponent<Animator>().SetInteger("dirX", (int) Mathf.Round(moveDir.x));
        GetComponent<Animator>().SetInteger("dirY", (int) Mathf.Round(moveDir.y));
    }
}
