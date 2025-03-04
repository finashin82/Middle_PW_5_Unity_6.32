using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "EnemySettingsInstaller", menuName = "Installers/EnemySettingsInstaller")]
public class EnemySettingsInstaller : ScriptableObjectInstaller<EnemySettingsInstaller>
{
    [SerializeField] private int _enemyStrikeForce;
    [SerializeField] private float _enemySpeed;
    [SerializeField] private int _enemyHealth;
    public override void InstallBindings()
    {
        Container.BindInstance(new EnemySettings(_enemyStrikeForce, _enemySpeed, _enemyHealth)).AsSingle().NonLazy();
    }
}

public class EnemySettings2
{
    public int StrikeForce;

    public float Speed;

    public int Health;

    public EnemySettings2(int strikeForce, float speed, int health)
    {
        StrikeForce = strikeForce;
        Speed = speed;
        Health = health;
    }
}