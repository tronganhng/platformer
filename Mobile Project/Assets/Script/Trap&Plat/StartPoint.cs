using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(Tag.Player))
        {
            GetComponent<Animator>().SetTrigger("active");
        }
    }
}
