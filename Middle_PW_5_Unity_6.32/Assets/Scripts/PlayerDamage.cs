using UnityEngine;
using Zenject;

public class PlayerDamage : MonoBehaviour
{
    [Inject] private PlayerSettings _playerSettings;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out var health))
        {
            health.TakeDamage(_playerSettings.StrikeForce);
        }
    }
}
