using UnityEngine;
using Zenject;

public class EnemyHealth : MonoBehaviour
{
    private EnemySettings _enemySettings;

    private SignalBus _signalBus;

    [Inject]
    public void Construct(EnemySettings enemySettings, SignalBus signalBus)
    {
        _enemySettings = enemySettings;
        _signalBus = signalBus;
    }

    private float currentHealth;

    private int targetId;

    void Start()
    {
        currentHealth = _enemySettings.Health;

        targetId = this.gameObject.GetInstanceID();
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }
        else
        {
            _signalBus.Fire(new DeathSignal
            {
                TargetId = targetId
            });
        }
    }
}
