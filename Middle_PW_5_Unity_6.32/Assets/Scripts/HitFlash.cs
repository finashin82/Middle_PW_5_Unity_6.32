using UnityEngine;

public class HitFlash : MonoBehaviour
{
    [SerializeField] private ParticleSystem hitFlash;

    private Vector3 contactPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Получаем ближайшую точку на коллайдере к позиции триггера
            Vector3 contactPoint = other.ClosestPoint(transform.position);

            hitFlash.transform.position = contactPoint;

            hitFlash.Play();
        }
    }
}
