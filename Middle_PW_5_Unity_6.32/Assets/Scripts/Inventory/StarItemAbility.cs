using System.Collections.Generic;
using UnityEngine;

public class StarItemAbility : MonoBehaviour, IAbilityTarget
{
    //public List<PlayerHealth> Targets { get; set; }

    public void Execute(GameObject target)
    {
        if (target.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            playerHealth.AddHealth(10);

            Debug.Log("+");
        }

        Destroy(this.gameObject);
    }
}
