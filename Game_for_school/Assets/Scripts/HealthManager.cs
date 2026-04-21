using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image health_bar_full;
    [SerializeField] private player_stats player_stats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        health_bar_full.fillAmount = (float)player_stats.health / player_stats.maxHealth;
    }
}
