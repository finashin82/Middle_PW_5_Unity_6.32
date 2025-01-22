using UnityEngine;

public class WalkStatePlayer : StatePlayer
{
    private SMPlayer SMP;

    public WalkStatePlayer(SMPlayer smPlayer)
    {
        SMP = smPlayer;
    }

    public override void Enter()
    {
        SMP.Anim.SetBool("isWalk", true);
    }

    public override void Exit()
    {
        SMP.Anim.SetBool("isWalk", false);
    }

    public override void Update()
    {
        //Vector3 direction = SMP.target.position - SMP.transform.position;
        //direction.Normalize();

        //Vector3 targetPosition = SMP.trans.transform.position;

        //Vector3 newPosition = new Vector3(SMP.target.transform.position.x, targetPosition.y, SMP.target.transform.position.z);

        //SMP.transform.LookAt(newPosition);
    }
}
