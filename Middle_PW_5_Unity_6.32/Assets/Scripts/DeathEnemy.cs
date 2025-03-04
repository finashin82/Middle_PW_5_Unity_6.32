using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using static Zenject.SpaceFighter.GameSettingsInstaller;

public class DeathEnemy : MonoBehaviour
{
    private EnemyPool _enemyPool;

    private SignalBus _signalBus;

    private EnemySettings _enemySettings;

    [Inject]
    public void Construct(EnemyPool enemyPool, SignalBus signalBus, EnemySettings enemySettings)
    {
        _enemyPool = enemyPool;
        _enemySettings = enemySettings;
        _signalBus = signalBus;
    }

    private Animator animator;

    private float currentHealth;

    private int MyId;

    private void Start()
    {
        animator = GetComponent<Animator>();

        // ������������� �� ������
        _signalBus.Subscribe<DeathSignal>(DeadEnemy);

        MyId = this.gameObject.GetInstanceID();
    }

    private void OnDestroy()
    {
        // ������������ ��� ����������� �������
        _signalBus.Unsubscribe<DeathSignal>(DeadEnemy);
    }

    /// <summary>
    /// �������� ������ �������
    /// </summary>
    private void DeadEnemy(DeathSignal signal)
    {
        if(signal.TargetId == MyId)
            animator.SetBool("isDead", true);
    }

    /// <summary>
    /// �������������� ������ ����� � ������� � ��� (����� ��������������� � ����� �������� ������ - Events)
    /// </summary>
    public void Die()
    {
        currentHealth = _enemySettings.Health;

        _enemyPool.ReturnEnemy(gameObject);
    }
}
