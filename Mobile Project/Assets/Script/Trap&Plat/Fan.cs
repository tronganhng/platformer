using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public Transform scanPoint;
    public Vector2 scanSize;
    public float activeTime = 3f;
    public float activeRate = 3f;
    public float power = 3f;
    float currentTime;
    bool active;
    void Update()
    {
        currentTime += Time.deltaTime;
        if(active)
        {
            GetComponent<Animator>().SetBool("on", true);
            Active();
            if(currentTime >= activeTime)
            {
                currentTime = 0;
                active = false;
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("on", false);
            if(currentTime >= activeRate)
            {
                currentTime = 0;
                active = true;
            }
        }
    }

    void Active()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(scanPoint.position, scanSize, 0);
        if(colliders != null)
        {
            foreach(Collider2D col in colliders)
            {
                if(col.gameObject.CompareTag(Tag.Player))
                {
                    Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
                    //rb.velocity = new Vector2(rb.velocity.x, power);
                    Vector2 direct = transform.up;
                    rb.AddForce(direct * power, ForceMode2D.Force);
                }
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(scanPoint.position, scanSize);
    }
}
