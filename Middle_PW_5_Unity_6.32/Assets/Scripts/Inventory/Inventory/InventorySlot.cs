using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Text itemNameText;
    public Text itemCountText;
    public Image itemIcon;

    private Item item;
    private int count;

    // Событие на клик
    public void Setup(Item item, int count)
    {
        this.item = item;
        this.count = count;

        itemNameText.text = item.itemName;
        itemCountText.text = count.ToString();
        itemIcon.sprite = item.icon;

        // Добавляем обработчик клика
        Button button = itemIcon.GetComponent<Button>();
        if (button == null)
        {
            button = itemIcon.gameObject.AddComponent<Button>();
        }

        button.onClick.AddListener(OnUseItem);
    }

    private void OnUseItem()
    {
        // Проверяем, что предмет существует и есть хотя бы один
        if (count > 0)
        {
            // Используем предмет (например, лечение)
            Debug.Log("Used item: " + item.itemName);

            // Пример: лечим игрока на 20 HP
            //PlayerHealth.instance.AddHeal(20);

            // Уменьшаем количество
            Inventory.instance.UseItem(item);
        }
    }
}