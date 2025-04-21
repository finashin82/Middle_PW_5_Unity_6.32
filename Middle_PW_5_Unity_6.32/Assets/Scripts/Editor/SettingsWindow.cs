using UnityEditor;
using UnityEngine;

public class SettingsWindow : EditorWindow
{
    private string[] settingsList;

    private int selectedIndex = 0;

    private string assetsPath = "Assets/ScriptableObject/Settings1.asset";

    [MenuItem("Window/Settings window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SettingsWindow));
    }

    private void OnGUI()
    {
        settingsList = AssetDatabase.FindAssets("t:ScriptableObject", new[] { "Assets/ScriptableObject" });

        GUILayout.Label("Game Settings", EditorStyles.boldLabel);

        GUILayout.Space(5);
        GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
        GUILayout.Space(5);

        //GUILayout.Label(settingsList?.Length.ToString(), EditorStyles.label);

        selectedIndex = EditorGUILayout.Popup("Select Setting:", selectedIndex, settingsList);

        if (GUILayout.Button("Show Selected"))
        {
            Debug.Log("Selected: " + settingsList[selectedIndex]);
        }

        ScriptableObject asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(assetsPath);
    }
}
