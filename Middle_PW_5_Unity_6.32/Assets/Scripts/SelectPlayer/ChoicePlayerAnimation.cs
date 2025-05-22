using UnityEngine;

public class ChoicePlayerAnimation : MonoBehaviour, IChoicedPlayer
{
    private Animator animator;

    private string choice = "choice";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ChoicePlayerOff()
    {
        animator.SetBool(choice, false);
    }

    public void ChoicePlayerOn()
    {
        animator.SetBool(choice, true);
    }
}
