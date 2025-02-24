using UnityEngine;

public class IsHitFalse : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void HitFalse()
    {
        animator.SetBool("isHit", false);
    }
}
