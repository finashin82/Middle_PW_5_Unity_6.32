using UnityEngine;
using Zenject;

public class SignalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // ������������� ������
        SignalBusInstaller.Install(Container);

        // ������������ ������
        Container.DeclareSignal<DeathSignal>();

        // ������������ ������ � ������� ����� �������������� ������
        Container.Bind<EnemyHealth>().AsSingle();
        Container.Bind<DeathEnemy>().AsSingle();
    }
}
