using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine
{
    public State CurrentState { get; set; }    
        
    public void Initialize(State startState)
    {
        CurrentState = startState;
        startState.Enter();
    }

    public void ChangeState(State newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
    }
}
