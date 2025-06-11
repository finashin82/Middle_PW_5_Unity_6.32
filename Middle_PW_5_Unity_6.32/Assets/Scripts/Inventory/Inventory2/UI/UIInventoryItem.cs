using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
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
    //public void OnBeginDrag()
    //{
    //    if (empty) return;

    //    OnItemBeginDrag?.Invoke(this);
    //}

    /// <summary>
    /// Перетаскивание
    /// </summary>
    //public void OnDrop()
    //{
    //}

    /// <summary>
    /// Конец перетаскивания
    /// </summary>
    //public void OnEndDrag() 
    //{
    //}

    /// <summary>
    /// Щелчок мышью (ЛКМ, ПКМ)
    /// </summary>
    /// <param name="data"></param>
    //public void OnPointerClick(BaseEventData data)
    //{
        
    //}

    public void OnPointerClick(PointerEventData pointerData)
    {
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

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (empty) return;

        OnItemBeginDrag?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}
