using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu]
public class CharacterOS : ScriptableObject
{
    public List<Character> characters;
}

[Serializable]
public class Character
{
    [field: SerializeField]
    public string name {get; private set;}
    [field: SerializeField]
    public AnimatorController animator {get; private set;}
    [field: SerializeField]
    public AnimationClip UI_animationClip {get; private set;}
}