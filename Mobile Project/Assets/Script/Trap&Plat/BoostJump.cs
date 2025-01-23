using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostJump : MonoBehaviour
{
    [SerializeField] float activeRate = 3;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag(Tag.Player))
        {
            other.GetComponent<StateManager>().jumpCharge++;
            GetComponent<Animator>().SetTrigger("hit");
            StartCoroutine(setAppear());
        }
    }

    public void TurnOffObj()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator setAppear()
    {
        yield return new WaitForSeconds(activeRate);
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Animator>().SetTrigger("appear");
    }
}
