using UnityEngine;

public class OnOffSword : MonoBehaviour
{
    [SerializeField] private Collider colliderSword;

    private void Start()
    {
        colliderSword.enabled = false;
    }

    public void OnSword()
    {
        colliderSword.enabled = true;
    }
    
    public void OffSword()
    {
        colliderSword.enabled = false;
    }
}
