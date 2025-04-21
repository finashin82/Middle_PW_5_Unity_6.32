using UnityEngine;

[CreateAssetMenu(fileName = "Settings2", menuName = "Scriptable Objects/Settings2")]

public class Settings2 : ScriptableObject
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
