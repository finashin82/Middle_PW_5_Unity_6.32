using UnityEngine;

public class SMPlayer : InputData
{
    public StateMachinePlayer StateMachinePlayer;
    public IdleStatePlayer IdleStatePlayer;
    public WalkStatePlayer WalkStatePlayer;

    public Animator Anim { get; set; }

    void Start()
    {
        StateMachinePlayer = new StateMachinePlayer();
        IdleStatePlayer = new IdleStatePlayer();
        WalkStatePlayer = new WalkStatePlayer(this);
        
        StateMachinePlayer.Initialize(IdleStatePlayer);

        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        StateMachinePlayer.CurrentStatePlayer.Update();

        if (inputVector != Vector2.zero)
        {
            StateMachinePlayer.ChangeStatePlayer(WalkStatePlayer);
        }
        else
        {
            StateMachinePlayer.ChangeStatePlayer(IdleStatePlayer);
        }
    }
}
