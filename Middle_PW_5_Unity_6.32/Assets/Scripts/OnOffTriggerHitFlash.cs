using UnityEngine;

public class OnOffTriggerHitFlash : MonoBehaviour
{
    [SerializeField] private Collider colliderHitFlash;

    private void Start()
    {
        colliderHitFlash.enabled = false;
    }

    public void OnHitFlash()
    {
        colliderHitFlash.enabled = true;
    }

    public void OffHitFlash()
    {
        colliderHitFlash.enabled = false;
    }
}
