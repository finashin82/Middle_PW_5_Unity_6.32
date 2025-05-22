using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryPanel;

    [SerializeField] private Transform _slotsPanel;

    [SerializeField] private List<InventorySlot> _slots = new List<InventorySlot>();

    private bool isOpened = false;

    private SphereCollider sphereCollider;

    [SerializeField] private float _rayDistance = 10f;

    private void Awake()
    {
        _inventoryPanel.SetActive(true);
    }

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();

        for (int i = 0; i < _slotsPanel.childCount; i++) 
        {
            if (_slotsPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                _slots.Add(_slotsPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }

        _inventoryPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            isOpened = !isOpened;

            
        }

        if (isOpened)
        {
            _inventoryPanel.SetActive(true);
        }
        else
        {
            _inventoryPanel.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Item>() != null)
        {
            AddItem(other.gameObject.GetComponent<Item>().itemSO, other.gameObject.GetComponent<Item>().amount);

            Destroy(other.gameObject);
        }
    }

    private void AddItem(ItemSO item, int amount)
    {
        foreach (InventorySlot slot in _slots)
        {
            if (slot._item == item)
            {
                slot._amount += amount;

                slot.itemAmountText.text = slot._amount.ToString();

                return;
            }
        }

        foreach (InventorySlot slot in _slots)
        {
            if (slot._isEmpty == true)
            {
                slot._item = item;

                slot._amount = amount;

                slot.SetIcon(item.icon);

                slot.itemAmountText.text = amount.ToString();

                slot._isEmpty = false;

                return;
            }
        }

    }
}
