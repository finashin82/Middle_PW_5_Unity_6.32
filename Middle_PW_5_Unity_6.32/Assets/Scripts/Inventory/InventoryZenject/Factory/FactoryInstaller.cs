using UnityEditor;
using UnityEngine;
using Zenject;

public class FactoryInstaller : MonoInstaller
{
    [SerializeField] private GameObject _starPrefab;

    [SerializeField] private GameObject _firstAidPrefab;

    public override void InstallBindings()
    {
        Container.Bind<GameObject>().WithId("Star").FromInstance(_starPrefab);

        Container.Bind<GameObject>().WithId("FirstAid").FromInstance(_firstAidPrefab);

        Container.Bind<IItemFactory>().To<ItemFactory>().AsSingle();
    }
}