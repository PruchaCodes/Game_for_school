using UnityEngine;

public class player_stats : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;

    public int maxStamina = 100;
    public int stamina;

    public int damage = 20;

    void Start()
    {
        health = maxHealth;
        stamina = maxStamina;
    }
}