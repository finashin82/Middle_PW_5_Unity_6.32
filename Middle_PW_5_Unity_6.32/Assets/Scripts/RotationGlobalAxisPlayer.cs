using Unity.Cinemachine;
using UnityEngine;

public class RotationGlobalAxisPlayer : MonoBehaviour
{
    [SerializeField] private Transform cinemachineCamera;

    private Transform transformPlayer;


    void Start()
    {
        transformPlayer = GetComponent<Transform>();
    }

    void Update()
    {
        
    }
}
