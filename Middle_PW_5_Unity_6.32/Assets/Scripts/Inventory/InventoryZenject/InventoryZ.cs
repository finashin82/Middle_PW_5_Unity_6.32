using UnityEngine;
using Zenject;

public class InventoryZ : MonoBehaviour, IInventory
{
    [SerializeField] private Transform _inventoryPanel;

    public void AddItem(GameObject gameObject)
    {
        gameObject.transform.SetParent(_inventoryPanel, false);
    }
}
