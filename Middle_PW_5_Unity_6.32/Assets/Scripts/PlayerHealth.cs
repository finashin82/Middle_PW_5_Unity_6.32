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

    private float currentHealth;

    void Start()
    {
        currentHealth = _playerSettings.Health;
    }

    private void Update()
    {
        if (currentHealth < 0) 
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
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }
    }
}
