using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private int _playerStrikeForce;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private int _playerHealth;

    public override void InstallBindings()
    {
        Container.BindInstance(new PlayerSettings(_playerHealth, _playerSpeed, _playerStrikeForce)).AsSingle().NonLazy();
    }
}

public class PlayerSettings
{
    public int StrikeForce;

    public float Speed;

    public int Health;

    public PlayerSettings(int health, float speed, int strikeForce)
    {
        Health = health;
        StrikeForce = strikeForce;
        Speed = speed;
    }
}
