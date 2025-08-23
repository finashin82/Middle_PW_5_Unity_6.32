using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerHealthTest
{
    private PlayerHealth playerHealth;

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(1);
    }

    [UnityTest]
    public IEnumerator PlayerHealthTestWithEnumeratorPasses()
    {
        playerHealth = GameObject.FindAnyObjectByType<PlayerHealth>();

        yield return null;

        // ѕровер€ем инициализацию здоровь€
        Assert.IsTrue(playerHealth._currentHealth > 0, "«доровье игрока должно быть больше 0");
        Assert.AreEqual(playerHealth._maxHealth, playerHealth._currentHealth,
            "Ќачальное здоровье должно равн€тьс€ максимальному");
    }
}
