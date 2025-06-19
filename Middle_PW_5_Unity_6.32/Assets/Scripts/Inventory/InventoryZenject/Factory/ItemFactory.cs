using UnityEngine;
using Zenject;

public class ItemFactory : IItemFactory
{
    private readonly DiContainer _container;
    private readonly GameObject _starPrefab;
    private readonly GameObject _firstAidPrefab;

    public ItemFactory(
        DiContainer container,
        [Inject(Id = "Star")] GameObject starPrefab,
        [Inject(Id = "FirstAid")] GameObject firstAidPrefab)
    {
        _container = container;
        _starPrefab = starPrefab;
        _firstAidPrefab = firstAidPrefab;
    }

    public GameObject Create(PrefabType type)
    {
        switch (type)
        {
            case PrefabType.Star:
                return _container.InstantiatePrefab(_starPrefab);
            case PrefabType.FirstAid:
                return _container.InstantiatePrefab(_firstAidPrefab);
            default:
                throw new System.ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}
