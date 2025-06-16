using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item itemData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInventory2>(out IInventory2 inventory))
        {
            Inventory.instance.AddItem(itemData);
            Destroy(gameObject);
        }
    }
}