using Unity.Cinemachine;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MovementPlayer : InputData
{
    [SerializeField] private float speed;

    [SerializeField] private CinemachineCamera freeLookCamera;

    private Rigidbody rb;

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

        // Поворачиваем объект по направлению камеры, чтобы он постоянно смотрел вперед
        Vector3 dir = new Vector3(cameraForward.x, 0, cameraForward.z);
        transform.rotation = Quaternion.LookRotation(dir);

        // Вычисляем направление движения относительно камеры
        Vector3 moveDirection = (cameraForward * inputVector.y + cameraRight * inputVector.x).normalized;

        // Направление по ходу движения
        transform.LookAt(transform.position + moveDirection);

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
            // Перемещение персонажа в направлении камеры
            rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
            
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
