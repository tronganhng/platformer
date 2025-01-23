using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public RectTransform uiElement;
    public Vector2 startPos;
    public Vector2 endPos;
    public float speed = 200;
    void FixedUpdate()
    {        
        uiElement.anchoredPosition += new Vector2(0, -speed * Time.deltaTime);
            if(uiElement.anchoredPosition.y <= endPos.y) {
                uiElement.anchoredPosition = startPos;
            }        
    }
}
