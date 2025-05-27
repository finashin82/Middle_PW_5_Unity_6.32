using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GiveItemPickUpAbility : MonoBehaviour
{
    public GameObject _UIItem;

    public GameObject UIItem => _UIItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CharacterData>(out var characterData)) 
        {
            

            var item = Instantiate(UIItem);

            item.transform.SetParent(characterData.InventoryUIRoot.transform);
        }

        Destroy(this.gameObject);
    }
}
