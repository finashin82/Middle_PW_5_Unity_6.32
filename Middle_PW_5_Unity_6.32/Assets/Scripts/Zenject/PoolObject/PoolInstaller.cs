using UnityEngine;
using Zenject;

public class PoolInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<EnemyPool>().FromComponentInHierarchy().AsSingle();
    }
}