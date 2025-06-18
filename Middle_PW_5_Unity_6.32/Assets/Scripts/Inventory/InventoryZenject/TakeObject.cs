using UnityEngine;
using Zenject;

public class TakeObject : MonoBehaviour
{
    [SerializeField] GameObject prefabItem;
    //[SerializeField] private IItem _item;

    private IInventory _inventory;

    [Inject]
    public void Construct(IInventory inventory)
    {
        _inventory = inventory;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInventory>(out var inventory))
        {
            //_item.OnCollected();
            inventory.AddItem();

            Destroy(this.gameObject);
        }
    }
}
