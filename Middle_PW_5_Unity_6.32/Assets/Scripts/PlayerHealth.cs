using UnityEngine;
using Zenject;
using static Zenject.SpaceFighter.GameSettingsInstaller;

public class PlayerHealth : MonoBehaviour
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

    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            Debug.Log($"Health Player: {currentHealth}");

        }
        else
        {
            _signalBus.Fire(new DeathPlayerSignal
            {

            });
        }
    }
}
