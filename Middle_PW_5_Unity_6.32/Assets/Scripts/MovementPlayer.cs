using Unity.Cinemachine;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MovementPlayer : InputData
{
    [SerializeField] private float speed;

    [SerializeField] private CinemachineCamera freeLookCamera;

    private Rigidbody rb;

    private Vector3 direction; 

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // �������� ����������� ������
        Vector3 cameraForward = freeLookCamera.transform.forward;
        Vector3 cameraRight = freeLookCamera.transform.right;

        // ���������� ������������ ������������ (������ ������ �����/����)
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // ��������� ����������� �������� ������������ ������
        Vector3 moveDirection = (cameraForward * inputVector.y + cameraRight * inputVector.x).normalized;

        if (isAttackBegin)
        {
            animator.SetBool("isAttack", true);
        }
        else
        {
            animator.SetBool("isAttack", false);
        }

        if (inputVector != Vector2.zero)
        {
            // �����������
            rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);

            // ����������� �� ���� ��������
            transform.LookAt(transform.position + moveDirection);
            animator.SetBool("isWalk", true);

            // ������� �� ���
            if (isSprint)
            {
                animator.SetBool("isRun", true);
            }
            else
            {
                animator.SetBool("isRun", false);
            }
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
    }
}
