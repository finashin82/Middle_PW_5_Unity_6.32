using UnityEngine;

public enum ItemType { Default, Food, Weapon, Tool}

public class ItemSO : ScriptableObject
{
    public ItemType itemType;

    public string itemName;
    public int maxAmiuntItem;
    public string itemDescription;

    public Sprite icon;

    public GameObject itemPrefab;
}
