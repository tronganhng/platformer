using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSticking : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(Tag.Player))
        {
            if(other.transform.position.y > transform.position.y)
            {
                other.transform.SetParent(gameObject.transform);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag(Tag.Player))
        {
            other.transform.SetParent(null);
        } 
    }
}
