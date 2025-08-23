using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerDeathTest
{
    private PlayerHealth playerHealth;

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(1);
    }

    [UnityTest]
    public IEnumerator PlayerDeathTestWithEnumeratorPasses()
    {
        playerHealth = GameObject.FindAnyObjectByType<PlayerHealth>();

        // Наносим смертельный урон
        playerHealth.TakeDamagePlayer(playerHealth._maxHealth + 10);

        yield return new WaitForSeconds(0.1f); // Ждем обработки смерти

        // Проверяем, что игрок умер
        Assert.IsTrue(playerHealth.IsDead, "Игрок должен быть мертв");
        Assert.AreEqual(0, playerHealth._currentHealth, "Здоровье должно быть 0");
    }
}
