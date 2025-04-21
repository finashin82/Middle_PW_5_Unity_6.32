using UnityEngine;

[CreateAssetMenu(fileName = "Settings1", menuName = "Scriptable Objects/Settings1")]

public class Settings1 : ScriptableObject
{
    [Header("Player Settings")]
    [SerializeField] private float playerHealth;
    [SerializeField] private float playerDamage;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerStrikeForce;

    [Header("Enemy Settings")]
    [SerializeField] private float enemyHealth;
    [SerializeField] private float enemyDamage;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float enemyStrikeForce;
}
