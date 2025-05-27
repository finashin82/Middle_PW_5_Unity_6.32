using UnityEngine;
using Zenject;

public class InventoryZ : MonoBehaviour, IInventory
{
    // DiConteiner нужен для создания префаба через Zenject (иначе Signal в префабе не работает)
    [Inject] private DiContainer container;

    [SerializeField] private GameObject inventoryPanel;

    public void AddItem(GameObject gameObject)
    {
        // Создаем префаб через Zenject (иначе Signal в префабе не работает)
        var item = container.InstantiatePrefab(gameObject);

        item.transform.SetParent(inventoryPanel.transform);
    }
}
