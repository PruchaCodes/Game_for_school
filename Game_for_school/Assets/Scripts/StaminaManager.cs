using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    [SerializeField] private Image stamina_bar_full;
    [SerializeField] private player_stats player_stats;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStaminaBar();
        
    }

    private void UpdateStaminaBar()
    {
        stamina_bar_full.fillAmount = (float)player_stats.stamina / player_stats.maxStamina;
    }

    
}
