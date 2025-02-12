using UnityEngine;
using Zenject;

public class EnemyAttack : MonoBehaviour
{
    [Inject] private EnemySettings _enemySettings;

    void Start()
    {
        Debug.Log($"Enemy Strike Force: {_enemySettings.StrikeForce}");
        Debug.Log($"Enemy Speed: {_enemySettings.Speed}");        
    }

    void Update()
    {
        
    }
}
