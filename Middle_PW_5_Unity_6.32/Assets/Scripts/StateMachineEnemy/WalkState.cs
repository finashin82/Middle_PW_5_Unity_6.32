using UnityEngine;

public class WalkState : State
{
    private RealizationStateMachine RSM;

    public WalkState(RealizationStateMachine realizationStateMachine)
    {
        RSM = realizationStateMachine;
    }

    public override void Enter()
    {
        RSM.Anim.SetBool("isWalk", true);
    }

    public override void Exit()
    {
        RSM.Anim.SetBool("isWalk", false);
    }

    public override void Update()
    {        
        
    }
}
