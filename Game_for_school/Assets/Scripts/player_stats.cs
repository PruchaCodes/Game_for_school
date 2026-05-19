using UnityEngine;

public class player_stats : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float damage;
    public float stamina;
    public float maxStamina;
    public float mana;
    public float maxMana;

    void Start()
    {
        if(GameManager.Instance != null)
        {
            health = GameManager.Instance.currentHealth;
            maxHealth = GameManager.Instance.currentMaxHealth;
            damage = GameManager.Instance.currentDamage;
            stamina = GameManager.Instance.currentStamina;
            maxStamina = GameManager.Instance.currentMaxStamina;
            mana = GameManager.Instance.currentMana;
            maxMana = GameManager.Instance.currentMaxMana;
        }
    }


    void Update()
    {
        if (health < 0)
        {
            health = 0;
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (stamina < 0)
        {
            stamina = 0;
        }
        if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }

        if (mana < 0)
        {
            mana = 0;
        }
        if (mana > maxMana)
        {
            mana = maxMana;
        }

        if(GameManager.Instance != null)

        {
            GameManager.Instance.currentHealth = (int)health;
            GameManager.Instance.currentStamina = (int)stamina;
            GameManager.Instance.currentMana = (int)mana;
        }
    }
}