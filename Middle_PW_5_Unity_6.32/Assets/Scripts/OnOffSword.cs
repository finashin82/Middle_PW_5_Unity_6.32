using UnityEngine;

public class OnOffSword : MonoBehaviour
{
    [SerializeField] private Collider colliderSword;

   public void OnSword()
    {
        colliderSword.enabled = true;
    }
    
    public void OffSword()
    {
        colliderSword.enabled = false;
    }
}
