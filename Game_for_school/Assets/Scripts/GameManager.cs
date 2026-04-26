using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public CharacterData selectedCharacter;

    public int currentHealth;
    public int currentMaxHealth;
    public int currentDamage;
    public int currentStamina;
    public int currentMaxStamina;
    public int currentMana;
    public int currentMaxMana;
    public int currentLevel = 1;

    public int progressIndex = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}