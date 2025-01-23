using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.Rendering.HableCurve;

public class RealizationStateMachine : MonoBehaviour
{
    public Transform target;
    public Transform trans;

    public StateMachine StateMachine;
    public IdleState IdleState;
    public WalkState WalkState;
    public ChaseState ChaseState;
    public AttackState AttackState;

    [SerializeField] private float distanceToChasing = 3f;
    [SerializeField] private float distanceToAttack = 1f;

    [SerializeField] private GameObject[] trackingPoints;

    private Vector3 distance;

    private NavMeshAgent agent;

    private int randPoint;

    private bool isChase;

    public Animator Anim { get; set; }    

    void Start()
    {
        StateMachine = new StateMachine();
        IdleState = new IdleState();
        WalkState = new WalkState(this);
        ChaseState = new ChaseState(this);
        AttackState = new AttackState(this);

        StateMachine.Initialize(IdleState);

        Anim = GetComponent<Animator>();

        trans = GetComponent<Transform>();

        agent = GetComponent<NavMeshAgent>();
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
            StateMachine.ChangeState(WalkState);

            //randPoint = new Random.Range(0);
        }

        
    }
}
