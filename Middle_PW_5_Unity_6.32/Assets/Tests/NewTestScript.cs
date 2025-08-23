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

    [UnityTest]
    public IEnumerator FindPlayerTest()
    {
        playerHealth = GameObject.FindAnyObjectByType<PlayerHealth>();

        yield return new WaitForSeconds(5);

        UnityEngine.Assertions.Assert.IsNotNull(playerHealth);
    }
}
