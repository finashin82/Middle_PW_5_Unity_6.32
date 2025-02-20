using Unity.Cinemachine;
using UnityEngine;

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

        Vector3 moveVector = new Vector3(-inputVector.x, 0, -inputVector.y);

        //Vector3 moveDirection = (cameraForward * inputVector.x + cameraRight * inputVector.x).normalized;

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
            rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);

            // Направление по ходу движения
            direction = new Vector3(-inputVector.x, 0, -inputVector.y);

            transform.LookAt(transform.position + direction);

            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
    }
}
