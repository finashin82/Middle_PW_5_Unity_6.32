using UnityEngine;
using Zenject;
using static Zenject.SpaceFighter.GameSettingsInstaller;

public class PlayerHealth : MonoBehaviour, ITakeDamagePlayer
{
    //private PlayerSettings _playerSettings;

    private SignalBus _signalBus;

    [Inject]
    public void Construct(/*PlayerSettings playerSettings, */SignalBus signalBus)
    {
        //_playerSettings = playerSettings;
        _signalBus = signalBus;
    }

    //[SerializeField] private int _currentHealth;

    [SerializeField] private int _maxHealth = 40;

    private int _currentHealth;

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

    private void Update()
    {
        Debug.Log($"Player Health: {_currentHealth}");

        if (_currentHealth < 0) 
        {
            _signalBus.Fire(new DeathPlayerSignal
            {

            });
        }
    }

    /// <summary>
    /// Урон игроку
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamagePlayer(int damage)
    {
        if (_currentHealth > 0)
        {
            _currentHealth -= damage;
        }
    }

    public void AddHealth(SignalPlayerHealth signalPlayerHealth)
    {
        if (signalPlayerHealth == null) return;

        _currentHealth += signalPlayerHealth.AmountHealth;

        Debug.Log($"Player Health: {_currentHealth}");
    }
}
