using UnityEngine;

public class ChoicePlayerAnimation : MonoBehaviour, IChoicedPlayer
{
    private Animator animator;

    private bool choice = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChoicePlayerOff()
    {
        animator.SetBool("choice", false);
    }

    public void ChoicePlayerOn()
    {
        animator.SetBool("choice", true);
    }
}
