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
        // Получаем направление камеры
        Vector3 cameraForward = freeLookCamera.transform.forward;
        Vector3 cameraRight = freeLookCamera.transform.right;

        // Игнорируем вертикальную составляющую (наклон камеры вверх/вниз)
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Вычисляем направление движения относительно камеры
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
            // Перемещение
            rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);

            // Направление по ходу движения
            transform.LookAt(transform.position + moveDirection);
            animator.SetBool("isWalk", true);

            // Переход на бег
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
