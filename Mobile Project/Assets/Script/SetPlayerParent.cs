using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetPlayerParent : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag(Tag.Player))
        {
            other.transform.SetParent(gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag(Tag.Player))
        {
            other.transform.SetParent(null);
        }    
    }
}
