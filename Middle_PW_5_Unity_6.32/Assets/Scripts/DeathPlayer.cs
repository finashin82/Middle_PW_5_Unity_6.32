using UnityEngine;
using Zenject;
using static Zenject.SpaceFighter.GameSettingsInstaller;

public class DeathPlayer : MonoBehaviour
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Подписываемся на сигнал
        _signalBus.Subscribe<DeathPlayerSignal>(DeadPlayer);
    }

    private void OnDestroy()
    {
        // Отписываемся при уничтожении объекта
        _signalBus.Unsubscribe<DeathPlayerSignal>(DeadPlayer);
    }

    /// <summary>
    /// Анимация смерти объекта
    /// </summary>
    private void DeadPlayer()
    {
            animator.SetBool("isDead", true);
    }

    /// <summary>
    /// Восстановление жизней врага и возврат в пул (метод воспроизводится в конце анимации смерти - Events)
    /// </summary>
    public void Die()
    {
        Debug.Log("Конец игры.");

        Destroy(gameObject);
    }
}
