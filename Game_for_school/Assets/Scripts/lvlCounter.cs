using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class lvlCounter : MonoBehaviour
{
    public static lvlCounter Instance;
    private player_stats player_stats;

    public int currentLevel = 1;
    public int currentExp;
    private int i = 1;
    public int expToNextLevel = 20;
    public TextMeshProUGUI levelText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateLevelText();
        
    }

    void Update()
    {

        if (player_stats == null)
        {
            player_stats = GameObject.FindGameObjectWithTag("Player").GetComponent<player_stats>();
        }
        
        if(currentExp >= expToNextLevel*currentLevel)
        {
            gainLvl();
        }
    }

    public void gainLvl()
    {
        i++;
        currentExp = 0;
        currentLevel++;
        UpdateLevelText();
        if(currentLevel == i)
        {
            player_stats.maxHealth += player_stats.maxHealth/(currentLevel*2);
            player_stats.health = player_stats.maxHealth;
            player_stats.damage += player_stats.damage/3;
            player_stats.maxStamina += player_stats.maxStamina/3;
            player_stats.stamina = player_stats.maxStamina;
        }
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level: " + currentLevel;
    }
}