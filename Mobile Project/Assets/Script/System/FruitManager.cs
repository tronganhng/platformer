using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public static FruitManager instance;
    public Text fruitText;

    private void Awake() 
    {
        if(instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateFruitText();
    }

    public void UpdateFruitText()
    {
        if(GameData.instance != null)
            fruitText.text = GameData.instance.fruitCnt.ToString();
    }
}
