using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DialoguePlayer : EditorWindow
{
    [MenuItem("Tools/Dialogue Player")]
    public static void OpenWindow()
    {
        GetWindow<DialoguePlayer>("Dialogue Player");
    }

    private Dialogue _currentDialogue;
    private bool _isPlaying;
    private int _currentLine;

    private void OnGUI()
    {

        GUI.enabled = !_isPlaying;
            
        _currentDialogue = 
            (Dialogue)EditorGUILayout.ObjectField("Dialogue", _currentDialogue, typeof(Dialogue), false);

        GUI.enabled = true;

        if (_currentDialogue == null)
        {
            EditorGUILayout.HelpBox("Seleziona un dialogo", MessageType.Warning);
            return;
        }

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button(_isPlaying ? "Restart" : "Start"))
        {
            _isPlaying = true;
            _currentLine = 0;
        }

        if (GUILayout.Button("Stop"))
        {
            _isPlaying = false;
        }
        
        
        EditorGUILayout.EndHorizontal();

        if (!_isPlaying) return;
        
        GUILayout.Label(_currentDialogue.lines[_currentLine].character.characterName, 
            EditorStyles.largeLabel);
        
        EditorGUILayout.BeginVertical("Box");
        GUILayout.Label(_currentDialogue.lines[_currentLine].content);
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginHorizontal();
        
        if (GUILayout.Button("Linea precedente"))
        {
            _currentLine = Mathf.Max(0, _currentLine - 1);
        }

        if (GUILayout.Button("Linea successiva"))
        {
            _currentLine = Mathf.Min(_currentDialogue.lines.Count - 1, _currentLine + 1);
        }
        
        EditorGUILayout.EndHorizontal();
    }
}
