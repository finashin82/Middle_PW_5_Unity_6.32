using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FindScriptableObject : MonoBehaviour
{
    [SerializeField] private Dropdown dropdown;

    private string targetFolderPath = "Assets/ScriptableObject";

    private List<ScriptableObject> scriptableObjects = new List<ScriptableObject>();

    void Start()
    {
        // Получаем все .asset в указанной папке
        string[] objects = AssetDatabase.FindAssets("t:ScriptableObject", new[] { targetFolderPath });

        foreach (string obj in objects)
        {
            // Делаем читаемый путь
            string path = AssetDatabase.GUIDToAssetPath(obj);

            ScriptableObject so = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);

            if (so != null)
            {
                scriptableObjects.Add(so);
            }
        }

        // Очистка выпадающего меню от значений по умолчанию
        dropdown.ClearOptions();

        // Создаем список имен ScriptableObject для Dropdown
        List<string> options = scriptableObjects.Select(so => so.name).ToList();

        // Добавляем опции в Dropdown
        dropdown.AddOptions(options);

        // Добавляем обработчик выбора
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int index)
    {
        if (index >= 0 && index < scriptableObjects.Count)
        {
            ScriptableObject selectedSO = scriptableObjects[index];
            Debug.Log("Selected: " + selectedSO.name);
        }
    }
}
