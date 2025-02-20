using UnityEngine;
using Zenject;

public class EnemyCreate : MonoBehaviour
{
    private EnemyPool enemyPool;

    [Inject]
    public void Construct(EnemyPool enemyPool)
    {
        this.enemyPool = enemyPool;
    }

    private Rigidbody rb;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = enemyPool.GetEnemy();
        enemy.transform.position = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
    }
}
