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

        //if (other.gameObject.TryGetComponent<Animator>(out var anim))
        //{
        //    // Получаем доступ к компоненту
        //    Animator enemyAnim = other.gameObject.GetComponent<Animator>();

        //    enemyAnim.SetBool("isHit", true);
        //    enemyAnim.SetBool("isHit", false);
        //}
    }
}
