using System.Collections.Generic;
using UnityEngine;

public class StarItemAbility : MonoBehaviour
{
    public List<PlayerHealth> Targets { get; set; } = new List<PlayerHealth>();

    private void Start()
    {
        //Targets = FindObjectsByType<PlayerHealth>();
    }

    public void Execute()
    {
        foreach (var target in Targets)
        {
            var character = target.GetComponent<PlayerHealth>();

            if (character == null) return;

            character.AddHealth(5);

            Debug.Log("+");
        }

        Destroy(this.gameObject);
    }
}
