using UnityEngine;
using Zenject;

public class SignalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Устанавливаем сигнал
        SignalBusInstaller.Install(Container);

        // Регистрируем сигнал
        Container.DeclareSignal<DeathSignal>();

        // Регистрируем классы в которых будет использоваться сигнал
        Container.Bind<EnemyHealth>().AsSingle();
        Container.Bind<DeathEnemy>().AsSingle();
    }
}
