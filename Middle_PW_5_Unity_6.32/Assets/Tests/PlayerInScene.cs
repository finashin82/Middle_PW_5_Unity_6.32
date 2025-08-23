using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerInScene
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(1);
    }

    [UnityTest]
    public IEnumerator PlayerInSceneWithEnumeratorPasses()
    {
        // Ищем все объекты с компонентом PlayerHealth
        var players = GameObject.FindObjectsByType<PlayerHealth>(FindObjectsSortMode.None);

        yield return null; // Ждем один кадр

        // Проверяем, что ровно один игрок в сцене
        UnityEngine.Assertions.Assert.AreEqual(1, players.Length, "В сцене должен быть ровно один игрок");
        UnityEngine.Assertions.Assert.IsNotNull(players[0], "Игрок не должен быть null");
    }
}
