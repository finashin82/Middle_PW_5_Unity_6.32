using UnityEngine;
using Zenject;

public class PlayerHealth : MonoBehaviour
{
    [Inject] private MaxHealthPlayer _maxHealthPlayer;

    void Start()
    {
        Debug.Log($"Max Health Player {_maxHealthPlayer.Health}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
