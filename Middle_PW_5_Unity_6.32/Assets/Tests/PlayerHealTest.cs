using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerHealTest
{
    private PlayerHealth playerHealth;

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(1);
    }

    [UnityTest]
    public IEnumerator PlayerHealTestWithEnumeratorPasses()
    {
        playerHealth = GameObject.FindAnyObjectByType<PlayerHealth>();

        // Сначала наносим урон
        playerHealth.TakeDamagePlayer(10);
        int damagedHealth = playerHealth._currentHealth;

        // Затем лечим
        playerHealth.Heal(10);

        yield return null;

        // Проверяем восстановление здоровья
        Assert.AreEqual(damagedHealth + 10, playerHealth._currentHealth,
            "Здоровье должно увеличиться на величину лечения");

        // Проверяем, что нельзя превысить максимальное здоровье
        playerHealth.Heal(1000);
        yield return null;
        Assert.AreEqual(playerHealth._maxHealth, playerHealth._currentHealth,
            "Здоровье не должно превышать максимальное");
    }
}
