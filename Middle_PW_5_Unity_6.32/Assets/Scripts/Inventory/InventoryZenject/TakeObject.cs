using UnityEngine;

public class TakeObject : MonoBehaviour
{
    [SerializeField] GameObject prefabItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInventory>(out var inventory))
        {
            inventory.AddItem(prefabItem);

            Destroy(this.gameObject);
        }
    }
}
