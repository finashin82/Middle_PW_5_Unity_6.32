using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField] private UIInventoryItem _itemPrefab;

    [SerializeField] private RectTransform _contentPanel;

    [SerializeField] private UIInventoryDescription _itemDescription;

    [SerializeField] private MouseFollower _mouseFollower;

    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

    public Sprite image;
    public int quantity;
    public string title, description;

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

    private void HandleShowItemActions(UIInventoryItem obj)
    {

    }

    private void HandleEndDrag(UIInventoryItem obj)
    {
        _mouseFollower.Toggle(false);
    }

    private void HandleSwap(UIInventoryItem obj)
    {

    }

    private void HandleBeginDrag(UIInventoryItem obj)
    {
        _mouseFollower.Toggle(true);

        _mouseFollower.SetData(image, quantity);
    }

    private void HandleItemSelection(UIInventoryItem obj)
    {
        _itemDescription.SetDescription(image, title, description);

        listOfUIItems[0].Select();
    }

    public void Show()
    {
        gameObject.SetActive(true);

        _itemDescription.ResetDescription();

        listOfUIItems[0].SetData(image, quantity);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
