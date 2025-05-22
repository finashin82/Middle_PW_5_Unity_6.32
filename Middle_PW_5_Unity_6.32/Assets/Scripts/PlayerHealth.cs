using UnityEngine;
using Zenject;
using static Zenject.SpaceFighter.GameSettingsInstaller;

public class PlayerHealth : MonoBehaviour, ITakeDamagePlayer
{
    private PlayerSettings _playerSettings;

    private SignalBus _signalBus;

    [Inject]
    public void Construct(PlayerSettings playerSettings, SignalBus signalBus)
    {
        _playerSettings = playerSettings;
        _signalBus = signalBus;
    }

    [SerializeField] private int _currentHealth;

    //public float CurrentHealth;

    void Start()
    {
        //CurrentHealth = _playerSettings.Health;
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

    public void AddHealth(int health)
    {
        _currentHealth += health;

        Debug.Log($"Player Health: {_currentHealth}");
    }
}
