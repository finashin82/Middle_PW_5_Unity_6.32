using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SettingsWindow : EditorWindow
{
    private string[] settingsList;

    private int selectedIndex = 0;

    private string assetsPath = "Assets/ScriptableObject";

    private ScriptableObject loadObject;

    private Editor editor;

    [MenuItem("Window/Settings window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SettingsWindow));
    }

    private void OnGUI()
    {
        // Заголовок
        GUILayout.Label("Game Settings", EditorStyles.boldLabel);

        // Горизонтальная полоса (разделитель)
        GUILayout.Space(5);
        GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
        GUILayout.Space(5);

        // Получаем все .asset в указанной папке (в виде идентификаторов)
        settingsList = AssetDatabase.FindAssets("t:ScriptableObject", new[] { assetsPath });

        // Массив для имен
        var settingsName = new string[settingsList.Length];

        // Заполняем массив именами
        for (int i = 0; i < settingsList.Length; i++)
        {
            // Путь к файлу
            var settingsPath = AssetDatabase.GUIDToAssetPath(settingsList[i]);

            // Получаем имена файлов
            var settingsPathName = Path.GetFileNameWithoutExtension(settingsPath);

            // Помещаем имена в массив
            settingsName[i] = Path.GetFileName(settingsPathName);
        }
        
        // Список с именами файлов
        selectedIndex = EditorGUILayout.Popup("Select Setting:", selectedIndex, settingsName);

        if (GUILayout.Button("Show Selected"))
        {
            // Получаем путь к выбранному из списка файлу
            var gameSettingPath = AssetDatabase.GUIDToAssetPath(settingsList[selectedIndex]);

            // Загружаем файл с настройками по известному пути
            loadObject = AssetDatabase.LoadAssetAtPath<ScriptableObject>(gameSettingPath);

            if (loadObject != null) 
            {
                editor = Editor.CreateEditor(loadObject);

                editor.OnInspectorGUI();

                Debug.Log("+");
            }
            else
            {
                Debug.LogError($"Файл не существует: {gameSettingPath}");
            }

            Debug.Log($"Имя файла: {settingsName[selectedIndex]}. Путь к этому файлу: {gameSettingPath}");
        }
    }
}
