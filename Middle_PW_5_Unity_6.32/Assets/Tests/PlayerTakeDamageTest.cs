using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerTakeDamageTest
{
    private PlayerHealth playerHealth;

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(1);
    }

    [UnityTest]
    public IEnumerator PlayerTakeDamageTestWithEnumeratorPasses()
    {
        playerHealth = GameObject.FindAnyObjectByType<PlayerHealth>();
        int initialHealth = playerHealth._currentHealth;
        int damageAmount = 10;

        // Наносим урон
        playerHealth.TakeDamagePlayer(damageAmount);

        yield return null;

        // Проверяем, что здоровье уменьшилось
        Assert.AreEqual(initialHealth - damageAmount, playerHealth._currentHealth,
            "Здоровье должно уменьшиться на величину урона");
    }
}
