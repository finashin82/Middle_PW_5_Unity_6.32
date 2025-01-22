using UnityEngine;

public class StateMachinePlayer
{
    public StatePlayer CurrentStatePlayer { get; set; }

    public void Initialize(StatePlayer startState)
    {
        CurrentStatePlayer = startState;
        startState.Enter();
    }

    public void ChangeStatePlayer(StatePlayer newState)
    {
        CurrentStatePlayer.Exit();
        CurrentStatePlayer = newState;
        newState.Enter();
    }
}
