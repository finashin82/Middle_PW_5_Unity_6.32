using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private int poolSize = 3;

    private List<GameObject> enemyPool= new List<GameObject>();

    private DiContainer container;

    [Inject]
    public void Construct(DiContainer container) 
    {  
        this.container = container;

        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = container.InstantiatePrefab(_enemyPrefab);

            enemy.SetActive(false);

            enemyPool.Add(enemy);
        }
    }

    public GameObject GetEnemy() 
    {
        foreach (GameObject enemy in enemyPool) 
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);

                return enemy;
            }
        }

        return null;

        // Если все объекты в пуле заняты, создаем новый (не обязательно)
        //GameObject newEnemy = container.InstantiatePrefab(_enemyPrefab);
        //enemyPool.Add(newEnemy);
        //return newEnemy;
    }

    public void ReturnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
    }
}
