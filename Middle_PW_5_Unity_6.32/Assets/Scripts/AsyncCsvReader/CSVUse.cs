using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class CSVUse : MonoBehaviour
{
    private string pathFile = "Assets/CSVSettings";

    private string nameFile = "GameSettingsCSV.csv";

    void Start()
    {
        // Запуск асинхронной задачи
        LoadCSVData().Forget();
    }

    /// <summary>
    /// Получение списка из файла и работа с ним
    /// </summary>
    /// <returns></returns>
    private async UniTaskVoid LoadCSVData()
    {
        //// Получаем асинхронно данные из класса ReadCSVAsync
        List<CSVData> fileCsv = await CSVReader.ReadCSVAsync(pathFile, nameFile);

        if (fileCsv != null)
        {
            foreach (var itemData in fileCsv)
            {
                Debug.Log($"{itemData.Name}, {itemData.Value}");
            }
        }
    }
}
