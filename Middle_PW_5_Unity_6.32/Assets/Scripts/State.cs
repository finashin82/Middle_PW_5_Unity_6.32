using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract float Evaluate();

    public abstract void Execute();
}
