using UnityEngine;

public class enemy_stats : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public int damage = 10;
    public int stamina = 100;
    public int maxStamina = 100;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}