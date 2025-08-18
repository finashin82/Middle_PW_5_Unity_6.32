using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class NewTestScript
{
    private PlayerHealth playerHealth;

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene(1);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator FindPlayerTest()
    {
        playerHealth = GameObject.FindAnyObjectByType<PlayerHealth>();

        yield return new WaitForSeconds(5);

        UnityEngine.Assertions.Assert.IsNotNull(playerHealth);

        playerHealth._currentHealth = 0;

        yield return new WaitForSeconds(5);

        UnityEngine.Assertions.Assert.IsNull(playerHealth);
    }
}
