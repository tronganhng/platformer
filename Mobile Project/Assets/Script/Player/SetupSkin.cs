using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class SetupSkin : MonoBehaviour
{
    public Animator animator;
    public CharacterOS characterOS;
    private void OnEnable() {
        if(GameData.instance == null) return;
        int char_index = characterOS.characters.FindIndex(x => x.name == GameData.instance.currentCharacter);
        animator.runtimeAnimatorController = characterOS.characters[char_index].animator;
    }
}
