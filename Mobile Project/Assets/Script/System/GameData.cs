using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    public int fruitCnt = 0;
    public int level = 1;
    public string currentCharacter;

    private void Awake() {
        if(instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        IntermediaryData data = SaveAndLoad.load();
        if(data == null) return;
        instance.fruitCnt = data.fruitCnt;
        instance.level = data.level;
        instance.currentCharacter = data.currentCharacter;
    }

    private void OnDestroy() {
        if(instance == this)
            SaveAndLoad.save(instance);
    }
}
