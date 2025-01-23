using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public string previewSkin;
    public Animator animator;
    public CharacterOS characterOS;
    private AnimatorOverrideController animatorOverride;
    private int index;

    private void Start() {
        index = characterOS.characters.FindIndex(x => x.name == GameData.instance.currentCharacter);
    }
    
    void Update()
    {
        previewSkin = characterOS.characters[index].name;


        animatorOverride = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animatorOverride.name = "Override Animator";
        animator.runtimeAnimatorController = animatorOverride;
        animatorOverride["maskdudeUI_idle"] = characterOS.characters[index].UI_animationClip;
    }

    public void NextSkin()
    {
        if(index == characterOS.characters.Count - 1)
            index = 0;
        else
            index++;
    }

    public void BackSkin()
    {
        if(index == 0)
            index = characterOS.characters.Count - 1;
        else
            index--;
    }

    public void Apply()
    {
        GameData.instance.currentCharacter = previewSkin;
    }
}
