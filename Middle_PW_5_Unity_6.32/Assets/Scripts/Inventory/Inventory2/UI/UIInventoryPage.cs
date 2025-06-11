using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class UIInventoryPage : MonoBehaviour
    {
        [SerializeField] private UIInventoryItem _itemPrefab;

        [SerializeField] private RectTransform _contentPanel;

        [SerializeField] private UIInventoryDescription _itemDescription;

        [SerializeField] private MouseFollower _mouseFollower;

        List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

        private int currentlyDraggedItemIndex = -1;

        public event Action<int> OnDescriptionRequested, OnItemActionRequested, OnStartDragging;

        public event Action<int, int> OnSwapItems;

        private void Awake()
        {
            Hide();

            _mouseFollower.Toggle(false);

            _itemDescription.ResetDescription();
        }

        public void InitializeInventoryUI(int inventorySize)
        {
            for (int i = 0; i < inventorySize; i++)
            {
                UIInventoryItem uiItem = Instantiate(_itemPrefab, Vector3.zero, Quaternion.identity);

                uiItem.transform.SetParent(_contentPanel);

                listOfUIItems.Add(uiItem);

                uiItem.OnItemClicked += HandleItemSelection;
                uiItem.OnItemBeginDrag += HandleBeginDrag;
                uiItem.OnItemDroppedOn += HandleSwap;
                uiItem.OnItemEndDrag += HandleEndDrag;
                uiItem.OnRightMouseBtnClick += HandleShowItemActions;
            }
        }

        public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity)
        {
            if (listOfUIItems.Count > itemIndex)
            {
                listOfUIItems[itemIndex].SetData(itemImage, itemQuantity);
            }
        }

        private void HandleShowItemActions(UIInventoryItem inventoryItemUI)
        {

        }

        private void HandleEndDrag(UIInventoryItem inventoryItemUI)
        {
            ResetDraggtedItem();
        }

        private void HandleSwap(UIInventoryItem inventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(inventoryItemUI);

            if (index == -1)
            {
                return;
            }

            OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
        }

        private void ResetDraggtedItem()
        {
            _mouseFollower.Toggle(false);

            currentlyDraggedItemIndex = -1;
        }

        private void HandleBeginDrag(UIInventoryItem inventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(inventoryItemUI);

            if (index == -1) return;

            currentlyDraggedItemIndex = index;

            HandleItemSelection(inventoryItemUI);

            OnStartDragging?.Invoke(index);
        }

        public void CreateDraggedItem(Sprite sprite, int quantity)
        {
            _mouseFollower.Toggle(true);

            _mouseFollower.SetData(sprite, quantity);
        }

        /// <summary>
        /// Выбор элементов инвентаря
        /// </summary>
        /// <param name="inventoryItemUI"></param>
        private void HandleItemSelection(UIInventoryItem inventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(inventoryItemUI);

            if (index == -1) return;

            OnDescriptionRequested?.Invoke(index);
        }

        /// <summary>
        /// Показать окно инвентаря
        /// </summary>
        public void Show()
        {
            gameObject.SetActive(true);

            ResetSelection();
        }

        /// <summary>
        /// Сброс выбранного элемента
        /// </summary>
        public void ResetSelection()
        {
            _itemDescription.ResetDescription();

            DeselectAllItems();
        }

        /// <summary>
        /// Отмена выбора всех элементов
        /// </summary>
        private void DeselectAllItems()
        {
            foreach (UIInventoryItem item in listOfUIItems)
            {
                item.Deselect();
            }
        }

        /// <summary>
        /// Скрытие окна инвентаря
        /// </summary>
        public void Hide()
        {
            gameObject.SetActive(false);

            ResetDraggtedItem();
        }

        internal void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description)
        {
            _itemDescription.SetDescription(itemImage, name, description);

            DeselectAllItems();

            listOfUIItems[itemIndex].Select();
        }
    }
}