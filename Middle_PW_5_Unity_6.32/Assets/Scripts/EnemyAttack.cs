using UnityEngine;
using Zenject;

public class EnemyAttack : MonoBehaviour
{
    // Не правильно сделанная инъекция, нужно через метод Construct
    [Inject] private EnemySettings _enemySettings;
}
