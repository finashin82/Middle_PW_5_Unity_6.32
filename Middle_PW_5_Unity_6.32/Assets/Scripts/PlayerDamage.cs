using UnityEngine;
using Zenject;

public class PlayerDamage : MonoBehaviour
{
    [Inject] private PlayerSettings _playerSettings;

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
