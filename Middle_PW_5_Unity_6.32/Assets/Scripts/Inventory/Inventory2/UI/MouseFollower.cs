using UnityEngine;
using UnityEngine.Rendering;

public class MouseFollower : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;

    [SerializeField] private UIInventoryItem _item;

    public void Awake()
    {
        _canvas = transform.root.GetComponent<Canvas>();

        _item = GetComponentInChildren<UIInventoryItem>();
    }

    public void SetData(Sprite sprite, int quantity)
    {
        _item.SetData(sprite, quantity);
    }

    private void Update()
    {
        Vector2 position;

        // Преобразуем координаты мыши в координаты точки на Canvas
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)_canvas.transform, Input.mousePosition, /*_canvas.worldCamera*/ null, out position);

        transform.position = _canvas.transform.TransformPoint(position);
    }

    public void Toggle(bool val)
    {
        Debug.Log($"Item toggled {val}");

        gameObject.SetActive(val);
    }
}
