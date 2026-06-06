using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    [SerializeField] private Image mana_bar_full;
    public Image mana_bar_empty;

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

        mana_bar_full.fillAmount = (float)player_stats.mana / player_stats.maxMana;
            
    }
}