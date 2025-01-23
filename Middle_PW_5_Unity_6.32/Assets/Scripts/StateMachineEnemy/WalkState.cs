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
        //Vector3 direction = RSM.target.position - RSM.transform.position;
        //direction.Normalize();

        //Vector3 targetPosition = RSM.trans.transform.position;

        //Vector3 newPosition = new Vector3(RSM.target.transform.position.x, targetPosition.y, RSM.target.transform.position.z);

        //RSM.transform.LookAt(newPosition);
    }
}
