using UnityEngine;
using Zenject;
using static Zenject.SpaceFighter.GameSettingsInstaller;

public class PlayerHealth : MonoBehaviour, ITakeDamagePlayer
{
    //private PlayerSettings _playerSettings;

    public static PlayerHealth instance;

    private SignalBus _signalBus;

    [Inject]
    public void Construct(/*PlayerSettings playerSettings, */SignalBus signalBus)
    {
        //_playerSettings = playerSettings;
        _signalBus = signalBus;
    }

    //[SerializeField] private int _currentHealth;

    [SerializeField] private int _maxHealth = 40;

    public int _currentHealth;

    void Start()
    {
        //_currentHealth = _playerSettings.Health;
        _currentHealth = _maxHealth;
    }

    private void OnEnable()
    {
        // Подписываемся на сигнал
        _signalBus.Subscribe<SignalPlayerHealth>(AddHealth);
    }

    private void OnDestroy()
    {
        // Отписываемся при уничтожении объекта
        _signalBus.Unsubscribe<SignalPlayerHealth>(AddHealth);
    }

    /// <summary>
    /// Урон игроку
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamagePlayer(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _signalBus.Fire(new DeathPlayerSignal
            {

            });
        }
    }


    /// <summary>
    /// Добавляем жизни через сигнал (Zenject)
    /// </summary>
    /// <param name="signalPlayerHealth"></param>
    public void AddHealth(SignalPlayerHealth signalPlayerHealth)
    {
        if (signalPlayerHealth == null) return;

        _currentHealth += signalPlayerHealth.AmountHealth;

        Debug.Log($"Player Health: {_currentHealth}");

        Debug.Log($"+ {signalPlayerHealth.AmountHealth} к жизни");
    }
}
