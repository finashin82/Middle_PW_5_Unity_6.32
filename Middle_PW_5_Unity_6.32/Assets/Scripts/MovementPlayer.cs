using UnityEngine;

public class MovementPlayer : InputData
{
    [SerializeField] private float speed;

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
        Vector3 moveVector = new Vector3(-inputVector.x, 0, -inputVector.y);

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
