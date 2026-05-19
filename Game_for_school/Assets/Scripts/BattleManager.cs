using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    public player_stats player_stats;
    public enemy_stats enemy_stats;

    public bool playerTurn = true;
    private bool miniBossHere = true;
    private bool bossHere = true;

    void Update()
    {
        if (player_stats == null)
        {
            player_stats = GameObject.FindGameObjectWithTag("Player").GetComponent<player_stats>();
        }

        if (enemy_stats == null)
        {
            enemy_stats = GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemy_stats>();
            
        }

        
    }
        // Hráč útočí na nepřítele, pokud je jeho tah a má dostatek staminy
    public void PlayerAttack()
    {

        if (miniBossHere)
        {
           if(enemy_stats.isMiniboss)
            {
                miniBossHere = false;
                StartCoroutine(EnemyTurn());
                return;
            }
            
        }

        if (bossHere)
        {
           
            if(enemy_stats.isBoss)
            {
                bossHere = false;
                StartCoroutine(EnemyTurn());
                return;
            }
        }

        if (!playerTurn)
        {
            Vyhodnoceni();
            return;
        }

        if(player_stats.stamina < 10)
        {
            Vyhodnoceni();
            return;
        }

        if(enemy_stats.health <= 0)
        {
            Vyhodnoceni();
            return;
        }

        if(player_stats.health <= 0)
        {
            Vyhodnoceni();
            return;
        }

        enemy_stats.health -= player_stats.damage;
        player_stats.stamina -= 10;

        playerTurn = false;
        StartCoroutine(EnemyTurn());
    }
        // Nepřítel útočí na hráče, pokud je jeho tah a hráč je stále naživu
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1.5f);
        
        if(enemy_stats.health > 0 && player_stats.health > 0)
        {
            player_stats.health -= enemy_stats.damage;
            Debug.Log("Enemy attacks! Player health: " + player_stats.health);
        }

        if(player_stats.health <= 0)
        {
            
            Vyhodnoceni();
        }

        if(enemy_stats.health <= 0)
{
            StartCoroutine(FindFirstObjectByType<EnemySpawn>().EnemyDefeated());
            miniBossHere = true;
            bossHere = true;
        }

        playerTurn = true;
    }

        //Regenerace staminy
    public void RegenStamina()
    {
        if(player_stats.stamina < player_stats.maxStamina && playerTurn && player_stats.health > 0)
        {
            player_stats.stamina += 2 * (player_stats.maxStamina/player_stats.stamina);
            Vyhodnoceni();
            playerTurn = false;
            StartCoroutine(EnemyTurn());
        }

        if (miniBossHere)
        {
        
            miniBossHere = false;
            StartCoroutine(EnemyTurn());
            return;
        }

        if (bossHere)
        {
            
            bossHere = false;
            StartCoroutine(EnemyTurn());
            return;
        }

    }

        //Vyhodnocení stavu
    public void Vyhodnoceni()
    {
        if(enemy_stats.health <= 0)
        {
            Debug.Log("Enemy defeated!");
        }

        if(player_stats.stamina < 10)
        {
            Debug.Log("Not enough stamina to attack!");
        }

        if(player_stats.health <= 0)
        {
            Debug.Log("You have been defeated!");
        }

        if(player_stats.stamina >= player_stats.maxStamina)
        {
            Debug.Log("Stamina is full!");
        }
    }
}
