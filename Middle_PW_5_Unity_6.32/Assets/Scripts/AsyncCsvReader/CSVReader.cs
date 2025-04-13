using Cysharp.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class CSVReader
{
    /// <summary>
    /// Чтение файла CSV, который возвращает список со структурой CSVData
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static async UniTask<List<CSVData>> ReadCSVAsync(string pathFile, string fileName)
    {
        // Объединяет несколько строк в один путь
        var filePathCsv = Path.Combine(pathFile, fileName);

        // Проверка существования файла
        if (!File.Exists(filePathCsv))
        {
            Debug.LogError($"Файл не найден: {filePathCsv}");
            return null;
        }

        try
        {
            // Асинхронное чтение файла. Читает весь текст из файла по указанному пути
            string fileContent = await File.ReadAllTextAsync(filePathCsv);

            // Создаем из файла стринговый массив (удаляем пустые строки)
            string[] lines = fileContent.Split(new[] {',', '\r', '\n'}, System.StringSplitOptions.RemoveEmptyEntries);

            if (lines != null)
            {
                // Создаем новый лист, в котором будут все данные в виде CSVData
                var itemDatas = new List<CSVData>();

                // Добавляем в лист данные из строкового массива (четные индексы - это Name, нечетные - Value)
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        var name = lines[i];
                        var value = lines[i + 1];

                        itemDatas.Add(new CSVData { Name = name, Value = value });
                    }
                }

                return itemDatas;
            }
            else
            {
                return null;
            }
        }
        // Вывод ошибок, если они есть
        catch (System.Exception e)
        {
            Debug.LogError($"Ошибка при чтении файла: {e.Message}");
            return null;
        }
    }
}
