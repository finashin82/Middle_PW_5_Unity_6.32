using UnityEngine;

public interface IItemFactory
{
    GameObject Create(PrefabType type);
}
