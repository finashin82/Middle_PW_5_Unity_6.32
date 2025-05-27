using UnityEngine;

public class LevelUpHealth : MonoBehaviour, ILevelUp
{
    private PlayerHealth health;

    public void LevelUp(CharacterData data, int level)
    {
        if (health == null) 
        {
            health = GetComponent<PlayerHealth>();

            if (health == null) return;
        }

        //health.CurrentHealth += 10;

        //health.AddHealth(10);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
