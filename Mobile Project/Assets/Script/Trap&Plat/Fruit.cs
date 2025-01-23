using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(Tag.Player))
        {
            GetComponentInParent<Animator>().SetTrigger("collect");
            Destroy(transform.parent.gameObject, 0.5f);
            if(GameData.instance != null)
                GameData.instance.fruitCnt++;
                FruitManager.instance.UpdateFruitText();
        }
    }
}
