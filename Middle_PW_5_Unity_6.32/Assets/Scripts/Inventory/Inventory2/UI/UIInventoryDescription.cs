using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryDescription : MonoBehaviour
{
    [SerializeField] private Image _itemImage;

    [SerializeField] private TMP_Text _title;

    [SerializeField] private TMP_Text _description;

    public void Awake()
    {
        ResetDescription();
    }

    /// <summary>
    /// Сброс описания
    /// </summary>
    public void ResetDescription()
    {
        this._itemImage.gameObject.SetActive(false);

        this._title.text = "";

        this._description.text = "";
    }

    /// <summary>
    /// Заполнение описания
    /// </summary>
    /// <param name="sprite"></param>
    /// <param name="itemName"></param>
    /// <param name="itenDescription"></param>
    public void SetDescription(Sprite sprite, string itemName, string itenDescription)
    {
        this._itemImage.gameObject.SetActive(true);

        this._itemImage.sprite = sprite;

        this._title.text = itemName;

        this._description.text = itenDescription;
    }
}
