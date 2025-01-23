using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterial : MonoBehaviour
{
    public Material defaultMat;
    public Material glowMat;
    public Color newColor;
    private void OnTriggerEnter2D(Collider2D other) {
        SpriteRenderer s;
        if(other.TryGetComponent<SpriteRenderer>(out s))
        {
            s.material = glowMat;
            s.color = newColor;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        SpriteRenderer s;
        if(other.TryGetComponent<SpriteRenderer>(out s))
        {
            s.material = defaultMat;
            s.color = Color.white;
        }
    }
}
