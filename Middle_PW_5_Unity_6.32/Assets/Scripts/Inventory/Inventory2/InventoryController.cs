using Inventory.UI;
using System;
using UnityEngine;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private UIInventoryPage _inventoryUI;

        [SerializeField] private InventorySO _inventoryData;

        private void Start()
        {
            PrepareUI();

            //_inventoryData.Initialize();
        }

        /// <summary>
        /// Подготовка инвентаря
        /// </summary>
        private void PrepareUI()
        {
            _inventoryUI.InitializeInventoryUI(_inventoryData.Size);

            _inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
            _inventoryUI.OnSwapItems += HandleSwapItems;
            _inventoryUI.OnStartDragging += HandleDrapping;
            _inventoryUI.OnItemActionRequested += HandleItemActionRequest;
        }

        private void HandleItemActionRequest(int itemIndex)
        {

        }

        private void HandleDrapping(int itemIndex)
        {

        }

        private void HandleSwapItems(int itemIndex_1, int itemIndex_2)
        {

        }

        private void HandleDescriptionRequest(int itemIndex)
        {
            InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);

            if (inventoryItem.IsEmpty)
            {
                _inventoryUI.ResetSelection();

                return;
            }

            ItemSO item = inventoryItem.item;

            _inventoryUI.UpdateDescription(itemIndex, item.ItemImage, item.name, item.Description);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (_inventoryUI.isActiveAndEnabled == false)
                {
                    _inventoryUI.Show();

                    foreach (var item in _inventoryData.GetCurrentInventoryState())
                    {
                        _inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
                    }
                }
                else
                {
                    _inventoryUI.Hide();
                }
            }
        }
    }
}