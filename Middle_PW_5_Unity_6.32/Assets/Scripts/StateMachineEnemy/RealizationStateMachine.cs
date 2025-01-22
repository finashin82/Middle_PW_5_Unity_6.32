using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.HableCurve;

public class RealizationStateMachine : MonoBehaviour
{
    public Transform target;
    public Transform trans;

    private Transform centerCircle;

    public StateMachine StateMachine;
    public IdleState IdleState;
    public ChaseState ChaseState;
    public AttackState AttackState;

    [SerializeField] private float distanceToChasing = 3f;
    [SerializeField] private float distanceToAttack = 1f;

    //private State currentState;

    private Vector3 distance;


    [SerializeField] private int segmentsInCircle = 50;
    private float radiusCircleToChase;

    private LineRenderer lineRenderer;

    public Animator Anim { get; set; }    

    void Start()
    {
        StateMachine = new StateMachine();
        IdleState = new IdleState();
        ChaseState = new ChaseState(this);
        AttackState = new AttackState(this);

        StateMachine.Initialize(IdleState);

        Anim = GetComponent<Animator>();

        trans = GetComponent<Transform>();
    }

    void Update()
    {
        StateMachine.CurrentState.Update();

        distance = transform.position - target.position;

        if (distance.magnitude < distanceToChasing && distance.magnitude > distanceToAttack)
        {
            StateMachine.ChangeState(ChaseState);
        }

        if (distance.magnitude <= distanceToAttack)
        {
            StateMachine.ChangeState(AttackState);
        }

        if (distance.magnitude > distanceToChasing)
        {
            StateMachine.ChangeState(IdleState);
        }
    }
}
