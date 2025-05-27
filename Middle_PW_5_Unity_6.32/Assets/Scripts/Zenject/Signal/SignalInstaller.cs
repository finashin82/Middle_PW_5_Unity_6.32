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
        Container.DeclareSignal<DeathPlayerSignal>();
        Container.DeclareSignal<ScoreSignal>();
        Container.DeclareSignal<SignalPlayerHealth>();

        // Регистрируем классы в которых будет использоваться сигнал
        Container.Bind<EnemyHealth>().AsSingle();
        Container.Bind<DeathEnemy>().AsSingle();
        Container.Bind<PlayerHealth>().AsSingle();
        Container.Bind<DeathPlayer>().AsSingle();
        Container.Bind<CharacterData>().AsSingle();
        Container.Bind<ClickImage>().AsSingle();
    }
}
