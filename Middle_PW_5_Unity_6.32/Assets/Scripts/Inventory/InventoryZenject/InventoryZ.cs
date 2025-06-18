using UnityEngine;
using Zenject;

public class InventoryZ : MonoBehaviour, IInventory
{
    // DiConteiner нужен для создания префаба через Zenject (иначе Signal в префабе не работает)
    //[Inject] private DiContainer container;

    private ClickStar.Factory _clickStarFactory;

    private ClickFirstAid.Factory _clickFirstAidFactory;
    //----------------------

    [Inject]
    public void Construct(ClickStar.Factory clickStarFactory, ClickFirstAid.Factory clickFirstAidFactory)
    {
        _clickStarFactory = clickStarFactory;

        _clickFirstAidFactory = clickFirstAidFactory;
    }
    //---------------------

    [SerializeField] private Transform _inventoryPanel;

    public void AddItem()
    {
        // Создаем префаб через Zenject (иначе Signal в префабе не работает)
        //var item = container.InstantiatePrefab(gameObject);

        var item = _clickStarFactory.Create().gameObject;

        item.transform.SetParent(_inventoryPanel);

        //GameObject go = null;

        //switch (item)
        //{
        //    case ClickStar:
        //        go = _clickStarFactory.Create().gameObject;
        //        break;

        //    case ClickFirstAid:
        //        go = _clickFirstAidFactory.Create().gameObject;
        //        break;

        //    default:
        //        Debug.LogWarning($"Неизвестный тип предмета: {item.GetType()}");
        //        return;
        //}

        //go.transform.SetParent(_inventoryPanel, false);
    }
}
