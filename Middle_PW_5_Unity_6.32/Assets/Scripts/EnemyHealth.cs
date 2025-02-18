using UnityEngine;
using Zenject;

public class EnemyHealth : MonoBehaviour
{
    [Inject] private EnemySettings _enemySettings;

    private float currentHealth;

    private Animator animator;

    void Start()
    {
        Debug.Log($"Enemy Health: {_enemySettings.Health}");

        currentHealth = _enemySettings.Health;
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }
    }

    private void DeathEnemy()
    {
        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);

            Invoke("DestroyEnemy", 3f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
