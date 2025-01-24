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

    [SerializeField] private float timeToIdle = 1f;

    [SerializeField] private GameObject[] trackingPoints;

    private Vector3 distanceToPlayer;
    private Vector3 distanceToPoint;

    private float currentTime;

    public NavMeshAgent agent;

    private int randPoint;

    private bool isFree;
    private bool isAgentDestination;

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

        currentTime = timeToIdle;

        isFree = true;
        isAgentDestination = true;
    }

    void Update()
    {
        StateMachine.CurrentState.Update();

        // Дистанция до плеера
        distanceToPlayer = transform.position - target.position;

        // Дистанция до точки отдыха
        distanceToPoint = transform.position - trackingPoints[randPoint].transform.position;

        // Условия преследования
        if (distanceToPlayer.magnitude < distanceToChasing && distanceToPlayer.magnitude > distanceToAttack)
        {
            StateMachine.ChangeState(ChaseState);
        }

        // Условие атаки
        if (distanceToPlayer.magnitude <= distanceToAttack)
        {
            StateMachine.ChangeState(AttackState);
        }

        // Условия патрулирования
        if (distanceToPlayer.magnitude > distanceToChasing)
        {
            // Выбираем случайную точку
            if (isFree)
            {
                randPoint = Random.Range(0, 7);

                isFree = false;                
            }

            // Запуск состояния патрулирования
            StateMachine.ChangeState(WalkState);

            if (isAgentDestination)
            {
                // Движение к точке
                agent.destination = trackingPoints[randPoint].transform.position;
            }

            // Отдых у точки
            if (distanceToPoint.magnitude <= agent.stoppingDistance)
            {
                isAgentDestination = false;

                StateMachine.ChangeState(IdleState);

                TimerToIdlePoint();
            }
            else 
            {
                isAgentDestination = true;
            }
        }
    }

    /// <summary>
    /// Таймер отдыха у точки
    /// </summary>
    private void TimerToIdlePoint()
    {
        if (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            isFree = true;
            currentTime = timeToIdle;
        }
    }
}
