using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    [SerializeField] private Image stamina_bar_full;

    private player_stats player_stats;

    void Update()
    {
        if(player_stats == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if(player != null)
            {
                player_stats = player.GetComponent<player_stats>();
            }
        }

        if(player_stats == null)
            return;

        stamina_bar_full.fillAmount = (float)player_stats.stamina / player_stats.maxStamina;
            
    }
}