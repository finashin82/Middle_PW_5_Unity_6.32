using UnityEngine;

public class OnOffShield : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shield;

    public void OnShield()
    {
        _shield.Play();
    }

    public void OffShield()
    {
        _shield.Stop();
    }
}
