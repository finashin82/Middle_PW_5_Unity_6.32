using UnityEngine;
using Zenject;

//public class SignalInstaller : MonoInstaller
//{
//    public override void InstallBindings()
//    {
//        Container.Bind<BoolSignal>().AsSingle();
//    }

//}





//public class UserJoinedSignal
//{
//    public string Username;
//}

//public class GameInitializer : IInitializable
//{
//    readonly SignalBus _signalBus;

//    public GameInitializer(SignalBus signalBus)
//    {
//        _signalBus = signalBus;
//    }

//    public void Initialize()
//    {
//        _signalBus.Fire(new UserJoinedSignal() { Username = "Bob" });
//    }
//}

//public class Greeter
//{
//    public void SayHello(UserJoinedSignal userJoinedInfo)
//    {
//        Debug.Log("Hello " + userJoinedInfo.Username + "!");
//    }
//}

//public class SignalInstaller : MonoInstaller<SignalInstaller>
//{
//    public override void InstallBindings()
//    {
//        SignalBusInstaller.Install(Container);

//        Container.DeclareSignal<UserJoinedSignal>();

//        Container.Bind<Greeter>().AsSingle();

//        Container.BindSignal<UserJoinedSignal>()
//            .ToMethod<Greeter>(x => x.SayHello).FromResolve();

//        Container.BindInterfacesTo<GameInitializer>().AsSingle();
//    }
//}