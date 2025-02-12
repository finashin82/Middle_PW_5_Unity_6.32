using UnityEngine;
using Zenject;

public class PlayerHealth : MonoBehaviour
{
    [Inject] private PlayerSettings _playerSettings;

    void Start()
    {
        Debug.Log($"Player Health: {_playerSettings.Health}");
    }

    void Update()
    {
        
    }
}
