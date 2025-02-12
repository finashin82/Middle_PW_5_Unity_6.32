using UnityEngine;
using Zenject;
using static Zenject.SpaceFighter.GameSettingsInstaller;

public class PlayerAttack : MonoBehaviour
{
    [Inject] private PlayerSettings _playerSettings;

    void Start()
    {
        Debug.Log($"Player Strike Force: {_playerSettings.StrikeForce}");
        Debug.Log($"Player Speed: {_playerSettings.Speed}");
    }

    void Update()
    {
        
    }
}
