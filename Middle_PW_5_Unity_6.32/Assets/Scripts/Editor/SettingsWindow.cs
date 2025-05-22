using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class SettingsWindow : EditorWindow
{
    List<GameObject> gameObject;

    private string[] settingsList;

    private int selectedIndex = 0;

    // Путь к папке где находятся ScriptableObject
    private string assetsPath = "Assets/ScriptableObject";

    private ScriptableObject loadObject;

    private bool isNull = false;

    private bool isWork = false;

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
                gameObject = FindScriptableObjectInComponent(loadObject);

                if (gameObject.Count == 0) 
                {
                    isNull = true;
                }
                else
                {
                    isNull = false;
                }
            }
            else
            {
                Debug.LogError($"Файл не существует: {gameSettingPath}");
            }
        }

        if (isNull)
        {
            GUILayout.Label($"Файл {loadObject} никто не использует", EditorStyles.boldLabel);
        }

        if (isWork)
        {
            foreach (var obj in gameObject)
            {
                GUILayout.Label($"Объект {obj.name} использует ScriptableObject {loadObject.name}");
            }
        }
    }

    /// <summary>
    /// Находим объекты которые используют нужные нам ScriptableObject
    /// </summary>
    /// <param name="scriptableObject"></param>
    /// <returns></returns>
    private List<GameObject> FindScriptableObjectInComponent(ScriptableObject scriptableObject)
    {
        // Получаем все объекты на активной сцене с помощью FindObjectsByType
        GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);

        // Создаем список для объектов, которые будут содержать ссылки на ScriptableObject
        List<GameObject> objectsUsingScriptableObject = new List<GameObject>();

        foreach (var obj in allObjects)
        {
            // Получаем все компоненты объекта
            Component[] components = obj.GetComponents<Component>();

            foreach (var component in components)
            {
                if (component != null)
                {
                    // Собираем все поля компонента
                    FieldInfo[] fields = component.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                    foreach (var field in fields)
                    {
                        // Проверяем, есть ли поле ScriptableObject в компоненте
                        if (field.FieldType.IsSubclassOf(typeof(ScriptableObject)))
                        {
                            // Берем значение поля этого экземпляра объекта
                            ScriptableObject referencedScriptableObject = field.GetValue(component) as ScriptableObject;

                            if (referencedScriptableObject == scriptableObject)
                            {
                                objectsUsingScriptableObject.Add(obj);

                                //Debug.Log($"Объект {obj.name} использует ScriptableObject {scriptableObject.name} в компоненте {component.GetType().Name}");
                                
                                isWork = true;

                                break;
                            }
                        }
                    }
                }
            }
        }

        return objectsUsingScriptableObject;
    }
}
