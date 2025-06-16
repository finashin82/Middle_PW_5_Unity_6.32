using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IInventory2
{
    public static Inventory instance;

    public List<Item> items = new List<Item>();
    public Dictionary<int, int> itemCounts = new Dictionary<int, int>();

    [SerializeField] private Transform itemsParent;
    [SerializeField] private GameObject inventoryUIPrefab;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Метод для добавления предмета
    public void AddItem(Item item)
    {
        if (itemCounts.ContainsKey(item.itemID))
        {
            itemCounts[item.itemID]++;
        }
        else
        {
            items.Add(item);
            itemCounts[item.itemID] = 1;
        }

        UpdateUI();
    }

    // Обновление UI
    private void UpdateUI()
    {
        foreach (Transform child in itemsParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in items)
        {
            GameObject go = Instantiate(inventoryUIPrefab, itemsParent);
            go.GetComponent<InventorySlot>().Setup(item, itemCounts[item.itemID]);
        }
    }

    // Метод для использования предмета
    public void UseItem(Item item)
    {
        if (itemCounts.ContainsKey(item.itemID))
        {
            itemCounts[item.itemID]--;

            if (itemCounts[item.itemID] <= 0)
            {
                items.Remove(item);
                itemCounts.Remove(item.itemID);
            }

            UpdateUI(); // Обновляем интерфейс
        }
    }
}