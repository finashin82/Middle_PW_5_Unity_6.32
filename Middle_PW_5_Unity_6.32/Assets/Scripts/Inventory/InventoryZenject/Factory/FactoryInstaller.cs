using UnityEngine;
using Zenject;

public class FactoryInstaller : MonoInstaller
{
    [SerializeField] private GameObject _starPrefab;

    [SerializeField] private GameObject _firstAidPrefab;

    public override void InstallBindings()
    {
        // Регистрация фабрики для звезды
        Container.BindFactory<ClickStar, ClickStar.Factory>().FromComponentInNewPrefab(_starPrefab).UnderTransformGroup("Stars");

        // Регистрация фабрики для Аптечки
        Container.BindFactory<ClickFirstAid, ClickFirstAid.Factory>().FromComponentInNewPrefab(_firstAidPrefab).UnderTransformGroup("Stars");
    }
}