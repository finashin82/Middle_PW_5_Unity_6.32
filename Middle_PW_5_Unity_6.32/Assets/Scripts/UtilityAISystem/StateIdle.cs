using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class StateIdle : State
{
    [SerializeField] private AnimationCurve _curve;

    private GameObject _player;

    [SerializeField] private float _radius;

    [SerializeField] private float timeToIdle = 1f;

    private GameObject[] trackingPoints;

    private Vector3 distanceToPoint;

    private float currentTime;

    private NavMeshAgent agent;

    private int randPoint;

    private bool isFree;
    private bool isAgentDestination;

    private Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();

        trackingPoints = GameObject.FindGameObjectsWithTag("TrackingPoint");

        _player = GameObject.FindGameObjectWithTag("Player");

        currentTime = timeToIdle;

        isFree = true;
        isAgentDestination = true;
    }

    public override void Exit()
    {
        agent.isStopped = true;

        animator.SetBool("isWalk", false);
    }

    public override void Execute()
    {
        Debug.Log("��������������");

        animator.SetBool("isWalk", true);

        // �������� ��������� �����
        if (isFree)
        {
            randPoint = Random.Range(0, trackingPoints.Length);

            isFree = false;
        }

        // ��������� �� ����� ������
        distanceToPoint = transform.position - trackingPoints[randPoint].transform.position;

        // ����������� �������� �� ���� ���������� ������ 
        if (isAgentDestination)
        {
            Vector3 directionXZ = new Vector3(agent.velocity.normalized.x, 0, agent.velocity.normalized.z);
            Vector3 newPosition = transform.position + directionXZ.normalized;
            transform.LookAt(newPosition);
        }

        // ����� � �����
        if (distanceToPoint.magnitude <= agent.stoppingDistance)
        {
            isAgentDestination = false;

            agent.isStopped = true;

            animator.SetBool("isWalk", false);

            isFree = false;

            TimerToIdlePoint();
        }
        else
        {
            agent.isStopped = false;

            agent.destination = trackingPoints[randPoint].transform.position;

            isAgentDestination = true;

            animator.SetBool("isWalk", true);
        }
    }

    /// <summary>
    /// ����������� ��������� ��� ����� ��������� � ������� ������ (� ������ ������, � ������ ��������� ������ ������, �� ��������� � ����������)
    /// </summary>
    /// <returns></returns>
    public override float Evaluate()
    {
        var distFloat = Vector3.Distance(this.transform.position, _player.transform.position);

        var clamp = Mathf.Clamp(distFloat, 0, _radius);

        var dist = _curve.Evaluate((_radius - clamp) / _radius);

        return dist;
    }

    /// <summary>
    /// ������ ������ � �����
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
