using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Header("PLAYER SETTINGS")]

    [SerializeField] private int _playerStrikeForce;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private int _playerHealth;

    [Header("ENEMY SETTINGS")]

    [SerializeField] private int _enemyStrikeForce;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private int _enemyHealth;

    public override void InstallBindings()
    {
        Container.BindInstance(new PlayerSettings(_playerStrikeForce, _playerSpeed, _playerHealth)).AsSingle().NonLazy();
        Container.BindInstance(new EnemySettings(_enemyStrikeForce, _enemySpeed, _enemyHealth)).AsSingle().NonLazy();
    }
}

public class PlayerSettings
{
    public int StrikeForce;
    public float Speed;
    public int Health;

    public PlayerSettings(int strikeForce, float speed, int health)
    {
        StrikeForce = strikeForce;
        Speed = speed;
        Health = health;
    }
}

public class EnemySettings
{
    public int StrikeForce;
    public float Speed;
    public int Health;

    public EnemySettings(int strikeForce, float speed, int health)
    {
        StrikeForce = strikeForce;
        Speed = speed;
        Health = health;
    }
}
