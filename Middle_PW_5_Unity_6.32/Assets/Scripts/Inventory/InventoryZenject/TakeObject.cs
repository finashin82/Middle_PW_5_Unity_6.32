using UnityEngine;
using Zenject;

public class TakeObject : MonoBehaviour
{
    //[SerializeField] private GameObject _prefabItem;

    [SerializeField] private PrefabType _itemType;

    private IItemFactory _itemFactory;

    //private IInventory _inventory;

    [Inject]
    public void Construct(IItemFactory itemFactory)
    {
        _itemFactory = itemFactory;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInventory>(out var inventory))
        {
            var item = _itemFactory.Create(_itemType);

            inventory.AddItem(item);

            Destroy(this.gameObject);
        }
    }
}
