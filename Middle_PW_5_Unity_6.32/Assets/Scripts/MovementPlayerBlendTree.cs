using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class MovementPlayerBlendTree : InputData
{
    [SerializeField] private float speed;

    [SerializeField] private CinemachineCamera freeLookCamera;

    private Rigidbody rb;

    private Animator animator;

    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        RotationBehindCamera();

        AnimationAttack();

        AnimationSprint();

        animator.SetFloat("x", inputVector.x);

        animator.SetFloat("y", inputVector.y);
    }

    private void FixedUpdate()
    {
        // Перемещение персонажа в направлении камеры
        //rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
        rb.position = (rb.position + moveDirection * speed * Time.deltaTime);
    }

    /// <summary>
    /// Вращение персонажа в направлении камеры
    /// </summary>
    private void RotationBehindCamera()
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
        moveDirection = (cameraForward * inputVector.y + cameraRight * inputVector.x).normalized;
    }

    /// <summary>
    /// Анимация атаки
    /// </summary>
    private void AnimationAttack()
    {
        if (isAttackBegin)
        {
            animator.SetBool("isAttack", true);
        }
        else
        {
            animator.SetBool("isAttack", false);
        }
    }

    /// <summary>
    /// Анимация ускорения
    /// </summary>
    private void AnimationSprint()
    {
        if (isSprint && inputVector != Vector2.zero)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }
}
