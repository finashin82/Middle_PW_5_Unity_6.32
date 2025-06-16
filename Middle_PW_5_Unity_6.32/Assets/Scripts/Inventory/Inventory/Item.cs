using System;
using UnityEngine;

[Serializable]
public class Item
{
    public string itemName;
    public int itemID;
    public Sprite icon;

    public Item(string name, int id)
    {
        itemName = name;
        itemID = id;
    }
}