using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBox : MonoBehaviour
{
    public Animator ani;
    public Transform scanPoint;
    public Vector2 scanSize;
    public float delayTime = 0.4f;
    public float activeTime = 1.5f;
    float currentTime;
    bool active;
    void Update()
    {
        if(ani.GetBool("on"))
        {
            currentTime += Time.deltaTime;
            if(currentTime >= activeTime)
            {
                active = false;
                currentTime = 0;
                ani.ResetTrigger("hit");
                ani.SetBool("on", false);
            }

            Collider2D[] colliders = Physics2D.OverlapBoxAll(scanPoint.position, scanSize, 0f);
            if(colliders.Length == 0) return;
            foreach(Collider2D col in colliders)
            {
                if(col.gameObject.CompareTag(Tag.Player))
                {
                    GameEvents.instance.playerDeath?.Invoke(true);
                }
            }
        }    
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag(Tag.Player) && !active)
        {
            active = true;
            ani.SetTrigger("hit");
            StartCoroutine(Activate());
        }
    }

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(delayTime);
        ani.SetBool("on", true);
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(scanPoint.position, scanSize);    
    }
}
