using UnityEngine;

public class MovementPlayer : InputData
{
    [SerializeField] private float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 moveVector = new Vector3(-inputVector.x, 0, -inputVector.y);
        
        if (inputVector != null)
        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);
    }
}
