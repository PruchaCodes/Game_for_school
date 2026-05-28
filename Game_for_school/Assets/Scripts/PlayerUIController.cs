using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    private BattleManager battle_manager;
    private Animator player_animator;
    public EnemySpawn enemySpawn;
    public coinCounter coinCounter;
    public player_stats player_stats;
    void Update()
    {
        if (battle_manager == null)
        {
            battle_manager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
        }

        player_animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        if(enemySpawn == null)
        {
            enemySpawn = GameObject.FindGameObjectWithTag("EnemySpawn").GetComponent<EnemySpawn>();
        }
        if(coinCounter == null)
        {
            coinCounter = GameObject.FindGameObjectWithTag("CoinCounter").GetComponent<coinCounter>();
        }
        if(player_stats == null)
        {
            player_stats = GameObject.FindGameObjectWithTag("Player").GetComponent<player_stats>();
        }

        


        
    }

   
    public void AttackButton()
    {
        if (battle_manager != null)
        {
            battle_manager.PlayerAttack();
        }
    }

    public void RegenStaminaButton()
    {
        if(battle_manager != null)
        {
            battle_manager.RegenStamina();
        }
    }

    public void HealButton()
    {
        if (battle_manager != null && player_stats.health < player_stats.maxHealth && coinCounter.currentCoins >= 20)
        {
            battle_manager.HealPlayer();
            enemySpawn.LeaveVillage();
        }
        else
        {
            Debug.Log("Not enough coins to heal or already at full health.");
        }
        
    }

    public void MaxHealthButton()
    {
        if (battle_manager != null && player_stats.health <= player_stats.maxHealth && coinCounter.currentCoins >= 50)
        {
            player_stats.maxHealth += 10;
            coinCounter.currentCoins -= 50;
            coinCounter.UpdateCoinText();
            enemySpawn.LeaveVillage();
        }
        else
        {
            Debug.Log("Not enough coins to increase max health or already at full health.");
        }
    }

    public void MaxStaminaButton()
    {
        
        if (battle_manager != null && player_stats.stamina <= player_stats.maxStamina && coinCounter.currentCoins >= 30)
        {
            player_stats.maxStamina += 10;
            coinCounter.currentCoins -= 30;
            coinCounter.UpdateCoinText();
            enemySpawn.LeaveVillage();
        }
        else
        {
            Debug.Log("Not enough coins to increase max stamina or already at full stamina.");
        }
    }

    public void UpgradeDmgButton()
    {
        
        if (battle_manager != null && coinCounter.currentCoins >= 40)
        {
            player_stats.damage += 5;
            coinCounter.currentCoins -= 40;
            coinCounter.UpdateCoinText();
            enemySpawn.LeaveVillage();
        }
        else
        {
            Debug.Log("Not enough coins to increase damage.");
        }
    }
}