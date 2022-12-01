using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue.asset", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    [Serializable]
    public struct DialogueLine
    {
        public Character character;
        public string content;
    }

    public string description;
    public List<DialogueLine> lines = new();
}
