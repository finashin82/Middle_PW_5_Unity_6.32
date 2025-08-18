using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class PlayerHealthTest
{
    [Test]
    [TestCase(10, 0, 10)]
    [TestCase(10, 5, 5)]
    [TestCase(10, 10, 0)]
    [TestCase(10, -5, 0)]
    public void PlayerHealthTestSimplePasses(int maxHealth, int damageAmount, int expectedHealth)
    {
        var fakeHealthView = new FakeHealthView();

        var testObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

        var health = testObject.AddComponent<PlayerHealth>();

        health.Construct(fakeHealthView, maxHealth);

        health.TakeDamagePlayer(damageAmount);

        UnityEngine.Assertions.Assert.AreEqual(expectedHealth, health.);
    }

    
    public class FakeHealthView
    {
        public int MaxHealth {  get; set; }
        public int CurrentHealth { get; set; }

        public void Display(int maxHealth, int currentHealth) 
        {
            MaxHealth = maxHealth;

            CurrentHealth = currentHealth;
        }
    }
}
