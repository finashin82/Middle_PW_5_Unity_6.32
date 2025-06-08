using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    [SerializeField] private Image _itemImage;

    [SerializeField] private TMP_Text _quantityText;

    [SerializeField] private Image _borderImage;

    public event Action<UIInventoryItem> OnItemClicked, OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag, OnRightMouseBtnClick;

    private bool empty = true;

    private void Awake()
    {
        ResetData();
        Deselect();
    }

    /// <summary>
    /// Сброс данных
    /// </summary>
    public void ResetData()
    {
        this._itemImage.gameObject.SetActive(false);

        empty = true;
    }

    /// <summary>
    /// Отмена выбора
    /// </summary>
    public void Deselect() 
    {
        _borderImage.enabled = false;
    }

    /// <summary>
    /// Данные для отображения
    /// </summary>
    /// <param name="sprite"></param>
    /// <param name="quantity"></param>
    public void SetData(Sprite sprite, int quantity)
    {
        this._itemImage.gameObject.SetActive(true);

        this._itemImage.sprite = sprite;

        this._quantityText.text = quantity + "";

        empty = false;
    }

    /// <summary>
    /// Выбор ячейки
    /// </summary>
    public void Select()
    {
        _borderImage.enabled = true;
    }

    /// <summary>
    /// Начало перетаскивания
    /// </summary>
    public void OnBeginDrag()
    {
        if (empty) return;

        OnItemBeginDrag?.Invoke(this);
    }

    /// <summary>
    /// Перетаскивание
    /// </summary>
    public void OnDrop()
    {
        OnItemDroppedOn?.Invoke(this);
    }

    /// <summary>
    /// Конец перетаскивания
    /// </summary>
    public void OnEndDrag() 
    {
        OnItemEndDrag?.Invoke(this);
    }

    /// <summary>
    /// Щелчок мышью (ЛКМ, ПКМ)
    /// </summary>
    /// <param name="data"></param>
    public void OnPointerClick(BaseEventData data)
    {
        if (empty) return;

        // Щелчок мышью
        PointerEventData pointerData = (PointerEventData)data;

        // Проверка кнопки мыши (ЛКМ или ПКМ)
        if (pointerData.button == PointerEventData.InputButton.Right)
        {
            OnRightMouseBtnClick?.Invoke(this);
        }
        else
        {
            OnItemClicked?.Invoke(this);
        }
    }
}
