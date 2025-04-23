using UnityEngine;
using UnityEngine.UIElements;

public class LookAtCamera : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        Vector3 direction = cameraTransform.position - transform.position;

        // Убираем наклон на камеру
        direction.y = 0; 

        transform.rotation = Quaternion.LookRotation(direction);
    }
}
