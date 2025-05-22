using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GiveScorePickUpAbility : MonoBehaviour, IAbilityTarget
{
    public List<GameObject> Targets { get; set; }

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

    //private void OnTriggerEnter(Collider other)
    //{
    //    foreach (var target in Targets)
    //    {
    //        var character = target.GetComponent<CharacterData>();

    //        if (character != null)
    //        {
    //            character.Score(3);
    //        }

    //        Destroy(this.gameObject);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        

        //var character = collision.gameObject.GetComponent<CharacterData>();

        //if (character != null)
        //{
        //    character.Score(3);
        //}

        //Destroy(this.gameObject);
    }
}
