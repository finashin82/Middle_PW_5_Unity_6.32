using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using ColorUtility = UnityEngine.ColorUtility;

public class GoogleSheetDataUse : MonoBehaviour
{
    public static string filePathCsv = "Assets/CSVSettings";

    public static string fileNameCsv = "GameSettingsCSV.csv";

    void Start()
    {
        ReadCsvSettings();
    }

    private void ReadCsvSettings()
    {
        // Чтение данных из CSV-файла
        var items = GoogleSheetDataReader.ReadCsv(filePathCsv, fileNameCsv);

        if (items == null || items.Count == 0)
        {
            Debug.LogError("Не удалось прочитать данные из CSV-файла.");
            return;
        }

        // Выводим в консоль данные
        foreach (var item in items)
        {
            //Debug.Log($"{item.Name}: {item.Value}");
        }
    }
}
