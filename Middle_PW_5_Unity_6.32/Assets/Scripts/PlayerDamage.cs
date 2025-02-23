using UnityEngine;
using Zenject;

public class PlayerDamage : MonoBehaviour
{
    private PlayerSettings _playerSettings;

    [Inject]
    public void Construct(PlayerSettings playerSettings)
    {
        _playerSettings = playerSettings;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<EnemyHealth>(out var health))
        {
            health.TakeDamage(_playerSettings.StrikeForce);
        }
    }
}
