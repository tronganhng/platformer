using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public int level = 1;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(Tag.Player))
        {
            GetComponent<Animator>().SetTrigger("active");
            GameEvents.instance.endLevel?.Invoke();
            if(GameData.instance.level == level)
                GameData.instance.level = level + 1;
        }
    }
}
