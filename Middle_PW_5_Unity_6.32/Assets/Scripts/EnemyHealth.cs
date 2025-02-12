using UnityEngine;
using Zenject;

public class EnemyHealth : MonoBehaviour
{
    [Inject] private EnemySettings _enemySettings;

    void Start()
    {
        Debug.Log($"Enemy Health: {_enemySettings.Health}");
    }

    void Update()
    {
        
    }
}
