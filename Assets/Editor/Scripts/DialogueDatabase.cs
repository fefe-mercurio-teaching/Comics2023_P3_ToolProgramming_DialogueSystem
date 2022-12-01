using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DialogueDatabase : EditorWindow
{
    [MenuItem("Tools/Dialogue Database")]
    public static void OpenWindow()
    {
        GetWindow<DialogueDatabase>("Dialogue Database");
    }

    private void OnGUI()
    {
        string[] dialogueIds = AssetDatabase.FindAssets("t:Dialogue");

        foreach (string dialogueGuid in dialogueIds)
        {
            string path = AssetDatabase.GUIDToAssetPath(dialogueGuid);
            Dialogue dialogue = AssetDatabase.LoadAssetAtPath<Dialogue>(path);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(dialogue.description, path);
            if (GUILayout.Button("Select", GUILayout.Width(100f)))
            {
                Selection.activeObject = dialogue;
            }
            
            EditorGUILayout.EndHorizontal();
        }
    }
}
