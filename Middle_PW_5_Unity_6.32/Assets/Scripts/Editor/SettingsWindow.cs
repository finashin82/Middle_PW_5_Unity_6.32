using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SettingsWindow : EditorWindow
{
    private string[] settingsList;

    private string[] fileNames;

    private int selectedIndex = 0;

    private string assetsPath = "Assets/ScriptableObject";

    private List<ScriptableObject> scriptableObjects = new List<ScriptableObject>();

    [MenuItem("Window/Settings window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SettingsWindow));
    }

    private void OnGUI()
    {
        // Получаем все .asset в указанной папке
        settingsList = AssetDatabase.FindAssets("t:ScriptableObject", new[] { assetsPath });

        GUILayout.Label("Game Settings", EditorStyles.boldLabel);

        GUILayout.Space(5);
        GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
        GUILayout.Space(5);

        selectedIndex = EditorGUILayout.Popup("Select Setting:", selectedIndex, settingsList);

        if (GUILayout.Button("Show Selected"))
        {
            Debug.Log("Selected: " + settingsList[selectedIndex]);
        }

        //ScriptableObject asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(assetsPath);
    }
}
