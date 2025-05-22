using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GiveItemPickUpAbility : MonoBehaviour, IAbilityTarget, IItem
{
    public GameObject _UIItem;

    public GameObject UIItem => _UIItem;

    public List<GameObject> Targets { get; set; } = new List<GameObject>();

    public void Execute()
    {
        foreach (var target in Targets) 
        {
            var character = target.GetComponent<CharacterData>();

            if (character != null) 
            {
                character.Score(3);
            }

            Destroy(this.gameObject);
        }
    }

    //public void UseItem(CharacterData data)
    //{

    //}

    private void OnTriggerEnter(Collider other)
    {
        var character = other.gameObject.GetComponent<CharacterData>();

        if (character == null) return;

        var item = Instantiate(UIItem);

        //character.Targets.Add(item);

        item.transform.SetParent(character.InventoryUIRoot.transform);

        //character.Targets.Add(character.gameObject);

        Debug.Log($"TargetAdd: {item}");

        Destroy(this.gameObject);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    var character = collision.gameObject.GetComponent<CharacterData>();

    //    if (character == null) return;

    //    var item = Instantiate(UIItem);

    //    item.transform.SetParent(character.InventoryUIRoot.transform);

    //    Targets.Add(item);

    //    Debug.Log($"TargetAdd: {item}");

    //    Destroy(this.gameObject);
    //}
}
