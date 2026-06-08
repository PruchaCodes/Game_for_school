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
    public TMPro.TextMeshProUGUI comentatoryText;
    public TMPro.TextMeshProUGUI comentatoryTextShop;
    public GameObject player;
    public SoundManager soundManager;
    void Update()
    {
        if(soundManager == null)
        {
            soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        }

        if (battle_manager == null)
        {
            battle_manager = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<BattleManager>();
        }

       if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        player_animator = player.GetComponent<Animator>();
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
        
        

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            soundManager.PlaySFX(soundManager.ClickSound);
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

    public void SpecialAttackButton()
    {

        if (battle_manager != null && player.GetComponent<SpriteRenderer>().sprite.name == "barbarian_0")
        {
            if(player_stats.stamina >= player_stats.maxStamina/3)
            {
                battle_manager.SpecialAttackBarbar();
            }else
            {
                comentatoryText.SetText("Not enough stamina to exploit enemy's weakness");
            }
        }
        

        if (battle_manager != null && player.GetComponent<SpriteRenderer>().sprite.name == "mage_0")
        {
            if(player_stats.mana >= 30)
            {
                battle_manager.SpecialAttackMage();
            }
            else
            {
                comentatoryText.SetText("Not enough mana to cast FIRE BALL");
            }
            
        }
        
        

        if (battle_manager != null && player.GetComponent<SpriteRenderer>().sprite.name == "ranger_0")
        {
            if(player_stats.stamina >= player_stats.maxStamina / 3)
            {
                battle_manager.SpecialAttackRanger();
            }
            else
            {
                comentatoryText.SetText("Not enough stamina to perform sneak attack");
            }
            
        }

    }

    public void HealButton()
    {
        if (battle_manager != null && player_stats.health < player_stats.maxHealth && coinCounter.currentCoins >= 20)
        {
            battle_manager.HealPlayer();
            comentatoryTextShop.SetText("Player healed!");
        }
        else
        {
            comentatoryTextShop.SetText("Not enough coins to heal or already at full health.");
        }
        
    }

    public void MaxHealthButton()
    {
        if (battle_manager != null && player_stats.health <= player_stats.maxHealth && coinCounter.currentCoins >= 20)
        {
            player_stats.maxHealth += 10;
            coinCounter.currentCoins -= 20;
            coinCounter.UpdateCoinText();
            comentatoryTextShop.SetText("Max health increased by 10!");
        }
        else
        {
            comentatoryTextShop.SetText("Not enough coins to increase max health or already at full health.");
        }
    }

    public void MaxStaminaButton()
    {
        
        if (battle_manager != null && player_stats.stamina <= player_stats.maxStamina && coinCounter.currentCoins >= 15)
        {
            player_stats.maxStamina += 10;
            if(player_stats.maxMana > 0)
            {
                player_stats.maxMana += 10;
            }
            player_stats.stamina = player_stats.maxStamina;
            player_stats.mana = player_stats.maxMana;
            coinCounter.currentCoins -= 15;
            coinCounter.UpdateCoinText();
            comentatoryTextShop.SetText("Max stamina increased by 10!");
        }
        else
        {
            comentatoryTextShop.SetText("Not enough coins to increase max stamina or already at full stamina.");
        }
    }

    public void UpgradeDmgButton()
    {
        
        if (battle_manager != null && coinCounter.currentCoins >= 20)
        {
            player_stats.damage += 5;
            coinCounter.currentCoins -= 20;
            coinCounter.UpdateCoinText();
            comentatoryTextShop.SetText("Damage increased by 5!");
        }
        else
        {
            comentatoryTextShop.SetText("Not enough coins to increase damage.");
        }
    }
}