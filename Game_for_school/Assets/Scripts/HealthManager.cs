using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image health_bar_full;

    [SerializeField] private Image enemy_health_bar_full;

    private player_stats player_stats;

    private enemy_stats enemy_stats;

    void Update()
    {
        FindPlayer();

        FindEnemy();

        UpdatePlayerBar();

        UpdateEnemyBar();
    }

    void FindPlayer()
    {
        if(player_stats == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if(player != null)
            {
                player_stats = player.GetComponent<player_stats>();
            }
        }
    }

    void FindEnemy()
    {
        if(enemy_stats == null)
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

            if(enemy != null)
            {
                enemy_stats = enemy.GetComponent<enemy_stats>();
            }
        }
    }

    void UpdatePlayerBar()
    {
        if(player_stats == null)
            return;

        health_bar_full.fillAmount =
            (float)player_stats.health / player_stats.maxHealth;
    }

    void UpdateEnemyBar()
    {
        if(enemy_stats == null)
            return;

        enemy_health_bar_full.fillAmount =
            (float)enemy_stats.health / enemy_stats.maxHealth;
    }
}