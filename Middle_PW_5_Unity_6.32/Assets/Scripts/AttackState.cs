using UnityEngine;

public class AttackState : State
{
    private RealizationStateMachine RSM;

    public AttackState(RealizationStateMachine realizationStateMachine)
    {
        RSM = realizationStateMachine;
    }

    public override void Enter()
    {
        RSM.Anim.SetBool("isAttack", true);        
    }

    public override void Exit()
    {
        RSM.Anim.SetBool("isAttack", false);
    }

    public override void Update()
    {
        Vector3 direction = RSM.target.position - RSM.transform.position;
        direction.Normalize();

        Vector3 targetPosition = RSM.trans.transform.position;

        Vector3 newPosition = new Vector3(RSM.target.transform.position.x, targetPosition.y, RSM.target.transform.position.z);

        RSM.transform.LookAt(newPosition);
    }
}
