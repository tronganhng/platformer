using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IntermediaryData {
    public int fruitCnt;
    public int level;
    public string currentCharacter;
    public IntermediaryData(GameData gameData) {
        fruitCnt = gameData.fruitCnt;
        level = gameData.level;
        currentCharacter = gameData.currentCharacter;
    }
}
