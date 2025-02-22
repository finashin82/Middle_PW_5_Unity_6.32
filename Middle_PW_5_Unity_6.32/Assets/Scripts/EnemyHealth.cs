using UnityEngine;
using Zenject;

public class EnemyHealth : MonoBehaviour
{
    private EnemyPool enemyPool;

    [Inject] private EnemySettings _enemySettings;

    [Inject]
    public void Construct(EnemyPool enemyPool)
    {
        this.enemyPool = enemyPool;
    }

    private float currentHealth;

    private Animator animator;

    private Rigidbody rb;

    void Start()
    {
        currentHealth = _enemySettings.Health;

        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        rb.isKinematic = false;
    }

    private void Update()
    {
        DeathEnemy();
    }

    public void NewHealth()
    {
        currentHealth = _enemySettings.Health;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            Debug.Log($"Enemy Health: {_enemySettings.Health}");
        }
    }

    private void DeathEnemy()
    {
        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
        }
    }

    public void Die()
    {
        currentHealth = _enemySettings.Health;

        enemyPool.ReturnEnemy(gameObject);
    }
}
