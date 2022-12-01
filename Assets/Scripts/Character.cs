using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chracter.asset", menuName = "Character")]
public class Character : ScriptableObject
{
    public string characterName;
    public Sprite sprite;
}
