using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image health_bar_full;
    [SerializeField] private player_stats player_stats;
    [SerializeField] private Enemy_script_goblin enemy_script_goblin;
    [SerializeField] private Image enemy_health_bar_full;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
        UpdateEnemyHealthBar();
    }

    private void UpdateHealthBar()
    {
        health_bar_full.fillAmount = (float)player_stats.health / player_stats.maxHealth;
    }

    private void UpdateEnemyHealthBar()
    {
        enemy_health_bar_full.fillAmount = (float)enemy_script_goblin.health / enemy_script_goblin.maxHealth;
    }
}
