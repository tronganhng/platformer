using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Box : MonoBehaviour, IPushTrap
{
    public GameObject fruit;
    public GameObject[] peaces;
    public Collider2D[] colliders;
    public int health = 2;
    public float pushHeight = 2f;
    public CinemachineImpulseSource impulseSource;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(Tag.Player))
        {
            if(impulseSource != null) impulseSource.GenerateImpulse();
            TakeHit();
            if(health >= 0)
            {
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                ((IPushTrap)this).pushPlayer(pushHeight, rb);
            }
        }
    }

    void TakeHit()
    {
        GetComponent<Animator>().SetTrigger("hit");
        GameObject newFruit = Instantiate(fruit, transform.position, Quaternion.identity);
        Vector2 direct = new Vector2((Random.Range(0,2) == 0) ? -1f:1f, 0.6f);
        newFruit.GetComponent<Rigidbody2D>().velocity = direct.normalized * Random.Range(5.2f, 7f);
        health--;
        if(health <= 0)
        {
            Broke();
        }
    }

    void Broke()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        foreach(Collider2D col in colliders)
        {
            col.enabled = false;
        }
        Destroy(gameObject, 3f);
        for(int i=0; i<peaces.Length; i++)
        {
            peaces[i].SetActive(true);
            Vector2 direct = new Vector2((i%2 == 0) ? -1:1, 1f);
            peaces[i].GetComponent<Rigidbody2D>().velocity = direct.normalized * Random.Range(4.1f, 5.2f);
        }
    }
}
