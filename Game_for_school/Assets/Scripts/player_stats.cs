using UnityEngine;

public class player_stats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public int health = 100;
    public int maxHealth = 100;
    public int damage = 10;
    public int stamina = 100;
    public int maxStamina = 100;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            health = 0;
        }else if(health > maxHealth)
        {
            health = maxHealth;
        }
        if(stamina <= 0)
        {
            stamina = 0;
        }else if(stamina > maxStamina)
        {
            stamina = maxStamina;
        }
    }
}
