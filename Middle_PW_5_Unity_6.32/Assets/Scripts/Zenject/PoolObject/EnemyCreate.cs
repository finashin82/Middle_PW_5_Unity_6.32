using System.Net;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using Zenject;

public class EnemyCreate : MonoBehaviour
{
    private EnemyPool enemyPool;

    private GameObject[] trackingPoints;

    private int randPoint;

    [Inject]
    public void Construct(EnemyPool enemyPool)
    {
        this.enemyPool = enemyPool;
    }

    private Rigidbody rb;

    private void Start()
    {
        trackingPoints = GameObject.FindGameObjectsWithTag("TrackingPoint");
    }

    void Update()
    {
        GameObject enemy = enemyPool.GetEnemy();

        if (enemy != null)
        {
            randPoint = Random.Range(0, trackingPoints.Length);

            enemy.transform.position = trackingPoints[randPoint].transform.position;
        }
    }
}
